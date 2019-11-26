using System.Collections.Generic;


namespace Step13.Common
{
  public interface ICalculator
  {
    int Add(IEnumerable<int> numbers);
    int Divide(IEnumerable<int> numbers);
    int Subtract(IEnumerable<int> numbers);
    int Multiply(IEnumerable<int> numbers);
    string CalcAndPrintEquation(Arguments givenArgs);
  }
}
