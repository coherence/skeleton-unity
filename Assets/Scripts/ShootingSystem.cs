using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Rendering;
using Coherence.Replication.Client.Unity.Ecs;
using Coherence.Generated.FirstProject;
using Coherence.Generated.Internal.FirstProject;

[AlwaysUpdateSystem]
class ShootingSystem : SystemBase
{
    protected override void OnStartRunning()
    {

    }

    protected override void OnUpdate()
    {
        Entities.ForEach((in LocalToWorld transform, in Input input) =>
        {
            if(input.Shoot)
            {
                var offset = new float3(0, 0.45f, 0) + math.mul(transform.Rotation, new float3(0, 0, 0.2f));
                CreateShot(transform.Position + offset, transform.Rotation);
            }
        }).WithStructuralChanges().WithoutBurst().Run();

        float dt = Time.DeltaTime;

        Entities.ForEach((ref Translation translation, in Rotation rotation, in Shot shot) =>
        {
            translation.Value += math.forward(rotation.Value) * 5.0f * dt;
        }).ScheduleParallel();
    }

    private Entity CreateShot(float3 position, quaternion rotation)
    {
        var shotPrefabEntity = PrefabHolder.Get().shotPrefabEntity;
        var newShotEntity = World.EntityManager.Instantiate(shotPrefabEntity);

        EntityManager.AddComponentData(newShotEntity, new CoherenceSimulateComponent()
        {

        });

        EntityManager.AddComponentData(newShotEntity, new CoherenceSessionComponent()
        {

        });

        EntityManager.AddComponentData(newShotEntity, new Shot()
        {

        });

        EntityManager.SetComponentData(newShotEntity, new Translation()
        {
            Value = position
        });

        EntityManager.SetComponentData(newShotEntity, new Rotation()
        {
            Value = rotation
        });

        return newShotEntity;
    }
}
