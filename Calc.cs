using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calc
    {
        public static int Add(string numbers)
        {
            if (numbers == "") return 0;
            numbers = numbers.Replace("\n", ",");

            var delimiter = ",";
            if (numbers.StartsWith("//"))
            {
                delimiter = numbers[2].ToString();
                numbers = numbers.Substring(4);
            }
            numbers = numbers.Replace("\n", delimiter);
                var values = numbers.Split(',');
                var sum = 0;
                foreach(var n in values)
                {
                    sum += int.Parse(n);
                }
                return sum;
        }
    }
}