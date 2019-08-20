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
            var calculator = new Calc();

            Assert.AreEqual(expected, calculator.Add(input));
        }
        [DataTestMethod]
        [DataRow("1", 1)]
        public void Add_WhenSingleNumber_ReturnNumber(string input, int expected)
        {
            var calculator = new Calc();

            Assert.AreEqual(expected, calculator.Add(input));
        }
        [DataTestMethod]
        [DataRow("1,20", 21)]
        public void Add_CommaDelimFormat(string input, int expected)
        {
            var calculator = new Calc();

            Assert.AreEqual(expected, calculator.Add(input));
        }
        //Step 2. support more than two numbers
        [DataTestMethod]
        [DataRow("1,2,3", 6)]
        public void Add_MoreThanTwoNumbers(string input, int expected)
        {
            var calculator = new Calc();

            Assert.AreEqual(expected, calculator.Add(input));
        }
        //Step 3. support newline char as delim
        [DataTestMethod]
        [DataRow("1\n2,3", 6)]
        public void Add_NewLineDelimiter(string input, int expected)
        {
            var calculator = new Calc();

            Assert.AreEqual(expected, calculator.Add(input));
        }
        //Step 4. negative not allowed throw exception
        [DataTestMethod]
        [DataRow("1,2,-3", "negatives not allowed: -3")]
        [DataRow("1,2,3,-4,-5,6,-7", "negatives not allowed: -4,-5,-7")]
        public void Add_Negatives_ThrowsException(string input, string expected)
        {
            var calculator = new Calc();
            
            Assert.AreEqual(expected, Assert.ThrowsException<Exception>(() => calculator.Add(input)).Message);
        }
        //step 5 ignore numbers higher than 1000
        [DataTestMethod]
        [DataRow("3,5,1001", 8)]
        public void Add_WhenNumbersOver1000_DontAdd(string input, int expected)
        {
            var calculator = new Calc();

            Assert.AreEqual(expected, calculator.Add(input));
        }
        //Step 6 suppor single custom delimiter
        [DataTestMethod]
        [DataRow("//;\n2;5", 7)]
        [DataRow("//^\n8^7\n5,2", 22)]
        public void Add_SingleCustomDelimiter(string input, int expected)
        {
           var calculator = new Calc();

            Assert.AreEqual(expected, calculator.Add(input));
        }
        //Step 7 support delimiter of any length
        [DataTestMethod]
        [DataRow("//[***]\n11***22***33", 66)]
        public void Add_AnyLengthDelimiter(string input, int expected)
        {
            var calculator = new Calc();

            Assert.AreEqual(expected, calculator.Add(input));
        }
        
    }
}
