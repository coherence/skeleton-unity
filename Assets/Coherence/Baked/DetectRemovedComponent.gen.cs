


#region DetectRemovedComponent
// -----------------------------------
//  DetectRemovedComponent.cs
// -----------------------------------
			

namespace Coherence.Generated.Internal
{
	using global::Coherence.Generated;
	using Coherence;
	using Coherence.Replication.Client.Unity.Ecs;
	using Coherence.Replication.Unity;
	using Unity.Entities;
	using Unity.Transforms;

    [UpdateInGroup(typeof(PresentationSystemGroup))]
    [UpdateBefore(typeof(DetectChangedComponentsSystem))]
    public class DetectRemovedComponentsSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var simulationFrame = World.GetOrCreateSystem<CoherenceSimulationSystemGroup>().SimulationFrame;
			var componentChanges = World.GetExistingSystem<SyncSendSystem>().ComponentChanges;
			var localComponentChanges = componentChanges.AsParallelWriter();
			

			Entities.WithNone<Translation>().ForEach((Entity entity, ref WorldPosition_Sync sync, in Simulated sim) =>
            {
                if (sync.deleteHasBeenSerialized)
                {
                    return;
                }
                
                if (sync.deletedAtTime == default)
                {
                    sync.deletedAtTime = (long)simulationFrame;
                }

                localComponentChanges.Add(sync.accumulatedPriority, new ComponentChange
                {
                    entity = entity,
                    componentType = TypeIds.InternalWorldPosition,
                    mask = 0,
                    resendMask = 0,
                });
            }).ScheduleParallel();

			Entities.WithNone<Rotation>().ForEach((Entity entity, ref WorldOrientation_Sync sync, in Simulated sim) =>
            {
                if (sync.deleteHasBeenSerialized)
                {
                    return;
                }
                
                if (sync.deletedAtTime == default)
                {
                    sync.deletedAtTime = (long)simulationFrame;
                }

                localComponentChanges.Add(sync.accumulatedPriority, new ComponentChange
                {
                    entity = entity,
                    componentType = TypeIds.InternalWorldOrientation,
                    mask = 0,
                    resendMask = 0,
                });
            }).ScheduleParallel();

			Entities.WithNone<global::Coherence.Generated.LocalUser>().ForEach((Entity entity, ref LocalUser_Sync sync, in Simulated sim) =>
            {
                if (sync.deleteHasBeenSerialized)
                {
                    return;
                }
                
                if (sync.deletedAtTime == default)
                {
                    sync.deletedAtTime = (long)simulationFrame;
                }

                localComponentChanges.Add(sync.accumulatedPriority, new ComponentChange
                {
                    entity = entity,
                    componentType = TypeIds.InternalLocalUser,
                    mask = 0,
                    resendMask = 0,
                });
            }).ScheduleParallel();

			Entities.WithNone<global::Coherence.Generated.WorldPositionQuery>().ForEach((Entity entity, ref WorldPositionQuery_Sync sync, in Simulated sim) =>
            {
                if (sync.deleteHasBeenSerialized)
                {
                    return;
                }
                
                if (sync.deletedAtTime == default)
                {
                    sync.deletedAtTime = (long)simulationFrame;
                }

                localComponentChanges.Add(sync.accumulatedPriority, new ComponentChange
                {
                    entity = entity,
                    componentType = TypeIds.InternalWorldPositionQuery,
                    mask = 0,
                    resendMask = 0,
                });
            }).ScheduleParallel();

			Entities.WithNone<global::Coherence.Generated.SessionBased>().ForEach((Entity entity, ref SessionBased_Sync sync, in Simulated sim) =>
            {
                if (sync.deleteHasBeenSerialized)
                {
                    return;
                }
                
                if (sync.deletedAtTime == default)
                {
                    sync.deletedAtTime = (long)simulationFrame;
                }

                localComponentChanges.Add(sync.accumulatedPriority, new ComponentChange
                {
                    entity = entity,
                    componentType = TypeIds.InternalSessionBased,
                    mask = 0,
                    resendMask = 0,
                });
            }).ScheduleParallel();

			Entities.WithNone<global::Coherence.Generated.Transferable>().ForEach((Entity entity, ref Transferable_Sync sync, in Simulated sim) =>
            {
                if (sync.deleteHasBeenSerialized)
                {
                    return;
                }
                
                if (sync.deletedAtTime == default)
                {
                    sync.deletedAtTime = (long)simulationFrame;
                }

                localComponentChanges.Add(sync.accumulatedPriority, new ComponentChange
                {
                    entity = entity,
                    componentType = TypeIds.InternalTransferable,
                    mask = 0,
                    resendMask = 0,
                });
            }).ScheduleParallel();

			Entities.WithNone<global::Coherence.Generated.Player>().ForEach((Entity entity, ref Player_Sync sync, in Simulated sim) =>
            {
                if (sync.deleteHasBeenSerialized)
                {
                    return;
                }
                
                if (sync.deletedAtTime == default)
                {
                    sync.deletedAtTime = (long)simulationFrame;
                }

                localComponentChanges.Add(sync.accumulatedPriority, new ComponentChange
                {
                    entity = entity,
                    componentType = TypeIds.InternalPlayer,
                    mask = 0,
                    resendMask = 0,
                });
            }).ScheduleParallel();


			Dependency.Complete();
        }
    }
}
// ------------------ end of DetectRemovedComponent.cs -----------------
#endregion
