using AutoTensor.Features;
using AutoTensor.Features.Simple;
using static AutoTensor.Ject;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoTensor.Features.Complex;

namespace AutoTensor.Tests
{
    public class TypeHelperTests
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
                var property = FindProperty(type.Key);
                Assert.Equal(type.Value, property.GetType());
            }
        }
    }
}
