


#region ComponentData
// -----------------------------------
//  ComponentData.cs
// -----------------------------------
			
namespace Coherence.Generated
{
	using Unity.Collections;
	using Unity.Entities;
	using Unity.Mathematics;
	using Unity.Transforms;

	
	
 
	
	
 
	
	
	// EcsComponentData: InternalLocalUserData
	public struct LocalUser : IComponentData
	{
		public int localIndex;
	}
	
	
	
	// EcsComponentData: InternalWorldPositionQueryData
	public struct WorldPositionQuery : IComponentData
	{
		public float3 position;
		public float radius;
	}
	
	
	
	// EcsComponentData: InternalSessionBasedData
	public struct SessionBased : IComponentData
	{
	}
	
	
	
	// EcsComponentData: InternalTransferableData
	public struct Transferable : IComponentData
	{
		public int participant;
	}
	
	
	
	// EcsComponentData: InternalPlayerData
	public struct Player : IComponentData
	{
	}
	
	

}


// ------------------ end of ComponentData.cs -----------------
#endregion
