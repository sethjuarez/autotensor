using System;
using System.Linq;
using System.Collections.Generic;

namespace AutoTensor.Property.Simple
{
	public class SbyteProperty : IProperty<sbyte, float>
	{ 
	    public string Name { get; set; }

        public Type Type => typeof(sbyte);

        public int Position { get; set; }

        public int Length => 1;

        public IEnumerable<string> GetColumns()
        {
            yield return Name;
        }

        public void PostProcess(IEnumerable<sbyte> items) { }

        public void PostProcess(sbyte item) { }

        public void PreProcess(IEnumerable<sbyte> items) { }

        public void PreProcess(sbyte item) { }

        public sbyte ToSource(IEnumerable<float> values) => (sbyte)values.First();

        public IEnumerable<float> ToValue(sbyte source)
        {
            yield return (float)source;
        }
	}

	public class ByteProperty : IProperty<byte, float>
	{ 
	    public string Name { get; set; }

        public Type Type => typeof(byte);

        public int Position { get; set; }

        public int Length => 1;

        public IEnumerable<string> GetColumns()
        {
            yield return Name;
        }

        public void PostProcess(IEnumerable<byte> items) { }

        public void PostProcess(byte item) { }

        public void PreProcess(IEnumerable<byte> items) { }

        public void PreProcess(byte item) { }

        public byte ToSource(IEnumerable<float> values) => (byte)values.First();

        public IEnumerable<float> ToValue(byte source)
        {
            yield return (float)source;
        }
	}

	public class ShortProperty : IProperty<short, float>
	{ 
	    public string Name { get; set; }

        public Type Type => typeof(short);

        public int Position { get; set; }

        public int Length => 1;

        public IEnumerable<string> GetColumns()
        {
            yield return Name;
        }

        public void PostProcess(IEnumerable<short> items) { }

        public void PostProcess(short item) { }

        public void PreProcess(IEnumerable<short> items) { }

        public void PreProcess(short item) { }

        public short ToSource(IEnumerable<float> values) => (short)values.First();

        public IEnumerable<float> ToValue(short source)
        {
            yield return (float)source;
        }
	}

	public class UshortProperty : IProperty<ushort, float>
	{ 
	    public string Name { get; set; }

        public Type Type => typeof(ushort);

        public int Position { get; set; }

        public int Length => 1;

        public IEnumerable<string> GetColumns()
        {
            yield return Name;
        }

        public void PostProcess(IEnumerable<ushort> items) { }

        public void PostProcess(ushort item) { }

        public void PreProcess(IEnumerable<ushort> items) { }

        public void PreProcess(ushort item) { }

        public ushort ToSource(IEnumerable<float> values) => (ushort)values.First();

        public IEnumerable<float> ToValue(ushort source)
        {
            yield return (float)source;
        }
	}

	public class IntProperty : IProperty<int, float>
	{ 
	    public string Name { get; set; }

        public Type Type => typeof(int);

        public int Position { get; set; }

        public int Length => 1;

        public IEnumerable<string> GetColumns()
        {
            yield return Name;
        }

        public void PostProcess(IEnumerable<int> items) { }

        public void PostProcess(int item) { }

        public void PreProcess(IEnumerable<int> items) { }

        public void PreProcess(int item) { }

        public int ToSource(IEnumerable<float> values) => (int)values.First();

        public IEnumerable<float> ToValue(int source)
        {
            yield return (float)source;
        }
	}

	public class UintProperty : IProperty<uint, float>
	{ 
	    public string Name { get; set; }

        public Type Type => typeof(uint);

        public int Position { get; set; }

        public int Length => 1;

        public IEnumerable<string> GetColumns()
        {
            yield return Name;
        }

        public void PostProcess(IEnumerable<uint> items) { }

        public void PostProcess(uint item) { }

        public void PreProcess(IEnumerable<uint> items) { }

        public void PreProcess(uint item) { }

        public uint ToSource(IEnumerable<float> values) => (uint)values.First();

        public IEnumerable<float> ToValue(uint source)
        {
            yield return (float)source;
        }
	}

	public class LongProperty : IProperty<long, float>
	{ 
	    public string Name { get; set; }

        public Type Type => typeof(long);

        public int Position { get; set; }

        public int Length => 1;

        public IEnumerable<string> GetColumns()
        {
            yield return Name;
        }

        public void PostProcess(IEnumerable<long> items) { }

        public void PostProcess(long item) { }

        public void PreProcess(IEnumerable<long> items) { }

        public void PreProcess(long item) { }

        public long ToSource(IEnumerable<float> values) => (long)values.First();

        public IEnumerable<float> ToValue(long source)
        {
            yield return (float)source;
        }
	}

	public class CharProperty : IProperty<char, float>
	{ 
	    public string Name { get; set; }

        public Type Type => typeof(char);

        public int Position { get; set; }

        public int Length => 1;

        public IEnumerable<string> GetColumns()
        {
            yield return Name;
        }

        public void PostProcess(IEnumerable<char> items) { }

        public void PostProcess(char item) { }

        public void PreProcess(IEnumerable<char> items) { }

        public void PreProcess(char item) { }

        public char ToSource(IEnumerable<float> values) => (char)values.First();

        public IEnumerable<float> ToValue(char source)
        {
            yield return (float)source;
        }
	}

	public class FloatProperty : IProperty<float, float>
	{ 
	    public string Name { get; set; }

        public Type Type => typeof(float);

        public int Position { get; set; }

        public int Length => 1;

        public IEnumerable<string> GetColumns()
        {
            yield return Name;
        }

        public void PostProcess(IEnumerable<float> items) { }

        public void PostProcess(float item) { }

        public void PreProcess(IEnumerable<float> items) { }

        public void PreProcess(float item) { }

        public float ToSource(IEnumerable<float> values) => (float)values.First();

        public IEnumerable<float> ToValue(float source)
        {
            yield return (float)source;
        }
	}

	public class UlongProperty : IProperty<ulong, float>
	{ 
	    public string Name { get; set; }

        public Type Type => typeof(ulong);

        public int Position { get; set; }

        public int Length => 1;

        public IEnumerable<string> GetColumns()
        {
            yield return Name;
        }

        public void PostProcess(IEnumerable<ulong> items) { }

        public void PostProcess(ulong item) { }

        public void PreProcess(IEnumerable<ulong> items) { }

        public void PreProcess(ulong item) { }

        public ulong ToSource(IEnumerable<float> values) => (ulong)values.First();

        public IEnumerable<float> ToValue(ulong source)
        {
            yield return (float)source;
        }
	}

}
  