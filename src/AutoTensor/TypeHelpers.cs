using System;
using System.Linq;
using System.Reflection;
using AutoTensor.Features;
using System.Linq.Expressions;
using AutoTensor.Features.Simple;
using System.Collections.Concurrent;

namespace AutoTensor
{
    public static class TypeHelpers
    {
        /// <summary>Gets property information.</summary>
		/// <tparam name="K">Generic type parameter.</tparam>
		/// <param name="property">The property.</param>
		/// <returns>The property information.</returns>
		public static PropertyInfo GetPropertyInfo<T, S>(Expression<Func<T, S>> property)
        {
            PropertyInfo propertyInfo = null;
            if (property.Body is MemberExpression)
                propertyInfo = (property.Body as MemberExpression).Member as PropertyInfo;
            else
                propertyInfo = (((UnaryExpression)property.Body).Operand as MemberExpression).Member as PropertyInfo;

            return propertyInfo;
        }

        /// <summary>
        /// for maintaining fast pointers to IProperty objects
        /// </summary>
        private static readonly ConcurrentDictionary<Type, Type> _properties =
            new ConcurrentDictionary<Type, Type>();
        public static IProperty FindProperty(Type sourceType)
        {
            // cached
            if (_properties.ContainsKey(sourceType))
                return Activator.CreateInstance(_properties[sourceType]) as IProperty;
            else
            {
                // find
                var types = FindType(
                                t => t.BaseType == typeof(Property<>)
                                      .MakeGenericType(sourceType));
                // if only one then cache and return
                if (types.Length == 1)
                {
                    _properties[sourceType] = types[0];
                    return Activator.CreateInstance(types[0]) as IProperty;
                }
                else if (types.Length == 0)
                    throw new InvalidCastException($"Cannot find appropriate feature Property for {nameof(sourceType)}");
                else
                    throw new InvalidCastException($"Found too many feature Property implementations for {nameof(sourceType)}: {string.Join(", ", types.Select(t => t.Name).ToArray())}");
            }
        }

        private static Type[] FindType(Func<Type, bool> predicate)
        {
            var type = AppDomain.CurrentDomain.GetAssemblies()
                             .SelectMany(a => a.GetTypes())
                             .Where(predicate)
                             .ToArray();

            return type;
        }
    }
}
