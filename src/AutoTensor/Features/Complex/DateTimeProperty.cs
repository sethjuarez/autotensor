using System;
using System.Collections.Generic;
using System.Text;

namespace AutoTensor.Features.Complex
{
    /// <summary>Features available for the DateTime property.</summary>
    [Flags]
    public enum DateTimeFeature
    {
        /// <summary>
        /// Year
        /// </summary>
        Year = 0x0001,
        /// <summary>
        /// Day of the year (1, 366)
        /// </summary>
        DayOfYear = 0x0002,
        /// <summary>
        /// Month
        /// </summary>
        Month = 0x0008,
        /// <summary>
        /// Day
        /// </summary>
        Day = 0x0010,
        /// <summary>
        /// Day of the week (0, 6)
        /// </summary>
        DayOfWeek = 0x0020,
        /// <summary>
        /// Hour
        /// </summary>
        Hour = 0x0040,
        /// <summary>
        /// Minute
        /// </summary>
        Minute = 0x0080,
        /// <summary>
        /// Second
        /// </summary>
        Second = 0x0100,
        /// <summary>
        /// Millisecond
        /// </summary>
        Millisecond = 0x0200
    }

    /// <summary>Date portions available for the DateTime property.</summary>
    [Flags]
    public enum DatePortion
    {
        /// <summary>
        /// Date (Jan. 1, 2000) -> [1, 1, 2000]
        /// </summary>
        Date = 0x0001,
        /// <summary>
        /// Extended Date (Jan. 1, 2000) -> [1, 6] (DayOfYear, DayOfWeek)
        /// </summary>
        DateExtended = 0x0002,
        /// <summary>
        /// Time 4:45pm -> [16, 45] (Hour, Minute)
        /// </summary>
        Time = 0x0008,
        /// <summary>
        /// Extended Time 4:45pm -> [0, 0] (Second, Millisecond)
        /// </summary>
        TimeExtended = 0x0010
    }

    public class DateTimeProperty : Property<DateTime>
    {
        public DateTimeProperty() 
            : base()
        {
            Features = ConvertToFeatures(DatePortion.Date | DatePortion.DateExtended);
        }

        public DateTimeProperty(string name)
            : base(name)
        {
            Features = ConvertToFeatures(DatePortion.Date | DatePortion.DateExtended);
        }

        public DateTimeProperty(DatePortion portion)
        {
            Features = ConvertToFeatures(portion);
        }

        public DateTimeProperty(DateTimeFeature features)
        {
            Features = features;
        }

        public DateTimeProperty(string name, DatePortion portion)
            : base(name)
        {
            Features = ConvertToFeatures(portion);
        }

        public DateTimeProperty(string name, DateTimeFeature features)
            : base(name)
        {
            Features = features;
        }

        public static DateTimeFeature ConvertToFeatures(DatePortion portion)
        {
            DateTimeFeature features = 0;
            if (portion.HasFlag(DatePortion.Date))
                features |= DateTimeFeature.Year | DateTimeFeature.Month |
                           DateTimeFeature.Day;

            if (portion.HasFlag(DatePortion.DateExtended))
                features |= DateTimeFeature.DayOfYear | DateTimeFeature.DayOfWeek;

            if (portion.HasFlag(DatePortion.Time))
                features |= DateTimeFeature.Hour | DateTimeFeature.Minute;

            if (portion.HasFlag(DatePortion.TimeExtended))
                features |= DateTimeFeature.Second | DateTimeFeature.Millisecond;

            return features;
        }

        /// <summary>Gets or sets the features.</summary>
        /// <value>The features.</value>
        public DateTimeFeature Features { get; set; }

        /// <summary>The length.</summary>
        private int _length = -1;
        /// <summary>Length of property.</summary>
        /// <value>The length.</value>
        public override int Length
        {
            get
            {
                if (_length == -1)
                {
                    _length = 0;
                    if (Features.HasFlag(DateTimeFeature.Year))
                        _length++;
                    if (Features.HasFlag(DateTimeFeature.DayOfYear))
                        _length++;
                    if (Features.HasFlag(DateTimeFeature.Month))
                        _length++;
                    if (Features.HasFlag(DateTimeFeature.Day))
                        _length++;
                    if (Features.HasFlag(DateTimeFeature.DayOfWeek))
                        _length++;
                    if (Features.HasFlag(DateTimeFeature.Hour))
                        _length++;
                    if (Features.HasFlag(DateTimeFeature.Minute))
                        _length++;
                    if (Features.HasFlag(DateTimeFeature.Second))
                        _length++;
                    if (Features.HasFlag(DateTimeFeature.Millisecond))
                        _length++;
                }

                return _length;
            }
        }

        public override IEnumerable<string> GetColumns()
        {
            if (Features.HasFlag(DateTimeFeature.Year))
                yield return nameof(DateTimeFeature.Year);
            if (Features.HasFlag(DateTimeFeature.DayOfYear))
                yield return nameof(DateTimeFeature.DayOfYear);
            if (Features.HasFlag(DateTimeFeature.Month))
                yield return nameof(DateTimeFeature.Month);
            if (Features.HasFlag(DateTimeFeature.Day))
                yield return nameof(DateTimeFeature.Day);
            if (Features.HasFlag(DateTimeFeature.DayOfWeek))
                yield return nameof(DateTimeFeature.DayOfWeek);
            if (Features.HasFlag(DateTimeFeature.Hour))
                yield return nameof(DateTimeFeature.Hour);
            if (Features.HasFlag(DateTimeFeature.Minute))
                yield return nameof(DateTimeFeature.Minute);
            if (Features.HasFlag(DateTimeFeature.Second))
                yield return nameof(DateTimeFeature.Second);
            if (Features.HasFlag(DateTimeFeature.Millisecond))
                yield return nameof(DateTimeFeature.Millisecond);
        }

        public override DateTime ToSource(IEnumerable<float> values)
        {
            throw new InvalidOperationException("Converting back to dates does not make sense....");
        }

        public override IEnumerable<float> ToValue(DateTime source)
        {
            if (Features.HasFlag(DateTimeFeature.Year))
                yield return source.Year;
            if (Features.HasFlag(DateTimeFeature.DayOfYear))
                yield return source.DayOfYear;
            if (Features.HasFlag(DateTimeFeature.Month))
                yield return source.Month;
            if (Features.HasFlag(DateTimeFeature.Day))
                yield return source.Day;
            if (Features.HasFlag(DateTimeFeature.DayOfWeek))
                yield return (float)source.DayOfWeek;
            if (Features.HasFlag(DateTimeFeature.Hour))
                yield return source.Hour;
            if (Features.HasFlag(DateTimeFeature.Minute))
                yield return source.Minute;
            if (Features.HasFlag(DateTimeFeature.Second))
                yield return source.Second;
            if (Features.HasFlag(DateTimeFeature.Millisecond))
                yield return source.Millisecond;
        }
    }

    /// <summary>Attribute for date feature.</summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DateTimeFeatureAttribute : FeatureAttribute
    {
        DateTimeFeature _features;

        public DateTimeFeatureAttribute(DateTimeFeature features)
        {
            _features = features;
        }

        public DateTimeFeatureAttribute(DatePortion portion)
        {
            _features = DateTimeProperty.ConvertToFeatures(portion);
        }

        public override IProperty PopulateProperty(IProperty property)
        {
            var dtp = property as DateTimeProperty;
            dtp.Features = _features;
            return dtp;
        }
    }
}
