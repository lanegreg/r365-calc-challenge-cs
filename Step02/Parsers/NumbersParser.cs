using System;
using System.Linq;


namespace Step02.Parsers
{
  public static class NumbersParser
  {
    public static int[] Parse(string stringOfNums)
    {
      var numbers = stringOfNums.Split(',');

      return numbers.Select(Transform).ToArray();
    }

    private static int Transform(string number)
    {
      return Int32.TryParse(number, out _) ? Int32.Parse(number) : 0;
    }
  }
}
