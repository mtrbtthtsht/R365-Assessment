using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StringCalculator
{
    [TestClass]
    public class StringCalculatorTests
    {
        //Step 1. support max 2 numbers
        //comma delim format
        //missing numbers = 0
        [DataTestMethod]
        [DataRow("",0)]
        public void Add_EmptyString(string input, int expected)
        {
            Assert.AreEqual(expected, Calc.Add(input));
        }
        [DataTestMethod]
        [DataRow("1,20", 21)]
        public void Add_CommaDelimFormat(string input, int expected)
        {

            Assert.AreEqual(expected, Calc.Add(input));
        }
        //Step 2. support more than two numbers
        [DataTestMethod]
        [DataRow("1,2,3", 6)]
        public void Add_MoreThanTwoNumbers(string input, int expected)
        {
            Assert.AreEqual(expected, Calc.Add(input));
        }
        //Step 3. support newline char as delim
        [DataTestMethod]
        [DataRow("1\n2,3", 6)]
        public void Add_NewLineDelimiter(string input, int expected)
        {
            Assert.AreEqual(expected, Calc.Add(input));
        }
        //Step 4. negative not allowed throw exception
        [DataTestMethod]
        [DataRow("1,2,-3", "negatives not allowed: -3,")]
        [DataRow("1,2,3,-4,-5,6,-7", "negatives not allowed: -4,-5,-7,")]
        public void Add_Negatives_ThrowsException(string input, string expected)
        {
            Assert.AreEqual(expected, Assert.ThrowsException<Exception>(() => Calc.Add(input)).Message);
        }
        //step 5 ignore numbers higher than 1000
        [DataTestMethod]
        [DataRow("3,5,1001", 8)]
        public void Add_WhenNumbersOver1000_DontAdd(string input, int expected)
        {
            Assert.AreEqual(expected, Calc.Add(input));
        }
    }
}
