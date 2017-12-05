using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace AutoTensor.Properties
{
    /// <summary>One Hot property. Expanded feature.</summary>
    public class OneHotProperty : Property
    {
        /// <summary>Default constructor.</summary>
        public OneHotProperty() { }
        /// <summary>Constructor.</summary>
        /// <param name="length">The length.</param>
        public OneHotProperty(int length)
        {
            Length = length;
            Categories = new string[Length];
            for(int i = 0; i < Length; i++)
                Categories[i] = string.Empty;
        }
        /// <summary>Length of property.</summary>
        /// <value>The length.</value>
        public override int Length { get; set; }
        public string[] Categories { get; set;}

        /// <summary>
        /// Retrieve the list of expanded columns. If there is a one-to-one correspondence between the
        /// type and its expansion it will return a single value/.
        /// </summary>
        /// <returns>
        /// An enumerator that allows foreach to be used to process the columns in this collection.
        /// </returns>
        public override IEnumerable<string> GetColumns()
        {
            for (int i = 0; i < Length; i++)
                yield return Categories[i];
        }
        /// <summary>Convert the numeric representation back to the original type.</summary>
        /// <param name="val">.</param>
        /// <returns>An object.</returns>
        public override object Convert(double val)
        {
            return val;
        }
        /// <summary>Convert an object to a list of numbers.</summary>
        /// <exception cref="InvalidCastException">Thrown when an object cannot be cast to a required
        /// type.</exception>
        /// <param name="o">Object.</param>
        /// <returns>Lazy list of doubles.</returns>
        public override IEnumerable<double> Convert(object o)
        {
            var s = o.ToString().Sanitize(false);
            var added = false;
            for(int i = 0; i < Length; i++)
            {
                if(Categories[i] == string.Empty && !added) 
                    Categories[i] = s;

                if(Categories[i] == s) 
                    added = true;

                yield return s == Categories[i] ? 1 : 0;
            }
        }
    }
}
