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
    }
}
