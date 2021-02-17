


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
        public uint resendMask;
        public uint howImportantAreYou;
        public uint accumulatedPriority;
        public long deletedAtTime;
        public bool hasBeenSerialized;
        public bool deleteHasBeenSerialized;
        public bool hasReceivedConstructor;
    }


    public struct WorldOrientation_Sync : IComponentData
    {
        public Rotation lastSentData;
        public uint resendMask;
        public uint howImportantAreYou;
        public uint accumulatedPriority;
        public long deletedAtTime;
        public bool hasBeenSerialized;
        public bool deleteHasBeenSerialized;
        public bool hasReceivedConstructor;
    }


    public struct LocalUser_Sync : IComponentData
    {
        public LocalUser lastSentData;
        public uint resendMask;
        public uint howImportantAreYou;
        public uint accumulatedPriority;
        public long deletedAtTime;
        public bool hasBeenSerialized;
        public bool deleteHasBeenSerialized;
        public bool hasReceivedConstructor;
    }


    public struct WorldPositionQuery_Sync : IComponentData
    {
        public WorldPositionQuery lastSentData;
        public uint resendMask;
        public uint howImportantAreYou;
        public uint accumulatedPriority;
        public long deletedAtTime;
        public bool hasBeenSerialized;
        public bool deleteHasBeenSerialized;
        public bool hasReceivedConstructor;
    }


    public struct SessionBased_Sync : IComponentData
    {
        public SessionBased lastSentData;
        public uint resendMask;
        public uint howImportantAreYou;
        public uint accumulatedPriority;
        public long deletedAtTime;
        public bool hasBeenSerialized;
        public bool deleteHasBeenSerialized;
        public bool hasReceivedConstructor;
    }


    public struct Transferable_Sync : IComponentData
    {
        public Transferable lastSentData;
        public uint resendMask;
        public uint howImportantAreYou;
        public uint accumulatedPriority;
        public long deletedAtTime;
        public bool hasBeenSerialized;
        public bool deleteHasBeenSerialized;
        public bool hasReceivedConstructor;
    }


    public struct ArchetypeComponent_Sync : IComponentData
    {
        public ArchetypeComponent lastSentData;
        public uint resendMask;
        public uint howImportantAreYou;
        public uint accumulatedPriority;
        public long deletedAtTime;
        public bool hasBeenSerialized;
        public bool deleteHasBeenSerialized;
        public bool hasReceivedConstructor;
    }


    public struct Player_Sync : IComponentData
    {
        public Player lastSentData;
        public uint resendMask;
        public uint howImportantAreYou;
        public uint accumulatedPriority;
        public long deletedAtTime;
        public bool hasBeenSerialized;
        public bool deleteHasBeenSerialized;
        public bool hasReceivedConstructor;
    }


    public struct A_Sync : IComponentData
    {
        public A lastSentData;
        public uint resendMask;
        public uint howImportantAreYou;
        public uint accumulatedPriority;
        public long deletedAtTime;
        public bool hasBeenSerialized;
        public bool deleteHasBeenSerialized;
        public bool hasReceivedConstructor;
    }


    public struct B_Sync : IComponentData
    {
        public B lastSentData;
        public uint resendMask;
        public uint howImportantAreYou;
        public uint accumulatedPriority;
        public long deletedAtTime;
        public bool hasBeenSerialized;
        public bool deleteHasBeenSerialized;
        public bool hasReceivedConstructor;
    }


    public struct C_Sync : IComponentData
    {
        public C lastSentData;
        public uint resendMask;
        public uint howImportantAreYou;
        public uint accumulatedPriority;
        public long deletedAtTime;
        public bool hasBeenSerialized;
        public bool deleteHasBeenSerialized;
        public bool hasReceivedConstructor;
    }


}


// ------------------ end of SyncComponent.cs -----------------
#endregion
