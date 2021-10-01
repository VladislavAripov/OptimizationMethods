using System;
using System.Text;

namespace FibonacciMethod
{
    public static class FibonacciMethodCalculator
    {
        public static void FindMinimumFunctionValue(Func<double, double> function, double a, double b, double epsilon)
        {
            var comparisonValue = (b - a) / epsilon;
            var n = 3;
            while (GetFibonacciNumber(n) < comparisonValue)
                n++;
            n -= 2;

            var y = ProcessY(a, b, n);
            Console.WriteLine($"y[0] = {y}");
            var z = ProcessZ(a, b, n);
            Console.WriteLine($"z[0] = {z}");

            var i = 0;
            do
            {
                i++;
                var iterationData = new StringBuilder();
                iterationData.AppendLine($"<iteration number: {i}>");
                var fy = function(y);
                iterationData.AppendLine($"<fy[{i}] = {Math.Round(fy, 3)};>");
                var fz = function(z);
                iterationData.AppendLine($"<fz[{i}] = {Math.Round(fz, 3)};>");

                if (fy <= fz)
                {
                    iterationData.AppendLine("fy <= fz => b = z, z = y");
                    b = z;
                    z = y;
                    y = ProcessY(a, b, n);
                    iterationData.AppendLine($"<y[{i}] = {Math.Round(y, 3)};>");
                }
                else
                {
                    iterationData.AppendLine("fz < fy => a = y");
                    a = y;
                    y = z;
                    z = ProcessZ(a, b, n);
                    iterationData.AppendLine($"<z[{i}] = {Math.Round(z, 3)};>");
                }

                Console.WriteLine(iterationData);
            } while (b - a <= epsilon);

            var c = (a + b) / 2;
            Console.WriteLine($"c[result] = {Math.Round(c, 3)}");
            var result = function(c);
            Console.WriteLine($"fc[result] = {Math.Round(result, 3)}");
        }

        private static double ProcessY(double a, double b, int n) =>
            a + (double) GetFibonacciNumber(n) / GetFibonacciNumber(n + 2) * (b - a);

        private static double ProcessZ(double a, double b, int n) =>
            a + (double) GetFibonacciNumber(n + 1) / GetFibonacciNumber(n + 2) * (b - a);

        private static int GetFibonacciNumber(int numberNumber)
        {
            var a = 1;
            var b = 1;
            for (var i = 3; i <= numberNumber; i++)
            {
                var c = a + b;
                a = b;
                b = c;
            }
            return b;
        }
    }
}