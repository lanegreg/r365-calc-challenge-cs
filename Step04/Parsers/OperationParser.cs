using System;
using Step04.Enums;


namespace Step04.Parsers
{
  public static class OperationParser
  {
    public static OperationEnum Parse(string operation)
    {
      switch (operation.ToUpper())
      {
        case "ADD":
          return OperationEnum.Add;

        default:
          throw new Exception("Operation command is invalid.");
      }
    }
  }
}
