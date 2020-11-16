using Coherence;
using Coherence.Generated.FirstProject;
using Coherence.Replication.Client.Unity.Ecs;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

class InputSystem : SystemBase
{
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

        // Sending commands
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Sending long text");
            Entities
                .WithNone<Simulated>()
                .ForEach((Entity entity,
                          in Player player) =>
            {
                UnityEngine.Debug.Log($"Adding command to: {entity}");

                var doitRequestBuffer = EntityManager.GetBuffer<DoitRequest>(entity);
                var r = new DoitRequest {
                        number = _counter++,
                        fnum = 12.34f,
                        b = true,
                        v3 = new float3(1, 2, 3),
                        v2 = new float2(100, 200),
                        rot = math.quaternion(1, 2, 3, 4),
                        e = entity,
                        text = "Håre's π " + _counter.ToString() + "!"
                };
                doitRequestBuffer.Add(r);
                Debug.Log($"SENDING a Doit command with the number {r.number}, {r.fnum}, {r.b}, {r.v3}, {r.v2}, {r.rot}, {r.e}, and the text '{r.text}'.");
            }).WithStructuralChanges().WithoutBurst().Run();
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Sending short text");
            Entities
                .WithNone<Simulated>()
                .ForEach((Entity entity,
                          in Player player) =>
            {
                var doitRequestBuffer = EntityManager.GetBuffer<DoitRequest>(entity);
                doitRequestBuffer.Add(new DoitRequest {
                        number = _counter++,
                        text = "x"
                    });
            }).WithStructuralChanges().WithoutBurst().Run();
        }
    }

    static int _counter = 0;
}
