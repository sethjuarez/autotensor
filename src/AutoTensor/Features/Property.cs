using System;
using System.Collections.Generic;

namespace AutoTensor.Features
{
    public abstract class Property<S> : IProperty, IConverter<S, float>
    {
        public Property() { }
        public Property(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public Type Type => typeof(S);

        public int Position { get; set; } = -1;

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


        //----- garbage
        public IConverter<K, T> GetConverter<K, T>()
        {
            return this as IConverter<K, T>;
        }

        public IEnumerable<T> ToValue<T>(object source)
        {
            if (typeof(T) != typeof(float))
                throw new InvalidOperationException();
            if(source.GetType() != typeof(S))
                throw new InvalidOperationException();

            return (IEnumerable<T>)ToValue((S)source);
        }
    }
}
