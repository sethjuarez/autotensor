using System;
using System.Linq;
using Xunit;
using System.Collections.Generic;
using AutoTensor;
using System.Numerics;

namespace AutoTensor.Tests
{
    public class LinAlgConversionTests
    {
        [Fact]
        public void Test_Dense_Matrix_Conversion()
        {
            IEnumerable<IEnumerable<double>> x =
                new double[][] 
                { 
                    new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                    new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                    new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                    new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                    new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                };

            Tensor<double> v = x.ToMatrix();

            Tensor<double> truth =
                new double[,] {
                    { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                    { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                    { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                    { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                    { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                }.ToTensor();


            Assert.Equal(truth, v);
        }

        [Fact]
        public void Test_Sparse_Matrix_Conversion()
        {
            IEnumerable<IEnumerable<double>> x =
                new double[][] 
                { 
                    new double[] { 0, 2, 0, 0, 5, 6, 0, 8, 0, 0 },
                    new double[] { 0, 2, 0, 0, 5, 6, 0, 8, 0, 0 },
                    new double[] { 0, 2, 0, 0, 5, 6, 0, 8, 0, 0 },
                    new double[] { 0, 2, 0, 0, 5, 6, 0, 8, 0, 0 },
                    new double[] { 0, 2, 0, 0, 5, 6, 0, 8, 0, 0 },
                };

            Tensor<double> v = x.ToMatrix();


            Tensor<double> truth =
                    new double[,] { 
                        { 0, 2, 0, 0, 5, 6, 0, 8, 0, 0 },
                        { 0, 2, 0, 0, 5, 6, 0, 8, 0, 0 },
                        { 0, 2, 0, 0, 5, 6, 0, 8, 0, 0 },
                        { 0, 2, 0, 0, 5, 6, 0, 8, 0, 0 },
                        { 0, 2, 0, 0, 5, 6, 0, 8, 0, 0 },
                    }.ToTensor();

            Assert.Equal(truth, v);
        }

        [Fact]
        public void Test_Jagged_Matrix_Conversion()
        {
            IEnumerable<IEnumerable<double>> x =
                new double[][] 
                { 
                    new double[] { 1, 2, 3, 4, 5, 6, 7 },
                    new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                    new double[] { 1, 2, 3, 4, 5, 6 },
                    new double[] { 1, 2, 3, 4, 5, 6, 7, 8},
                    new double[] { 1 },
                };

            Tensor<double> v = x.ToMatrix();

            Tensor<double> truth =
                    new double[,] { 
                        { 1, 2, 3, 4, 5, 6, 7, 0, 0, 0 },
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                        { 1, 2, 3, 4, 5, 6, 0, 0, 0, 0 },
                        { 1, 2, 3, 4, 5, 6, 7, 8, 0, 0 },
                        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    }.ToTensor();

            Assert.Equal(truth, v);
        }

        [Fact]
        public void Test_Example_Conversion()
        {
            IEnumerable<IEnumerable<double>> x =
                new double[][] 
                { 
                    new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, -1 },
                    new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 },
                    new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, -1 },
                    new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 },
                    new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 },
                };

            var tuple = x.ToExamples();

            Tensor<double> m =
                    new double[,] { 
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                    }.ToTensor();

            Tensor<double> v = new double[] { -1, 1, -1, 1, 1 }.ToTensor();

            Assert.Equal(m, tuple.X);
            Assert.Equal(v, tuple.Y);
        }

        [Fact]
        public void Test_Jagged_Example_Conversion()
        {
            IEnumerable<IEnumerable<double>> x =
                new double[][] 
                { 
                    new double[] { 1, 2, 3, 4, 5, 6, 7 },
                    new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                    new double[] { 1, 2, 3, 4, 5, 6 },
                    new double[] { 1, 2, 3, 4, 5, 6, 7, 8 },
                    new double[] { 1 },
                };

            var tuple = x.ToExamples();


            Tensor<double> m =
                    new double[,] { 
                        { 1, 2, 3, 4, 5, 6, 7, 0, 0 },
                        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                        { 1, 2, 3, 4, 5, 6, 0, 0, 0 },
                        { 1, 2, 3, 4, 5, 6, 7, 8, 0 },
                        { 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                    }.ToTensor();

            Tensor<double> v = new double[] { 0, 10, 0, 0, 0 }.ToTensor();


            Assert.Equal(m, tuple.X);
            Assert.Equal(v, tuple.Y);
        }
    }
}
