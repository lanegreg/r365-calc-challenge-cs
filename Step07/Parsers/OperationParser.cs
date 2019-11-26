using System;
using Step07.Enums;


namespace Step07.Parsers
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
