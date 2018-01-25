using AutoTensor.Features.Complex;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;

namespace AutoTensor.Tests.Complex
{
    public class DateTimePropertyTests
    {
        [Fact]
        public void Create_Empty_Test()
        {
            var p1 = new DateTimeProperty();
            Assert.Equal(5, p1.Length);
            Assert.Equal(DateTimeFeature.Year | DateTimeFeature.Month |
                           DateTimeFeature.Day | DateTimeFeature.DayOfYear |
                           DateTimeFeature.DayOfWeek,
                            p1.Features);

            p1 = new DateTimeProperty("A");
            Assert.Equal(5, p1.Length);
            Assert.Equal("A", p1.Name);
            Assert.Equal(DateTimeFeature.Year | DateTimeFeature.Month |
                           DateTimeFeature.Day | DateTimeFeature.DayOfYear |
                           DateTimeFeature.DayOfWeek,
                            p1.Features);
        }

        [Fact]
        public void Create_DatePortion_Test()
        {
            var p1 = new DateTimeProperty(DatePortion.Date);
            Assert.Equal(3, p1.Length);
            Assert.Equal(DateTimeFeature.Year | DateTimeFeature.Month |
                           DateTimeFeature.Day, p1.Features);

            p1 = new DateTimeProperty("A", DatePortion.DateExtended);
            Assert.Equal(2, p1.Length);
            Assert.Equal("A", p1.Name);
            Assert.Equal(DateTimeFeature.DayOfYear | DateTimeFeature.DayOfWeek, p1.Features);

            p1 = new DateTimeProperty(DatePortion.Time | DatePortion.DateExtended);
            Assert.Equal(4, p1.Length);
            Assert.Equal(DateTimeFeature.DayOfYear | DateTimeFeature.DayOfWeek |
                           DateTimeFeature.Hour | DateTimeFeature.Minute, p1.Features);

            p1 = new DateTimeProperty(DatePortion.Date | DatePortion.TimeExtended);
            Assert.Equal(5, p1.Length);
            Assert.Equal(DateTimeFeature.Year | DateTimeFeature.Month |
                         DateTimeFeature.Day | DateTimeFeature.Second | DateTimeFeature.Millisecond,
                           p1.Features);
        }

        [Fact]
        public void Create_DateFeature_Test()
        {
            var p1 = new DateTimeProperty(DateTimeFeature.Year | DateTimeFeature.DayOfWeek);
            Assert.Equal(2, p1.Length);
            Assert.Equal(DateTimeFeature.Year | DateTimeFeature.DayOfWeek, p1.Features);


            p1 = new DateTimeProperty("A", DateTimeFeature.Year | DateTimeFeature.DayOfWeek | DateTimeFeature.Minute);
            Assert.Equal(3, p1.Length);
            Assert.Equal("A", p1.Name);
            Assert.Equal(DateTimeFeature.Year | DateTimeFeature.DayOfWeek | DateTimeFeature.Minute, p1.Features);
        }

        [Fact]
        public void Get_Columns_Test()
        {
            var p1 = new DateTimeProperty(DateTimeFeature.Year | DateTimeFeature.DayOfWeek);
            var cols = new[] { "Year", "DayOfWeek" };
            var pCols = p1.GetColumns().ToArray();
            Assert.Equal(cols, pCols);

            p1 = new DateTimeProperty(DateTimeFeature.Year | DateTimeFeature.DayOfWeek | DateTimeFeature.Minute);
            cols = new[] { "Year", "DayOfWeek", "Minute" };
            pCols = p1.GetColumns().ToArray();
            Assert.Equal(cols, pCols);

            p1 = new DateTimeProperty(DateTimeFeature.Minute | DateTimeFeature.DayOfWeek | DateTimeFeature.Year);
            pCols = p1.GetColumns().ToArray();
            Assert.Equal(cols, pCols);

            p1 = new DateTimeProperty(DatePortion.Date | DatePortion.DateExtended | DatePortion.Time | DatePortion.TimeExtended);
            cols = new[] { "Year", "DayOfYear", "Month", "Day", "DayOfWeek", "Hour", "Minute", "Second", "Millisecond" };
            pCols = p1.GetColumns().ToArray();
            Assert.Equal(cols, pCols);
        }


        [Fact]
        public void Convert_To_Target_Test()
        {
            DateTime d = new DateTime(2017, 6, 5, 9, 22, 34, 233);
            var dayOfWeek = (float)d.DayOfWeek;
            var dayOfYear = (float)d.DayOfYear;

            var p1 = new DateTimeProperty(DateTimeFeature.Year | DateTimeFeature.DayOfWeek);
            var cols = new float[] { d.Year, dayOfWeek };
            var pCols = p1.ToValue(d).ToArray();
            Assert.Equal(cols, pCols);

            p1 = new DateTimeProperty(DateTimeFeature.Year | DateTimeFeature.DayOfWeek | DateTimeFeature.Minute);
            cols = new float[] { d.Year, dayOfWeek, d.Minute };
            pCols = p1.ToValue(d).ToArray();
            Assert.Equal(cols, pCols);

            p1 = new DateTimeProperty(DateTimeFeature.Minute | DateTimeFeature.DayOfWeek | DateTimeFeature.Year);
            cols = new float[] { d.Year, dayOfWeek, d.Minute };
            pCols = p1.ToValue(d).ToArray();
            Assert.Equal(cols, pCols);

            p1 = new DateTimeProperty(DatePortion.Date | DatePortion.DateExtended | DatePortion.Time | DatePortion.TimeExtended);
            cols = new float[] { d.Year, dayOfYear, d.Month, d.Day, dayOfWeek, d.Hour, d.Minute, d.Second, d.Millisecond };
            pCols = p1.ToValue(d).ToArray();
            Assert.Equal(cols, pCols);
        }

        [Fact]
        public void Convert_To_Source_Test()
        {
            var p1 = new DateTimeProperty(DateTimeFeature.Year | DateTimeFeature.DayOfWeek);
            Exception ex = Assert.Throws<InvalidOperationException>(
                () => p1.ToSource(new float[] { 1, 2 }));

        }

        [Fact]
        public void Length_Test()
        {
            var p1 = new DateTimeProperty(DateTimeFeature.Year | DateTimeFeature.DayOfWeek);
            Assert.Equal(2, p1.Length);

            p1 = new DateTimeProperty(DateTimeFeature.Year | DateTimeFeature.DayOfWeek | DateTimeFeature.Minute);
            Assert.Equal(3, p1.Length);

            p1 = new DateTimeProperty(DateTimeFeature.Minute | DateTimeFeature.DayOfWeek | DateTimeFeature.Year);
            Assert.Equal(3, p1.Length);

            p1 = new DateTimeProperty(DatePortion.Date | DatePortion.DateExtended | DatePortion.Time | DatePortion.TimeExtended);
            Assert.Equal(9, p1.Length);
        }

    }
}
