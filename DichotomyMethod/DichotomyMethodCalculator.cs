using System;
using System.Text;

namespace DichotomyMethod
{
    public static class DichotomyMethodCalculator
    {
        public static void FindMinimumFunctionValue(Func<double,double> function, double a, double b, double epsilon, double delta)
        {
            double c;

            var i = 0;
            do
            {
                i++;
                var iterationData = new StringBuilder();
                iterationData.AppendLine($"<iteration number: {i}>");
                
                iterationData.AppendLine($"<a[{i}] = {Math.Round(a, 3)};>");
                iterationData.AppendLine($"<b[{i}] = {Math.Round(b, 3)};>");
                c = (a + b) / 2;
                iterationData.AppendLine($"<c[{i}] = {Math.Round(c, 3)};>");
                var x = c - delta / 2;
                iterationData.AppendLine($"<x[{i}] = {Math.Round(x, 3)};>");
                var y = c + delta / 2;
                iterationData.AppendLine($"<y[{i}] = {Math.Round(y, 3)};>");

                var fx = function(x);
                iterationData.AppendLine($"<fx[{i}] = {Math.Round(fx, 3)};>");
                var fy = function(y);
                iterationData.AppendLine($"<fy[{i}] = {Math.Round(fy, 3)};>");

                if (fx <= fy)
                {
                    iterationData.AppendLine("fx <= fy => b=y");
                    b = y;
                }
                else
                {
                    iterationData.AppendLine("fy < fx => a=x");
                    a = x;
                }
                Console.WriteLine(iterationData);
            } while (b - a >= epsilon);

            c = (a + b) / 2;
            Console.WriteLine($"c[result] = {Math.Round(c, 3)}");
            var result = function(c);
            Console.WriteLine($"fc[result] = {Math.Round(result, 3)}");
        }
    }
}