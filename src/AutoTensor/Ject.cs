using System;
using System.Linq;
using System.Reflection;
using AutoTensor.Features;
using System.Linq.Expressions;
using AutoTensor.Features.Simple;
using System.Collections.Concurrent;

namespace AutoTensor
{
    public static class Ject
    {
        /// <summary>Gets property information.</summary>
		/// <tparam name="K">Generic type parameter.</tparam>
		/// <param name="property">The property.</param>
		/// <returns>The property information.</returns>
		public static PropertyInfo GetPropertyInfo<T, S>(Expression<Func<T, S>> property)
        {
            return (property.Body as MemberExpression).Member as PropertyInfo;
        }

        public static IProperty FindProperty(PropertyInfo pi)
        {
            var p = FindProperty(pi.PropertyType);
            p.Name = pi.Name;
            return p;
        }

        public static IProperty FindProperty(Type sourceType)
        {
            var type = FindPropertyConverterType(sourceType);
            return Activator.CreateInstance(type) as IProperty;
        }

        /// <summary>
        /// for maintaining fast pointers to IProperty objects
        /// </summary>
        private static readonly ConcurrentDictionary<Type, Type> _properties =
            new ConcurrentDictionary<Type, Type>();

        public static Type FindPropertyConverterType(Type sourceType)
        {
            // cached
            if (_properties.ContainsKey(sourceType))
                return _properties[sourceType];
            else
            {
                // find
                var types = FindType(t => t.BaseType == typeof(Property<>)
                                           .MakeGenericType(sourceType));

                // if only one then cache and return
                if (types.Length == 1)
                {
                    _properties[sourceType] = types[0];
                    return types[0];
                }
                else if (types.Length == 0)
                    throw new InvalidOperationException(
                        $"Cannot find appropriate feature Property for {nameof(sourceType)}");
                else
                    throw new InvalidOperationException(
                        $"Found too many feature Property implementations for {nameof(sourceType)}: {string.Join(", ", types.Select(t => t.Name).ToArray())}");
            }
        }

        internal static Type[] FindType(Func<Type, bool> predicate)
        {
            var type = AppDomain.CurrentDomain.GetAssemblies()
                                .SelectMany(a => a.GetTypes())
                                .Where(predicate)
                                .ToArray();
            return type;
        }
    }
}
