using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string s = "")
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            var numbers = s.Split(",");
            if (numbers.Count() > 1)
            {
                return int.Parse(numbers[0]) + int.Parse(numbers[1]);
            }

            return int.Parse(numbers[0]);
        }
    }
}