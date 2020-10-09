using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Rendering;
using Coherence.Replication.Client.Unity.Ecs;
using Coherence.Generated.FirstProject;
using Coherence.Generated.Internal.FirstProject;

[AlwaysUpdateSystem]
class JoinSystem : SystemBase
{
    protected override void OnStartRunning()
    {
        var networkSystem = World.GetExistingSystem<NetworkSystem>();
        networkSystem.Connect("127.0.0.1:12345");
    }

    protected override void OnUpdate()
    {
        // Are we connected yet?
        Entities.ForEach((in ConnectedEvent connected) =>
        {
            CreateWorldPositionQuery();
            CreateLocalPlayer();
        }).WithStructuralChanges().WithoutBurst().Run();

        // Detect remotely simulated Player entities and instantiate a proper Prefab for them.
        Entities.WithNone<RenderMesh>().ForEach((Entity networkEntity, in Player player) =>
        {
            var otherPlayerPrefabEntity = PrefabHolder.Get().otherPlayerPrefabEntity;
            var newPlayerEntity = World.EntityManager.Instantiate(otherPlayerPrefabEntity);
            EntityReplacer.Replace(EntityManager, networkEntity, newPlayerEntity);
        }).WithStructuralChanges().WithoutBurst().Run();

        if(UnityEngine.Time.frameCount % 60 == 0) {
            Entities.ForEach((Entity entity, in Player player, in Attach attach) =>
            {
                UnityEngine.Debug.Log($"I'm player {entity} and my parent is {attach.parent}");
            }).WithStructuralChanges().WithoutBurst().Run();
        }
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

    public static Entity parent;

    private Entity CreateLocalPlayer()
    {
        // Create a "parent" Entity
        parent = EntityManager.CreateEntity();

        EntityManager.AddComponentData(parent, new CoherenceSimulateComponent
        {

        });

        EntityManager.AddComponentData(parent, new CoherenceSessionComponent
        {

        });

        // Making the parent be part of the query, so that it's transfered to the other client
        EntityManager.AddComponentData(parent, new Translation
        {
            Value = new float3(0, 0, 0)
        });

        UnityEngine.Debug.Log($"parent entity = {parent}");



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
        EntityManager.AddComponentData(newPlayerEntity, new Input
        {
            Value = new float2()
        });

        // Set a random starting position.
        var range = 4.0f;
        EntityManager.AddComponentData(newPlayerEntity, new Translation
        {
            Value = new float3(UnityEngine.Random.Range(-range, range),
                               0.25f,
                               UnityEngine.Random.Range(-range, range))
        });

        // Add parent
        EntityManager.AddComponentData(newPlayerEntity, new Attach
        {
            parent = parent
        });

        return newPlayerEntity;
    }
}
