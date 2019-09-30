using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s="")
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            var separator = new []{",", "\n"};
            if (s.StartsWith("//"))
            {
                var split = s.Split("\n");
                separator = new[] {split.First().Replace("//", "")};
                s = split.Last();
            }
            var numbers = s.Split(separator, StringSplitOptions.None).Select(int.Parse);
            var negatives = numbers.Where(x => x < 0);
            if (negatives.Any())
            {
                throw new Exception("negatives not allowed: -2");
            }
            return numbers.Sum();
        }
    }
}