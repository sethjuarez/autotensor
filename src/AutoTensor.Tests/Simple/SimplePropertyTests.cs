using Xunit;
using System;
using System.Linq;
using AutoTensor.Features.Simple;
using System.Collections.Generic;

namespace AutoTensor.Tests.Simple
{
	public class SbytePropertyTests 
	{ 
        [Fact]
        public void Convert_To_Target_Test()
        {
            var property = new SbyteProperty();
            for(int i = 0; i < 128; i++)
            {
                var o = property.ToValue((sbyte)i);
                Assert.Equal(1, o.Count());
                Assert.Equal((float)i, o.First());
            }
        }

        [Fact]
        public void Convert_To_Source_Test()
        {
            var property = new SbyteProperty();
            for (int i = 0; i < 255; i++)
            {
                IEnumerable<float> val = new[] { (float)i };
                var o = property.ToSource(val);
                Assert.Equal((sbyte)i, o);
            }
        }

        [Fact]
        public void Length_Test()
        {
            var property = new SbyteProperty();
            Assert.Equal(1, property.Length);
        }

        [Fact] 
        public void Name_Test()
        {
            string name = "name";
            var property = new SbyteProperty(name);
            var cols = property.GetColumns();
            Assert.Equal(1, cols.Count());
            Assert.Equal(name, cols.First());
        }

        [Fact]
        public void Position_Test()
        {
            int pos = 1;
            var property = new SbyteProperty() { Position = pos };
            Assert.Equal(pos, property.Position);
        }

        [Fact]
        public void Type_Test()
        {
            Type type = typeof(sbyte);
            var property = new SbyteProperty();
            Assert.Equal(type, property.Type);
        }

        [Fact]
        public void Process_Test()
        {
            var property = new SbyteProperty();
            IEnumerable<sbyte> values = new sbyte[] 
			{ 
				(sbyte)1, 
				(sbyte)2, 
				(sbyte)3, 
				(sbyte)4 
			};
            property.PreProcess(values);
            property.PreProcess(values.First());

            property.PostProcess(values.First());
            property.PostProcess(values);
        }
    }

	public class BytePropertyTests 
	{ 
        [Fact]
        public void Convert_To_Target_Test()
        {
            var property = new ByteProperty();
            for(int i = 0; i < 128; i++)
            {
                var o = property.ToValue((byte)i);
                Assert.Equal(1, o.Count());
                Assert.Equal((float)i, o.First());
            }
        }

        [Fact]
        public void Convert_To_Source_Test()
        {
            var property = new ByteProperty();
            for (int i = 0; i < 255; i++)
            {
                IEnumerable<float> val = new[] { (float)i };
                var o = property.ToSource(val);
                Assert.Equal((byte)i, o);
            }
        }

        [Fact]
        public void Length_Test()
        {
            var property = new ByteProperty();
            Assert.Equal(1, property.Length);
        }

        [Fact] 
        public void Name_Test()
        {
            string name = "name";
            var property = new ByteProperty(name);
            var cols = property.GetColumns();
            Assert.Equal(1, cols.Count());
            Assert.Equal(name, cols.First());
        }

        [Fact]
        public void Position_Test()
        {
            int pos = 1;
            var property = new ByteProperty() { Position = pos };
            Assert.Equal(pos, property.Position);
        }

        [Fact]
        public void Type_Test()
        {
            Type type = typeof(byte);
            var property = new ByteProperty();
            Assert.Equal(type, property.Type);
        }

        [Fact]
        public void Process_Test()
        {
            var property = new ByteProperty();
            IEnumerable<byte> values = new byte[] 
			{ 
				(byte)1, 
				(byte)2, 
				(byte)3, 
				(byte)4 
			};
            property.PreProcess(values);
            property.PreProcess(values.First());

            property.PostProcess(values.First());
            property.PostProcess(values);
        }
    }

