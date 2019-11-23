using System;
using System.Linq;


namespace Step01.Parsers
{
  public static class NumbersParser
  {
    public static int[] Parse(string stringOfNums)
    {
      var numbers = stringOfNums.Split(',');

      if (numbers.Length > 2)
        throw new Exception("More than two numbers were provided.");

      return numbers.Select(Transform).ToArray();
    }

    private static int Transform(string number)
    {
      return Int32.TryParse(number, out _) ? Int32.Parse(number) : 0;
    }
  }
}
