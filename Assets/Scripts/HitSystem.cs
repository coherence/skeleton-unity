using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Rendering;
using Coherence.Replication.Client.Unity.Ecs;
using Coherence.Generated.FirstProject;
using Coherence.Generated.Internal.FirstProject;

[AlwaysUpdateSystem]
class HitSystem : SystemBase
{
    protected override void OnStartRunning()
    {

    }

    protected override void OnUpdate()
    {
        var playerQuery = EntityManager.CreateEntityQuery(typeof(Player), typeof(CoherenceSimulateComponent));
        if(playerQuery.CalculateEntityCount() == 1) {
            var player = playerQuery.GetSingletonEntity();
            var playerPosition = EntityManager.GetComponentData<Translation>(player).Value;
            var playerWasHit = false;

            Entities.WithNone<CoherenceSimulateComponent>().ForEach((ref Shot shot, in Translation translation) =>
            {
                if(math.distance(translation.Value, playerPosition) < 1f) {
                    //var who = shot.Owner == player ? "self" : "enemy";
                    //UnityEngine.Debug.Log($"Shot hit a player! ({who}, {shot.Owner})");
                    UnityEngine.Debug.Log($"Shot hit player!");
                    playerWasHit = true;
                }
            }).Run();

            if(playerWasHit) {
                var range = 4.0f;
                EntityManager.SetComponentData(player, new Translation()
                {
                    Value = new float3(UnityEngine.Random.Range(-range, range),
                                       0.25f,
                                       UnityEngine.Random.Range(-range, range))
                });
            }
        }
        else {
            UnityEngine.Debug.Log("No player found.");
        }
    }
}
