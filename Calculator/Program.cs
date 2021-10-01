using System;
using DichotomyMethod;
using FibonacciMethod;
using GoldenRatioMethod;

namespace CalculatorApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            // y = x^4 + e^-x
            double Function(double x) => Math.Pow(x, 4) + Math.Pow(Math.E, -x);

            double a, b, epsilon, delta;
            a = 0;
            b = 1;
            epsilon = 0.1;
            delta = 0.02;
            
            var method = Method.FibonacciMethod;

            switch (method)
            {
                case Method.DichotomyMethod:
                    DichotomyMethodCalculator.FindMinimumFunctionValue(Function, a, b, epsilon, delta);
                    break;
                case Method.GoldenRatioMethod:
                    GoldenRatioMethodCalculator.FindMinimumFunctionValue(Function, a, b, epsilon);
                    break;
                case Method.FibonacciMethod:
                    FibonacciMethodCalculator.FindMinimumFunctionValue(Function, a, b, epsilon);
                    break;
                default:
                    throw new NotSupportedException($"Not supported method: {method}");
            }

            Console.Read();
        }
        
        private enum Method
        {
            DichotomyMethod,
            GoldenRatioMethod,
            FibonacciMethod
        }
    }
}