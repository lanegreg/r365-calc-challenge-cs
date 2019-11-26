using System;
using System.Collections.Generic;
using System.Linq;
using Step13.Enums;
using Step13.Parsers;


namespace Step13.Common
{
  public class Arguments
  {
    private readonly IEnumerable<string> _arguments;
    private readonly Options _options;


    public Arguments(string givenArgs)
    {
      // Create an array of the given arguments.
      _arguments = givenArgs.Split(' ');

      if (_arguments.Count() < 2)
        throw new Exception("Invalid arguments were provided.");


      // Check for OPTIONS.
      var ignoreCase = StringComparison.InvariantCultureIgnoreCase;
      var optDelim = _arguments.FirstOrDefault(i => i.StartsWith("-delim", ignoreCase));
      var optMaxInt = _arguments.FirstOrDefault(i => i.StartsWith("-maxint", ignoreCase));

      _options = new Options
      {
        NoNegativeNumbers = _arguments.FirstOrDefault(i => i.StartsWith("-noneg", ignoreCase))?.Any() ?? false,
        Delimiter = optDelim?.Split(":")[1],
        MaxInt = optMaxInt?.Split(":")[1]
      };
    }

    public OperationEnum Operation
    {
      get { return OperationParser.Parse(_arguments.First()); }
    }

    public IEnumerable<int> Numbers
    {
      get
      {
        return NumbersParser.Parse(_arguments.Skip(1).First(), _options);
      }
    }
  }
}
