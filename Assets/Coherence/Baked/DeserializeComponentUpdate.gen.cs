


#region DeserializeComponentUpdate
// -----------------------------------
//  DeserializeComponentUpdate.cs
// -----------------------------------
			
namespace Coherence.Generated.Internal
{
	using Coherence.Brook;
	using Coherence.Log;
	using Unity.Entities;
	using Unity.Transforms;
	using DeltaEcs;
	using global::Coherence.Generated;
	using Coherence.SimulationFrame;
	using Replication.Client.Unity.Ecs;
	using Coherence.Replication.Unity;

	public class DeserializeComponentUpdateGenerated
	{
		private UnityReaders unityReaders;

		public DeserializeComponentUpdateGenerated(UnityMapper mapper)
		{
			unityReaders = new UnityReaders(mapper);
		}

		private void InterpolateTranslation(EntityManager entityManager, Entity entity, AbsoluteSimulationFrame simulationFrame, Translation tempComponentData)
		{
			// Ensure entities with interpolation also have Interpolation components and Sample components
			if (!entityManager.HasComponent<InterpolationComponent_Translation_Value>(entity))
			{
				var interpolationData = new InterpolationComponent_Translation_Value() 
				{
					setupID = InterpolationSetupID.DefaultTranslation
				};
				entityManager.AddComponentData(entity, interpolationData);
				entityManager.AddComponent<Sample_Translation_Value>(entity);
			}

			// Append buffer for components that use interpolation
			InterpolationSystem_Translation
				.AppendValueBuffer(entity, tempComponentData, entityManager.World, (ulong) simulationFrame.Frame);
		}

		private void InterpolateRotation(EntityManager entityManager, Entity entity, AbsoluteSimulationFrame simulationFrame, Rotation tempComponentData)
		{
			// Ensure entities with interpolation also have Interpolation components and Sample components
			if (!entityManager.HasComponent<InterpolationComponent_Rotation_Value>(entity))
			{
				var interpolationData = new InterpolationComponent_Rotation_Value() 
				{
					setupID = InterpolationSetupID.DefaultRotation
				};
				entityManager.AddComponentData(entity, interpolationData);
				entityManager.AddComponent<Sample_Rotation_Value>(entity);
			}

			// Append buffer for components that use interpolation
			InterpolationSystem_Rotation
				.AppendValueBuffer(entity, tempComponentData, entityManager.World, (ulong) simulationFrame.Frame);
		}

		private void DeserializeWorldPosition(EntityManager entityManager, Entity entity, bool componentOwnership, AbsoluteSimulationFrame simulationFrame, Coherence.Replication.Protocol.Definition.IInBitStream protocolStream, bool justCreated, IInBitStream bitStream)
		{
			if (!entityManager.HasComponent<Translation>(entity))
			{
				// UnityEngine.Debug.Log($"Had to add component 'Translation' to entity {entity}");
				entityManager.AddComponent<Translation>(entity);
			}

			// If we own the entity, don't overwrite with downstream data from server
			// TODO: Server should never send downstream to the simulating client
			if (componentOwnership)
			{
				// Read and discard data (the stream must always be read)
				var temp = new Translation();
				unityReaders.Read(ref temp, protocolStream);
				return;
			}
			var tempComponentData = new Translation();
			unityReaders.Read(ref tempComponentData, protocolStream);
			if (justCreated) // Hack
			{
				entityManager.SetComponentData(entity, tempComponentData);
			}

			InterpolateTranslation(entityManager, entity, simulationFrame, tempComponentData);
		}

		private void DeserializeWorldOrientation(EntityManager entityManager, Entity entity, bool componentOwnership, AbsoluteSimulationFrame simulationFrame, Coherence.Replication.Protocol.Definition.IInBitStream protocolStream, bool justCreated, IInBitStream bitStream)
		{
			if (!entityManager.HasComponent<Rotation>(entity))
			{
				// UnityEngine.Debug.Log($"Had to add component 'Rotation' to entity {entity}");
				entityManager.AddComponent<Rotation>(entity);
			}

			// If we own the entity, don't overwrite with downstream data from server
			// TODO: Server should never send downstream to the simulating client
			if (componentOwnership)
			{
				// Read and discard data (the stream must always be read)
				var temp = new Rotation();
				unityReaders.Read(ref temp, protocolStream);
				return;
			}
			var tempComponentData = new Rotation();
			unityReaders.Read(ref tempComponentData, protocolStream);
			if (justCreated) // Hack
			{
				entityManager.SetComponentData(entity, tempComponentData);
			}

			InterpolateRotation(entityManager, entity, simulationFrame, tempComponentData);
		}

