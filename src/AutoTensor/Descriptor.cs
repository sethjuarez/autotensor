using System;
using System.Reflection;
using AutoTensor.Features;
using System.Linq.Expressions;
using static AutoTensor.Ject;
using System.Collections.Generic;
using System.Linq;

namespace AutoTensor
{
    /// <summary>
    /// Descriptor describes the type that will be converted
    /// into a tensor. The source type being T
    /// </summary>
    /// <typeparam name="T">Source type to convert</typeparam>
    public partial class Descriptor<T>
    {
        public string Name { get; set; }
        public IProperty[] Features { get; set; }
        public IProperty[] Labels { get; set; }

        public IEnumerable<float> Convert(T item)
        {
            for(int i = 0; i < Features.Length; i++)
            {
                var feature = (Property<object>)Features[i];



                if (feature.Position < 0)
                    feature.Position = i == 0 ? 0 : Features[i - 1].Position + Features[i - 1].Length;
            }

            throw new NotImplementedException();
        }

        public IEnumerable<IEnumerable<float>> Convert(IEnumerable<T> items)
        {
            foreach (var item in items)
                yield return Convert(item);
        }
    }
}
