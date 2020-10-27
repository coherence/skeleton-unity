using Unity.Entities;
using Unity.Mathematics;

public struct Input : IComponentData
{
    public float ForwardSpeed;
    public float RotationSpeed;
    public bool Shoot;
}
