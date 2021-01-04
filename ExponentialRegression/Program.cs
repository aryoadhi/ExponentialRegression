using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExponentialRegression
{

    class Program
    {

        static void Main(string[] args)
        {
            float x = 0;
            float x2sum = 0;
            float y = 0;
            float sumxlny = 0;
            float sumlny = 0;
            CultureInfo culture = new CultureInfo("id-ID");
            Console.WriteLine("This program will determine exponential regression for given data.");
            Console.WriteLine("How many data samples?");
            int n = Convert.ToInt16(Console.ReadLine());
            List<float> columnx = new List<float>();
            List<float> columny = new List<float>();
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("x" + i + ":");
                columnx.Add(Convert.ToSingle(Console.ReadLine()));
                Console.WriteLine("y" + i + ":");
                columny.Add(Convert.ToSingle(Console.ReadLine()));
            }
            List<float> columnlny = new List<float>();
            List<float> columnx2 = new List<float>();
            // print column1
            Console.WriteLine("Column 1:");
            foreach (float element in columnx)
            {
                Console.WriteLine(Convert.ToDecimal(element, culture));
                x += element;
                columnx2.Add((float)Math.Pow(element, 2));
            }
            foreach (float element in columnx2)
            {
                x2sum += element;
            }
            // print column2
            Console.WriteLine("Column 2:");
            foreach (float element in columny)
            {
                Console.WriteLine(Convert.ToDecimal(element, culture));
                y += element;
                float lny = (float)Math.Log(Convert.ToDouble(element), Math.E);
                columnlny.Add(lny);
            }
            Console.WriteLine("Processing file...");
            List<float> colxlny = new List<float>();
            string sigma = "\u03A3";
            Console.WriteLine("Total data entries (n) = " + Convert.ToString(n));
            Console.WriteLine(sigma + "x = " + Convert.ToString(x));
            Console.WriteLine(sigma + "y = " + Convert.ToString(y));
            Console.WriteLine(sigma + "x\u00B2 = " + Convert.ToString(x2sum));
            for (int i = 0; i < n; i++)
            {
                colxlny.Add(columnx[i] * columnlny[i]);
                sumxlny += colxlny[i];
                sumlny += columnlny[i];
            }
            Console.WriteLine(sigma + "ln(y) = " + Convert.ToString(sumlny));
            Console.WriteLine(sigma + "(x ln(y)) = " + Convert.ToString(sumxlny));
            Console.WriteLine("Calculating a and b...");
            float a = (float)(((n * sumxlny) - (x * sumlny)) / ((n * x2sum) - Math.Pow(x, 2)));
            float b = (float)((sumlny / n) - (a * x / n));
            Console.WriteLine("Final result:");
            Console.WriteLine("y=e^(" + a + "x + (" + b + "))");
            Console.WriteLine("Find y value? (y/n) (leave blank to exit)");
            switch (Console.ReadLine().ToLower())
            {
                case "y":
                    Console.WriteLine("Writing for x = 0 to x = 1,0");
                    for (int i = 0; i <= 10; i++)
                    {
                        float v = (float)i / 10;
                        float z = (float)Math.Exp((a * v) + b);
                        Console.WriteLine(v + " = " + z);
                    }
                    break;
                case "n":
                    return;
                default:
                    return;
            }
        }
    }
}
