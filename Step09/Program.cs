using System;
using Step09.Common;
using Step09.Parsers;


namespace Step09
{
  class Program
  {
    static void Main(string[] args)
    {
      // Usage/Example help blurb.
      Console.WriteLine("Step 09 (Stretch 1)\n");
      Console.WriteLine("=============================================");
      Console.WriteLine("Usage: {operation} {n,n}");
      Console.WriteLine("{operation:string = [add]} {n:integer(n > 0)}");
      Console.WriteLine("Delimiters allowed: [',', '\\n']");
      Console.WriteLine("Example: add 2,6\\n3\nResult: 11");
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

        Printer.PrintEquation(operationCmd, numbers);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
