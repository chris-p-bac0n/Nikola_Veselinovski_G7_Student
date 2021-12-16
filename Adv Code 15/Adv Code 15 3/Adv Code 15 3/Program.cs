using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Adv_Code_15_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //var fileName = "listOfDimensions.txt";

            //using var sr = new StreamReader(fileName);

            //string line = String.Empty;

            //int totalNumberOfSqrFeet = 0;

            //while ((line = sr.ReadLine()) != null)
            //{
            //    var dimensions = line.Split('x').Select(Int32.Parse).ToList();
            //    int l = dimensions[0];
            //    int w = dimensions[1];
            //    int h = dimensions[2];                

            //    int[] smallestSideCalc = { (l * w), (w * h), (h * l) };
            //    int smallestSideSqrFeet = smallestSideCalc.Min();

            //    int totalSqrFeetOfPaper = 2 * l * w + 2 * w * h + 2 * h * l + smallestSideSqrFeet;
            //    totalNumberOfSqrFeet += totalSqrFeetOfPaper;
            //}

            //Console.WriteLine(totalNumberOfSqrFeet);

            var fileName = "listOfDimensions.txt";

            var dimmensionsArr = File.ReadAllLines(fileName);

            var result = dimmensionsArr
                .Select(x => x.Split('x'))
                .Select(x => new List<int> { int.Parse(x[0]), int.Parse(x[1]), int.Parse(x[2]) })
                .Select(x =>
                {
                    int[] smallestSideCalc = { (x[0] * x[1]), (x[1] * x[2]), (x[2] * x[0]) };

                    return 2 * x[0] * x[1] + 2 * x[1] * x[2] + 2 * x[2] * x[0] + smallestSideCalc.Min();

                }).Sum();
        }
    }
}
