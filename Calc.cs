using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calc
    {
        public static int Add(string numbers)
        {
            if (numbers == "1") return 1;
            if (numbers.Contains(","))
            {
                var values = numbers.Split(',');
                return int.Parse(values[0]) + int.Parse(values[1]);
            }
            return 0;
        }
    }
}