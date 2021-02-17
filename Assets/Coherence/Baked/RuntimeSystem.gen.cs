


#region RuntimeSystem
// -----------------------------------
//  RuntimeSystem.cs
// -----------------------------------
			
namespace Coherence.Sdk.Unity
{
	using Coherence.Generated.Internal;
	using global::Unity.Entities;
	using global::Unity.Transforms;
	using Coherence.Log;
	using Replication.Client.Unity.Ecs;
	using global::Coherence.Generated;

	[UpdateInGroup(typeof(SimulationSystemGroup))]
	public class CoherenceRuntimeSystem : ComponentSystem
	{
		protected override void OnCreate()
		{
			#region Register all known component types and their enums
			           GlobalLookups.Register<Translation>(TypeEnums.InternalWorldPosition);
           GlobalLookups.Register<Rotation>(TypeEnums.InternalWorldOrientation);
           GlobalLookups.Register<LocalUser>(TypeEnums.InternalLocalUser);
           GlobalLookups.Register<WorldPositionQuery>(TypeEnums.InternalWorldPositionQuery);
           GlobalLookups.Register<SessionBased>(TypeEnums.InternalSessionBased);
           GlobalLookups.Register<Transferable>(TypeEnums.InternalTransferable);
           GlobalLookups.Register<ArchetypeComponent>(TypeEnums.InternalArchetypeComponent);
           GlobalLookups.Register<Player>(TypeEnums.InternalPlayer);
           GlobalLookups.Register<A>(TypeEnums.InternalA);
           GlobalLookups.Register<B>(TypeEnums.InternalB);
           GlobalLookups.Register<C>(TypeEnums.InternalC);

			#endregion

			#region Register all known component types and their component type id
			           GlobalTypeIdLookups.Register<Translation>(TypeIds.InternalWorldPosition);
           GlobalTypeIdLookups.Register<Rotation>(TypeIds.InternalWorldOrientation);
           GlobalTypeIdLookups.Register<LocalUser>(TypeIds.InternalLocalUser);
           GlobalTypeIdLookups.Register<WorldPositionQuery>(TypeIds.InternalWorldPositionQuery);
           GlobalTypeIdLookups.Register<SessionBased>(TypeIds.InternalSessionBased);
           GlobalTypeIdLookups.Register<Transferable>(TypeIds.InternalTransferable);
           GlobalTypeIdLookups.Register<ArchetypeComponent>(TypeIds.InternalArchetypeComponent);
           GlobalTypeIdLookups.Register<Player>(TypeIds.InternalPlayer);
           GlobalTypeIdLookups.Register<A>(TypeIds.InternalA);
           GlobalTypeIdLookups.Register<B>(TypeIds.InternalB);
           GlobalTypeIdLookups.Register<C>(TypeIds.InternalC);

			#endregion

			base.OnCreate();
		}

		protected override void OnUpdate()
		{
		}
	}
}

// ------------------ end of RuntimeSystem.cs -----------------
#endregion
