using System;
using System.Collections.Generic;
using System.Linq;
using Step13.Enums;


namespace Step13.Common
{
  public class Calculator : ICalculator
  {
    public string CalcAndPrintEquation(Arguments givenArgs)
    {
      var equation = String.Empty;
      var numbers = givenArgs.Numbers;

      // Find which `Operation` to run then print equation.
      switch (givenArgs.Operation)
      {
        case OperationEnum.Add:
          {
            Console.Write(" adding...  ");
            equation = $"{String.Join("+", numbers)} = {Add(numbers)}";
            Console.WriteLine($"{equation}\n");
            return equation;
          }

        case OperationEnum.Divide:
          {
            Console.Write(" dividing...  ");
            equation = $"{String.Join("/", numbers)} = {Divide(numbers)}";
            Console.WriteLine($"{equation}\n");
            return equation;
          }

        case OperationEnum.Subtract:
          {
            Console.Write(" subtracting...  ");
            equation = $"{String.Join("-", numbers)} = {Subtract(numbers)}";
            Console.WriteLine($"{equation}\n");
            return equation;
          }

        case OperationEnum.Multiply:
          {
            Console.Write(" multiplying...  ");
            equation = $"{String.Join("*", numbers)} = {Multiply(numbers)}";
            Console.WriteLine($"{equation}\n");
            return equation;
          }

        default:
          return equation;
      }
    }


    #region - Operations
    public int Add(IEnumerable<int> numbers)
    {
      return numbers.Sum();
    }

    public int Divide(IEnumerable<int> numbers)
    {
      return numbers.Aggregate((a, b) => a / b);
    }

    public int Subtract(IEnumerable<int> numbers)
    {
      return numbers.Aggregate((a, b) => a - b);
    }

    public int Multiply(IEnumerable<int> numbers)
    {
      return numbers.Aggregate((a, b) => a * b);
    }
    #endregion
  }
}
