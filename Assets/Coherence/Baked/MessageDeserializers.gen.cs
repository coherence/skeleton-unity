


#region MessageDeserializers
// -----------------------------------
//  MessageDeserializers.cs
// -----------------------------------
			
namespace Coherence.Generated.Internal
{
	using Coherence.Replication.Protocol.Definition;
	using global::Coherence.Generated;
	using Unity.Transforms;	
	using Replication.Unity;


public class MessageDeserializers
{
    private CoherenceToUnityConverters coherenceToUnityConverters;

    public MessageDeserializers(UnityMapper mapper)
    {
        coherenceToUnityConverters = new CoherenceToUnityConverters(mapper);
    }


	public void Translation(IInBitStream bitstream, ref Translation data)
	{

			
				var value = bitstream.ReadVector3f(24, 2400);
				data.Value = coherenceToUnityConverters.ToUnityfloat3(value);
			
     
	}

	public void Rotation(IInBitStream bitstream, ref Rotation data)
	{

			
				var value = bitstream.ReadUnitRotation();
				data.Value = coherenceToUnityConverters.ToUnityquaternion(value);
			
     
	}

	public void LocalUser(IInBitStream bitstream, ref LocalUser data)
	{

			
				data.localIndex =  bitstream.ReadIntegerRange(15, -9999);
			
     
	}

	public void WorldPositionQuery(IInBitStream bitstream, ref WorldPositionQuery data)
	{

			
				var position = bitstream.ReadVector3f(24, 2400);
				data.position = coherenceToUnityConverters.ToUnityfloat3(position);
			

			
				var radius = bitstream.ReadFixedPoint(24, 2400);
				data.radius = coherenceToUnityConverters.ToUnityfloat(radius);
			
     
	}

	public void SessionBased(IInBitStream bitstream, ref SessionBased data)
	{
     
	}

	public void Transferable(IInBitStream bitstream, ref Transferable data)
	{

			
				data.participant =  bitstream.ReadIntegerRange(15, -9999);
			
     
	}

	public void ArchetypeComponent(IInBitStream bitstream, ref ArchetypeComponent data)
	{

			
				data.index =  bitstream.ReadIntegerRange(15, -9999);
			
     
	}

	public void Player(IInBitStream bitstream, ref Player data)
	{
     
	}

	public void A(IInBitStream bitstream, ref A data)
	{
     
	}

	public void B(IInBitStream bitstream, ref B data)
	{
     
	}

	public void C(IInBitStream bitstream, ref C data)
	{
     
	}

	public void AuthorityTransfer(IInBitStream bitstream, ref AuthorityTransfer data)
	{

			
				data.participant =  bitstream.ReadIntegerRange(15, -9999);
			
     
	}

	public void TransferAction(IInBitStream bitstream, ref TransferAction data)
	{

			
				data.participant =  bitstream.ReadIntegerRange(15, -9999);
			

			
				data.accepted =  bitstream.ReadBool();
			
     
	}


}

}

// ------------------ end of MessageDeserializers.cs -----------------
#endregion
