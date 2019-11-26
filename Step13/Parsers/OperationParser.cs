using System;
using Step13.Enums;


namespace Step13.Parsers
{
  public static class OperationParser
  {
    public static OperationEnum Parse(string stringToParse)
    {
      switch (stringToParse.ToUpper())
      {
        case "ADD":
          return OperationEnum.Add;

        case "DIVIDE":
          return OperationEnum.Divide;

        case "SUBTRACT":
          return OperationEnum.Subtract;

        case "MULTIPLY":
          return OperationEnum.Multiply;

        default:
          throw new Exception("Operation command is invalid.");
      }
    }
  }
}
