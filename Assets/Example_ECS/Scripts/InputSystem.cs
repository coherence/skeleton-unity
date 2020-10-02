using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

class InputSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var vec = new float2();

        if (UnityEngine.Input.GetKey(KeyCode.LeftArrow)) { vec.x -= 1; }
        if (UnityEngine.Input.GetKey(KeyCode.RightArrow)) { vec.x += 1; }
        if (UnityEngine.Input.GetKey(KeyCode.UpArrow)) { vec.y += 1; }
        if (UnityEngine.Input.GetKey(KeyCode.DownArrow)) { vec.y -= 1; }

        if (math.length(vec) > 0f)
        {
            vec = math.mul(float2x2.Rotate(math.PI * 0.25f), math.normalize(vec));
        }

        Entities.ForEach((ref Input input) =>
        {
            input.Value = vec;
        }).ScheduleParallel();
    }
}
