using System;
using System.Collections.Generic;
using System.Linq;


namespace Step04.Parsers
{
  public static class NumbersParser
  {
    private static readonly List<int> _negativeNums = new List<int>();

    public static IEnumerable<int> Parse(string stringOfNums)
    {
      var numbers = stringOfNums
        .Replace("\\n", "\n")
        .Split(new[] { ',', '\n' })
        .Select(Transform);

      // Check for any negative numbers.
      numbers.All(n => { NegativeNumberCheck(n); return true; });
      if (_negativeNums.Any())
      {
        var exMsg = $"Numbers can not be less than zero.\n[{String.Join(",", _negativeNums)}]";
        throw new Exception(exMsg);
      }

      return numbers;
    }

    private static int Transform(string number)
    {
      return Int32.TryParse(number, out _) ? Int32.Parse(number) : 0;
    }

    private static void NegativeNumberCheck(int number)
    {
      if (number < 0)
        _negativeNums.Add(number);
    }
  }
}
