using System;
using Microsoft.Extensions.DependencyInjection;
using Step12.Common;
using Step12.Parsers;


namespace Step12
{
  class Program
  {
    static void Main(string[] args)
    {
      #region - Usage/Example help blurb.
      Console.WriteLine("Step 12 (Stretch 4)\n");
      Console.WriteLine("========================================================");
      Console.WriteLine("USAGE: {add} [//[DELIMITER][...]\\n]{n1[,...]} [OPTIONS]");
      Console.WriteLine("OPTIONS:");
      Console.WriteLine(" -delim:char      – single char to override delimiter (defaults are `,`, `\\n`)");
      Console.WriteLine(" -noneg           – default is to allow negative integers");
      Console.WriteLine(" -maxint:n        – default is no upper bound");
      Console.WriteLine("\nEXAMPLES:");
      Console.WriteLine(" % add 2,6\\n3              –> 11");
      Console.WriteLine(" % add 2^6^3 -delim:^      –> 11");
      Console.WriteLine(" % add 2,-6,3 -noneg       –> 'exception thrown'");
      Console.WriteLine(" % add 2,11,3 -maxint:10   –> 5");
      Console.WriteLine(" % add //[**]\\n2**6**3     –> 11");
      Console.WriteLine(" % add //[**][!!]\\n2**6!!3 –> 11");
      Console.WriteLine("========================================================\n");
      //add //[@][!]\n55@33!22 -delim:% -maxint:50 -noneg
      #endregion

      var serviceProvider = new ServiceCollection()
            .AddSingleton<ICalculator, Calculator>()
            .BuildServiceProvider();

      Console.CancelKeyPress += delegate { Console.WriteLine("Good bye!"); };

      try
      {
        while (true)
        {
          var givenArgs = new Arguments(Console.ReadLine());
          var operationCmd = OperationParser.Parse(givenArgs.GetOperationString());
          var numbers = NumbersParser.Parse(givenArgs.GetNumbersString(), givenArgs.GetOptions());

          serviceProvider.GetService<ICalculator>().CalcAndPrintEquation(operationCmd, numbers);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
