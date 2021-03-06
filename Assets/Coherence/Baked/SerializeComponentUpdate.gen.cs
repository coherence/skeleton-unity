


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

            // Reset accumulated priority so the same component is not sent again next frame
            var syncData = EntityManager.GetComponentData<WorldPosition_Sync>(entity);

            syncData.accumulatedPriority = 0;

            syncData.lastSentData = componentData;

            syncData.hasBeenSerialized = true;
            syncData.resendMask &= ~mask;	// Clear serialized fields from resend mask
            EntityManager.SetComponentData(entity, syncData);
        }
        

        private void SerializeWorldOrientation(EntityManager EntityManager, Entity entity, uint mask, IOutBitStream protocolOutStream)
        {

            // Write component changes to output stream
            var componentData = EntityManager.GetComponentData<Rotation>(entity);
            unityWriters.Write(componentData, mask, protocolOutStream);

            // Reset accumulated priority so the same component is not sent again next frame
            var syncData = EntityManager.GetComponentData<WorldOrientation_Sync>(entity);

            syncData.accumulatedPriority = 0;

            syncData.lastSentData = componentData;

            syncData.hasBeenSerialized = true;
            syncData.resendMask &= ~mask;	// Clear serialized fields from resend mask
            EntityManager.SetComponentData(entity, syncData);
        }
        

        private void SerializeLocalUser(EntityManager EntityManager, Entity entity, uint mask, IOutBitStream protocolOutStream)
        {

            // Write component changes to output stream
            var componentData = EntityManager.GetComponentData<LocalUser>(entity);
            unityWriters.Write(componentData, mask, protocolOutStream);

            // Reset accumulated priority so the same component is not sent again next frame
            var syncData = EntityManager.GetComponentData<LocalUser_Sync>(entity);

            syncData.accumulatedPriority = 0;

            syncData.lastSentData = componentData;

            syncData.hasBeenSerialized = true;
            syncData.resendMask &= ~mask;	// Clear serialized fields from resend mask
            EntityManager.SetComponentData(entity, syncData);
        }
        

        private void SerializeWorldPositionQuery(EntityManager EntityManager, Entity entity, uint mask, IOutBitStream protocolOutStream)
        {

            // Write component changes to output stream
            var componentData = EntityManager.GetComponentData<WorldPositionQuery>(entity);
            unityWriters.Write(componentData, mask, protocolOutStream);

            // Reset accumulated priority so the same component is not sent again next frame
            var syncData = EntityManager.GetComponentData<WorldPositionQuery_Sync>(entity);

            syncData.accumulatedPriority = 0;

            syncData.lastSentData = componentData;

            syncData.hasBeenSerialized = true;
            syncData.resendMask &= ~mask;	// Clear serialized fields from resend mask
            EntityManager.SetComponentData(entity, syncData);
        }
        

        private void SerializeArchetypeComponent(EntityManager EntityManager, Entity entity, uint mask, IOutBitStream protocolOutStream)
        {

            // Write component changes to output stream
            var componentData = EntityManager.GetComponentData<ArchetypeComponent>(entity);
            unityWriters.Write(componentData, mask, protocolOutStream);

            // Reset accumulated priority so the same component is not sent again next frame
            var syncData = EntityManager.GetComponentData<ArchetypeComponent_Sync>(entity);

            syncData.accumulatedPriority = 0;

            syncData.lastSentData = componentData;

            syncData.hasBeenSerialized = true;
            syncData.resendMask &= ~mask;	// Clear serialized fields from resend mask
            EntityManager.SetComponentData(entity, syncData);
        }
        

        private void SerializePersistence(EntityManager EntityManager, Entity entity, uint mask, IOutBitStream protocolOutStream)
        {

            // Write component changes to output stream
            var componentData = EntityManager.GetComponentData<Persistence>(entity);
            unityWriters.Write(componentData, mask, protocolOutStream);

            // Reset accumulated priority so the same component is not sent again next frame
            var syncData = EntityManager.GetComponentData<Persistence_Sync>(entity);

            syncData.accumulatedPriority = 0;

            syncData.lastSentData = componentData;

            syncData.hasBeenSerialized = true;
            syncData.resendMask &= ~mask;	// Clear serialized fields from resend mask
            EntityManager.SetComponentData(entity, syncData);
        }
        

        private void SerializePlayer(EntityManager EntityManager, Entity entity, uint mask, IOutBitStream protocolOutStream)
        {

            // Reset accumulated priority so the same component is not sent again next frame
            var syncData = EntityManager.GetComponentData<Player_Sync>(entity);

            syncData.accumulatedPriority = 0;

            syncData.hasBeenSerialized = true;
            syncData.resendMask &= ~mask;	// Clear serialized fields from resend mask
            EntityManager.SetComponentData(entity, syncData);
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

                case TypeIds.InternalPlayer:
                    SerializePlayer(entityManager, unityEntity, fieldMask, protocolOutStream);
                    break;

                default:
                    throw new Exception($"unknown componentType {componentType}");
            }
        }
    
        
        public void UpdateDestructState(EntityManager entityManager, Entity unityEntity, uint componentTypeId)
        {
            switch (componentTypeId)
            {

                case TypeIds.InternalWorldPosition:
                {
                    var syncData = entityManager.GetComponentData<WorldPosition_Sync>(unityEntity);
                    syncData.deleteHasBeenSerialized = true;
                    entityManager.SetComponentData(unityEntity, syncData);
                    break;
                }

                case TypeIds.InternalWorldOrientation:
                {
                    var syncData = entityManager.GetComponentData<WorldOrientation_Sync>(unityEntity);
                    syncData.deleteHasBeenSerialized = true;
                    entityManager.SetComponentData(unityEntity, syncData);
                    break;
                }

                case TypeIds.InternalLocalUser:
                {
                    var syncData = entityManager.GetComponentData<LocalUser_Sync>(unityEntity);
                    syncData.deleteHasBeenSerialized = true;
                    entityManager.SetComponentData(unityEntity, syncData);
                    break;
                }

                case TypeIds.InternalWorldPositionQuery:
                {
                    var syncData = entityManager.GetComponentData<WorldPositionQuery_Sync>(unityEntity);
                    syncData.deleteHasBeenSerialized = true;
                    entityManager.SetComponentData(unityEntity, syncData);
                    break;
                }

                case TypeIds.InternalArchetypeComponent:
                {
                    var syncData = entityManager.GetComponentData<ArchetypeComponent_Sync>(unityEntity);
                    syncData.deleteHasBeenSerialized = true;
                    entityManager.SetComponentData(unityEntity, syncData);
                    break;
                }

                case TypeIds.InternalPersistence:
                {
                    var syncData = entityManager.GetComponentData<Persistence_Sync>(unityEntity);
                    syncData.deleteHasBeenSerialized = true;
                    entityManager.SetComponentData(unityEntity, syncData);
                    break;
                }

                case TypeIds.InternalPlayer:
                {
                    var syncData = entityManager.GetComponentData<Player_Sync>(unityEntity);
                    syncData.deleteHasBeenSerialized = true;
                    entityManager.SetComponentData(unityEntity, syncData);
                    break;
                }


                default:
                    throw new Exception($"unknown componentType {componentTypeId}");
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
    	
    	public void UpdateDestructState(EntityManager entityManager, Entity unityEntity, uint componentTypeId)
    	{
            serializeComponentUpdatesGenerated.UpdateDestructState(entityManager, unityEntity, componentTypeId);
        }
    }

}


// ------------------ end of SerializeComponentUpdate.cs -----------------
#endregion
