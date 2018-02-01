using AutoTensor.Features.Complex;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoTensor.Tests.Data
{
    public class StronglyDeclaredOnlyFeatures
    {
        [Feature]
        public sbyte A { get; set; }
        [Feature]
        public byte B { get; set; }
        [Feature]
        public short C { get; set; }
        [Feature]
        public ushort D { get; set; }
        [Feature]
        public int E { get; set; }
        [Feature]
        public uint F { get; set; }
        [Feature]
        public long G { get; set; }
        [Feature]
        public char H { get; set; }
        [Feature]
        public float I { get; set; }
        [Feature]
        public ulong J { get; set; }
    }

    public class StronglyDeclared
    {
        [Feature]
        public sbyte A { get; set; }
        [Feature]
        public byte B { get; set; }
        [Feature]
        public short C { get; set; }
        [Feature]
        public ushort D { get; set; }
        [Feature]
        public int E { get; set; }
        [Label]
        public uint F { get; set; }
        [Label]
        public long G { get; set; }
        [Label]
        public char H { get; set; }
        [Label]
        public float I { get; set; }
        
        [Label]
        public ulong J { get; set; }
    }

    public class StronglyDeclaredOverlap
    {
        [Feature]
        public sbyte A { get; set; }
        [Feature]
        public byte B { get; set; }
        [Feature]
        public short C { get; set; }
        [Feature]
        public ushort D { get; set; }
        [Feature]
        public int E { get; set; }
        [Label]
        public uint F { get; set; }
        [Label]
        public long G { get; set; }
        [Label]
        public char H { get; set; }
        [Label]
        public float I { get; set; }
        [Label]
        [Feature]
        public ulong J { get; set; }
    }

    public class StrongDateTime
    {
        [Feature]
        public DateTime A { get; set; }

        [Label]
        [Feature]
        public DateTime B { get; set; }
    }

    public class StrongDateTimeCustom
    {
        [DateTimeFeature(DateTimeFeature.DayOfWeek)]
        public DateTime A { get; set; }

        [Feature]
        public DateTime B { get; set; }

        [Label]
        [DateTimeFeature(DatePortion.Time)]
        public DateTime C { get; set; }
    }

    public class StrongDateTimeCustomException
    {
        [DateTimeFeature(DateTimeFeature.DayOfWeek)]
        public DateTime A { get; set; }

        [Feature]
        [DateTimeFeature(DateTimeFeature.Minute | DateTimeFeature.Second)]
        public DateTime B { get; set; }

        [Label]
        [DateTimeFeature(DatePortion.Time)]
        public DateTime C { get; set; }
    }

    public class StrongDateTimeCustomTripleException
    {
        [DateTimeFeature(DateTimeFeature.DayOfWeek)]
        public DateTime A { get; set; }

        [Label]
        [Feature]
        [DateTimeFeature(DateTimeFeature.Minute | DateTimeFeature.Second)]
        public DateTime B { get; set; }

        [Label]
        [DateTimeFeature(DatePortion.Time)]
        public DateTime C { get; set; }
    }

    public class Fake
    {
        public long A { get; set; }

        public short B { get; set; }

        public char C { get; set; }
        
        public DateTime D { get; set; }

        public long E { get; set; }

        public short F { get; set; }

        public char G { get; set; }
        
    }

    public class TinyFake
    {

    }
}
