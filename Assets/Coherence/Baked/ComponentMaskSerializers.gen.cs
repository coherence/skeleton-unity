


#region ComponentMaskSerializers
// -----------------------------------
//  ComponentMaskSerializers.cs
// -----------------------------------
			
namespace Coherence.Generated.Internal
{
	using global::Coherence.Generated;
	using Replication.Unity;
	using Unity.Transforms;


	public class UnityWriters
	{
        private CoherenceToUnityConverters coherenceToUnityConverters;

        public UnityWriters(UnityMapper mapper)
        {
            coherenceToUnityConverters = new CoherenceToUnityConverters(mapper);
        }

		
		
		public void Write(in Translation data, uint propertyMask, Coherence.Replication.Protocol.Definition.IOutBitStream bitstream)
		{
	
			if (bitstream.WriteMask((propertyMask & 0x01) != 0))
			{
				
					var v = coherenceToUnityConverters.FromUnityfloat3(data.Value);
					bitstream.WriteVector3f(v, 24, 2400);
				
			}
			propertyMask >>= 1;
	
	     }

		
		
		public void Write(in Rotation data, uint propertyMask, Coherence.Replication.Protocol.Definition.IOutBitStream bitstream)
		{
	
			if (bitstream.WriteMask((propertyMask & 0x01) != 0))
			{
				
					var v = coherenceToUnityConverters.FromUnityquaternion(data.Value);
					bitstream.WriteUnitRotation(v);
				
			}
			propertyMask >>= 1;
	
	     }

		
		
		public void Write(in LocalUser data, uint propertyMask, Coherence.Replication.Protocol.Definition.IOutBitStream bitstream)
		{
	
			if (bitstream.WriteMask((propertyMask & 0x01) != 0))
			{
				
					bitstream.WriteIntegerRange(data.localIndex, 15, -9999);
				
			}
			propertyMask >>= 1;
	
	     }

		
		
		public void Write(in WorldPositionQuery data, uint propertyMask, Coherence.Replication.Protocol.Definition.IOutBitStream bitstream)
		{
	
			if (bitstream.WriteMask((propertyMask & 0x01) != 0))
			{
				
					var v = coherenceToUnityConverters.FromUnityfloat3(data.position);
					bitstream.WriteVector3f(v, 24, 2400);
				
			}
			propertyMask >>= 1;
	
			if (bitstream.WriteMask((propertyMask & 0x01) != 0))
			{
				
					var v = coherenceToUnityConverters.FromUnityfloat(data.radius);
					bitstream.WriteFixedPoint(v, 24, 2400);
				
			}
			propertyMask >>= 1;
	
	     }

		
		
		public void Write(in ArchetypeComponent data, uint propertyMask, Coherence.Replication.Protocol.Definition.IOutBitStream bitstream)
		{
	
			if (bitstream.WriteMask((propertyMask & 0x01) != 0))
			{
				
					bitstream.WriteIntegerRange(data.index, 15, -9999);
				
			}
			propertyMask >>= 1;
	
	     }

		
		
		public void Write(in Persistence data, uint propertyMask, Coherence.Replication.Protocol.Definition.IOutBitStream bitstream)
		{
	
			if (bitstream.WriteMask((propertyMask & 0x01) != 0))
			{
				
					var v = coherenceToUnityConverters.FromUnityFixedString64(data.uuid);
					bitstream.WriteShortString(v);
				
			}
			propertyMask >>= 1;
	
			if (bitstream.WriteMask((propertyMask & 0x01) != 0))
			{
				
					var v = coherenceToUnityConverters.FromUnityFixedString64(data.expiry);
					bitstream.WriteShortString(v);
				
			}
			propertyMask >>= 1;
	
	     }

		
		
		public void Write(in ConnectedEntity data, uint propertyMask, Coherence.Replication.Protocol.Definition.IOutBitStream bitstream)
		{
	
			if (bitstream.WriteMask((propertyMask & 0x01) != 0))
			{
				
					bitstream.WriteEntity(data.value);
				
			}
			propertyMask >>= 1;
	
	     }

		
		
		public void Write(in Player data, uint propertyMask, Coherence.Replication.Protocol.Definition.IOutBitStream bitstream)
		{
	
	     }

		
	}
}

// ------------------ end of ComponentMaskSerializers.cs -----------------
#endregion
