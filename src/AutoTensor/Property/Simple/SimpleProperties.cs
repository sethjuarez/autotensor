using System;
using System.Linq;
using System.Collections.Generic;

namespace AutoTensor.Property.Simple
{
	public class SbyteProperty : BaseProperty<sbyte>
	{ 
        public override sbyte ToSource(IEnumerable<float> values) 
			=> (sbyte)values.First();

        public override IEnumerable<float> ToValue(sbyte source)
        {
            yield return (float)source;
        }
	}

	public class ByteProperty : BaseProperty<byte>
	{ 
        public override byte ToSource(IEnumerable<float> values) 
			=> (byte)values.First();

        public override IEnumerable<float> ToValue(byte source)
        {
            yield return (float)source;
        }
	}

	public class ShortProperty : BaseProperty<short>
	{ 
        public override short ToSource(IEnumerable<float> values) 
			=> (short)values.First();

        public override IEnumerable<float> ToValue(short source)
        {
            yield return (float)source;
        }
	}

	public class UshortProperty : BaseProperty<ushort>
	{ 
        public override ushort ToSource(IEnumerable<float> values) 
			=> (ushort)values.First();

        public override IEnumerable<float> ToValue(ushort source)
        {
            yield return (float)source;
        }
	}

	public class IntProperty : BaseProperty<int>
	{ 
        public override int ToSource(IEnumerable<float> values) 
			=> (int)values.First();

        public override IEnumerable<float> ToValue(int source)
        {
            yield return (float)source;
        }
	}

	public class UintProperty : BaseProperty<uint>
	{ 
        public override uint ToSource(IEnumerable<float> values) 
			=> (uint)values.First();

        public override IEnumerable<float> ToValue(uint source)
        {
            yield return (float)source;
        }
	}

	public class LongProperty : BaseProperty<long>
	{ 
        public override long ToSource(IEnumerable<float> values) 
			=> (long)values.First();

        public override IEnumerable<float> ToValue(long source)
        {
            yield return (float)source;
        }
	}

	public class CharProperty : BaseProperty<char>
	{ 
        public override char ToSource(IEnumerable<float> values) 
			=> (char)values.First();

        public override IEnumerable<float> ToValue(char source)
        {
            yield return (float)source;
        }
	}

	public class FloatProperty : BaseProperty<float>
	{ 
        public override float ToSource(IEnumerable<float> values) 
			=> (float)values.First();

        public override IEnumerable<float> ToValue(float source)
        {
            yield return (float)source;
        }
	}

	public class UlongProperty : BaseProperty<ulong>
	{ 
        public override ulong ToSource(IEnumerable<float> values) 
			=> (ulong)values.First();

        public override IEnumerable<float> ToValue(ulong source)
        {
            yield return (float)source;
        }
	}

}
  