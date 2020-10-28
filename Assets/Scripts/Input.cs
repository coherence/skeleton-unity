using Unity.Entities;
using Unity.Mathematics;

public struct PlayerInput : IComponentData
{
    public float ForwardSpeed;
    public float RotationSpeed;
    public bool Shoot;
}
