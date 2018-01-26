using System;
using System.Reflection;
using AutoTensor.Features;
using System.Linq.Expressions;
using static AutoTensor.Ject;
using System.Collections.Generic;
using System.Linq;

namespace AutoTensor
{
    public class Descriptor
    {
        public static Descriptor<object> Create(string name = "")
        {
            return new Descriptor<object>() { Name = name };
        }

        public static Descriptor<T> Create<T>()
        {
            var d = For<T>();

            // find all features
            List<IProperty> features = new List<IProperty>();
            List<IProperty> labels = new List<IProperty>();
            var t = typeof(T);
            foreach (var pi in t.GetProperties())
            {
                var f = pi.GetCustomAttributes(typeof(FeatureAttribute), false);

                // no attribute? move on!
                if (f.Count() == 0) continue;
                // has a feature attribute
                else if (f.Count() == 1)
                {
                    var feature = f.First() as FeatureAttribute;
                    var property = FindProperty(pi);
                    feature.PopulateProperty(property);

                    // is it a label?
                    if (IsLabel(feature))
                        labels.Add(property);
                    else
                        features.Add(property);
                }
                // has a feature and a label attribute
                else if (f.Count() == 2)
                {
                    var f1 = f.ElementAt(0) as FeatureAttribute;
                    var f2 = f.ElementAt(1) as FeatureAttribute;

                    // both are feature attributes (no, no)
                    if (IsFeature(f1) && IsFeature(f2))
                        throw new InvalidOperationException($"{t.Name}.{pi.Name} has too many feature attributes.");

                    var feature = f1.GetType() == typeof(LabelAttribute) ? f2 : f1;
                    var property = FindProperty(pi);
                    feature.PopulateProperty(property);
                    labels.Add(property);
                }
                else
                    throw new InvalidOperationException($"{t.Name}.{pi.Name} has too many attributes.");
            }

            d.Features = features.ToArray();
            d.Labels = labels.ToArray();

            return d;
        }

        public static Descriptor<T> For<T>()
        {
            return new Descriptor<T>() { Name = typeof(T).Name };
        }

        private static bool IsFeature(FeatureAttribute attr) =>
            (attr.GetType() == typeof(FeatureAttribute) ||
            attr.GetType().IsSubclassOf(typeof(FeatureAttribute)))
            && attr.GetType() != typeof(LabelAttribute);

        private static bool IsLabel(FeatureAttribute attr) =>
            attr.GetType() == typeof(LabelAttribute);
    }
    
    public partial class Descriptor<T>
    {
        public Descriptor<T> With<S>(string name)
        {
            return AddPropertyFor(typeof(S), name);
        }

        public Descriptor<T> With<S, K>(string name)
            where K : Property<S>
        {
            return AddProperty(CreateProperty(name, typeof(K)));
        }

        public Descriptor<T> With<S>(Expression<Func<T, S>> p)
        {
            var pi = GetPropertyInfo(p);
            return AddPropertyFor(pi.PropertyType, pi.Name);
        }

        public Descriptor<T> With<S, K>(Expression<Func<T, S>> p)
            where K : Property<S>
        {
            var pi = GetPropertyInfo(p);
            return AddProperty(CreateProperty(pi.Name, typeof(K)));
        }

        public Descriptor<T> With<S>(Property<S> property)
        {
            if (!IsValidProperty(property))
                throw new InvalidOperationException($"Invalid property name for {nameof(property)}");
            return AddProperty(property);
        }

        public Descriptor<T> With<S>(Expression<Func<T, S>> p, Property<S> property)
        {
            var pi = GetPropertyInfo(p);
            property.Name = pi.Name;
            return AddProperty(property);
        }

        public Descriptor<T> Learn<S>(string name)
        {
            return AddPropertyFor(typeof(S), name, true);
        }

        public Descriptor<T> Learn<S, K>(string name)
            where K : Property<S>
        {
            return AddProperty(CreateProperty(name, typeof(K)), true);
        }

        public Descriptor<T> Learn<S>(Property<S> property)
        {
            if (!IsValidProperty(property))
                throw new InvalidOperationException($"Invalid property name for {nameof(property)}");
            return AddProperty(property, true);
        }

        public Descriptor<T> Learn<S>(Expression<Func<T, S>> p)
        {
            var pi = GetPropertyInfo(p);
            return AddPropertyFor(pi.PropertyType, pi.Name, true);
        }

        public Descriptor<T> Learn<S, K>(Expression<Func<T, S>> p)
            where K : Property<S>
        {
            var pi = GetPropertyInfo(p);
            return AddProperty(CreateProperty(pi.Name, typeof(K)), true);
        }

        public Descriptor<T> Learn<S>(Expression<Func<T, S>> p, Property<S> property)
        {
            var pi = GetPropertyInfo(p);
            property.Name = pi.Name;
            return AddProperty(property, true);
        }

        private bool IsValidProperty(IProperty property) => 
            !string.IsNullOrEmpty(property.Name) &&
            !string.IsNullOrWhiteSpace(property.Name);

        private IProperty CreateProperty(string name, Type converter)
        {
            var p = Activator.CreateInstance(converter) as IProperty;
            p.Name = name;
            return p;
        }

        private Descriptor<T> AddPropertyFor(Type type, string name, bool asLabel = false)
        {
            var property = FindProperty(type);
            property.Name = name;
            return AddProperty(property, asLabel);
        }

        private Descriptor<T> AddProperty(IProperty property, bool asLabel = false)
        {
            var list = asLabel ? Labels : Features;
            var properties = new List<IProperty>(list ?? new IProperty[] { });
            properties.Add(property);
            if (asLabel)
                Labels = properties.ToArray();
            else
                Features = properties.ToArray();
            return this;
        }
    }
}
