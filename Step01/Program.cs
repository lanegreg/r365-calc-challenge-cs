using System;
using Step01.Parsers;
using Step01.Enums;


namespace Step01
{
  class Program
  {
    static void Main(string[] args)
    {
      // Usage/Example help blurb.
      Console.WriteLine("Step 01\n");
      Console.WriteLine("=============================================");
      Console.WriteLine("Usage: {operation} {n,n}");
      Console.WriteLine("{operation:string = [add]} {n:integer}");
      Console.WriteLine("Example: add 2,6");
      Console.WriteLine("=============================================\n");


      try
      {
        // Create array of given arguments.
        var arguments = Console.ReadLine().Split(' ');

        // First position should be the `Operation` command.
        var operationCmd = OperationParser.Parse(arguments[0]);

        // Transform the `String` representation of all 
        // integers in the list to `Int` and also apply
        // various cli rules during transformation.
        var numbers = NumbersParser.Parse(arguments[1]);


        // Find which `Operation` to run and get result.
        var result = 0;

        switch (operationCmd)
        {
          case OperationEnum.Add:
            {
              Console.WriteLine("Adding . . .");
              result = Calculator.Add(numbers);
              break;
            }

          default:
            break;
        }

        Console.WriteLine("{0}", result);
      }
      catch(Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
