using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s="")
        {
            if(string.IsNullOrEmpty(s))
                return 0;
            var numbers = GetNumbersList(s);
            VerifyNegatives(numbers);
            return numbers.Sum();
        }

        static void VerifyNegatives(IEnumerable<int> numbers)
        {
            var negatives = numbers.Where(x => x < 0);
            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }
        }

        static IEnumerable<int> GetNumbersList(string s)
        {
            var separator = new[] {",", "\n"};
            if (s.StartsWith("//"))
            {
                var strings = s.Split("\n");
                separator = strings.First().Replace("//", "").Replace("[", "").Split("]");
                s = strings.Last();
            }

            var numbers = s.Split(separator, StringSplitOptions.None).Select(int.Parse).Where(x => x < 1001);
            return numbers;
        }
    }
}