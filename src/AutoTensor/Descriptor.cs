using System;
using AutoTensor.Features;
using System.Linq.Expressions;
using static AutoTensor.TypeHelpers;
using System.Collections.Generic;

namespace AutoTensor
{
    /// <summary>
    /// Descriptor describes the type that will be converted
    /// into a tensor. The source type being T
    /// </summary>
    /// <typeparam name="T">Source type to convert</typeparam>
    public class Descriptor<T>
    {
        public string Name { get; set; }
        public IProperty[] Features { get; set; }
        public IProperty Label { get; set; }

        public Descriptor<T> With<S>(string name)
        {
            return With(typeof(S), name);
        }

        public Descriptor<T> With<S>(Expression<Func<T, S>> property)
        {
            var pi = GetPropertyInfo(property);
            return With(pi.PropertyType, pi.Name);
        }

        public Descriptor<T> With(Type type, string name)
        {
            var properties = new List<IProperty>(Features ?? new IProperty[] { });
            var newProp = FindProperty(type);
            newProp.Name = name;
            properties.Add(newProp);
            Features = properties.ToArray();
            return this;
        }
    }


    public class Descriptor
    {
        public static Descriptor<object> Create(string name = "")
        {
            return new Descriptor<object>() { Name = name };
        }
        public static Descriptor<T> For<T>()
        {
            return new Descriptor<T>() { Name = typeof(T).Name };
        }
    }
}
