using System;
using System.Collections.Generic;
using System.Text;

namespace AutoTensor.Property
{
    public class IntProperty : IProperty<int>
    {
        public string Name { get; set; }

        public Type Type => typeof(int);

        public int Position { get; set; }

        public int Length => 1;

        public IEnumerable<string> GetColumns()
        {
            yield return Name;
        }

        public void PostProcess(IEnumerable<int> items) { }

        public void PostProcess(int item) { }

        public void PreProcess(IEnumerable<int> items) { }

        public void PreProcess(int item) { }

        public int ToSource(IEnumerable<float> values)
        {
            
        }

        public IEnumerable<float> ToValue(int source)
        {
            yield return (float)source;
        }
    }
}
