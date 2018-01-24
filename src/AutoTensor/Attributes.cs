using System;
using AutoTensor.Features;


namespace AutoTensor
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FeatureAttribute : Attribute
    {
        public virtual IProperty PopulateProperty(IProperty property)
        {
            return property;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class LabelAttribute : FeatureAttribute { }
}
