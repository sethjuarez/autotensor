using System;
using System.Collections.Generic;
using System.Text;

namespace AutoTensor.Property
{
    /// <summary>
    /// Property interface designed to convert any type to
    /// a list of floats to stuff into a Tensor
    /// </summary>
    /// <typeparam name="T">Type to convert</typeparam>
    public interface IProperty<S, T>
    {
        /// <summary>
        /// Property name
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Explicit type of source object
        /// </summary>
        Type Type { get; }
        /// <summary>
        /// Property start position in target tensor
        /// </summary>
        int Position { get; set; }
        /// <summary>
        /// Property length
        /// </summary>
        int Length { get; }
        /// <summary>
        /// Retrieve the list of expanded columns. If there is a one-to-one correspondence between the
        /// type and its expansion it will return a single value/.
        /// </summary>
        /// <returns>
        /// An enumerator that allows foreach to be used to process the columns in this collection.
        /// </returns>
        IEnumerable<string> GetColumns();

        /// <summary>
        /// Used as a preprocessing step when overridden. Can be used to look at the entire data set as a
        /// whole before converting single elements.
        /// </summary>
        /// <param name="items">items to pre-process</param>
        void PreProcess(IEnumerable<S> items);
        /// <summary>
        /// Used as a preprocessing step when overridden. Can be used to look at the current object in
        /// question before converting single elements.
        /// </summary>
        /// <param name="item">item to pre-process</param>
        void PreProcess(S item);
        /// <summary>
        /// Used as a postprocessing step when overridden. Can be used to look at the entire data set as
        /// a whole after converting single elements.
        /// </summary>
        /// <param name="items">Items to post process</param>
        void PostProcess(IEnumerable<S> items);
        /// <summary>
        /// Used as a postprocessing step when overridden. Can be used to look at the current object in
        /// question after converting single elements.
        /// </summary>
        /// <param name="item">Item to post process</param>
        void PostProcess(S item);
        /// <summary>
        /// Convert source object to lazy list of floats
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        IEnumerable<T> ToValue(S source);
        /// <summary>
        /// Convert list of float values to source object
        /// </summary>
        /// <param name="values">float values</param>
        /// <returns>source object</returns>
        S ToSource(IEnumerable<T> values);
    }
}
