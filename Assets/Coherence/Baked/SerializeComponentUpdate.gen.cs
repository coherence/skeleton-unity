


#region SerializeComponentUpdate
// -----------------------------------
//  SerializeComponentUpdate.cs
// -----------------------------------
			

namespace Coherence.Generated.Internal
{
	using System;
	using Unity.Entities;
	using Unity.Transforms;
	using global::Coherence.Generated;
	using Coherence.Replication.Protocol.Definition;
	using Replication.Client.Unity.Ecs;
    using Coherence.Replication.Unity;

    public class SerializeComponentUpdatesGenerated
    {
         private UnityWriters unityWriters;

         public SerializeComponentUpdatesGenerated(UnityMapper mapper)
         {
             unityWriters = new UnityWriters(mapper);
         }


        private void SerializeWorldPosition(EntityManager EntityManager, Entity entity, uint mask, IOutBitStream protocolOutStream)
        {
            // Write component changes to output stream
            var componentData = EntityManager.GetComponentData<Translation>(entity);
            unityWriters.Write(componentData, mask, protocolOutStream);
        }
        

        private void SerializeWorldOrientation(EntityManager EntityManager, Entity entity, uint mask, IOutBitStream protocolOutStream)
        {
            // Write component changes to output stream
            var componentData = EntityManager.GetComponentData<Rotation>(entity);
            unityWriters.Write(componentData, mask, protocolOutStream);
        }
        

        private void SerializeLocalUser(EntityManager EntityManager, Entity entity, uint mask, IOutBitStream protocolOutStream)
        {
            // Write component changes to output stream
            var componentData = EntityManager.GetComponentData<LocalUser>(entity);
            unityWriters.Write(componentData, mask, protocolOutStream);
        }
        

        private void SerializeWorldPositionQuery(EntityManager EntityManager, Entity entity, uint mask, IOutBitStream protocolOutStream)
        {
            // Write component changes to output stream
            var componentData = EntityManager.GetComponentData<WorldPositionQuery>(entity);
            unityWriters.Write(componentData, mask, protocolOutStream);
        }
        

        private void SerializeArchetypeComponent(EntityManager EntityManager, Entity entity, uint mask, IOutBitStream protocolOutStream)
        {
            // Write component changes to output stream
            var componentData = EntityManager.GetComponentData<ArchetypeComponent>(entity);
            unityWriters.Write(componentData, mask, protocolOutStream);
        }
        

        private void SerializePersistence(EntityManager EntityManager, Entity entity, uint mask, IOutBitStream protocolOutStream)
        {
            // Write component changes to output stream
            var componentData = EntityManager.GetComponentData<Persistence>(entity);
            unityWriters.Write(componentData, mask, protocolOutStream);
        }
        

        private void SerializeConnectedEntity(EntityManager EntityManager, Entity entity, uint mask, IOutBitStream protocolOutStream)
        {
            // Write component changes to output stream
            var componentData = EntityManager.GetComponentData<ConnectedEntity>(entity);
            unityWriters.Write(componentData, mask, protocolOutStream);
        }
        

        private void SerializePlayer(EntityManager EntityManager, Entity entity, uint mask, IOutBitStream protocolOutStream)
        {
        }
        

    
        public void SerializeComponent(EntityManager entityManager, Entity unityEntity, uint componentType, uint fieldMask, IOutBitStream protocolOutStream)
        {
            switch (componentType)
            {

                case TypeIds.InternalWorldPosition:
                    SerializeWorldPosition(entityManager, unityEntity, fieldMask, protocolOutStream);
                    break;

                case TypeIds.InternalWorldOrientation:
                    SerializeWorldOrientation(entityManager, unityEntity, fieldMask, protocolOutStream);
                    break;

                case TypeIds.InternalLocalUser:
                    SerializeLocalUser(entityManager, unityEntity, fieldMask, protocolOutStream);
                    break;

                case TypeIds.InternalWorldPositionQuery:
                    SerializeWorldPositionQuery(entityManager, unityEntity, fieldMask, protocolOutStream);
                    break;

                case TypeIds.InternalArchetypeComponent:
                    SerializeArchetypeComponent(entityManager, unityEntity, fieldMask, protocolOutStream);
                    break;

                case TypeIds.InternalPersistence:
                    SerializePersistence(entityManager, unityEntity, fieldMask, protocolOutStream);
                    break;

                case TypeIds.InternalConnectedEntity:
                    SerializeConnectedEntity(entityManager, unityEntity, fieldMask, protocolOutStream);
                    break;

                case TypeIds.InternalPlayer:
                    SerializePlayer(entityManager, unityEntity, fieldMask, protocolOutStream);
                    break;

                default:
                    throw new Exception($"unknown componentType {componentType}");
            }
        }
    }
    
    class SerializeComponentUpdatesWrapper : ISchemaSpecificComponentSerializer
    {
        private SerializeComponentUpdatesGenerated serializeComponentUpdatesGenerated;

        public SerializeComponentUpdatesWrapper(UnityMapper mapper)
        {
            serializeComponentUpdatesGenerated = new SerializeComponentUpdatesGenerated(mapper);
        }

    	public void SerializeComponent(EntityManager entityManager, Entity unityEntity, uint ComponentTypeId, uint fieldMask, IOutBitStream protocolOutStream)
    	{
    		serializeComponentUpdatesGenerated.SerializeComponent(entityManager, unityEntity, ComponentTypeId, fieldMask, protocolOutStream);
    	}
    }

}


// ------------------ end of SerializeComponentUpdate.cs -----------------
#endregion
