using AutoTensor.Features;
using static AutoTensor.Ject;
using System;
using System.Reflection;

namespace AutoTensor
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FeatureAttribute : Attribute
    {
        public virtual IProperty GenerateProperty(PropertyInfo pi)
        {
            return FindProperty(pi);
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class LabelAttribute : Attribute { }
}
