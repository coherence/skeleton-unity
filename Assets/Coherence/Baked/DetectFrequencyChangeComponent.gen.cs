


#region DetectFrequencyChangeComponent
// -----------------------------------
//  DetectFrequencyChangeComponent.cs
// -----------------------------------
			

namespace Coherence.Generated.Internal
{
	using global::Coherence.Generated;
	using Coherence.Replication.Client.Unity.Ecs;
	using Unity.Entities;
	using Unity.Transforms;

	[UpdateInGroup(typeof(PresentationSystemGroup))]
	[UpdateBefore(typeof(DetectRemovedComponentsSystem))]
	public class DetectFrequencyComponentsSystem : SystemBase
	{

		private EndSimulationEntityCommandBufferSystem m_EndSimulationEcbSystem;

		protected override void OnCreate()
		{
			base.OnCreate();
			m_EndSimulationEcbSystem = World
				.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
		}

		protected override void OnUpdate()
		{

			var ecb = m_EndSimulationEcbSystem.CreateCommandBuffer().AsParallelWriter();
			Entities
			.ForEach((Entity entity, int entityInQueryIndex, ref WorldPosition_Sync sync, in SetWorldPositionFrequency data) =>
			{
				sync.minSamplingTime = 1/data.samplingFrequency;
				ecb.RemoveComponent<SetWorldPositionFrequency>(entityInQueryIndex, entity);
			}).ScheduleParallel();
			Entities
			.ForEach((Entity entity, int entityInQueryIndex, ref WorldOrientation_Sync sync, in SetWorldOrientationFrequency data) =>
			{
				sync.minSamplingTime = 1/data.samplingFrequency;
				ecb.RemoveComponent<SetWorldOrientationFrequency>(entityInQueryIndex, entity);
			}).ScheduleParallel();
			Entities
			.ForEach((Entity entity, int entityInQueryIndex, ref LocalUser_Sync sync, in SetLocalUserFrequency data) =>
			{
				sync.minSamplingTime = 1/data.samplingFrequency;
				ecb.RemoveComponent<SetLocalUserFrequency>(entityInQueryIndex, entity);
			}).ScheduleParallel();
			Entities
			.ForEach((Entity entity, int entityInQueryIndex, ref WorldPositionQuery_Sync sync, in SetWorldPositionQueryFrequency data) =>
			{
				sync.minSamplingTime = 1/data.samplingFrequency;
				ecb.RemoveComponent<SetWorldPositionQueryFrequency>(entityInQueryIndex, entity);
			}).ScheduleParallel();
			Entities
			.ForEach((Entity entity, int entityInQueryIndex, ref ArchetypeComponent_Sync sync, in SetArchetypeComponentFrequency data) =>
			{
				sync.minSamplingTime = 1/data.samplingFrequency;
				ecb.RemoveComponent<SetArchetypeComponentFrequency>(entityInQueryIndex, entity);
			}).ScheduleParallel();
			Entities
			.ForEach((Entity entity, int entityInQueryIndex, ref Persistence_Sync sync, in SetPersistenceFrequency data) =>
			{
				sync.minSamplingTime = 1/data.samplingFrequency;
				ecb.RemoveComponent<SetPersistenceFrequency>(entityInQueryIndex, entity);
			}).ScheduleParallel();
			Entities
			.ForEach((Entity entity, int entityInQueryIndex, ref ConnectedEntity_Sync sync, in SetConnectedEntityFrequency data) =>
			{
				sync.minSamplingTime = 1/data.samplingFrequency;
				ecb.RemoveComponent<SetConnectedEntityFrequency>(entityInQueryIndex, entity);
			}).ScheduleParallel();
			Entities
			.ForEach((Entity entity, int entityInQueryIndex, ref Player_Sync sync, in SetPlayerFrequency data) =>
			{
				sync.minSamplingTime = 1/data.samplingFrequency;
				ecb.RemoveComponent<SetPlayerFrequency>(entityInQueryIndex, entity);
			}).ScheduleParallel();

			m_EndSimulationEcbSystem.AddJobHandleForProducer(this.Dependency);
		}
	}
}
// ------------------ end of DetectFrequencyChangeComponent.cs -----------------
#endregion
