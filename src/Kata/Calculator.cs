using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s="")
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }


            var separator = new []{"\n",","};
            if (s.Contains("//"))
            {
                var strings = s.Split("\n");
                separator = new[] {strings.First().Replace("//", "")};
                s = strings.Last();
            }
            var numbers = s.Split(separator, StringSplitOptions.None).Select(int.Parse).Where(x=>x<1001);
            var negatives = numbers.Where(x => x < 0);
            if (negatives.Any())
            {
                throw new Exception($@"Negatives not allowed: {string.Join(", ", negatives)}");
            }
            return numbers.Sum();
        }
    }
}