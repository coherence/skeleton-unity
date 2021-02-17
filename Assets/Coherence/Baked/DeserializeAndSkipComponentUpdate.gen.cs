


#region DeserializeAndSkipComponentUpdate
// -----------------------------------
//  DeserializeAndSkipComponentUpdate.cs
// -----------------------------------
			
namespace Coherence.Generated.Internal
{
    using Coherence.Log;
    using Unity.Transforms;
    using global::Coherence.Generated;
    using Replication.Client.Unity.Ecs;
    using Coherence.Replication.Unity;

    public class DeserializeComponentUpdateSkipGenerated
    {
        private UnityReaders unityReaders;

        public DeserializeComponentUpdateSkipGenerated(UnityMapper mapper)
        {
            unityReaders = new UnityReaders(mapper);
        }

		
		private void DeserializeWorldPosition(Coherence.Replication.Protocol.Definition.IInBitStream protocolStream)
		{
            var ignored = new Translation();
            unityReaders.Read(ref ignored, protocolStream);
		}
		
		private void DeserializeWorldOrientation(Coherence.Replication.Protocol.Definition.IInBitStream protocolStream)
		{
            var ignored = new Rotation();
            unityReaders.Read(ref ignored, protocolStream);
		}
		
		private void DeserializeLocalUser(Coherence.Replication.Protocol.Definition.IInBitStream protocolStream)
		{
            var ignored = new LocalUser();
            unityReaders.Read(ref ignored, protocolStream);
		}
		
		private void DeserializeWorldPositionQuery(Coherence.Replication.Protocol.Definition.IInBitStream protocolStream)
		{
            var ignored = new WorldPositionQuery();
            unityReaders.Read(ref ignored, protocolStream);
		}
		
		private void DeserializeSessionBased(Coherence.Replication.Protocol.Definition.IInBitStream protocolStream)
		{
            var ignored = new SessionBased();
            unityReaders.Read(ref ignored, protocolStream);
		}
		
		private void DeserializeTransferable(Coherence.Replication.Protocol.Definition.IInBitStream protocolStream)
		{
            var ignored = new Transferable();
            unityReaders.Read(ref ignored, protocolStream);
		}
		
		private void DeserializeArchetypeComponent(Coherence.Replication.Protocol.Definition.IInBitStream protocolStream)
		{
            var ignored = new ArchetypeComponent();
            unityReaders.Read(ref ignored, protocolStream);
		}
		
		private void DeserializePlayer(Coherence.Replication.Protocol.Definition.IInBitStream protocolStream)
		{
            var ignored = new Player();
            unityReaders.Read(ref ignored, protocolStream);
		}
		
		private void DeserializeA(Coherence.Replication.Protocol.Definition.IInBitStream protocolStream)
		{
            var ignored = new A();
            unityReaders.Read(ref ignored, protocolStream);
		}
		
		private void DeserializeB(Coherence.Replication.Protocol.Definition.IInBitStream protocolStream)
		{
            var ignored = new B();
            unityReaders.Read(ref ignored, protocolStream);
		}
		
		private void DeserializeC(Coherence.Replication.Protocol.Definition.IInBitStream protocolStream)
		{
            var ignored = new C();
            unityReaders.Read(ref ignored, protocolStream);
		}
		
 
		public void SkipComponentDataUpdate(uint componentType, Coherence.Replication.Protocol.Definition.IInBitStream inProtocolStream)
        {
			switch (componentType)
            {

                case TypeIds.InternalWorldPosition:
					DeserializeWorldPosition(inProtocolStream);
                    break;

                case TypeIds.InternalWorldOrientation:
					DeserializeWorldOrientation(inProtocolStream);
                    break;

                case TypeIds.InternalLocalUser:
					DeserializeLocalUser(inProtocolStream);
                    break;

                case TypeIds.InternalWorldPositionQuery:
					DeserializeWorldPositionQuery(inProtocolStream);
                    break;

                case TypeIds.InternalSessionBased:
					DeserializeSessionBased(inProtocolStream);
                    break;

                case TypeIds.InternalTransferable:
					DeserializeTransferable(inProtocolStream);
                    break;

                case TypeIds.InternalArchetypeComponent:
					DeserializeArchetypeComponent(inProtocolStream);
                    break;

                case TypeIds.InternalPlayer:
					DeserializePlayer(inProtocolStream);
                    break;

                case TypeIds.InternalA:
					DeserializeA(inProtocolStream);
                    break;

                case TypeIds.InternalB:
					DeserializeB(inProtocolStream);
                    break;

                case TypeIds.InternalC:
					DeserializeC(inProtocolStream);
                    break;

			}
		}
    }
    
    public class DeserializeComponentsAndSkipWrapper : ISchemaSpecificComponentDeserializerAndSkip
    {
        DeserializeComponentUpdateSkipGenerated deserializeComponentUpdateSkipGenerated;

        public DeserializeComponentsAndSkipWrapper(UnityMapper mapper)
        {
            deserializeComponentUpdateSkipGenerated = new DeserializeComponentUpdateSkipGenerated(mapper);
        }

        public void DeserializeAndSkipComponent(uint componentTypeId, Coherence.Replication.Protocol.Definition.IInBitStream protocolOutStream)
        {
            deserializeComponentUpdateSkipGenerated.SkipComponentDataUpdate(componentTypeId, protocolOutStream);
        }
    }    
}

// ------------------ end of DeserializeAndSkipComponentUpdate.cs -----------------
#endregion
