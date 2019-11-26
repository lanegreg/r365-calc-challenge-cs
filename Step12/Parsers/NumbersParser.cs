using System;
using System.Collections.Generic;
using System.Linq;
using Step12.Common;


namespace Step12.Parsers
{
  public static class NumbersParser
  {
    public static IEnumerable<int> Parse(string stringToParse)
    {
      return Parse(stringToParse, new Options());
    }

    public static IEnumerable<int> Parse(string stringToParse, Options options)
    {
      var format = new InputFormat(stringToParse);
      var delimiters = options.Delimiter != null ? new string[] { options.Delimiter } : DelimitersParser.Parse(format);

      var numbers = format.GetNumbersToParse()
        .Replace("\\n", "\n")
        .Split(delimiters, StringSplitOptions.None)
        .Select(Transform)
        .Where(i => NotGreaterThanUpperBound(i, Convert.ToInt32(options.MaxInt)));

      if (options.NoNegativeNumbers) CheckForNegativeNumbers(numbers);

      return numbers;
    }


    private static int Transform(string number)
    {
      return Int32.TryParse(number, out _) ? Int32.Parse(number) : 0;
    }


    private static bool NotGreaterThanUpperBound(int number, int upperBound)
    {
      return upperBound <= 0 || number <= upperBound;
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
