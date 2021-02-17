


#region SerializeCreateEntity
// -----------------------------------
//  SerializeCreateEntity.cs
// -----------------------------------
			
namespace Coherence.Generated.Internal
{
    using Message.Serializer.Serialize;
    using Coherence.Log;
    using Unity.Entities;
    using Unity.Transforms;
    using IOutBitStream = Coherence.Brook.IOutBitStream;
    using global::Coherence.Generated;
    using Coherence.Replication.Unity;

    public class SerializeCreateEntityRequest
    {
        private MessageSerializers messageSerializers;

        public SerializeCreateEntityRequest(UnityMapper mapper)
        {
            messageSerializers = new MessageSerializers(mapper);
        }
        
        public void SerializeComponentsInMessageFormat(EntityManager entityManager,
            Entity entity, uint[] foundComponentTypes, IOutBitStream bitStream)
        {
            var protocolOutStream = new FieldStream.Serialize.Streams.OutBitStream(bitStream);

            foreach (var coherenceComponentType in foundComponentTypes)
            {
				ComponentTypeIdSerializer.Serialize(coherenceComponentType, bitStream);

				switch (coherenceComponentType)
                {
					
                    case TypeIds.InternalWorldPosition:
					{
						var data = entityManager.GetComponentData<Translation>(entity);
						messageSerializers.WorldPosition(protocolOutStream, data);
						break;
					}
					
                    case TypeIds.InternalWorldOrientation:
					{
						var data = entityManager.GetComponentData<Rotation>(entity);
						messageSerializers.WorldOrientation(protocolOutStream, data);
						break;
					}
					
                    case TypeIds.InternalLocalUser:
					{
						var data = entityManager.GetComponentData<LocalUser>(entity);
						messageSerializers.LocalUser(protocolOutStream, data);
						break;
					}
					
                    case TypeIds.InternalWorldPositionQuery:
					{
						var data = entityManager.GetComponentData<WorldPositionQuery>(entity);
						messageSerializers.WorldPositionQuery(protocolOutStream, data);
						break;
					}
					
                    case TypeIds.InternalSessionBased:
					{
						var data = entityManager.GetComponentData<SessionBased>(entity);
						messageSerializers.SessionBased(protocolOutStream, data);
						break;
					}
					
                    case TypeIds.InternalTransferable:
					{
						var data = entityManager.GetComponentData<Transferable>(entity);
						messageSerializers.Transferable(protocolOutStream, data);
						break;
					}
					
                    case TypeIds.InternalArchetypeComponent:
					{
						var data = entityManager.GetComponentData<ArchetypeComponent>(entity);
						messageSerializers.ArchetypeComponent(protocolOutStream, data);
						break;
					}
					
                    case TypeIds.InternalPlayer:
					{
						var data = entityManager.GetComponentData<Player>(entity);
						messageSerializers.Player(protocolOutStream, data);
						break;
					}
					
                    case TypeIds.InternalA:
					{
						var data = entityManager.GetComponentData<A>(entity);
						messageSerializers.A(protocolOutStream, data);
						break;
					}
					
                    case TypeIds.InternalB:
					{
						var data = entityManager.GetComponentData<B>(entity);
						messageSerializers.B(protocolOutStream, data);
						break;
					}
					
                    case TypeIds.InternalC:
					{
						var data = entityManager.GetComponentData<C>(entity);
						messageSerializers.C(protocolOutStream, data);
						break;
					}
					

                    default:
                    {
                        Log.Warning($"Unknown component", "component", coherenceComponentType);
                        break;
                    }
                }
            }
        }
    }
}

// ------------------ end of SerializeCreateEntity.cs -----------------
#endregion
