using System;
using System.Collections.Generic;
using System.Linq;
using Step10.Common;


namespace Step10.Parsers
{
  public static class NumbersParser
  {
    public static IEnumerable<int> Parse(string stringToParse)
    {
      var format = new InputFormat(stringToParse);

      var numbers = format.GetNumbersToParse()
        .Replace("\\n", "\n")
        .Split(DelimitersParser.Parse(format),StringSplitOptions.None)
        .Select(Transform)
        .Where(NotGreaterThanOneThousand);

      CheckForNegativeNumbers(numbers);

      return numbers;
    }


    private static int Transform(string number)
    {
      return Int32.TryParse(number, out _) ? Int32.Parse(number) : 0;
    }


    private static bool NotGreaterThanOneThousand(int number)
    {
      return number <= 1000;
    }


    private static void CheckForNegativeNumbers(IEnumerable<int> numbers)
    {
      var _negativeNums = new List<int>();

      numbers.All(num => {
        if (num < 0)
          _negativeNums.Add(num);

        return true;
      });

      if (_negativeNums.Any())
      {
        var exMsg = $"Numbers can not be less than zero.\n[{String.Join(",", _negativeNums)}]";
        throw new Exception(exMsg);
      }
    }
  }
}
