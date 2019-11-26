using System;
using Microsoft.Extensions.DependencyInjection;
using Step13.Common;
using Step13.Parsers;


namespace Step13
{
  class Program
  {
    static void Main(string[] args)
    {
      #region - Usage/Example help blurb.
      Console.WriteLine("Step 13 (Stretch 5)\n");
      Console.WriteLine("========================================================");
      Console.WriteLine("USAGE: {add|subtract|multiply|divide} [//[DELIMITER][...]\\n]{n1[,...]} [OPTIONS]");
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

          serviceProvider.GetService<ICalculator>().CalcAndPrintEquation(givenArgs);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
