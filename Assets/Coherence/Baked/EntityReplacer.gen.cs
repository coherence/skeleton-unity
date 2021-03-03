


#region EntityReplacer
// -----------------------------------
//  EntityReplacer.cs
// -----------------------------------
			
namespace Coherence.Generated
{
	using Unity.Entities;
	using Unity.Transforms;
	using UnityEngine;
	using Coherence.Replication.Client.Unity.Ecs;

	public class EntityReplacer {
		public static void Replace(EntityManager entityManager, Entity networkEntity, Entity newEntity)
		{
#if UNITY_EDITOR
			entityManager.SetName(newEntity, $"{networkEntity} (remote)");
#endif

			CopyComponents(entityManager, networkEntity, newEntity);

			var mapper = entityManager.World.GetExistingSystem<SyncSendSystem>().Sender.Mapper;
			if (!mapper.ToCoherenceEntityId(networkEntity, out var entityId))
			{
				Debug.LogError("Networked Entity not found in mapper: " + networkEntity); // Should not happen
			}

			mapper.Remove(entityId);
			mapper.Add(entityId, newEntity);
			entityManager.AddComponent<Mapped>(newEntity);
			entityManager.DestroyEntity(networkEntity);
		}

		private static void CopyComponents(EntityManager entityManager, Entity source, Entity destination)
		{
			/////////////////////////////////////////////////////////////
			// Copy SDK components 
			// Simulated and Orphan are defined in the SDK, 
			// and should be copied similar to schema components below
			/////////////////////////////////////////////////////////////

			if(entityManager.HasComponent<Simulated>(source))
			{
				if(!entityManager.HasComponent<Simulated>(destination)) {
					entityManager.AddComponentData<Simulated>(destination, new Simulated());
				}
				var data = entityManager.GetComponentData<Simulated>(source);
				entityManager.SetComponentData<Simulated>(destination, data);
			}
		
			if(entityManager.HasComponent<Orphan>(source))
			{
				entityManager.AddComponentData<Orphan>(destination, new Orphan());
			}

			/////////////////////////////////////////////////////////////
			// Copy schema components
			/////////////////////////////////////////////////////////////
		
            if(entityManager.HasComponent<Translation>(source))
			{
		        // Translation is built in
                var data = entityManager.GetComponentData<Translation>(source);
                entityManager.SetComponentData<Translation>(destination, data);
		
			}
		
            if(entityManager.HasComponent<Rotation>(source))
			{
		        // Rotation is built in
                var data = entityManager.GetComponentData<Rotation>(source);
                entityManager.SetComponentData<Rotation>(destination, data);
		
			}
		
            if(entityManager.HasComponent<LocalUser>(source))
			{
		        // LocalUser has fields, will copy it.			
                if(!entityManager.HasComponent<LocalUser>(destination)) {
                    entityManager.AddComponentData<LocalUser>(destination, new LocalUser());
                }
				var data = entityManager.GetComponentData<LocalUser>(source);
				entityManager.SetComponentData<LocalUser>(destination, data);
		
			}
		
            if(entityManager.HasComponent<WorldPositionQuery>(source))
			{
		        // WorldPositionQuery has fields, will copy it.			
                if(!entityManager.HasComponent<WorldPositionQuery>(destination)) {
                    entityManager.AddComponentData<WorldPositionQuery>(destination, new WorldPositionQuery());
                }
				var data = entityManager.GetComponentData<WorldPositionQuery>(source);
				entityManager.SetComponentData<WorldPositionQuery>(destination, data);
		
			}
		
            if(entityManager.HasComponent<ArchetypeComponent>(source))
			{
		        // ArchetypeComponent has fields, will copy it.			
                if(!entityManager.HasComponent<ArchetypeComponent>(destination)) {
                    entityManager.AddComponentData<ArchetypeComponent>(destination, new ArchetypeComponent());
                }
				var data = entityManager.GetComponentData<ArchetypeComponent>(source);
				entityManager.SetComponentData<ArchetypeComponent>(destination, data);
		
			}
		
            if(entityManager.HasComponent<Persistence>(source))
			{
		        // Persistence has fields, will copy it.			
                if(!entityManager.HasComponent<Persistence>(destination)) {
                    entityManager.AddComponentData<Persistence>(destination, new Persistence());
                }
				var data = entityManager.GetComponentData<Persistence>(source);
				entityManager.SetComponentData<Persistence>(destination, data);
		
			}
		
            if(entityManager.HasComponent<Player>(source))
			{
		        // Player has no fields, will just add it.
		        entityManager.AddComponentData<Player>(destination, new Player());
		
			}
		

        // Command buffers
        
            if (entityManager.HasComponent<AuthorityTransfer>(source) &&
                !entityManager.HasComponent<AuthorityTransfer>(destination)) {
                entityManager.AddBuffer<AuthorityTransfer>(destination);
            }
            if (entityManager.HasComponent<AuthorityTransferRequest>(source) &&
                !entityManager.HasComponent<AuthorityTransferRequest>(destination)) {
                entityManager.AddBuffer<AuthorityTransferRequest>(destination);
            }
        

		}
	}
}


// ------------------ end of EntityReplacer.cs -----------------
#endregion