	public class ShortPropertyTests 
	{ 
        [Fact]
        public void Convert_To_Target_Test()
        {
            var property = new ShortProperty();
            for(int i = 0; i < 128; i++)
            {
                var o = property.ToValue((short)i);
                Assert.Equal(1, o.Count());
                Assert.Equal((float)i, o.First());
            }
        }

        [Fact]
        public void Convert_To_Source_Test()
        {
            var property = new ShortProperty();
            for (int i = 0; i < 255; i++)
            {
                IEnumerable<float> val = new[] { (float)i };
                var o = property.ToSource(val);
                Assert.Equal((short)i, o);
            }
        }

        [Fact]
        public void Length_Test()
        {
            var property = new ShortProperty();
            Assert.Equal(1, property.Length);
        }

        [Fact] 
        public void Name_Test()
        {
            string name = "name";
            var property = new ShortProperty(name);
            var cols = property.GetColumns();
            Assert.Equal(1, cols.Count());
            Assert.Equal(name, cols.First());
        }

        [Fact]
        public void Position_Test()
        {
            int pos = 1;
            var property = new ShortProperty() { Position = pos };
            Assert.Equal(pos, property.Position);
        }

        [Fact]
        public void Type_Test()
        {
            Type type = typeof(short);
            var property = new ShortProperty();
            Assert.Equal(type, property.Type);
        }

        [Fact]
        public void Process_Test()
        {
            var property = new ShortProperty();
            IEnumerable<short> values = new short[] 
			{ 
				(short)1, 
				(short)2, 
				(short)3, 
				(short)4 
			};
            property.PreProcess(values);
            property.PreProcess(values.First());

            property.PostProcess(values.First());
            property.PostProcess(values);
        }
    }

	public class UshortPropertyTests 
	{ 
        [Fact]
        public void Convert_To_Target_Test()
        {
            var property = new UshortProperty();
            for(int i = 0; i < 128; i++)
            {
                var o = property.ToValue((ushort)i);
                Assert.Equal(1, o.Count());
                Assert.Equal((float)i, o.First());
            }
        }

        [Fact]
        public void Convert_To_Source_Test()
        {
            var property = new UshortProperty();
            for (int i = 0; i < 255; i++)
            {
                IEnumerable<float> val = new[] { (float)i };
                var o = property.ToSource(val);
                Assert.Equal((ushort)i, o);
            }
        }

        [Fact]
        public void Length_Test()
        {
            var property = new UshortProperty();
            Assert.Equal(1, property.Length);
        }

        [Fact] 
        public void Name_Test()
        {
            string name = "name";
            var property = new UshortProperty(name);
            var cols = property.GetColumns();
            Assert.Equal(1, cols.Count());
            Assert.Equal(name, cols.First());
        }

        [Fact]
        public void Position_Test()
        {
            int pos = 1;
            var property = new UshortProperty() { Position = pos };
            Assert.Equal(pos, property.Position);
        }

        [Fact]
        public void Type_Test()
        {
            Type type = typeof(ushort);
            var property = new UshortProperty();
            Assert.Equal(type, property.Type);
        }

        [Fact]
        public void Process_Test()
        {
            var property = new UshortProperty();
            IEnumerable<ushort> values = new ushort[] 
			{ 
				(ushort)1, 
				(ushort)2, 
				(ushort)3, 
				(ushort)4 
			};
            property.PreProcess(values);
            property.PreProcess(values.First());

            property.PostProcess(values.First());
            property.PostProcess(values);
        }
    }

	public class IntPropertyTests 
	{ 
        [Fact]
        public void Convert_To_Target_Test()
        {
            var property = new IntProperty();
            for(int i = 0; i < 128; i++)
            {
                var o = property.ToValue((int)i);
                Assert.Equal(1, o.Count());
                Assert.Equal((float)i, o.First());
            }
        }

