using System;
using Step08.Enums;


namespace Step08.Parsers
{
  public static class OperationParser
  {
    public static OperationEnum Parse(string stringToParse)
    {
      switch (stringToParse.ToUpper())
      {
        case "ADD":
          return OperationEnum.Add;

        default:
          throw new Exception("Operation command is invalid.");
      }
    }
  }
}
