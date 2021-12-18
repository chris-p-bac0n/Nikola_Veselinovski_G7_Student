using System;
using System.Linq;

namespace NumberApp.Services
{
    public static class Helpers
    {
        public static int ParseStringToInt(string inputString)
        {
            return Int32.Parse(inputString);
        }
        public static string GetAllNumbersFromString(string inputString)
        {
            return new string(inputString.Where(c => char.IsDigit(c)).ToArray());
        }
    }
}