        [Fact]
        public void Convert_To_Source_Test()
        {
            var property = new IntProperty();
            for (int i = 0; i < 255; i++)
            {
                IEnumerable<float> val = new[] { (float)i };
                var o = property.ToSource(val);
                Assert.Equal((int)i, o);
            }
        }

        [Fact]
        public void Length_Test()
        {
            var property = new IntProperty();
            Assert.Equal(1, property.Length);
        }

        [Fact] 
        public void Name_Test()
        {
            string name = "name";
            var property = new IntProperty(name);
            var cols = property.GetColumns();
            Assert.Equal(1, cols.Count());
            Assert.Equal(name, cols.First());
        }

        [Fact]
        public void Position_Test()
        {
            int pos = 1;
            var property = new IntProperty() { Position = pos };
            Assert.Equal(pos, property.Position);
        }

        [Fact]
        public void Type_Test()
        {
            Type type = typeof(int);
            var property = new IntProperty();
            Assert.Equal(type, property.Type);
        }

        [Fact]
        public void Process_Test()
        {
            var property = new IntProperty();
            IEnumerable<int> values = new int[] 
			{ 
				(int)1, 
				(int)2, 
				(int)3, 
				(int)4 
			};
            property.PreProcess(values);
            property.PreProcess(values.First());

            property.PostProcess(values.First());
            property.PostProcess(values);
        }
    }

	public class UintPropertyTests 
	{ 
        [Fact]
        public void Convert_To_Target_Test()
        {
            var property = new UintProperty();
            for(int i = 0; i < 128; i++)
            {
                var o = property.ToValue((uint)i);
                Assert.Equal(1, o.Count());
                Assert.Equal((float)i, o.First());
            }
        }

        [Fact]
        public void Convert_To_Source_Test()
        {
            var property = new UintProperty();
            for (int i = 0; i < 255; i++)
            {
                IEnumerable<float> val = new[] { (float)i };
                var o = property.ToSource(val);
                Assert.Equal((uint)i, o);
            }
        }

        [Fact]
        public void Length_Test()
        {
            var property = new UintProperty();
            Assert.Equal(1, property.Length);
        }

        [Fact] 
        public void Name_Test()
        {
            string name = "name";
            var property = new UintProperty(name);
            var cols = property.GetColumns();
            Assert.Equal(1, cols.Count());
            Assert.Equal(name, cols.First());
        }

        [Fact]
        public void Position_Test()
        {
            int pos = 1;
            var property = new UintProperty() { Position = pos };
            Assert.Equal(pos, property.Position);
        }

        [Fact]
        public void Type_Test()
        {
            Type type = typeof(uint);
            var property = new UintProperty();
            Assert.Equal(type, property.Type);
        }

        [Fact]
        public void Process_Test()
        {
            var property = new UintProperty();
            IEnumerable<uint> values = new uint[] 
			{ 
				(uint)1, 
				(uint)2, 
				(uint)3, 
				(uint)4 
			};
            property.PreProcess(values);
            property.PreProcess(values.First());

            property.PostProcess(values.First());
            property.PostProcess(values);
        }
    }

	public class LongPropertyTests 
	{ 
        [Fact]
        public void Convert_To_Target_Test()
        {
            var property = new LongProperty();
            for(int i = 0; i < 128; i++)
            {
                var o = property.ToValue((long)i);
                Assert.Equal(1, o.Count());
                Assert.Equal((float)i, o.First());
            }
        }

        [Fact]
        public void Convert_To_Source_Test()
        {
            var property = new LongProperty();
            for (int i = 0; i < 255; i++)
            {
                IEnumerable<float> val = new[] { (float)i };
                var o = property.ToSource(val);
                Assert.Equal((long)i, o);
            }
        }

        [Fact]
        public void Length_Test()
        {
            var property = new LongProperty();
            Assert.Equal(1, property.Length);
        }

        [Fact] 
        public void Name_Test()
        {
            string name = "name";
            var property = new LongProperty(name);
            var cols = property.GetColumns();
            Assert.Equal(1, cols.Count());
            Assert.Equal(name, cols.First());
        }

