using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

class InputSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var x = 0f;
        var y = 0f;

        if(UnityEngine.Input.GetKey(KeyCode.LeftArrow)) { x -= 1; }
        if(UnityEngine.Input.GetKey(KeyCode.RightArrow)) { x += 1; }
        if(UnityEngine.Input.GetKey(KeyCode.UpArrow)) { y += 1; }
        if(UnityEngine.Input.GetKey(KeyCode.DownArrow)) { y -= 1; }

        var angle = math.atan2(y, x);
        var magnitude = math.sqrt(math.pow(x, 2) + math.pow(y, 2));

        var vec = new float2(math.cos(angle) * magnitude,
                             math.sin(angle) * magnitude);

        Entities.ForEach((ref Input input) =>
        {
            input.Value = vec;
        }).ScheduleParallel();
    }
}
