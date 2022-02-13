using System;
using Xunit;
using TextCalculatorApp.Services.Services;
using TextCalculatorApp.Services;

namespace TextCalculatorApp.Tests
{
    public class TextCalculatorTests
    {
        //TESTS WHETHER AN EMPTY INPUT STRING RETURNS "0"
        [Fact]
        public void AddMethod_Empty_Input_String_Returns_Zero()
        {
            //ARRANGE
            var test = new TextCalculator();
            string inputString = "";

            //ACT
            string result = test.Add(inputString);

            //ASSERT
            Assert.Equal("0", result);
        }
        //TESTS WHETHER 2 SIMPLE INTEGERS RETURN THE CORRECT RESULT
        [Fact]
        public void AddMethod_Simple_Sum_Test_With_Only_Integers()
        {
            //ARRANGE
            var test = new TextCalculator();
            string inputString = "2,3";

            //ACT
            string result = test.Add(inputString);

            //ASSERT
            Assert.Equal("5", result);
        }
        //TESTS WHETHER 2 SIMPLE DECIMALS RETURN THE CORRECT RESULT
        [Fact]
        public void AddMethod_Simple_Sum_Test_With_Only_Doubles()
        {
            //ARRANGE
            var test = new TextCalculator();
            string inputString = "1.1,2.5";

            //ACT
            string result = test.Add(inputString);

            //ASSERT
            Assert.Equal("3.6", result);
        }
        //TESTS WHETHER A MIX OF DECIMALS, INTEGERS AND A ZERO RETURN THE CORRECT RESULT
        [Fact]
        public void AddMethod_Advanced_Sum_Test_Mix_Of_Decimals_And_Integers()
        {
            //ARRANGE
            var test = new TextCalculator();
            string inputString = "1.1,2.5,5,7,0";

            //ACT
            string result = test.Add(inputString);

            //ASSERT
            Assert.Equal("15.6", result);
        }
        //TESTS WHETHER A MISSING NUMBER IN THE LAST POSITION THROWS AN ERROR
        [Fact]
        public void AddMethod_Missing_Number_Last_Position_Throws_Correct_Error()
        {
            //ARRANGE
            var test = new TextCalculator();
            string inputString = "1.1,2.5,";
            var listOfStringParts = Helpers.GetListOfInputStringParts(inputString);

            //ACT
            Action act = () => test.Add(inputString);

            //ASSERT
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(act);
            Assert.Equal("Missing number in last position", exception.Message);
        }
        //TESTS WHETHER A MULTIPLE NUMBERS IN DIFFERENT POSITIONS THROW AN ERROR
        [Fact]
        public void AddMethod_Missing_Multiple_Number_Positions_Throws_Correct_Error()
        {
            //ARRANGE
            var test = new TextCalculator();
            string inputString = "1.1, ,2.5,";
            var listOfStringParts = Helpers.GetListOfInputStringParts(inputString);

            //ACT
            Action act = () => test.Add(inputString);

            //ASSERT
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(act);
            Assert.Equal("Missing number in position 2, and last position", exception.Message);
        }
        //TESTS WHETHER A NEGATIVE NUMBER THROWS AN EXCEPTION
        [Fact]
        public void AddMethod_Sum_With_Negative_Number_Throws_Error()
        {
            //ARRANGE
            var test = new TextCalculator();
            string inputString = "2,-4,-5";

            //ACT
            Action act = () => test.Add(inputString);

            //ASSERT
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("Negative not allowed : -4, -5", exception.ParamName);
        }
        //TESTS WHETHER A NON-NUMBER THROWS AN ERROR
        [Fact]
        public void AddMethod_Sum_With_Non_Numbers_Throws_Error()
        {
            //ARRANGE
            var test = new TextCalculator();
            string inputString = "6,A,1,/,4";

            //ACT
            Action act = () => test.Add(inputString);

            //ASSERT
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Input contains non-numbers", exception.Message);
        }
    }
}
