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

            var delimiter = ",";
            numbers = numbers.Replace("\n", delimiter);

            if (numbers.StartsWith("//"))
            {
                delimiter = numbers[2].ToString();
                numbers = numbers.Substring(4);
            }

            numbers = numbers.Replace("\n", delimiter);

            var values = numbers.Split(',');
            List<int> negatives = new List<int>();
            var sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                int value = int.Parse(values[i]);
                if (value < 0)
                {
                    negatives.Add(value);
                }
                sum += value;
            }
            if (negatives.Count > 0)
            {
                string msg = "negatives not allowed: ";
                for (int i = 0; i < negatives.Count; i++)
                {
                    msg += negatives[i] + ",";
                }
                throw new Exception(msg);
            }
            return sum;
        }
    }
}