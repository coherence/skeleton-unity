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
            var newRotation = math.mul(quaternion.RotateY(input.RotationSpeed * dt), rotation.Value);
            rotation.Value = newRotation;

            var movementVector = math.forward(newRotation) * input.ForwardSpeed * dt;
            translation.Value += movementVector;
        }).ScheduleParallel();
    }
}
