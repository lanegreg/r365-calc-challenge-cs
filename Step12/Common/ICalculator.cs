using System.Collections.Generic;
using Step12.Enums;


namespace Step12.Common
{
  public interface ICalculator
  {
    int Add(IEnumerable<int> numbers);
    string CalcAndPrintEquation(OperationEnum operationCmd, IEnumerable<int> numbers);
  }
}
