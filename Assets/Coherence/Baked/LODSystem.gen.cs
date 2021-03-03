


#region LODSystem
// -----------------------------------
//  LODSystem.cs
// -----------------------------------
			
namespace Coherence.Generated
{
	using Coherence.Replication.Client.Unity.Ecs;
	using Unity.Collections;
	using Unity.Entities;
	using Unity.Mathematics;
	using Unity.Transforms;

	public class LODSystem : SystemBase
	{
		EndSimulationEntityCommandBufferSystem commandBufferSystem;

		protected override void OnStartRunning()
		{
			commandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
		}

		protected override void OnUpdate()
		{
			var commandBuffer = commandBufferSystem.CreateCommandBuffer().AsParallelWriter();

			var queries = EntityManager.CreateEntityQuery(typeof(WorldPositionQuery));
			var queryCount = queries.CalculateEntityCount();

			if(queryCount == 0)
			{
				return;
			}

			var queryPositions = new NativeArray<float3>(queryCount, Allocator.TempJob);

			Entities.ForEach((int entityInQueryIndex, in WorldPositionQuery query) =>
			{
				queryPositions[entityInQueryIndex] = query.position;
			}).ScheduleParallel();

			Dependency.Complete(); // The ForEach below will read from 'queryPositions'

			

			Dependency.Complete();
			queryPositions.Dispose();
		}

		private static float DistanceToClosestQuery(NativeArray<float3> queryPositions, float3 pos)
		{
			float closest = float.MaxValue;
			foreach(var queryPos in queryPositions)
			{
				var d = math.distance(queryPos, pos);
				if(d < closest)
				{
					closest = d;
				}
			}
			return closest;
		}
	}
}


// ------------------ end of LODSystem.cs -----------------
#endregion
