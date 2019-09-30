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
            return numbers.Sum();
        }
    }
}