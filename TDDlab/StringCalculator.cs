using System;
using System.Collections.Generic;
using System.Linq;

namespace TDDlab
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            string[] n;
            int result;
            if (String.IsNullOrEmpty(numbers))
                return 0;
            if (Int32.TryParse(numbers, out result))
            {
                if (result < 0)
                    throw new ArgumentOutOfRangeException();
                return result;
            }
            List<char> delimiters = new List<char> { ',', '\n' };
            if (numbers.Contains("//"))
            {
                numbers = numbers.Remove(0, 2);
                char delimiter = numbers[0];
                numbers = numbers.Remove(0, 1);
                delimiters.Add(delimiter);
            }
            n = numbers.Split(delimiters.ToArray());
            result = 0;
            for (int i = 0; i < n.Length; i++)
            {
                var parsedNumber = Int32.Parse(n[i]);
                if (parsedNumber < 0)
                    throw new ArgumentOutOfRangeException();
                if (parsedNumber > 1000)
                    continue;
                result += Int32.Parse(n[i]); 
            }
            return result;
        }
    }
}
