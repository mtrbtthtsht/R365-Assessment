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
        
    }
}
