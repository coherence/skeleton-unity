


#region DetectChangedComponent
// -----------------------------------
//  DetectChangedComponent.cs
// -----------------------------------
			

namespace Coherence.Generated.Internal
{
    using global::Coherence.Generated;
    using Coherence.Replication.Client.Unity.Ecs;
    using Coherence.Replication.Unity;
    using Unity.Entities;
    using Unity.Transforms;
    using System.Diagnostics;
    using Unity.Collections;
	using Unity.Mathematics;

    [UpdateInGroup(typeof(PresentationSystemGroup))]
    [UpdateBefore(typeof(SyncSendSystem))]
    public class DetectChangedComponentsSystem : SystemBase
    {
		        static bool HasNoticeableDifference(float a, float b, float epsilonFloat)
        {
            return math.abs(a - b) > epsilonFloat;
        }

        static bool HasNoticeableDifference(FixedString64 a, FixedString64 b)
        {
            return !a.Equals(b);
        }

        static bool HasNoticeableDifference(int a, int b)
        {
            return !a.Equals(b);
        }

        static bool HasNoticeableDifference(float2 a, float2 b, float epsilonFloat)
        {
            if (HasNoticeableDifference(a.x, b.x, epsilonFloat)) return true;
            if (HasNoticeableDifference(a.y, b.y, epsilonFloat)) return true;

            return false;
        }

        static bool HasNoticeableDifference(float3 a, float3 b, float epsilonFloat)
        {
            if (HasNoticeableDifference(a.x, b.x, epsilonFloat)) return true;
            if (HasNoticeableDifference(a.y, b.y, epsilonFloat)) return true;
            if (HasNoticeableDifference(a.z, b.z, epsilonFloat)) return true;

            return false;
        }

        static bool HasNoticeableDifference(quaternion a, quaternion b, float epsilonFloat)
        {
            if (HasNoticeableDifference(a.value.x, b.value.x, epsilonFloat)) return true;
            if (HasNoticeableDifference(a.value.y, b.value.y, epsilonFloat)) return true;
            if (HasNoticeableDifference(a.value.z, b.value.z, epsilonFloat)) return true;
            if (HasNoticeableDifference(a.value.w, b.value.w, epsilonFloat)) return true;

            return false;
        }

