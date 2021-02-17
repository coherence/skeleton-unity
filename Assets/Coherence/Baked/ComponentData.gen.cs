


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
	
	
	
	// EcsComponentData: InternalArchetypeComponentData
	public struct ArchetypeComponent : IComponentData
	{
		public int index;
	}
	
	
	
	// EcsComponentData: InternalPlayerData
	public struct Player : IComponentData
	{
	}
	
	
	
	// EcsComponentData: InternalAData
	public struct A : IComponentData
	{
	}
	
	
	
	// EcsComponentData: InternalBData
	public struct B : IComponentData
	{
	}
	
	
	
	// EcsComponentData: InternalCData
	public struct C : IComponentData
	{
	}
	
	

}


// ------------------ end of ComponentData.cs -----------------
#endregion
