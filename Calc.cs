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