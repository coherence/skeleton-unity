using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
//using UnityEngine.InputSystem;
using Coherence.Replication.Client.Unity.Ecs;
using Coherence.Replication.Client.Connection;
//using Coherence.Generated.Internal.FirstProject;
using FirstProject;
using Coherence.Sdk.Unity;
using UnityEngine;

[AlwaysUpdateSystem]
class JoinSystem : SystemBase
{
    static bool hasSaidWeAreConnected = false;
    static bool worldQueryCreated = false;

    protected override void OnStartRunning()
    {
        Debug.Log("The 'JoinSystem' will try to connect...");
        var coherenceRuntime = World.GetOrCreateSystem<CoherenceRuntimeSystem>();
        coherenceRuntime.Connect("127.0.0.1:32001", ConnectionType.Simulator);
    }

    protected override void OnUpdate()
    {
        var coherenceRuntime = World.GetOrCreateSystem<CoherenceRuntimeSystem>();
        if (coherenceRuntime.IsConnected && !hasSaidWeAreConnected)
        {
            Debug.Log("Now we are connected!");
            hasSaidWeAreConnected = true;
        }

        if(coherenceRuntime.IsConnected && !worldQueryCreated)
        {
            Debug.Log("Trying to start World Query...");
            StartWorldQuery();
        }

        //var keyboard = Keyboard.current;
    }

    void StartWorldQuery()
    {
        var localUser = entityManager.CreateEntityQuery(typeof(LocalUser));

        if( localUser.CalculateEntityCount() == 0 )
        {
            return;
        }

        var worldQueryEntity = EntityManager.CreateEntity();

        EntityManager.AddComponentData(worldQueryEntity, new CoherenceSimulateComponent
        {
            Authority = localUser.GetSingletonEntity(),
        });

        EntityManager.AddComponentData(worldQueryEntity, new WorldPositionQuery
        {
            position = new float3(0, 0, 0),
        });

        Debug.Log("World query is go!");
        worldQueryCreated = true;
    }
}
