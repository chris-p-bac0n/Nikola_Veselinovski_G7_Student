using System.Collections.Generic;


namespace NumberApp.Services
{
    public static class NumbersLexicon
    {
        public static string[] ones = new string[]
            {
                "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
            };

        public static string[] onesAndTens = new string[]
        {
                "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        };

        public static string[] tens = new string[]
        {
                "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        };

        public static string[] highTens = new string[]
        {
                "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety"
        };

        public static Dictionary<string, int> numberTable = new Dictionary<string, int>
            {
                {"zero",0},{"one",1},{"two",2},{"three",3},{"four",4},
                {"five",5},{"six",6},{"seven",7},{"eight",8},{"nine",9},
                {"ten",10},{"eleven",11},{"twelve",12},{"thirteen",13},
                {"fourteen",14},{"fifteen",15},{"sixteen",16},
                {"seventeen",17},{"eighteen",18},{"nineteen",19},{"twenty",20},
                {"thirty",30},{"forty",40},{"fifty",50},{"sixty",60},
                {"seventy",70},{"eighty",80},{"ninety",90}
            };
    }
}
