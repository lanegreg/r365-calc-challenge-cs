using System;
using System.Collections.Generic;
using System.Linq;
using Step11.Enums;


namespace Step11.Common
{
  public static class Calculator
  {
    public static int Add(IEnumerable<int> numbers)
    {
      //return numbers.Aggregate(0, (a, b) => a + b);
      return numbers.Sum();
    }

    public static string CalcAndPrintEquation(OperationEnum operationCmd, IEnumerable<int> numbers)
    {
      var equation = String.Empty;

      // Find which `Operation` to run then print equation.
      switch (operationCmd)
      {
        case OperationEnum.Add:
          {
            Console.Write(" adding...  ");
            equation = $"{String.Join("+", numbers)} = {Add(numbers)}";
            Console.WriteLine($"{equation}\n");
            return equation;
          }

        default:
          return equation;
      }
    }
  }
}
