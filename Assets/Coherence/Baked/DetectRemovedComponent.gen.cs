


#region DetectRemovedComponent
// -----------------------------------
//  DetectRemovedComponent.cs
// -----------------------------------
			

namespace Coherence.Generated.Internal
{
	using Coherence;
	using Coherence.Replication.Client.Unity.Ecs;
	using Unity.Collections;
	using Unity.Entities;
	using Unity.Transforms;
	using Coherence.DeltaEcs;

	[UpdateInGroup(typeof(GatherChangesGroup))]
	public class DetectRemovedComponentsSystem : SystemBase
	{
		private NativeHashMap<EntityComponentTuple, ComponentChange> componentChanges;
		private NetworkSystem networkSystem;
		private FrameCountSystem frameCountSystem;
		private EndInitializationEntityCommandBufferSystem endInitializationEntityCommandBufferSystem;

		protected override void OnCreate()
		{
			base.OnCreate();
			componentChanges = new NativeHashMap<EntityComponentTuple, ComponentChange>(65536, Allocator.Persistent);
			networkSystem = World.GetExistingSystem<NetworkSystem>();
			frameCountSystem = World.GetExistingSystem<FrameCountSystem>();
			endInitializationEntityCommandBufferSystem = World.GetExistingSystem<EndInitializationEntityCommandBufferSystem>();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			componentChanges.Dispose();
		}

		protected override void OnUpdate()
		{
			var localComponentChanges = componentChanges.AsParallelWriter();
			var simulationFrame = frameCountSystem.SimulationFrame;
			var commandBufferWriter = endInitializationEntityCommandBufferSystem.CreateCommandBuffer().AsParallelWriter();


			Entities.WithNone<Translation>().ForEach((Entity entity, int entityInQueryIndex, ref WorldPosition_Sync sync, in Simulated sim) =>
			{

				var componentChange = new ComponentChange
				{
					entity = entity,
					componentType = TypeIds.InternalWorldPosition,
					state = ComponentState.Destruct,
					priority = (int)sync.howImportantAreYou,
					simulationFrame = simulationFrame
				};

				localComponentChanges.TryAdd(new EntityComponentTuple(entity, componentChange.componentType), componentChange);

				commandBufferWriter.RemoveComponent<WorldPosition_Sync>(entityInQueryIndex, entity);
			}).ScheduleParallel();

			Entities.WithNone<Rotation>().ForEach((Entity entity, int entityInQueryIndex, ref WorldOrientation_Sync sync, in Simulated sim) =>
			{

				var componentChange = new ComponentChange
				{
					entity = entity,
					componentType = TypeIds.InternalWorldOrientation,
					state = ComponentState.Destruct,
					priority = (int)sync.howImportantAreYou,
					simulationFrame = simulationFrame
				};

				localComponentChanges.TryAdd(new EntityComponentTuple(entity, componentChange.componentType), componentChange);

				commandBufferWriter.RemoveComponent<WorldOrientation_Sync>(entityInQueryIndex, entity);
			}).ScheduleParallel();

			Entities.WithNone<global::Coherence.Generated.LocalUser>().ForEach((Entity entity, int entityInQueryIndex, ref LocalUser_Sync sync, in Simulated sim) =>
			{

				var componentChange = new ComponentChange
				{
					entity = entity,
					componentType = TypeIds.InternalLocalUser,
					state = ComponentState.Destruct,
					priority = (int)sync.howImportantAreYou,
					simulationFrame = simulationFrame
				};

				localComponentChanges.TryAdd(new EntityComponentTuple(entity, componentChange.componentType), componentChange);

				commandBufferWriter.RemoveComponent<LocalUser_Sync>(entityInQueryIndex, entity);
			}).ScheduleParallel();

			Entities.WithNone<global::Coherence.Generated.WorldPositionQuery>().ForEach((Entity entity, int entityInQueryIndex, ref WorldPositionQuery_Sync sync, in Simulated sim) =>
			{

				var componentChange = new ComponentChange
				{
					entity = entity,
					componentType = TypeIds.InternalWorldPositionQuery,
					state = ComponentState.Destruct,
					priority = (int)sync.howImportantAreYou,
					simulationFrame = simulationFrame
				};

				localComponentChanges.TryAdd(new EntityComponentTuple(entity, componentChange.componentType), componentChange);

				commandBufferWriter.RemoveComponent<WorldPositionQuery_Sync>(entityInQueryIndex, entity);
			}).ScheduleParallel();

			Entities.WithNone<global::Coherence.Generated.ArchetypeComponent>().ForEach((Entity entity, int entityInQueryIndex, ref ArchetypeComponent_Sync sync, in Simulated sim) =>
			{

				var componentChange = new ComponentChange
				{
					entity = entity,
					componentType = TypeIds.InternalArchetypeComponent,
					state = ComponentState.Destruct,
					priority = (int)sync.howImportantAreYou,
					simulationFrame = simulationFrame
				};

				localComponentChanges.TryAdd(new EntityComponentTuple(entity, componentChange.componentType), componentChange);

				commandBufferWriter.RemoveComponent<ArchetypeComponent_Sync>(entityInQueryIndex, entity);
			}).ScheduleParallel();

			Entities.WithNone<global::Coherence.Generated.Persistence>().ForEach((Entity entity, int entityInQueryIndex, ref Persistence_Sync sync, in Simulated sim) =>
			{

				var componentChange = new ComponentChange
				{
					entity = entity,
					componentType = TypeIds.InternalPersistence,
					state = ComponentState.Destruct,
					priority = (int)sync.howImportantAreYou,
					simulationFrame = simulationFrame
				};

				localComponentChanges.TryAdd(new EntityComponentTuple(entity, componentChange.componentType), componentChange);

				commandBufferWriter.RemoveComponent<Persistence_Sync>(entityInQueryIndex, entity);
			}).ScheduleParallel();

			Entities.WithNone<global::Coherence.Generated.ConnectedEntity>().ForEach((Entity entity, int entityInQueryIndex, ref ConnectedEntity_Sync sync, in Simulated sim) =>
			{

				var componentChange = new ComponentChange
				{
					entity = entity,
					componentType = TypeIds.InternalConnectedEntity,
					state = ComponentState.Destruct,
					priority = (int)sync.howImportantAreYou,
					simulationFrame = simulationFrame
				};

				localComponentChanges.TryAdd(new EntityComponentTuple(entity, componentChange.componentType), componentChange);

				commandBufferWriter.RemoveComponent<ConnectedEntity_Sync>(entityInQueryIndex, entity);
			}).ScheduleParallel();

			Entities.WithNone<global::Coherence.Generated.Player>().ForEach((Entity entity, int entityInQueryIndex, ref Player_Sync sync, in Simulated sim) =>
			{

				var componentChange = new ComponentChange
				{
					entity = entity,
					componentType = TypeIds.InternalPlayer,
					state = ComponentState.Destruct,
					priority = (int)sync.howImportantAreYou,
					simulationFrame = simulationFrame
				};

				localComponentChanges.TryAdd(new EntityComponentTuple(entity, componentChange.componentType), componentChange);

				commandBufferWriter.RemoveComponent<Player_Sync>(entityInQueryIndex, entity);
			}).ScheduleParallel();


			Dependency.Complete();

			foreach (var change in componentChanges.GetValueArray(Allocator.Temp))
			{
				networkSystem.changeBuffer.UpdateEntity(change.entity, change);
			}

			componentChanges.Clear();
		}
	}
}
// ------------------ end of DetectRemovedComponent.cs -----------------
#endregion
