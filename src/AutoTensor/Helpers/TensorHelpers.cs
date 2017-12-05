using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;

namespace AutoTensor
{
    public static class TensorHelpers
    {
        public static Tensor<double> ToVector(this IEnumerable<double> seq)
        {
            Tensor<double> t = new DenseTensor<double>(seq.Count());
            int i = -1;
            foreach (double item in seq)
                t[++i] = item;
            return t;
        }

        public static Tensor<double> ToMatrix(this IEnumerable<IEnumerable<double>> matrix)
        {
            // materialize
            double[][] x = (from v in matrix select v.ToArray()).ToArray();

            // determine matrix
            // size and type
            var (n, d) = FindDimensions(x);

            var m = new DenseTensor<double>(new[] { n, d });

            // fill 'er up!
            for (int i = 0; i < n; i++)
                for (int j = 0; j < d; j++)
                    if (j >= x[i].Length)  // over bound limits
                        m[i, j] = 0;       // pad overflow to 0
                    else
                        m[i, j] = x[i][j];

            return m;
        }

        public static (DenseTensor<double> X, DenseTensor<double> Y) ToExamples(this IEnumerable<IEnumerable<double>> matrix)
        {
            // materialize
            double[][] x = (from v in matrix select v.ToArray()).ToArray();

            // determine matrix
            // size and type
            var (n, d) = FindDimensions(x, true); // clip last col
            var m = new DenseTensor<double>(new[] { n, d });

            // fill 'er up!
            for (int i = 0; i < n; i++)
                for (int j = 0; j < d; j++)
                    if (j >= x[i].Length)  // over bound limits
                        m[i, j] = 0;       // pad overflow to 0
                    else
                        m[i, j] = x[i][j];

            // fill up vector
            DenseTensor<double> y = new DenseTensor<double>(n);
            for (int i = 0; i < n; i++)
                if (d >= x[i].Length)
                    y[i] = 0;              // pad overflow to 0
                else
                    y[i] = x[i][d];

            return (m, y);
        }

        private static (int n, int d) FindDimensions(double[][] x, bool clip = false)
        {
            // rows
            int n = x.Length;
            if (n == 0)
                throw new InvalidOperationException("Empty tensor (n)");

            // cols (being nice here...)
            var cols = x.Select(v => v.Length);
            int d = cols.Max();

            if (d == 0)
                throw new InvalidOperationException("Empty tensor (d)");

            // total zeros in matrix
            var zeros = (from v in x select v.Count(i => i == 0)).Sum();

            // if irregularities in jagged matrix, need to 
            // pad rows with less columns with additional
            // zeros by subtracting max width with each
            // individual row and getting the sum
            var pad = cols.Select(c => d - c).Sum();

            // check sparsity
            // var percent = (decimal)(zeros + pad) / (decimal)(n * d);
            return (n, clip ? d - 1 : d);
        }
    }
}