        [Fact]
        public void Position_Test()
        {
            int pos = 1;
            var property = new LongProperty() { Position = pos };
            Assert.Equal(pos, property.Position);
        }

        [Fact]
        public void Type_Test()
        {
            Type type = typeof(long);
            var property = new LongProperty();
            Assert.Equal(type, property.Type);
        }

        [Fact]
        public void Process_Test()
        {
            var property = new LongProperty();
            IEnumerable<long> values = new long[] 
			{ 
				(long)1, 
				(long)2, 
				(long)3, 
				(long)4 
			};
            property.PreProcess(values);
            property.PreProcess(values.First());

            property.PostProcess(values.First());
            property.PostProcess(values);
        }
    }

	public class CharPropertyTests 
	{ 
        [Fact]
        public void Convert_To_Target_Test()
        {
            var property = new CharProperty();
            for(int i = 0; i < 128; i++)
            {
                var o = property.ToValue((char)i);
                Assert.Equal(1, o.Count());
                Assert.Equal((float)i, o.First());
            }
        }

        [Fact]
        public void Convert_To_Source_Test()
        {
            var property = new CharProperty();
            for (int i = 0; i < 255; i++)
            {
                IEnumerable<float> val = new[] { (float)i };
                var o = property.ToSource(val);
                Assert.Equal((char)i, o);
            }
        }

        [Fact]
        public void Length_Test()
        {
            var property = new CharProperty();
            Assert.Equal(1, property.Length);
        }

        [Fact] 
        public void Name_Test()
        {
            string name = "name";
            var property = new CharProperty(name);
            var cols = property.GetColumns();
            Assert.Equal(1, cols.Count());
            Assert.Equal(name, cols.First());
        }

        [Fact]
        public void Position_Test()
        {
            int pos = 1;
            var property = new CharProperty() { Position = pos };
            Assert.Equal(pos, property.Position);
        }

        [Fact]
        public void Type_Test()
        {
            Type type = typeof(char);
            var property = new CharProperty();
            Assert.Equal(type, property.Type);
        }

        [Fact]
        public void Process_Test()
        {
            var property = new CharProperty();
            IEnumerable<char> values = new char[] 
			{ 
				(char)1, 
				(char)2, 
				(char)3, 
				(char)4 
			};
            property.PreProcess(values);
            property.PreProcess(values.First());

            property.PostProcess(values.First());
            property.PostProcess(values);
        }
    }

	public class FloatPropertyTests 
	{ 
        [Fact]
        public void Convert_To_Target_Test()
        {
            var property = new FloatProperty();
            for(int i = 0; i < 128; i++)
            {
                var o = property.ToValue((float)i);
                Assert.Equal(1, o.Count());
                Assert.Equal((float)i, o.First());
            }
        }

        [Fact]
        public void Convert_To_Source_Test()
        {
            var property = new FloatProperty();
            for (int i = 0; i < 255; i++)
            {
                IEnumerable<float> val = new[] { (float)i };
                var o = property.ToSource(val);
                Assert.Equal((float)i, o);
            }
        }

        [Fact]
        public void Length_Test()
        {
            var property = new FloatProperty();
            Assert.Equal(1, property.Length);
        }

        [Fact] 
        public void Name_Test()
        {
            string name = "name";
            var property = new FloatProperty(name);
            var cols = property.GetColumns();
            Assert.Equal(1, cols.Count());
            Assert.Equal(name, cols.First());
        }

        [Fact]
        public void Position_Test()
        {
            int pos = 1;
            var property = new FloatProperty() { Position = pos };
            Assert.Equal(pos, property.Position);
        }

        [Fact]
        public void Type_Test()
        {
            Type type = typeof(float);
            var property = new FloatProperty();
            Assert.Equal(type, property.Type);
        }

