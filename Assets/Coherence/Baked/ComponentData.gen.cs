


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
	using Coherence.Ecs;

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

	// EcsComponentData: InternalArchetypeComponentData
	public struct ArchetypeComponent : IComponentData
	{
		public int index;
	}

	// EcsComponentData: InternalPersistenceData
	public struct Persistence : IComponentData
	{
		public FixedString64 uuid;
		public FixedString64 expiry;
	}

	// EcsComponentData: InternalConnectedEntityData
	public struct ConnectedEntity : IComponentData
	{
		public SerializeEntityID value;
	}

	// EcsComponentData: InternalPlayerData
	public struct Player : IComponentData
	{
	}
}
// ------------------ end of ComponentData.cs -----------------
#endregion