		private void DeserializeLocalUser(EntityManager entityManager, Entity entity, bool componentOwnership, AbsoluteSimulationFrame simulationFrame, Coherence.Replication.Protocol.Definition.IInBitStream protocolStream, bool justCreated, IInBitStream bitStream)
		{
			if (!entityManager.HasComponent<LocalUser>(entity))
			{
				// UnityEngine.Debug.Log($"Had to add component 'LocalUser' to entity {entity}");
				entityManager.AddComponent<LocalUser>(entity);
			}

			// If we own the entity, don't overwrite with downstream data from server
			// TODO: Server should never send downstream to the simulating client
			if (componentOwnership)
			{
				// Read and discard data (the stream must always be read)
				var temp = new LocalUser();
				unityReaders.Read(ref temp, protocolStream);
				return;
			}
			// Overwrite components that don't use interpolation
			var componentData = entityManager.GetComponentData<LocalUser>(entity);
			unityReaders.Read(ref componentData, protocolStream);
			entityManager.SetComponentData(entity, componentData);
		}

		private void DeserializeWorldPositionQuery(EntityManager entityManager, Entity entity, bool componentOwnership, AbsoluteSimulationFrame simulationFrame, Coherence.Replication.Protocol.Definition.IInBitStream protocolStream, bool justCreated, IInBitStream bitStream)
		{
			if (!entityManager.HasComponent<WorldPositionQuery>(entity))
			{
				// UnityEngine.Debug.Log($"Had to add component 'WorldPositionQuery' to entity {entity}");
				entityManager.AddComponent<WorldPositionQuery>(entity);
			}

			// If we own the entity, don't overwrite with downstream data from server
			// TODO: Server should never send downstream to the simulating client
			if (componentOwnership)
			{
				// Read and discard data (the stream must always be read)
				var temp = new WorldPositionQuery();
				unityReaders.Read(ref temp, protocolStream);
				return;
			}
			// Overwrite components that don't use interpolation
			var componentData = entityManager.GetComponentData<WorldPositionQuery>(entity);
			unityReaders.Read(ref componentData, protocolStream);
			entityManager.SetComponentData(entity, componentData);
		}

		private void DeserializeArchetypeComponent(EntityManager entityManager, Entity entity, bool componentOwnership, AbsoluteSimulationFrame simulationFrame, Coherence.Replication.Protocol.Definition.IInBitStream protocolStream, bool justCreated, IInBitStream bitStream)
		{
			if (!entityManager.HasComponent<ArchetypeComponent>(entity))
			{
				// UnityEngine.Debug.Log($"Had to add component 'ArchetypeComponent' to entity {entity}");
				entityManager.AddComponent<ArchetypeComponent>(entity);
			}

			// If we own the entity, don't overwrite with downstream data from server
			// TODO: Server should never send downstream to the simulating client
			if (componentOwnership)
			{
				// Read and discard data (the stream must always be read)
				var temp = new ArchetypeComponent();
				unityReaders.Read(ref temp, protocolStream);
				return;
			}
			// Overwrite components that don't use interpolation
			var componentData = entityManager.GetComponentData<ArchetypeComponent>(entity);
			unityReaders.Read(ref componentData, protocolStream);
			entityManager.SetComponentData(entity, componentData);
		}

		private void DeserializePersistence(EntityManager entityManager, Entity entity, bool componentOwnership, AbsoluteSimulationFrame simulationFrame, Coherence.Replication.Protocol.Definition.IInBitStream protocolStream, bool justCreated, IInBitStream bitStream)
		{
			if (!entityManager.HasComponent<Persistence>(entity))
			{
				// UnityEngine.Debug.Log($"Had to add component 'Persistence' to entity {entity}");
				entityManager.AddComponent<Persistence>(entity);
			}

			// If we own the entity, don't overwrite with downstream data from server
			// TODO: Server should never send downstream to the simulating client
			if (componentOwnership)
			{
				// Read and discard data (the stream must always be read)
				var temp = new Persistence();
				unityReaders.Read(ref temp, protocolStream);
				return;
			}
			// Overwrite components that don't use interpolation
			var componentData = entityManager.GetComponentData<Persistence>(entity);
			unityReaders.Read(ref componentData, protocolStream);
			entityManager.SetComponentData(entity, componentData);
		}

