using System;
using Xunit;
using TextCalculatorApp.Services.Services;
using System.Collections.Generic;

namespace TextCalculatorApp.Tests
{
    public class HelpersTests
    {
        //TESTS WHETHER THE FORMAT OF RETURNED LIST OF STRINGS IS VALID
        [Fact]
        public void GetListOfInputStringParts_Returns_List_In_Correct_Format()
        {
            //ARRANGE
            string inputString = "1.1,2.5";

            //ACT
            var result = Helpers.GetListOfInputStringParts(inputString);

            //ASSERT
            Assert.Collection(result, 
                item => item.Contains("1.1"),
                item => item.Contains("2.5"));
        }
        //TESTS WHETHER AN EXCEPTION REGARDING AN EMPTY LAST NUMBER POSITION IS THROWN
        [Fact]
        public void ReturnEmptyInputPositionsException_Returns_Empty_Last_Position()
        {
            //ARRANGE
            string inputString = "1.1,2.5,";
            var listOfStringParts = Helpers.GetListOfInputStringParts(inputString);
            
            //ACT
            Action act = () => Helpers.ReturnEmptyInputPositionsException(listOfStringParts);
            
            //ASSERT
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(act);
            Assert.Equal("Missing number in last position", exception.Message);
        }
        //TESTS WHETHER AN EXCEPTION REGARDING AN MULTIPLE EMPTY NUMBER POSITIONS IS THROWN
        [Fact]
        public void ReturnEmptyInputPositionsException_Returns_Multiple_Empty_Positions()
        {
            //ARRANGE
            string inputString = "1.1, ,2.5,";
            var listOfStringParts = Helpers.GetListOfInputStringParts(inputString);
            
            //ACT
            Action act = () => Helpers.ReturnEmptyInputPositionsException(listOfStringParts);
            
            //ASSERT
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(act);
            Assert.Equal("Missing number in position 2, and last position", exception.Message);
        }
        //TESTS WHETHER THE LIST OF STRINGS IS CORRECTLY PARSED INTO A LIST OF NUMBERS
        [Fact]
        public void ConvertListOfStringsToListOfNumbers_Converts_Succesfully()
        {
            //ARRANGE
            string inputString = "1.1,2.5,A, ";
            var listOfStringParts = Helpers.GetListOfInputStringParts(inputString);

            //ACT
            var result = Helpers.ConvertListOfStringsToListOfNumbers(Helpers.GetListOfInputStringParts(inputString));
            List<double> expected = new List<double> { 1.1, 2.5 };

            //ASSERT
            Assert.Equal(expected, result);
        }
    }
}
