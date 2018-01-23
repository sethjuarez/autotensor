using System;
using System.Collections.Generic;
using System.Text;

namespace AutoTensor.Tests.Data
{
    public class Fake
    {
        public long A { get; set; }
        public short B { get; set; }
        public char C { get; set; }

        public static IEnumerable<Fake> GetObjects()
        {
            for (int i = 0; i < 5; i++)
            {
                yield return new Fake { A = 1, B = 1, C = 'A' };
            }
        }
    }
}
