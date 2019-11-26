using System;
using System.Collections.Generic;
using System.Linq;
using Step12.Enums;


namespace Step12.Common
{
  public class Calculator : ICalculator
  {
    public int Add(IEnumerable<int> numbers)
    {
      //return numbers.Aggregate(0, (a, b) => a + b);
      return numbers.Sum();
    }

    public string CalcAndPrintEquation(OperationEnum operationCmd, IEnumerable<int> numbers)
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
