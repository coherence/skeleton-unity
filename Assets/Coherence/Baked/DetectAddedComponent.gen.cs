


#region DetectAddedComponent
// -----------------------------------
//  DetectAddedComponent.cs
// -----------------------------------
			

namespace Coherence.Generated.Internal
{
	using global::Coherence.Generated;
	using Coherence.Replication.Client.Unity.Ecs;
	using Unity.Entities;
	using Unity.Transforms;

	[UpdateInGroup(typeof(PresentationSystemGroup))]
	[UpdateBefore(typeof(DetectRemovedComponentsSystem))]
    public class DetectAddedComponentsSystem : SystemBase
    {
        protected override void OnUpdate()
        {

            Entities.WithAll<Translation, Simulated>().WithNone<WorldPosition_Sync>().ForEach((Entity entity) =>
			{

				EntityManager.AddComponentData(entity, new WorldPosition_Sync 
				{
					howImportantAreYou = 1000
				});
			}).WithStructuralChanges().Run();

            Entities.WithAll<Rotation, Simulated>().WithNone<WorldOrientation_Sync>().ForEach((Entity entity) =>
			{

				EntityManager.AddComponentData(entity, new WorldOrientation_Sync 
				{
					howImportantAreYou = 1000
				});
			}).WithStructuralChanges().Run();

            Entities.WithAll<global::Coherence.Generated.LocalUser, Simulated>().WithNone<LocalUser_Sync>().ForEach((Entity entity) =>
			{

				EntityManager.AddComponentData(entity, new LocalUser_Sync 
				{
					howImportantAreYou = 600
				});
			}).WithStructuralChanges().Run();

            Entities.WithAll<global::Coherence.Generated.WorldPositionQuery, Simulated>().WithNone<WorldPositionQuery_Sync>().ForEach((Entity entity) =>
			{

				EntityManager.AddComponentData(entity, new WorldPositionQuery_Sync 
				{
					howImportantAreYou = 600
				});
			}).WithStructuralChanges().Run();

            Entities.WithAll<global::Coherence.Generated.ArchetypeComponent, Simulated>().WithNone<ArchetypeComponent_Sync>().ForEach((Entity entity) =>
			{

				EntityManager.AddComponentData(entity, new ArchetypeComponent_Sync 
				{
					howImportantAreYou = 600
				});
			}).WithStructuralChanges().Run();

            Entities.WithAll<global::Coherence.Generated.Persistence, Simulated>().WithNone<Persistence_Sync>().ForEach((Entity entity) =>
			{

				EntityManager.AddComponentData(entity, new Persistence_Sync 
				{
					howImportantAreYou = 600
				});
			}).WithStructuralChanges().Run();

            Entities.WithAll<global::Coherence.Generated.Player, Simulated>().WithNone<Player_Sync>().ForEach((Entity entity) =>
			{

				EntityManager.AddComponentData(entity, new Player_Sync 
				{
					howImportantAreYou = 600
				});
			}).WithStructuralChanges().Run();

			Dependency.Complete();
        }
    }
}
// ------------------ end of DetectAddedComponent.cs -----------------
#endregion
