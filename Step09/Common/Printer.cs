using System;
using System.Collections.Generic;
using Step09.Enums;


namespace Step09.Common
{
  public static class Printer
  {
    public static string PrintEquation(OperationEnum operationCmd, IEnumerable<int> numbers)
    {
      var equation = String.Empty;

      // Find which `Operation` to run then print equation.
      switch (operationCmd)
      {
        case OperationEnum.Add:
          {
            Console.WriteLine("Adding . . .");
            equation = $"{String.Join("+", numbers)} = {Calculator.Add(numbers)}";
            Console.WriteLine(equation);
            return equation;
          }

        default:
          return equation;
      }
    }
  }
}
