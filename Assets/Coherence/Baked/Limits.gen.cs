


#region Limits
// -----------------------------------
//  Limits.cs
// -----------------------------------
			
namespace Coherence.Generated
{
	using Coherence.Replication.Client.Unity.Ecs;
	using Unity.Collections;
	using Unity.Transforms;
	using Unity.Entities;
	using UnityEngine;
	using System;
	using global::Coherence.Generated;

	public class CoherenceLimits : MonoBehaviour
	{
	
		
		// Component name: Translation
		
		// value : float3
		
		
		public static readonly float Translation_value_Min = -2400f;
		public static readonly float Translation_value_Max = 2400f;
		public static readonly float Translation_value_Epsilon = 0.000286102294921875f;
		
		
		
	
		
		// Component name: Rotation
		
		// value : quaternion
		
		
		
		public static readonly float Rotation_value_Epsilon = 0.01f; // TODO!
		
		
	
		
		// Component name: LocalUser
		
		// localIndex : int
		
		public static readonly int LocalUser_localIndex_Min = -9999;
		public static readonly int LocalUser_localIndex_Max = 9999;
		
		
		
		
	
		
		// Component name: WorldPositionQuery
		
		// position : float3
		
		
		public static readonly float WorldPositionQuery_position_Min = -2400f;
		public static readonly float WorldPositionQuery_position_Max = 2400f;
		public static readonly float WorldPositionQuery_position_Epsilon = 0.000286102294921875f;
		
		
		
		// radius : float
		
		
		public static readonly float WorldPositionQuery_radius_Min = -2400f;
		public static readonly float WorldPositionQuery_radius_Max = 2400f;
		public static readonly float WorldPositionQuery_radius_Epsilon = 0.000286102294921875f;
		
		
		
	
		
		// Component name: ArchetypeComponent
		
		// index : int
		
		public static readonly int ArchetypeComponent_index_Min = -9999;
		public static readonly int ArchetypeComponent_index_Max = 9999;
		
		
		
		
	
		
		// Component name: Persistence
		
		// uuid : FixedString64
		
		
		
		
		// expiry : FixedString64
		
		
		
		
	
		
		// Component name: ConnectedEntity
		
		// value : SerializeEntityID
		
		
		
		
	
		
		// Component name: Player
		
	
	}
}

// ------------------ end of Limits.cs -----------------
#endregion
