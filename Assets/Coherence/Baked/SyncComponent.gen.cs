


#region SyncComponent
// -----------------------------------
//  SyncComponent.cs
// -----------------------------------
			
namespace Coherence.Generated.Internal
{
	using Unity.Entities;
	using Unity.Transforms;
	using global::Coherence.Generated;


	public struct WorldPosition_Sync : IComponentData
	{
		public Translation lastSentData;
		public uint howImportantAreYou;
		public bool hasBeenSerialized;
		public bool hasReceivedConstructor;
		public double lastSampledTime;
		public double minSamplingTime;
	}


	public struct WorldOrientation_Sync : IComponentData
	{
		public Rotation lastSentData;
		public uint howImportantAreYou;
		public bool hasBeenSerialized;
		public bool hasReceivedConstructor;
		public double lastSampledTime;
		public double minSamplingTime;
	}


	public struct LocalUser_Sync : IComponentData
	{
		public LocalUser lastSentData;
		public uint howImportantAreYou;
		public bool hasBeenSerialized;
		public bool hasReceivedConstructor;
		public double lastSampledTime;
		public double minSamplingTime;
	}


	public struct WorldPositionQuery_Sync : IComponentData
	{
		public WorldPositionQuery lastSentData;
		public uint howImportantAreYou;
		public bool hasBeenSerialized;
		public bool hasReceivedConstructor;
		public double lastSampledTime;
		public double minSamplingTime;
	}


	public struct ArchetypeComponent_Sync : IComponentData
	{
		public ArchetypeComponent lastSentData;
		public uint howImportantAreYou;
		public bool hasBeenSerialized;
		public bool hasReceivedConstructor;
		public double lastSampledTime;
		public double minSamplingTime;
	}


	public struct Persistence_Sync : IComponentData
	{
		public Persistence lastSentData;
		public uint howImportantAreYou;
		public bool hasBeenSerialized;
		public bool hasReceivedConstructor;
		public double lastSampledTime;
		public double minSamplingTime;
	}


	public struct ConnectedEntity_Sync : IComponentData
	{
		public ConnectedEntity lastSentData;
		public uint howImportantAreYou;
		public bool hasBeenSerialized;
		public bool hasReceivedConstructor;
		public double lastSampledTime;
		public double minSamplingTime;
	}


	public struct Player_Sync : IComponentData
	{
		public Player lastSentData;
		public uint howImportantAreYou;
		public bool hasBeenSerialized;
		public bool hasReceivedConstructor;
		public double lastSampledTime;
		public double minSamplingTime;
	}


}


// ------------------ end of SyncComponent.cs -----------------
#endregion
