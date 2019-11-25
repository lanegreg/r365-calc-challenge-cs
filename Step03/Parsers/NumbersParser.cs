using System;
using System.Collections.Generic;
using System.Linq;


namespace Step03.Parsers
{
  public static class NumbersParser
  {
    public static IEnumerable<int> Parse(string stringOfNums)
    {
      var numbers = stringOfNums
        .Replace("\\n", "\n")
        .Split(new[] { ',', '\n' });
      
      return numbers.Select(Transform);
    }

    private static int Transform(string number)
    {
      return Int32.TryParse(number, out _) ? Int32.Parse(number) : 0;
    }
  }
}
