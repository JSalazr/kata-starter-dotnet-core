using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "")
        {
            if(string.IsNullOrEmpty(s))
                return 0;
            var separator = new []{",", "\n"};
            if (s.Contains("//"))
            {
                var strings = s.Split("\n");
                separator = new[] {strings.First().Replace("//", "")};
                s = strings.Last();
            }
            var numbers = s.Split(separator,StringSplitOptions.None).Select(int.Parse);
            foreach (var number in numbers)
            {
                if(number < 0)
                    throw new Exception("negatives not allowed: -2");
            }
            return numbers.Sum();

        }
    }
}