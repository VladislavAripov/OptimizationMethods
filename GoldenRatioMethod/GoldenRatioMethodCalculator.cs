using System;
using System.Text;

namespace GoldenRatioMethod
{
    public static class GoldenRatioMethodCalculator
    {
        private const double Alpha = 0.382;
        private const double Beta = 0.618;
        
        public static void FindMinimumFunctionValue(Func<double, double> function, double a, double b, double epsilon)
        {
            var z1 = ProcessZ1(a, b);
            Console.WriteLine($"z1[0] = {z1}");
            var z2 = ProcessZ2(a, b);
            Console.WriteLine($"z2[0] = {z2}");

            var i = 0;
            do
            {
                i++;
                var iterationData = new StringBuilder();
                iterationData.AppendLine($"<iteration number: {i}>");
                var fz1 = function(z1);
                iterationData.AppendLine($"<fz1[{i}] = {Math.Round(fz1, 3)};>");
                var fz2 = function(z2);
                iterationData.AppendLine($"<fz2[{i}] = {Math.Round(fz2, 3)};>");

                if (fz1 <= fz2)
                {
                    iterationData.AppendLine("fz1 <= fz2 => b = z2, z2 = z1");
                    b = z2;
                    z2 = z1;
                    z1 = ProcessZ1(a, b);
                    iterationData.AppendLine($"<z1[{i}] = {Math.Round(z1, 3)};>");
                }
                else
                {
                    iterationData.AppendLine("fz2 < fz1 => a = z1");
                    a = z1;
                    z1 = z2;
                    z2 = ProcessZ2(a, b);
                    iterationData.AppendLine($"<z2[{i}] = {Math.Round(z2, 3)};>");
                }
                Console.WriteLine(iterationData);
            } while (b - a <= epsilon);

            var c = (a + b) / 2;
            Console.WriteLine($"c[result] = {Math.Round(c, 3)}");
            var result = function(c);
            Console.WriteLine($"fc[result] = {Math.Round(result, 3)}");
        }

        private static double ProcessZ1(double a, double b) => a + Alpha * (b - a);

        private static double ProcessZ2(double a, double b) => a + Beta * (b - a);
    }
}