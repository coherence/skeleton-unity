using Coherence;
using Coherence.Generated.FirstProject;
using Coherence.Replication.Client.Unity.Ecs;
using Unity.Entities;
using UnityEngine;

class DoitSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity,
                          ref DynamicBuffer<Doit> buffer) =>
        {
            if (buffer.Length == 0)
            {
                return;
            }
            var doitCommands = buffer.Reinterpret<Doit>();

            for (var i = 0; i < doitCommands.Length; i++)
            {
                var doitCommand = doitCommands[i];
                Debug.Log($"Got a Doit command with the number {doitCommand.number}, {doitCommand.fnum}, {doitCommand.b}, {doitCommand.v3}, {doitCommand.v2}, {doitCommand.rot}, {doitCommand.e}, and the text '{doitCommand.text}'.");
            }

            buffer.Clear();
        }).Run();
    }
}