		private void DeserializeConnectedEntity(EntityManager entityManager, Entity entity, bool componentOwnership, AbsoluteSimulationFrame simulationFrame, Coherence.Replication.Protocol.Definition.IInBitStream protocolStream, bool justCreated, IInBitStream bitStream)
		{
			if (!entityManager.HasComponent<ConnectedEntity>(entity))
			{
				// UnityEngine.Debug.Log($"Had to add component 'ConnectedEntity' to entity {entity}");
				entityManager.AddComponent<ConnectedEntity>(entity);
			}

			// If we own the entity, don't overwrite with downstream data from server
			// TODO: Server should never send downstream to the simulating client
			if (componentOwnership)
			{
				// Read and discard data (the stream must always be read)
				var temp = new ConnectedEntity();
				unityReaders.Read(ref temp, protocolStream);
				return;
			}
			// Overwrite components that don't use interpolation
			var componentData = entityManager.GetComponentData<ConnectedEntity>(entity);
			unityReaders.Read(ref componentData, protocolStream);
			entityManager.SetComponentData(entity, componentData);
		}

		private void DeserializePlayer(EntityManager entityManager, Entity entity, bool componentOwnership, AbsoluteSimulationFrame simulationFrame, Coherence.Replication.Protocol.Definition.IInBitStream protocolStream, bool justCreated, IInBitStream bitStream)
		{
			// No need to read empty components, just ensure that it's there
			if (!entityManager.HasComponent<Player>(entity))
			{
				entityManager.AddComponent<Player>(entity);
			}
		}

		public void ReadComponentDataUpdate(EntityManager entityManager, Entity entity, uint componentType, AbsoluteSimulationFrame simulationFrame, IInBitStream bitStream)
		{
			ReadComponentDataUpdateEx(entityManager, entity, componentType, simulationFrame, bitStream, false);
		}

		public void ReadComponentDataUpdateEx(EntityManager entityManager, Entity entity, uint componentType, AbsoluteSimulationFrame simulationFrame, IInBitStream bitStream, bool justCreated)
		{
			var componentOwnership = Deserializator.ReadComponentOwnership(bitStream); // Read bit from stream...
			componentOwnership = entityManager.HasComponent<Simulated>(entity); // Then overwrite it with entity ownership.
			var inProtocolStream = new Coherence.FieldStream.Deserialize.Streams.InBitStream(bitStream);
			switch (componentType)
			{
			case TypeIds.InternalWorldPosition:
				DeserializeWorldPosition(entityManager, entity, componentOwnership, simulationFrame, inProtocolStream, justCreated, bitStream);
				break;
			case TypeIds.InternalWorldOrientation:
				DeserializeWorldOrientation(entityManager, entity, componentOwnership, simulationFrame, inProtocolStream, justCreated, bitStream);
				break;
			case TypeIds.InternalLocalUser:
				DeserializeLocalUser(entityManager, entity, componentOwnership, simulationFrame, inProtocolStream, justCreated, bitStream);
				break;
			case TypeIds.InternalWorldPositionQuery:
				DeserializeWorldPositionQuery(entityManager, entity, componentOwnership, simulationFrame, inProtocolStream, justCreated, bitStream);
				break;
			case TypeIds.InternalArchetypeComponent:
				DeserializeArchetypeComponent(entityManager, entity, componentOwnership, simulationFrame, inProtocolStream, justCreated, bitStream);
				break;
			case TypeIds.InternalPersistence:
				DeserializePersistence(entityManager, entity, componentOwnership, simulationFrame, inProtocolStream, justCreated, bitStream);
				break;
			case TypeIds.InternalConnectedEntity:
				DeserializeConnectedEntity(entityManager, entity, componentOwnership, simulationFrame, inProtocolStream, justCreated, bitStream);
				break;
			case TypeIds.InternalPlayer:
				DeserializePlayer(entityManager, entity, componentOwnership, simulationFrame, inProtocolStream, justCreated, bitStream);
				break;
			default:
				Log.Warning("couldn't find component", "componentType", componentType);
				break;
			}
		}

