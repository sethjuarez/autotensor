using System;
using System.Collections.Generic;

namespace AutoTensor.Features
{
    public abstract class Property<S> : IProperty, IConverter<S, float>
    {
        public string Name { get; set; }

        public Type Type => typeof(S);

        public int Position { get; set; }

        public virtual int Length => 1;

        public virtual IEnumerable<string> GetColumns()
        {
            yield return Name;
        }

        public virtual void PostProcess(IEnumerable<S> items) { }

        public virtual void PostProcess(S item) { }

        public virtual void PreProcess(IEnumerable<S> items) { }

        public virtual void PreProcess(S item) { }

        public abstract S ToSource(IEnumerable<float> values);

        public abstract IEnumerable<float> ToValue(S source);
    }
}
