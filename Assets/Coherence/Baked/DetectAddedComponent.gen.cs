


#region DetectAddedComponent
// -----------------------------------
//  DetectAddedComponent.cs
// -----------------------------------
			

namespace Coherence.Generated.Internal
{
	using global::Coherence.Generated;
	using Coherence.Replication.Client.Unity.Ecs;
	using Unity.Entities;
	using Unity.Transforms;

	[UpdateInGroup(typeof(GatherChangesGroup))]
	[UpdateBefore(typeof(DetectRemovedComponentsSystem))]
	public class DetectAddedComponentsSystem : SystemBase
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


			Entities.WithAll<Translation, Simulated>().WithNone<WorldPosition_Sync>().ForEach((Entity entity, int entityInQueryIndex) =>
			{

				ecb.AddComponent(entityInQueryIndex, entity, new WorldPosition_Sync
				{
					howImportantAreYou = 1000,
					// 30Hz
					minSamplingTime = 0.033f
				});
			}).ScheduleParallel();

			Entities.WithAll<Rotation, Simulated>().WithNone<WorldOrientation_Sync>().ForEach((Entity entity, int entityInQueryIndex) =>
			{

				ecb.AddComponent(entityInQueryIndex, entity, new WorldOrientation_Sync
				{
					howImportantAreYou = 1000,
					// 30Hz
					minSamplingTime = 0.033f
				});
			}).ScheduleParallel();

			Entities.WithAll<global::Coherence.Generated.LocalUser, Simulated>().WithNone<LocalUser_Sync>().ForEach((Entity entity, int entityInQueryIndex) =>
			{

				ecb.AddComponent(entityInQueryIndex, entity, new LocalUser_Sync
				{
					howImportantAreYou = 100,
					// 30Hz
					minSamplingTime = 0.033f
				});
			}).ScheduleParallel();

			Entities.WithAll<global::Coherence.Generated.WorldPositionQuery, Simulated>().WithNone<WorldPositionQuery_Sync>().ForEach((Entity entity, int entityInQueryIndex) =>
			{

				ecb.AddComponent(entityInQueryIndex, entity, new WorldPositionQuery_Sync
				{
					howImportantAreYou = 100,
					// 30Hz
					minSamplingTime = 0.033f
				});
			}).ScheduleParallel();

			Entities.WithAll<global::Coherence.Generated.ArchetypeComponent, Simulated>().WithNone<ArchetypeComponent_Sync>().ForEach((Entity entity, int entityInQueryIndex) =>
			{

				ecb.AddComponent(entityInQueryIndex, entity, new ArchetypeComponent_Sync
				{
					howImportantAreYou = 100,
					// 30Hz
					minSamplingTime = 0.033f
				});
			}).ScheduleParallel();

			Entities.WithAll<global::Coherence.Generated.Persistence, Simulated>().WithNone<Persistence_Sync>().ForEach((Entity entity, int entityInQueryIndex) =>
			{

				ecb.AddComponent(entityInQueryIndex, entity, new Persistence_Sync
				{
					howImportantAreYou = 100,
					// 30Hz
					minSamplingTime = 0.033f
				});
			}).ScheduleParallel();

			Entities.WithAll<global::Coherence.Generated.ConnectedEntity, Simulated>().WithNone<ConnectedEntity_Sync>().ForEach((Entity entity, int entityInQueryIndex) =>
			{

				ecb.AddComponent(entityInQueryIndex, entity, new ConnectedEntity_Sync
				{
					howImportantAreYou = 100,
					// 30Hz
					minSamplingTime = 0.033f
				});
			}).ScheduleParallel();

			Entities.WithAll<global::Coherence.Generated.Player, Simulated>().WithNone<Player_Sync>().ForEach((Entity entity, int entityInQueryIndex) =>
			{

				ecb.AddComponent(entityInQueryIndex, entity, new Player_Sync
				{
					howImportantAreYou = 100,
					// 30Hz
					minSamplingTime = 0.033f
				});
			}).ScheduleParallel();

			m_EndSimulationEcbSystem.AddJobHandleForProducer(this.Dependency);
		}
	}
}
// ------------------ end of DetectAddedComponent.cs -----------------
#endregion
