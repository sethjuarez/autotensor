using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AutoTensor.Tests
{
    public class DescriptorConversionTests
    {
        [Fact]
        public void Weak_Conversion_Test()
        {
            var d = Descriptor.For("General")
                                .With<long>("A")
                                .With<double>("B")
                                .With<char>("C");

            var o = new { A = 1L, B = 23d, C = 'A' };

            d.Convert(o);
        }
    }
}