        protected override void OnUpdate()
        {
            var componentChanges = World.GetExistingSystem<SyncSendSystem>().ComponentChanges;
            var localComponentChanges = componentChanges.AsParallelWriter();



            Entities.ForEach((Entity entity, ref WorldPosition_Sync sync, in Translation data, in Simulated simulate) =>
            {
                uint mask = 0;
                if (!sync.hasBeenSerialized)
                {
                    mask = 0xffffffff;
                }


				if (HasNoticeableDifference(data.Value, sync.lastSentData.Value, CoherenceLimits.Translation_value_Epsilon) ) mask |= 0b00000000000000000000000000000001;



                if (mask != 0 || sync.resendMask != 0)
                {
                    
                    
                    
                    
                    
                    CheckRange(data.Value.x, CoherenceLimits.Translation_value_Min, CoherenceLimits.Translation_value_Max);
                    CheckRange(data.Value.y, CoherenceLimits.Translation_value_Min, CoherenceLimits.Translation_value_Max);
                    CheckRange(data.Value.z, CoherenceLimits.Translation_value_Min, CoherenceLimits.Translation_value_Max);
                    
                    
                    

                    sync.accumulatedPriority += sync.howImportantAreYou;
                    var componentChange = new ComponentChange
                    {
                        entity = entity,
                        componentType = TypeIds.InternalWorldPosition,
                        mask = mask,
                        resendMask = sync.resendMask,
                        entityHasReceivedConstructor = simulate.hasReceivedConstructor,
                        componentHasReceivedConstructor = sync.hasReceivedConstructor,
                    };

                    localComponentChanges.Add(sync.accumulatedPriority, componentChange);
                }
            }).ScheduleParallel();


            Entities.ForEach((Entity entity, ref WorldOrientation_Sync sync, in Rotation data, in Simulated simulate) =>
            {
                uint mask = 0;
                if (!sync.hasBeenSerialized)
                {
                    mask = 0xffffffff;
                }


				if (HasNoticeableDifference(data.Value, sync.lastSentData.Value, CoherenceLimits.Rotation_value_Epsilon) ) mask |= 0b00000000000000000000000000000001;



                if (mask != 0 || sync.resendMask != 0)
                {
                    
                    
                    
                    
                    
                    
                    

                    sync.accumulatedPriority += sync.howImportantAreYou;
                    var componentChange = new ComponentChange
                    {
                        entity = entity,
                        componentType = TypeIds.InternalWorldOrientation,
                        mask = mask,
                        resendMask = sync.resendMask,
                        entityHasReceivedConstructor = simulate.hasReceivedConstructor,
                        componentHasReceivedConstructor = sync.hasReceivedConstructor,
                    };

                    localComponentChanges.Add(sync.accumulatedPriority, componentChange);
                }
            }).ScheduleParallel();


            Entities.ForEach((Entity entity, ref LocalUser_Sync sync, in global::Coherence.Generated.LocalUser data, in Simulated simulate) =>
            {
                uint mask = 0;
                if (!sync.hasBeenSerialized)
                {
                    mask = 0xffffffff;
                }


                if (data.localIndex != sync.lastSentData.localIndex) mask |= 0b00000000000000000000000000000001;



                if (mask != 0 || sync.resendMask != 0)
                {
                    
                    
                    
                    
                    CheckRange(data.localIndex, CoherenceLimits.LocalUser_localIndex_Min, CoherenceLimits.LocalUser_localIndex_Max);
                    
                    
                    
                    

                    sync.accumulatedPriority += sync.howImportantAreYou;
                    var componentChange = new ComponentChange
                    {
                        entity = entity,
                        componentType = TypeIds.InternalLocalUser,
                        mask = mask,
                        resendMask = sync.resendMask,
                        entityHasReceivedConstructor = simulate.hasReceivedConstructor,
                        componentHasReceivedConstructor = sync.hasReceivedConstructor,
                    };

                    localComponentChanges.Add(sync.accumulatedPriority, componentChange);
                }
            }).ScheduleParallel();


            Entities.ForEach((Entity entity, ref WorldPositionQuery_Sync sync, in global::Coherence.Generated.WorldPositionQuery data, in Simulated simulate) =>
            {
                uint mask = 0;
                if (!sync.hasBeenSerialized)
                {
                    mask = 0xffffffff;
                }


				if (HasNoticeableDifference(data.position, sync.lastSentData.position, CoherenceLimits.WorldPositionQuery_position_Epsilon) ) mask |= 0b00000000000000000000000000000001;



                if (data.radius != sync.lastSentData.radius) mask |= 0b00000000000000000000000000000010;



                if (mask != 0 || sync.resendMask != 0)
                {
                    
                    
                    
                    
                    
                    CheckRange(data.position.x, CoherenceLimits.WorldPositionQuery_position_Min, CoherenceLimits.WorldPositionQuery_position_Max);
                    CheckRange(data.position.y, CoherenceLimits.WorldPositionQuery_position_Min, CoherenceLimits.WorldPositionQuery_position_Max);
                    CheckRange(data.position.z, CoherenceLimits.WorldPositionQuery_position_Min, CoherenceLimits.WorldPositionQuery_position_Max);
                    
                    
                    
                    
                    
                    
                    CheckRange(data.radius, CoherenceLimits.WorldPositionQuery_radius_Min, CoherenceLimits.WorldPositionQuery_radius_Max);
                    
                    
                    
                    

                    sync.accumulatedPriority += sync.howImportantAreYou;
                    var componentChange = new ComponentChange
                    {
                        entity = entity,
                        componentType = TypeIds.InternalWorldPositionQuery,
                        mask = mask,
                        resendMask = sync.resendMask,
                        entityHasReceivedConstructor = simulate.hasReceivedConstructor,
                        componentHasReceivedConstructor = sync.hasReceivedConstructor,
                    };

                    localComponentChanges.Add(sync.accumulatedPriority, componentChange);
                }
            }).ScheduleParallel();


            Entities.ForEach((Entity entity, ref SessionBased_Sync sync, in global::Coherence.Generated.SessionBased data, in Simulated simulate) =>
            {
                uint mask = 0;
                if (!sync.hasBeenSerialized)
                {
                    mask = 0xffffffff;
                }


                if (mask != 0 || sync.resendMask != 0)
                {
                    

                    sync.accumulatedPriority += sync.howImportantAreYou;
                    var componentChange = new ComponentChange
                    {
                        entity = entity,
                        componentType = TypeIds.InternalSessionBased,
                        mask = mask,
                        resendMask = sync.resendMask,
                        entityHasReceivedConstructor = simulate.hasReceivedConstructor,
                        componentHasReceivedConstructor = sync.hasReceivedConstructor,
                    };

                    localComponentChanges.Add(sync.accumulatedPriority, componentChange);
                }
            }).ScheduleParallel();


            Entities.ForEach((Entity entity, ref Transferable_Sync sync, in global::Coherence.Generated.Transferable data, in Simulated simulate) =>
            {
                uint mask = 0;
                if (!sync.hasBeenSerialized)
                {
                    mask = 0xffffffff;
                }


                if (data.participant != sync.lastSentData.participant) mask |= 0b00000000000000000000000000000001;



                if (mask != 0 || sync.resendMask != 0)
                {
                    
                    
                    
                    
                    CheckRange(data.participant, CoherenceLimits.Transferable_participant_Min, CoherenceLimits.Transferable_participant_Max);
                    
                    
                    
                    

                    sync.accumulatedPriority += sync.howImportantAreYou;
                    var componentChange = new ComponentChange
                    {
                        entity = entity,
                        componentType = TypeIds.InternalTransferable,
                        mask = mask,
                        resendMask = sync.resendMask,
                        entityHasReceivedConstructor = simulate.hasReceivedConstructor,
                        componentHasReceivedConstructor = sync.hasReceivedConstructor,
                    };

                    localComponentChanges.Add(sync.accumulatedPriority, componentChange);
                }
            }).ScheduleParallel();


            Entities.ForEach((Entity entity, ref Player_Sync sync, in global::Coherence.Generated.Player data, in Simulated simulate) =>
            {
                uint mask = 0;
                if (!sync.hasBeenSerialized)
                {
                    mask = 0xffffffff;
                }


                if (mask != 0 || sync.resendMask != 0)
                {
                    

                    sync.accumulatedPriority += sync.howImportantAreYou;
                    var componentChange = new ComponentChange
                    {
                        entity = entity,
                        componentType = TypeIds.InternalPlayer,
                        mask = mask,
                        resendMask = sync.resendMask,
                        entityHasReceivedConstructor = simulate.hasReceivedConstructor,
                        componentHasReceivedConstructor = sync.hasReceivedConstructor,
                    };

                    localComponentChanges.Add(sync.accumulatedPriority, componentChange);
                }
            }).ScheduleParallel();


            Dependency.Complete();
        }

        [Conditional("UNITY_EDITOR")]
        private static void CheckRange(float x, float min, float max)
        {
            if(x.CompareTo(min) < 0) {
                UnityEngine.Debug.LogWarning($"float out of range: {x} (must be at least {min})");
                return;
            }
            if(x.CompareTo(max) >= 0) {
                UnityEngine.Debug.LogWarning($"float out of range: {x} (must be less than {max})");
            }
        }

        [Conditional("UNITY_EDITOR")]
        private static void CheckRange(int x, int min, int max)
        {
            if(x.CompareTo(min) < 0) {
                UnityEngine.Debug.LogWarning($"int out of range: {x} (must be at least {min})");
                return;
            }
            if(x.CompareTo(max) >= 0) {
                UnityEngine.Debug.LogWarning($"int out of range: {x} (must be less than {max})");
            }
        }
    }
}
// ------------------ end of DetectChangedComponent.cs -----------------
#endregion
