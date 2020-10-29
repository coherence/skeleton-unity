using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[AlwaysUpdateSystem]
class MovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var dt = Time.DeltaTime;

        Entities.ForEach((ref Translation translation,
                          ref Rotation rotation,
                          in PlayerInput input) =>
        {
            var rotate = quaternion.RotateY(input.RotationSpeed * dt);
            rotation.Value = math.mul(rotate, rotation.Value);

            var movementVector = math.forward(rotation.Value) * input.ForwardSpeed * dt;
            translation.Value += movementVector;
        }).ScheduleParallel();
    }
}
