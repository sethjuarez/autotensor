using AutoTensor.Features.Simple;
using AutoTensor.Tests.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AutoTensor.Tests
{
    public class DescriptorTests
    {
        public IEnumerable<object> GetObjects()
        {
            for(int i = 0; i < 5; i++)
            {
                yield return new { A = (long)1, B = (short)1, C = 'A' };
            }
        }

        [Fact]
        public void Test_Generic_Descriptor_Creation()
        {
            var d = Descriptor.Create("General")
                                .With<long>("A")
                                .With<short>("B")
                                .With<char>("C");

            Assert.Equal(3, d.Features.Length);
            Assert.Equal(typeof(LongProperty), d.Features[0].GetType());
            Assert.Equal(typeof(ShortProperty), d.Features[1].GetType());
            Assert.Equal(typeof(CharProperty), d.Features[2].GetType());
        }

        [Fact]
        public void Test_Descriptor_Creation()
        {
            var d = Descriptor.For<Fake>()
                                .With(f => f.A)
                                .With(f => f.B)
                                .With(f => f.C);

            Assert.Equal(3, d.Features.Length);
            Assert.Equal(typeof(LongProperty), d.Features[0].GetType());
            Assert.Equal(typeof(ShortProperty), d.Features[1].GetType());
            Assert.Equal(typeof(CharProperty), d.Features[2].GetType());
        }
    }
}
