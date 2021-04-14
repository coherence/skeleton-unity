


#region BufferElementData
// -----------------------------------
//  BufferElementData.cs
// -----------------------------------
			
namespace Coherence.Generated
{
	using Coherence.Ecs;
	using UnityEngine.Scripting;
	using Unity.Collections;
	using Unity.Entities;
	using Unity.Mathematics;
	using Unity.Transforms;
	
	// EcsComponentData: InternalAuthorityTransferData
	public struct AuthorityTransfer : IBufferElementData
	{
		public int participant;
	}

	public struct AuthorityTransferRequest : IBufferElementData
	{
		public int participant;
	}
}

// ------------------ end of BufferElementData.cs -----------------
#endregion
