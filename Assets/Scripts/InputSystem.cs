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

        if (Input.GetKeyDown(KeyCode.Z))
        {
            AddEvent(0);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            AddEvent(1);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            AddEvent(2);
        }

        //Entities.ForEach((Entity entity, in Bam bam) =>
        //{
        //    Debug.Log($"The entity {entity} has a Bam event with strength {bam.strength}");
        //}).WithStructuralChanges().WithoutBurst().Run();
    }

    void AddEvent(int type)
    {
        Entities.WithAll<Simulated>()
                .ForEach((Entity localPlayer, in Player player) =>
                {
                    var randomStrength = UnityEngine.Random.Range(0, 1000);
                    Debug.Log($"Sending Event ({type}) of strength {randomStrength} to {localPlayer}");
                    if(type == 0)
                    {
                        EntityManager.AddComponentData(localPlayer, new Bam()
                        {
                            strength = randomStrength
                        });
                    }
                    else if (type == 1)
                    {
                        EntityManager.AddComponentData(localPlayer, new Bom()
                        {
                            strength = randomStrength
                        });
                    }
                    else if (type == 2)
                    {
                        EntityManager.AddComponentData(localPlayer, new Bim()
                        {
                            strength = randomStrength
                        });
                    }
                }).WithStructuralChanges().WithoutBurst().Run();
    }
}
