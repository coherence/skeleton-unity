


#region MessageSerializers
// -----------------------------------
//  MessageSerializers.cs
// -----------------------------------
			
namespace Coherence.Generated.Internal
{
	using Coherence.Replication.Protocol.Definition;
	using global::Coherence.Generated;
	using Unity.Transforms;
	using Replication.Unity;

	public class MessageSerializers
	{
    	private CoherenceToUnityConverters coherenceToUnityConverters;

    	public MessageSerializers(UnityMapper mapper)
    	{
        	coherenceToUnityConverters = new CoherenceToUnityConverters(mapper);
    	}
	
		public void WorldPosition(IOutBitStream bitstream, Translation data)
		{
			var converted_value = coherenceToUnityConverters.FromUnityfloat3(data.Value);
			bitstream.WriteVector3f(converted_value, 24, 2400);
		}
	
		public void WorldOrientation(IOutBitStream bitstream, Rotation data)
		{
			var converted_value = coherenceToUnityConverters.FromUnityquaternion(data.Value);
			bitstream.WriteUnitRotation(converted_value);
		}
	
		public void LocalUser(IOutBitStream bitstream, LocalUser data)
		{
			bitstream.WriteIntegerRange(data.localIndex, 15, -9999);
		}
	
		public void WorldPositionQuery(IOutBitStream bitstream, WorldPositionQuery data)
		{
			var converted_position = coherenceToUnityConverters.FromUnityfloat3(data.position);
			bitstream.WriteVector3f(converted_position, 24, 2400);
			var converted_radius = coherenceToUnityConverters.FromUnityfloat(data.radius);
			bitstream.WriteFixedPoint(converted_radius, 24, 2400);
		}
	
		public void ArchetypeComponent(IOutBitStream bitstream, ArchetypeComponent data)
		{
			bitstream.WriteIntegerRange(data.index, 15, -9999);
		}
	
		public void Persistence(IOutBitStream bitstream, Persistence data)
		{
			var converted_uuid = coherenceToUnityConverters.FromUnityFixedString64(data.uuid);
			bitstream.WriteShortString(converted_uuid);
			var converted_expiry = coherenceToUnityConverters.FromUnityFixedString64(data.expiry);
			bitstream.WriteShortString(converted_expiry);
		}
	
		public void ConnectedEntity(IOutBitStream bitstream, ConnectedEntity data)
		{
			bitstream.WriteEntity(data.value);
		}
	
		public void Player(IOutBitStream bitstream, Player data)
		{
		}
	
		public void AuthorityTransfer(IOutBitStream bitstream, AuthorityTransfer data)
		{
			bitstream.WriteIntegerRange(data.participant, 15, -9999);
		}
	
		public void TransferAction(IOutBitStream bitstream, TransferAction data)
		{
			bitstream.WriteIntegerRange(data.participant, 15, -9999);
			bitstream.WriteBool(data.accepted);
		}
		/// ------------------------ Requests --------------------------
		
		public void AuthorityTransferRequest(IOutBitStream bitstream, AuthorityTransferRequest data)
		{
			bitstream.WriteIntegerRange(data.participant, 15, -9999);
		}
	}
}

// ------------------ end of MessageSerializers.cs -----------------
#endregion
