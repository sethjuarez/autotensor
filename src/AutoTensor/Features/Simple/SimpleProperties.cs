using System;
using System.Linq;
using System.Collections.Generic;

namespace AutoTensor.Features.Simple
{
	public class SbyteProperty : Property<sbyte>
	{
		public SbyteProperty() : base() { }
		public SbyteProperty(string name) : base(name) { }

        public override sbyte ToSource(IEnumerable<float> values) 
			=> (sbyte)values.First();

        public override IEnumerable<float> ToValue(sbyte source)
        {
            yield return (float)source;
        }
	}

	public class ByteProperty : Property<byte>
	{
		public ByteProperty() : base() { }
		public ByteProperty(string name) : base(name) { }

        public override byte ToSource(IEnumerable<float> values) 
			=> (byte)values.First();

        public override IEnumerable<float> ToValue(byte source)
        {
            yield return (float)source;
        }
	}

	public class ShortProperty : Property<short>
	{
		public ShortProperty() : base() { }
		public ShortProperty(string name) : base(name) { }

        public override short ToSource(IEnumerable<float> values) 
			=> (short)values.First();

        public override IEnumerable<float> ToValue(short source)
        {
            yield return (float)source;
        }
	}

	public class UshortProperty : Property<ushort>
	{
		public UshortProperty() : base() { }
		public UshortProperty(string name) : base(name) { }

        public override ushort ToSource(IEnumerable<float> values) 
			=> (ushort)values.First();

        public override IEnumerable<float> ToValue(ushort source)
        {
            yield return (float)source;
        }
	}

	public class IntProperty : Property<int>
	{
		public IntProperty() : base() { }
		public IntProperty(string name) : base(name) { }

        public override int ToSource(IEnumerable<float> values) 
			=> (int)values.First();

        public override IEnumerable<float> ToValue(int source)
        {
            yield return (float)source;
        }
	}

	public class UintProperty : Property<uint>
	{
		public UintProperty() : base() { }
		public UintProperty(string name) : base(name) { }

        public override uint ToSource(IEnumerable<float> values) 
			=> (uint)values.First();

        public override IEnumerable<float> ToValue(uint source)
        {
            yield return (float)source;
        }
	}

	public class LongProperty : Property<long>
	{
		public LongProperty() : base() { }
		public LongProperty(string name) : base(name) { }

        public override long ToSource(IEnumerable<float> values) 
			=> (long)values.First();

        public override IEnumerable<float> ToValue(long source)
        {
            yield return (float)source;
        }
	}

	public class CharProperty : Property<char>
	{
		public CharProperty() : base() { }
		public CharProperty(string name) : base(name) { }

        public override char ToSource(IEnumerable<float> values) 
			=> (char)values.First();

        public override IEnumerable<float> ToValue(char source)
        {
            yield return (float)source;
        }
	}

	public class FloatProperty : Property<float>
	{
		public FloatProperty() : base() { }
		public FloatProperty(string name) : base(name) { }

        public override float ToSource(IEnumerable<float> values) 
			=> (float)values.First();

        public override IEnumerable<float> ToValue(float source)
        {
            yield return (float)source;
        }
	}

	public class UlongProperty : Property<ulong>
	{
		public UlongProperty() : base() { }
		public UlongProperty(string name) : base(name) { }

        public override ulong ToSource(IEnumerable<float> values) 
			=> (ulong)values.First();

        public override IEnumerable<float> ToValue(ulong source)
        {
            yield return (float)source;
        }
	}

	public class DoubleProperty : Property<double>
	{
		public DoubleProperty() : base() { }
		public DoubleProperty(string name) : base(name) { }

        public override double ToSource(IEnumerable<float> values) 
			=> (double)values.First();

        public override IEnumerable<float> ToValue(double source)
        {
            yield return (float)source;
        }
	}

}
  