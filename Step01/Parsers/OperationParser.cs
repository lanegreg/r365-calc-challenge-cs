﻿using System;
using Step01.Enums;


namespace Step01.Parsers
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