		public void CreateIfNeededAndReadComponentDataUpdate(EntityManager entityManager, Entity entity, uint componentType, AbsoluteSimulationFrame simulationFrame, IInBitStream bitStream)
		{
#region Commands

			{
				var hasBuffer = entityManager.HasComponent<AuthorityTransfer>(entity);
				if (!hasBuffer)
				{
					entityManager.AddBuffer<AuthorityTransfer>(entity);
				}

				var hasRequestBuffer = entityManager.HasComponent<AuthorityTransferRequest>(entity);
				if (!hasRequestBuffer)
				{
					entityManager.AddBuffer<AuthorityTransferRequest>(entity);
				}
			}

#endregion

			switch (componentType)
			{
				case TypeIds.InternalWorldPosition:
				{
					var justCreated = false;
					var hasComponentData = entityManager.HasComponent<Translation>(entity);
					if (!hasComponentData)
					{
						entityManager.AddComponentData(entity, new Translation());
						justCreated = true;
					}

					ReadComponentDataUpdateEx(entityManager, entity, componentType, simulationFrame, bitStream, justCreated);
					break;
				}
				case TypeIds.InternalWorldOrientation:
				{
					var justCreated = false;
					var hasComponentData = entityManager.HasComponent<Rotation>(entity);
					if (!hasComponentData)
					{
						entityManager.AddComponentData(entity, new Rotation());
						justCreated = true;
					}

					ReadComponentDataUpdateEx(entityManager, entity, componentType, simulationFrame, bitStream, justCreated);
					break;
				}
				case TypeIds.InternalLocalUser:
				{
					var justCreated = false;
					var hasComponentData = entityManager.HasComponent<LocalUser>(entity);
					if (!hasComponentData)
					{
						entityManager.AddComponentData(entity, new LocalUser());
						justCreated = true;
					}

					ReadComponentDataUpdateEx(entityManager, entity, componentType, simulationFrame, bitStream, justCreated);
					break;
				}
				case TypeIds.InternalWorldPositionQuery:
				{
					var justCreated = false;
					var hasComponentData = entityManager.HasComponent<WorldPositionQuery>(entity);
					if (!hasComponentData)
					{
						entityManager.AddComponentData(entity, new WorldPositionQuery());
						justCreated = true;
					}

					ReadComponentDataUpdateEx(entityManager, entity, componentType, simulationFrame, bitStream, justCreated);
					break;
				}
				case TypeIds.InternalArchetypeComponent:
				{
					var justCreated = false;
					var hasComponentData = entityManager.HasComponent<ArchetypeComponent>(entity);
					if (!hasComponentData)
					{
						entityManager.AddComponentData(entity, new ArchetypeComponent());
						justCreated = true;
					}

					ReadComponentDataUpdateEx(entityManager, entity, componentType, simulationFrame, bitStream, justCreated);
					break;
				}
				case TypeIds.InternalPersistence:
				{
					var justCreated = false;
					var hasComponentData = entityManager.HasComponent<Persistence>(entity);
					if (!hasComponentData)
					{
						entityManager.AddComponentData(entity, new Persistence());
						justCreated = true;
					}

					ReadComponentDataUpdateEx(entityManager, entity, componentType, simulationFrame, bitStream, justCreated);
					break;
				}
				case TypeIds.InternalConnectedEntity:
				{
					var justCreated = false;
					var hasComponentData = entityManager.HasComponent<ConnectedEntity>(entity);
					if (!hasComponentData)
					{
						entityManager.AddComponentData(entity, new ConnectedEntity());
						justCreated = true;
					}

					ReadComponentDataUpdateEx(entityManager, entity, componentType, simulationFrame, bitStream, justCreated);
					break;
				}
				case TypeIds.InternalPlayer:
				{
					var justCreated = false;
					var hasComponentData = entityManager.HasComponent<Player>(entity);
					if (!hasComponentData)
					{
						entityManager.AddComponentData(entity, new Player());
						justCreated = true;
					}

					ReadComponentDataUpdateEx(entityManager, entity, componentType, simulationFrame, bitStream, justCreated);
					break;
				}
				default:
				{
					Log.Warning("can not create component type");
					break;
				}
			}
		}
	}

	public class ComponentDeserializeWrapper : ISchemaSpecificComponentDeserialize
	{
		private DeserializeComponentUpdateGenerated deserializeComponentUpdateGenerated;

		public ComponentDeserializeWrapper(UnityMapper mapper)
		{
			deserializeComponentUpdateGenerated = new DeserializeComponentUpdateGenerated(mapper);
		}

		public void CreateIfNeededAndReadComponentDataUpdate(EntityManager entityManager, Entity entity, uint componentType, AbsoluteSimulationFrame simulationFrame, IInBitStream bitStream)
		{
			deserializeComponentUpdateGenerated.CreateIfNeededAndReadComponentDataUpdate(entityManager, entity, componentType, simulationFrame, bitStream);
		}

		public void ReadComponentDataUpdate(EntityManager entityManager, Entity entity, uint componentType, AbsoluteSimulationFrame simulationFrame, IInBitStream bitStream)
		{
			deserializeComponentUpdateGenerated.ReadComponentDataUpdate(entityManager, entity, componentType, simulationFrame, bitStream);
		}
	}
}

// ------------------ end of DeserializeComponentUpdate.cs -----------------
#endregion
