using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Coherence.Generated;

class InputSystem : SystemBase
{
    EndSimulationEntityCommandBufferSystem commandBufferSystem;
         
    protected override void OnCreate()
    {
        commandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        var vec = new float2();

        if (Input.GetKey(KeyCode.LeftArrow)) { vec.x -= 1; }
        if (Input.GetKey(KeyCode.RightArrow)) { vec.x += 1; }
        if (Input.GetKey(KeyCode.UpArrow)) { vec.y += 1; }
        if (Input.GetKey(KeyCode.DownArrow)) { vec.y -= 1; }

        if (math.length(vec) > 0f)
        {
            vec = math.mul(float2x2.Rotate(math.PI * 0.25f), math.normalize(vec));
        }

        Entities.ForEach((ref PlayerInput input) =>
        {
            input.Value = vec;
        }).ScheduleParallel();

        var commandBuffer = commandBufferSystem.CreateCommandBuffer();

        if (Input.GetKeyDown(KeyCode.Z))
        {            
            var monsterEntity = Archetype.InstantiateMonster(commandBuffer);
            Debug.Log($"Created monster entity: {monsterEntity}");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            var heroEntity = Archetype.InstantiateHero(commandBuffer);
            Debug.Log($"Created hero entity: {heroEntity}");
        }
    }
}
