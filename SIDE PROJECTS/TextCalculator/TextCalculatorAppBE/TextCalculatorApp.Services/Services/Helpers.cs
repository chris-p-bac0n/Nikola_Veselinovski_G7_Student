using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TextCalculatorApp.Services.Services
{
    public static class Helpers
    {
        //SPLITS A STRING INTO A LIST STRINGS 
        public static List<string> GetListOfInputStringParts(string inputString)
        {
            return new List<string>(inputString.Split(',').Select(p => p.Trim()).ToList());
        }
        //THROWS AN EXCEPTION IF THERE IS AN EMPTY NUMBER POSITION
        public static void ReturnEmptyInputPositionsException(List<string> listOfInputStringParts)
        {
            List<string> emptyPositions = new List<string>();
            for (int i = 0; i < listOfInputStringParts.Count; i++)
            {
                if (i == listOfInputStringParts.Count-1 && listOfInputStringParts.LastOrDefault() == "")
                {
                    if (!emptyPositions.Any())
                    {
                        throw new InvalidOperationException("Missing number in last position");
                    }
                    else
                    {
                        emptyPositions.Add("and last position");
                    }
                }
                else if (listOfInputStringParts[i] == "")
                {
                    emptyPositions.Add((i + 1).ToString());
                }
            }
            throw new InvalidOperationException($"Missing number in position {String.Join(", ", emptyPositions)}");
        }
        //SAFELY PARSES A LIST OF STRINGS TO A LIST OF NUMBERS TAKING INTO ACCOUNT DIFFERENT SYSTEM GLOBALIZATIONS
        public static List<double> ConvertListOfStringsToListOfNumbers(List<string> listOfInputStringParts)
        {
            return listOfInputStringParts
               .Select(x => { double y; return double.TryParse(x, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out y) ? y : (double?)null; })
               .Where(y => y.HasValue)
               .Select(y => y.Value)
               .ToList();
        }
    }
}
