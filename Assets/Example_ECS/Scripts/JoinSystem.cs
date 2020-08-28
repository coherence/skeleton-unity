using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Coherence.Replication.Client.Unity.Ecs;
using Coherence.Replication.Client.Connection;
using Coherence.Generated.FirstProject;
using Coherence.Sdk.Unity;
using UnityEngine;
using Unity.Rendering;

[AlwaysUpdateSystem]
class JoinSystem : SystemBase
{
    CoherenceRuntimeSystem coherenceRuntime;
    Entity localUserAuthority;

    protected override void OnStartRunning()
    {
        coherenceRuntime = World.GetOrCreateSystem<CoherenceRuntimeSystem>();
        coherenceRuntime.Connect("127.0.0.1:32001", ConnectionType.Client);
    }

    protected override void OnUpdate()
    {
        // When we are connected we try to get hold of our LocalUser entity,
        // which allows us to create a WorldPositionQuery and Player.
        if(coherenceRuntime.IsConnected && localUserAuthority.Equals(Entity.Null))
        {
            var localUserQuery = EntityManager.CreateEntityQuery(typeof(LocalUser));

            if(localUserQuery.CalculateEntityCount() > 0)
            {
                localUserAuthority = localUserQuery.GetSingletonEntity();
                CreateWorldPositionQuery(localUserAuthority);
                CreatePlayer(localUserAuthority);
            }
        }

        // Detect remotely simulated Player entities and instantiate a proper Prefab for them.
        Entities.WithNone<RenderMesh>().ForEach((Entity networkEntity, in Player player) =>
        {
            var noAuthority = new Entity();
            var newEntity = CreatePlayer(noAuthority);
            CoherenceUtil.ReplaceEntity(EntityManager, networkEntity, newEntity);
        }
        ).WithStructuralChanges().WithoutBurst().Run();

        if(UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            CreatePlayer(localUserAuthority);
        }
    }

    void CreateWorldPositionQuery(Entity authority)
    {
        var worldQueryEntity = EntityManager.CreateEntity();

        EntityManager.AddComponentData(worldQueryEntity, new CoherenceSimulateComponent
        {
            Authority = authority
        });

        EntityManager.AddComponentData(worldQueryEntity, new WorldPositionQuery
        {
            position = new float3(0, 0, 0),
        });
    }

    private Entity CreatePlayer(Entity authority)
    {
        var queryForPlayers = EntityManager.CreateEntityQuery(typeof(Player));
        var playerCount = queryForPlayers.CalculateEntityCount();

        var playerPrefabEntity = PrefabHolder.Get().playerPrefabEntity;
        var newPlayerEntity = World.EntityManager.Instantiate(playerPrefabEntity);

        // The empty 'Player' component acts as a tag to query for.
        EntityManager.AddComponentData(newPlayerEntity, new Player()
        {

        });

        var isLocalPlayer = !authority.Equals(Entity.Null);

        if(isLocalPlayer)
        {
            // This component makes us responsible for the simulation of the Entity.
            EntityManager.AddComponentData(newPlayerEntity, new CoherenceSimulateComponent
            {
                Authority = authority,
            });

            // This component makes the Entity disappear if we log out or disconnect.
            EntityManager.AddComponentData(newPlayerEntity, new CoherenceSessionComponent
            {

            });

            // This component makes our keyboard input affect the Entity.
            EntityManager.AddComponentData(newPlayerEntity, new Input
            {
                Value = new float2()
            });

            // Spawn players in a circle around the center of the level.
            var angle = math.PI * 0.25f * (float)playerCount;
            var radius = 3.5f;
            Debug.Log($"angle: {angle}, radius: {radius}, playerCount: {playerCount}");

            EntityManager.AddComponentData(newPlayerEntity, new Translation
            {
                Value = new float3(math.cos(angle) * radius,
                                   0.25f,
                                   math.sin(angle) * radius)
            });
        }

        return newPlayerEntity;
    }
}
