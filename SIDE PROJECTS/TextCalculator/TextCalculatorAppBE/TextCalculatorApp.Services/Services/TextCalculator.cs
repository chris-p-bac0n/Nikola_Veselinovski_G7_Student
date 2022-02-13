using System;
using System.Linq;
using TextCalculatorApp.Services.Interfaces;
using TextCalculatorApp.Services.Services;

namespace TextCalculatorApp.Services
{
    public class TextCalculator : ITextCalculator
    {
        //RETURNS A SUM OF THE INPUT NUMBERS (FROM THE INPUT STRING)
        public string Add(string inputString)
        {
            //SPLITS THE INPUT STRING IN TO MULTIPLE STRINGS THAT SHOULD HOLD THE NUMBERS
            var listOfInputStringParts = Helpers.GetListOfInputStringParts(inputString);

            //CHECKS IF THE INPUT STRING IS EMPTY AND RETURNS "0" IF IT IS
            if (inputString == "")
            {
                return "0";
            }            

            //CHECKS IF THE LIST OF STRINGS HAS A NUMBER THAT IS MISSING IN ANY POSITION
            if (listOfInputStringParts.Any(x => x == ""))
            {
                Helpers.ReturnEmptyInputPositionsException(listOfInputStringParts);
            }

            //CHECKS IF THE LIST OF STRINGS HAS A NON-NUMBER 
            if (!listOfInputStringParts.All(x => double.TryParse(x, out _)))
            {
                throw new ArgumentException("Input contains non-numbers");
            };

            //PARSES THE LIST OF STRINGS TO A LIST OF DECIMALS
            var listOfNumbers = Helpers.ConvertListOfStringsToListOfNumbers(listOfInputStringParts);

            //CHECKS IF THE LIST OF NUMBERS HAVE NEGATIVE NUMBERS
            if (listOfNumbers.Any(x => x < 0))
            {
                var negativeNumbers = listOfNumbers.Where(x => x < 0).ToList();
                throw new ArgumentOutOfRangeException($"Negative not allowed : {String.Join(", ", negativeNumbers)}");
            };

            //RETURNS A SUM OF THE LIST OF NUMBERS
            return listOfNumbers.Sum().ToString();
        }
    }
}
