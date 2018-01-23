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
            foreach (var property in t.GetProperties())
            {
                var item = property.GetCustomAttributes(typeof(FeatureAttribute), false);

                var featureAttribute = property.GetCustomAttributes(typeof(FeatureAttribute), false);
                var isFeature = featureAttribute.Count() == 1;
                var isLabel = property.GetCustomAttributes(typeof(LabelAttribute), false).Count() == 1;


                if(isFeature && !isLabel)
                {

                }
                

                //// has feature attribute
                if (item.Count() == 1)
                {
                //    var p = FindProperty



                    // generate appropriate property from attribute
                    //Property p = attrib.GenerateProperty(property);

                    //// feature
                    //if (attrib.GetType().GetTypeInfo().IsSubclassOf(typeof(FeatureAttribute)) ||
                    //    attrib is FeatureAttribute)
                    //    features.Add(p);
                    //// label
                    //else if (attrib.GetType().GetTypeInfo().IsSubclassOf(typeof(LabelAttribute)) ||
                    //    attrib is LabelAttribute)
                    //{
                    //    if (label != null)
                    //        throw new InvalidOperationException("Cannot have multiple labels in a class");
                    //    label = p;
                    //}
                }
            }


            return d;
        }

        public static Descriptor<T> For<T>()
        {
            return new Descriptor<T>() { Name = typeof(T).Name };
        }
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
