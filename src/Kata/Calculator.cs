using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "")
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            var separator = new []{",", "\n"};
            if (s.StartsWith("//"))
            {
                var strings = s.Split("\n");
                separator = new[] {strings.First().Replace("//", "")};
                s = strings.Last();
            }
            var numbers = s.Split(separator, StringSplitOptions.None).Select(int.Parse);
            var negatives = numbers.Where(x => x < 0);
            var valid_numbers = numbers.Where(x => x > 0 && x < 1001);
            if (negatives.Any())
            {
                throw new Exception($@"Negatives not allowed: {string.Join(", ", negatives)}");
            }
            return valid_numbers.Sum();
        }
    }
}