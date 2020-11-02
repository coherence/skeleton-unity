using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Rendering;
using Coherence.Replication.Client.Unity.Ecs;
using Coherence.Generated.FirstProject;
using UnityEngine;

[DisableAutoCreation]
[AlwaysUpdateSystem]
class JoinSystem : SystemBase
{
    protected override void OnStartRunning()
    {
        Debug.Log("JoinSystem::OnStartRunning");
        var networkSystem = World.GetExistingSystem<NetworkSystem>();
        networkSystem.Connect("127.0.0.1:12345");
    }

    bool once;

    protected override void OnUpdate()
    {
        // // Are we connected yet?
        // Entities.ForEach((in ConnectedEvent connected) =>
        // {
        //     CreateWorldPositionQuery();
        //     CreateLocalPlayer();
        // }).WithStructuralChanges().WithoutBurst().Run();

        if(!once && World.GetExistingSystem<NetworkSystem>().IsConnected) {
            once = true;
            CreateWorldPositionQuery();
            CreateLocalPlayer();
        }

        // Detect remotely simulated Player entities and instantiate a proper Prefab for them.
        Entities.WithNone<RenderMesh>().ForEach((Entity networkEntity, in Player player) =>
        {
            var otherPlayerPrefabEntity = PrefabHolder.Get().otherPlayerPrefabEntity;
            var newPlayerEntity = World.EntityManager.Instantiate(otherPlayerPrefabEntity);
            EntityReplacer.Replace(EntityManager, networkEntity, newPlayerEntity);
        }).WithStructuralChanges().WithoutBurst().Run();

        Entities.ForEach((Entity entity,
                          ref DynamicBuffer<AssignToTeam> buffer,
                          in Player player) =>
        {
            if (buffer.Length == 0)
            {
                return;
            }

            var commands = buffer.Reinterpret<AssignToTeam>();

            for (var i = 0; i < commands.Length; i++)
            {
                var command = commands[i];
                Debug.Log($"Got command to assign player to team {command.Team}");
                var teamLabel = GameObject.Find("TeamLabel").GetComponent<UnityEngine.UI.Text>().text = $"Team {command.Team}";
                EntityManager.AddComponentData(entity, new TeamMember() {
                        Team = command.Team
                    });
            }

            buffer.Clear();
        }).WithoutBurst().Run();
    }

    void CreateWorldPositionQuery()
    {
        var worldQueryEntity = EntityManager.CreateEntity();

        EntityManager.AddComponentData(worldQueryEntity, new CoherenceSimulateComponent
        {

        });

        EntityManager.AddComponentData(worldQueryEntity, new WorldPositionQuery
        {
            position = new float3(0, 0, 0),
        });
    }

    private Entity CreateLocalPlayer()
    {
        var playerPrefabEntity = PrefabHolder.Get().playerPrefabEntity;
        var newPlayerEntity = World.EntityManager.Instantiate(playerPrefabEntity);

        // The empty 'Player' component acts as a tag to query for.
        EntityManager.AddComponentData(newPlayerEntity, new Player()
        {

        });

        // This component makes us responsible for the simulation of the Entity.
        EntityManager.AddComponentData(newPlayerEntity, new CoherenceSimulateComponent
        {

        });

        // This component makes the Entity disappear if we log out or disconnect.
        EntityManager.AddComponentData(newPlayerEntity, new CoherenceSessionComponent
        {

        });

        // This component makes our keyboard input affect the Entity.
        EntityManager.AddComponentData(newPlayerEntity, new PlayerInput
        {

        });

        // Set a random starting position.
        var range = 4.0f;
        EntityManager.AddComponentData(newPlayerEntity, new Translation
        {
            Value = new float3(UnityEngine.Random.Range(-range, range),
                               0.25f,
                               UnityEngine.Random.Range(-range, range))
        });

        return newPlayerEntity;
    }
}
