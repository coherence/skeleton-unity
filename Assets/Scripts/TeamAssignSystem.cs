using Coherence.Generated.FirstProject;
using Coherence.Replication.Client.Unity.Ecs;
using Unity.Entities;
using UnityEngine;

public struct Assigned : IComponentData { }

[DisableAutoCreation]
[AlwaysUpdateSystem]
public class TeamAssignSystem : SystemBase
{
    bool once;

    protected override void OnStartRunning()
    {
        var networkSystem = World.GetExistingSystem<NetworkSystem>();
        networkSystem.Connect("127.0.0.1:12345");
    }

    protected override void OnUpdate()
    {
        Entities.WithNone<Assigned>().ForEach((Entity entity, in Player player) =>
        {
            Debug.Log($"Found unassigned player: {entity}");
            var buffer = EntityManager.GetBuffer<AssignToTeamRequest>(entity);
            buffer.Add(new AssignToTeamRequest { Team = NextTeamToJoin() });
            EntityManager.AddComponent<Assigned>(entity);
        }).WithStructuralChanges().WithoutBurst().Run();

        if(!once && World.GetExistingSystem<NetworkSystem>().IsConnected) {
            once = true;
            CreateWorldPositionQuery();
        }
    }

    int counter = 0;

    private int NextTeamToJoin()
    {
        var team = counter % 2;
        counter++;
        return team;
    }

    void CreateWorldPositionQuery()
    {
        var worldQueryEntity = EntityManager.CreateEntity();

        EntityManager.AddComponentData(worldQueryEntity, new CoherenceSimulateComponent
        {

        });

        EntityManager.AddComponentData(worldQueryEntity, new WorldPositionQuery
        {

        });
    }
}
