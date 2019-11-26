using System;
using System.Collections.Generic;
using System.Linq;


namespace Step12.Common
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

    public string GetOperationString()
    {
      return _arguments.First();
    }

    public string GetNumbersString()
    {
      return _arguments.Skip(1).First();
    }

    public Options GetOptions()
    {
      return _options;
    }
  }
}
