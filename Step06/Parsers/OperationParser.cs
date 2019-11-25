using System;
using Step06.Enums;


namespace Step06.Parsers
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
