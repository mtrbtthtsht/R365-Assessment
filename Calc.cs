﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calc
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;

            var delimiter = GrabDelimiters(numbers);
            var values = StringToIntegers(numbers, delimiter);
            return SumOfIntegers(values);
            


        }
        private int SumOfIntegers(IEnumerable<int> numbers)
        {
            var filteredNumbers = numbers.Where(x => x <= 1000);
            return filteredNumbers.Sum();
        }

        private IEnumerable<int> StringToIntegers(string numbers, char[] delimiter)
        {
            var inputs = ChangeStringValues(numbers);
            var symbols = GetNumbers(inputs, delimiter);
            var digits = symbols.Select(int.Parse);
            NegativeNumbersThrowException(digits);
            return digits;
        }

        private void NegativeNumbersThrowException(IEnumerable<int> digits)
        {
            var negatives = digits.Where(x => x < 0);
            if (negatives.Any())
            {
                var stringOfNegatives = String.Join(",", negatives);
                throw new Exception($"negatives not allowed: {stringOfNegatives}");
            }
        }

        private string[] GetNumbers(string numbers, char[] delimiter)
        {
            var symbols = numbers.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            return symbols;
        }

        private string ChangeStringValues(string numbers)
        {
            var results = numbers;
            if (numbers.StartsWith("//"))
            {
                var indexOfNewLinedelimiter = numbers.IndexOf('\n');
                results = numbers.Substring(indexOfNewLinedelimiter + 1);
            }
            return results;
        }

        private char[] GrabDelimiters(string numbers)
        {
            var delimiter = new[] { ',', '\n' };
            if (numbers.StartsWith("//"))
            {
                delimiter = AddDelimiters(numbers, delimiter);
            }
            return delimiter;
        }

        private char[] AddDelimiters(string numbers, char[] delimiter)
        {
            var beginning = numbers.IndexOf("//");
            var end = numbers.IndexOf("\n");
            var symbols = numbers.Substring(beginning, (end - beginning)).ToCharArray();
            return JoinDelimiters(delimiter, symbols);
        }

        private char[] JoinDelimiters(char[] delimiter, char[] symbols)
        {
            var delimiterLengthOne = delimiter.Length;
            var newLength = delimiterLengthOne + symbols.Length;
            Array.Resize(ref delimiter, newLength);
            Array.Copy(symbols, 0, delimiter, delimiterLengthOne, symbols.Length);
            return delimiter;
        }
    }
}
