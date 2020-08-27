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
        if(coherenceRuntime.IsConnected && localUserAuthority.Equals(Entity.Null))
        {
            var localUserQuery = EntityManager.CreateEntityQuery(typeof(LocalUser));

            if(localUserQuery.CalculateEntityCount() > 0)
            {
                localUserAuthority = localUserQuery.GetSingletonEntity();
                CreateWorldQuery(localUserAuthority);
                CreatePlayer(localUserAuthority);
            }
        }

        Entities.WithNone<RenderMesh>().ForEach((Entity networkEntity,
                                                     in Player player) =>
        {
            var newEntity = CreatePlayer(new Entity());
            CoherenceUtil.ReplaceEntity(EntityManager, networkEntity, newEntity);
        }).WithStructuralChanges().WithoutBurst().Run();
    }

    void CreateWorldQuery(Entity authority)
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
        var localPlayer = !authority.Equals(Entity.Null);

        var playerPrefabEntity = PrefabHolder.Get().playerPrefabEntity;
        var newPlayerEntity = World.EntityManager.Instantiate(playerPrefabEntity);

        var query = EntityManager.CreateEntityQuery(typeof(Player));
        var playerCount = query.CalculateEntityCount();

        EntityManager.AddComponentData(newPlayerEntity, new Player()
        {

        });

        EntityManager.AddComponentData(newPlayerEntity, new Translation
        {
            Value = new float3(playerCount * 2.0f, 0.25f, 0.0f)
        });

        if(localPlayer)
        {
            EntityManager.AddComponentData(newPlayerEntity, new CoherenceSimulateComponent
            {
                Authority = authority,
            });

            EntityManager.AddComponentData(newPlayerEntity, new CoherenceSessionComponent
            {

            });

            EntityManager.AddComponentData(newPlayerEntity, new Input
            {
                Value = new float2()
            });
        }

        return newPlayerEntity;
    }
}
