using AutoTensor.Features;
using AutoTensor.Features.Simple;
using static AutoTensor.Ject;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoTensor.Features.Complex;
using AutoTensor.Tests.Data;

namespace AutoTensor.Tests
{
    public class FakeProperty1 : Property<Fake>
    {
        public override Fake ToSource(IEnumerable<float> values)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<float> ToValue(Fake source)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeProperty2 : Property<Fake>
    {
        public override Fake ToSource(IEnumerable<float> values)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<float> ToValue(Fake source)
        {
            throw new NotImplementedException();
        }
    }

    public class Nonsense { }

    public class JectTests
    {
        [Fact]
        public void Simple_FindProperty_Tests()
        {
            Dictionary<Type, Type> mappings = new Dictionary<Type, Type>
            {
                { typeof(sbyte), typeof(SbyteProperty) },
                { typeof(byte), typeof(ByteProperty) },
		        { typeof(short), typeof(ShortProperty) },
		        { typeof(ushort), typeof(UshortProperty) },
		        { typeof(int), typeof(IntProperty) },
		        { typeof(uint), typeof(UintProperty) },
		        { typeof(long), typeof(LongProperty) },
		        { typeof(char), typeof(CharProperty) },
		        { typeof(float), typeof(FloatProperty) },
		        { typeof(ulong), typeof(UlongProperty) },
                { typeof(DateTime), typeof(DateTimeProperty) },
            };
            
            foreach (var type in mappings)
            {
                var property = FindPropertyConverterType(type.Key);
                Assert.Equal(type.Value, property);
            }
        }

        [Fact]
        public void Found_No_Many_Mappings_Test()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(
                () => FindPropertyConverterType(typeof(Nonsense)));
        }

        [Fact]
        public void Found_Too_Many_Mappings_Test()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(
                () => FindPropertyConverterType(typeof(Fake)));
        }
    }
}
