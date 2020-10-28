using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

class InputSystem : SystemBase
{
    protected override void OnUpdate()
    {
        const float targetForwardSpeed = 3f;
        const float targetRotationSpeed = 4f;

        var forwardSpeed = 0f;
        var rotationSpeed = 0f;
        var shoot = false;

        if (Input.GetKey(KeyCode.LeftArrow)) { rotationSpeed -= targetRotationSpeed; }
        if (Input.GetKey(KeyCode.RightArrow)) { rotationSpeed += targetRotationSpeed; }
        if (Input.GetKey(KeyCode.UpArrow)) { forwardSpeed += targetForwardSpeed; }
        if (Input.GetKey(KeyCode.DownArrow)) { forwardSpeed -= targetForwardSpeed; }
        if (Input.GetKeyDown(KeyCode.Space)) { shoot = true; }

        Entities.ForEach((ref PlayerInput input) =>
        {
            input.ForwardSpeed = forwardSpeed;
            input.RotationSpeed = rotationSpeed;
            input.Shoot = shoot;
        }).ScheduleParallel();
    }
}
