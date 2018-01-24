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

                // has a feature attribute
                if (f.Count() == 1)
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
                    if(IsFeature(f1) && IsFeature(f2))
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
            attr.GetType() == typeof(FeatureAttribute) ||
            attr.GetType().IsSubclassOf(typeof(FeatureAttribute));

        private static bool IsLabel(FeatureAttribute attr) =>
            attr.GetType() == typeof(LabelAttribute);
    }


    public partial class Descriptor<T>
    {
        public Descriptor<T> With<S>(string name)
        {
            return With(typeof(S), name);
        }

        public Descriptor<T> Learn<S>(string name)
        {
            return Learn(typeof(S), name);
        }

        public Descriptor<T> With<S>(Expression<Func<T, S>> property)
        {
            var pi = GetPropertyInfo(property);
            return With(pi.PropertyType, pi.Name);
        }

        public Descriptor<T> Learn<S>(Expression<Func<T, S>> property)
        {
            var pi = GetPropertyInfo(property);
            return Learn(pi.PropertyType, pi.Name);
        }


        public Descriptor<T> With(Type type, string name)
        {
            var property = FindProperty(type);
            property.Name = name;
            return AddProperty(property);
        }

        public Descriptor<T> Learn(Type type, string name)
        {
            var property = FindProperty(type);
            property.Name = name;
            return AddProperty(property, true);
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
