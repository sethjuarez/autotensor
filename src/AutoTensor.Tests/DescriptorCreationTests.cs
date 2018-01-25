using AutoTensor.Features.Simple;
using AutoTensor.Tests.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using AutoTensor.Features;
using AutoTensor.Features.Complex;

namespace AutoTensor.Tests
{
    
    public class DescriptorCreationTests
    {
        private bool HasProperty(IProperty[] list, string name, Type propertyType)
        {
            return list
                    .Where(p => p.Name == name && p.GetType() == propertyType)
                    .Count() == 1;
        }

        [Fact]
        public void Weak_Descriptor_Features_Creation_Test()
        {
            var d = Descriptor.Create("General")
                                .With<long>("A")
                                .With<short>("B")
                                .With<char>("C");

            Assert.Equal(3, d.Features.Length);
            Assert.Equal(typeof(LongProperty), d.Features[0].GetType());
            Assert.Equal("A", d.Features[0].Name);
            Assert.Equal(typeof(ShortProperty), d.Features[1].GetType());
            Assert.Equal("B", d.Features[1].Name);
            Assert.Equal(typeof(CharProperty), d.Features[2].GetType());
            Assert.Equal("C", d.Features[2].Name);
        }

        [Fact]
        public void Descriptor_Features_Creation_Test()
        {
            var d = Descriptor.For<Fake>()
                                .With(f => f.A)
                                .With(f => f.B)
                                .With(f => f.C);

            Assert.Equal(3, d.Features.Length);
            Assert.Equal(typeof(LongProperty), d.Features[0].GetType());
            Assert.Equal("A", d.Features[0].Name);
            Assert.Equal(typeof(ShortProperty), d.Features[1].GetType());
            Assert.Equal("B", d.Features[1].Name);
            Assert.Equal(typeof(CharProperty), d.Features[2].GetType());
            Assert.Equal("C", d.Features[2].Name);
        }

        [Fact]
        public void Strong_Descriptor_Features_Creation_Test()
        {
            var d = Descriptor.Create<StronglyDeclaredOnlyFeatures>();

            var items = new Dictionary<string, Type>
            {
                { "A", typeof(SbyteProperty) },
                { "B", typeof(ByteProperty) },
                { "C", typeof(ShortProperty) },
                { "D", typeof(UshortProperty) },
                { "E", typeof(IntProperty) },
                { "F", typeof(UintProperty) },
                { "G", typeof(LongProperty) },
                { "H", typeof(CharProperty) },
                { "I", typeof(FloatProperty) },
                { "J", typeof(UlongProperty) },
            };

            Assert.Equal(items.Count(), d.Features.Length);
            foreach (var item in items)
                Assert.True(HasProperty(d.Features, item.Key, item.Value));

        }

        [Fact]
        public void Strong_Descriptor_Creation_Test()
        {
            var d = Descriptor.Create<StronglyDeclared>();

            var features = new Dictionary<string, Type>
            {
                { "A", typeof(SbyteProperty) },
                { "B", typeof(ByteProperty) },
                { "C", typeof(ShortProperty) },
                { "D", typeof(UshortProperty) },
                { "E", typeof(IntProperty) }
            };
            var labels = new Dictionary<string, Type>
            {
                { "F", typeof(UintProperty) },
                { "G", typeof(LongProperty) },
                { "H", typeof(CharProperty) },
                { "I", typeof(FloatProperty) },
                { "J", typeof(UlongProperty) },
            };

            Assert.Equal(features.Count(), d.Features.Length);
            foreach (var item in features)
                Assert.True(HasProperty(d.Features, item.Key, item.Value));

            Assert.Equal(labels.Count(), d.Labels.Length);
            foreach (var item in labels)
                Assert.True(HasProperty(d.Labels, item.Key, item.Value));

        }

        [Fact]
        public void Strong_Descriptor_Overlap_Creation_Test()
        {
            var d = Descriptor.Create<StronglyDeclaredOverlap>();

            var features = new Dictionary<string, Type>
            {
                { "A", typeof(SbyteProperty) },
                { "B", typeof(ByteProperty) },
                { "C", typeof(ShortProperty) },
                { "D", typeof(UshortProperty) },
                { "E", typeof(IntProperty) }
            };
            var labels = new Dictionary<string, Type>
            {
                { "F", typeof(UintProperty) },
                { "G", typeof(LongProperty) },
                { "H", typeof(CharProperty) },
                { "I", typeof(FloatProperty) },
                { "J", typeof(UlongProperty) },
            };

            Assert.Equal(features.Count(), d.Features.Length);
            foreach (var item in features)
                Assert.True(HasProperty(d.Features, item.Key, item.Value));

            Assert.Equal(labels.Count(), d.Labels.Length);
            foreach (var item in labels)
                Assert.True(HasProperty(d.Labels, item.Key, item.Value));

        }

        [Fact]
        public void Strong_Descriptor_DateTime_Creation_Test()
        {
            var d = Descriptor.Create<StrongDateTime>();


            Assert.Equal(1, d.Features.Length);
            Assert.Equal("A", d.Features[0].Name);
            Assert.Equal(typeof(DateTimeProperty), d.Features[0].GetType());
            Assert.Equal(DateTimeFeature.Year | DateTimeFeature.Month |
                           DateTimeFeature.Day | DateTimeFeature.DayOfYear | 
                           DateTimeFeature.DayOfWeek, 
                            ((DateTimeProperty)d.Features[0]).Features);

            Assert.Equal(1, d.Labels.Length);
            Assert.Equal("B", d.Labels[0].Name);
            Assert.Equal(typeof(DateTimeProperty), d.Labels[0].GetType());
            Assert.Equal(DateTimeFeature.Year | DateTimeFeature.Month |
                           DateTimeFeature.Day | DateTimeFeature.DayOfYear |
                           DateTimeFeature.DayOfWeek,
                            ((DateTimeProperty)d.Labels[0]).Features);

        }

        [Fact]
        public void Strong_Descriptor_DateTime_Custom_Creation_Test()
        {
            var d = Descriptor.Create<StrongDateTimeCustom>();


            Assert.Equal(2, d.Features.Length);
            Assert.Equal("A", d.Features[0].Name);
            Assert.Equal(typeof(DateTimeProperty), d.Features[0].GetType());
            Assert.Equal(DateTimeFeature.DayOfWeek,
                            ((DateTimeProperty)d.Features[0]).Features);

            Assert.Equal("B", d.Features[1].Name);
            Assert.Equal(typeof(DateTimeProperty), d.Features[1].GetType());
            Assert.Equal(DateTimeFeature.Year | DateTimeFeature.Month |
                           DateTimeFeature.Day | DateTimeFeature.DayOfYear |
                           DateTimeFeature.DayOfWeek,
                            ((DateTimeProperty)d.Features[1]).Features);

            Assert.Equal(1, d.Labels.Length);
            Assert.Equal("C", d.Labels[0].Name);
            Assert.Equal(typeof(DateTimeProperty), d.Labels[0].GetType());
            Assert.Equal(DateTimeFeature.Hour | DateTimeFeature.Minute,
                            ((DateTimeProperty)d.Labels[0]).Features);

        }

        [Fact]
        public void Strong_Descriptor_DateTime_Exception_Creation_Test()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(
                () => Descriptor.Create<StrongDateTimeCustomException>());
        }

        [Fact]
        public void Strong_Descriptor_DateTime_Triple_Exception_Creation_Test()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(
                () => Descriptor.Create<StrongDateTimeCustomTripleException>());
        }
    }
}
