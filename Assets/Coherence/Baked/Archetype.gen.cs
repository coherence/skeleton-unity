


#region Archetype
// -----------------------------------
//  Archetype.cs
// -----------------------------------
			
namespace Coherence.Generated
{
	using Coherence.Replication.Client.Unity.Ecs;
	using Unity.Collections;
	using Unity.Entities;
	using Unity.Mathematics;
	using Unity.Transforms;

	
	public struct MonsterArchetype : IComponentData
	{

	}
	
	public struct HeroArchetype : IComponentData
	{

	}
	

	public static class Archetype
	{
	
		public const int MonsterIndex = 0;
	
		public const int HeroIndex = 1;
	

	
		public static Entity InstantiateMonster(EntityCommandBuffer commandBuffer)
		{
			var entity = commandBuffer.CreateEntity();

			// For transmitting the archetype to/from the server
			commandBuffer.AddComponent(entity, new ArchetypeComponent { index = MonsterIndex });

			// Only used for speeding up local queries
			commandBuffer.AddComponent<MonsterArchetype>(entity);

			// Coherence components
			commandBuffer.AddComponent<Simulated>(entity);

			// User defined components (LOD 0)
			
			commandBuffer.AddComponent<Translation>(entity);
			
			commandBuffer.AddComponent<A>(entity);
			
			commandBuffer.AddComponent<B>(entity);
			
			commandBuffer.AddComponent<C>(entity);
			
			return entity;
		}
	
		public static Entity InstantiateHero(EntityCommandBuffer commandBuffer)
		{
			var entity = commandBuffer.CreateEntity();

			// For transmitting the archetype to/from the server
			commandBuffer.AddComponent(entity, new ArchetypeComponent { index = HeroIndex });

			// Only used for speeding up local queries
			commandBuffer.AddComponent<HeroArchetype>(entity);

			// Coherence components
			commandBuffer.AddComponent<Simulated>(entity);

			// User defined components (LOD 0)
			
			commandBuffer.AddComponent<Translation>(entity);
			
			commandBuffer.AddComponent<Rotation>(entity);
			
			commandBuffer.AddComponent<A>(entity);
			
			commandBuffer.AddComponent<B>(entity);
			
			return entity;
		}
	
	}

	public class ArchetypeTagSystem : SystemBase
	{
		EndSimulationEntityCommandBufferSystem commandBufferSystem;

		protected override void OnCreate()
		{
			commandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
		}

		protected override void OnUpdate()
		{
			var commandBuffer = commandBufferSystem.CreateCommandBuffer().AsParallelWriter();

			Entities.WithNone<MonsterArchetype,HeroArchetype>().ForEach((Entity e, int entityInQueryIndex, ArchetypeComponent ac) =>
			{
				switch(ac.index) {
				
				case Archetype.MonsterIndex:
					commandBuffer.AddComponent<MonsterArchetype>(entityInQueryIndex, e);
					break;
				
				case Archetype.HeroIndex:
					commandBuffer.AddComponent<HeroArchetype>(entityInQueryIndex, e);
					break;
				
				}
			}).ScheduleParallel();

			commandBufferSystem.AddJobHandleForProducer(this.Dependency);
		}
	}
}


// ------------------ end of Archetype.cs -----------------
#endregion
