using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StringCalculator
{
    [TestClass]
    public class StringCalculatorTests
    {
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
    }
}