        [Fact]
        public void Process_Test()
        {
            var property = new FloatProperty();
            IEnumerable<float> values = new float[] 
			{ 
				(float)1, 
				(float)2, 
				(float)3, 
				(float)4 
			};
            property.PreProcess(values);
            property.PreProcess(values.First());

            property.PostProcess(values.First());
            property.PostProcess(values);
        }
    }

	public class UlongPropertyTests 
	{ 
        [Fact]
        public void Convert_To_Target_Test()
        {
            var property = new UlongProperty();
            for(int i = 0; i < 128; i++)
            {
                var o = property.ToValue((ulong)i);
                Assert.Equal(1, o.Count());
                Assert.Equal((float)i, o.First());
            }
        }

        [Fact]
        public void Convert_To_Source_Test()
        {
            var property = new UlongProperty();
            for (int i = 0; i < 255; i++)
            {
                IEnumerable<float> val = new[] { (float)i };
                var o = property.ToSource(val);
                Assert.Equal((ulong)i, o);
            }
        }

        [Fact]
        public void Length_Test()
        {
            var property = new UlongProperty();
            Assert.Equal(1, property.Length);
        }

        [Fact] 
        public void Name_Test()
        {
            string name = "name";
            var property = new UlongProperty(name);
            var cols = property.GetColumns();
            Assert.Equal(1, cols.Count());
            Assert.Equal(name, cols.First());
        }

        [Fact]
        public void Position_Test()
        {
            int pos = 1;
            var property = new UlongProperty() { Position = pos };
            Assert.Equal(pos, property.Position);
        }

        [Fact]
        public void Type_Test()
        {
            Type type = typeof(ulong);
            var property = new UlongProperty();
            Assert.Equal(type, property.Type);
        }

        [Fact]
        public void Process_Test()
        {
            var property = new UlongProperty();
            IEnumerable<ulong> values = new ulong[] 
			{ 
				(ulong)1, 
				(ulong)2, 
				(ulong)3, 
				(ulong)4 
			};
            property.PreProcess(values);
            property.PreProcess(values.First());

            property.PostProcess(values.First());
            property.PostProcess(values);
        }
    }

	public class DoublePropertyTests 
	{ 
        [Fact]
        public void Convert_To_Target_Test()
        {
            var property = new DoubleProperty();
            for(int i = 0; i < 128; i++)
            {
                var o = property.ToValue((double)i);
                Assert.Equal(1, o.Count());
                Assert.Equal((float)i, o.First());
            }
        }

        [Fact]
        public void Convert_To_Source_Test()
        {
            var property = new DoubleProperty();
            for (int i = 0; i < 255; i++)
            {
                IEnumerable<float> val = new[] { (float)i };
                var o = property.ToSource(val);
                Assert.Equal((double)i, o);
            }
        }

        [Fact]
        public void Length_Test()
        {
            var property = new DoubleProperty();
            Assert.Equal(1, property.Length);
        }

        [Fact] 
        public void Name_Test()
        {
            string name = "name";
            var property = new DoubleProperty(name);
            var cols = property.GetColumns();
            Assert.Equal(1, cols.Count());
            Assert.Equal(name, cols.First());
        }

        [Fact]
        public void Position_Test()
        {
            int pos = 1;
            var property = new DoubleProperty() { Position = pos };
            Assert.Equal(pos, property.Position);
        }

        [Fact]
        public void Type_Test()
        {
            Type type = typeof(double);
            var property = new DoubleProperty();
            Assert.Equal(type, property.Type);
        }

        [Fact]
        public void Process_Test()
        {
            var property = new DoubleProperty();
            IEnumerable<double> values = new double[] 
			{ 
				(double)1, 
				(double)2, 
				(double)3, 
				(double)4 
			};
            property.PreProcess(values);
            property.PreProcess(values.First());

            property.PostProcess(values.First());
            property.PostProcess(values);
        }
    }

}
  