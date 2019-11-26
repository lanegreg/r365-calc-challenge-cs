using System.Collections.Generic;
using System.Linq;


namespace Step10.Common
{
  public static class Calculator
  {
    public static int Add(IEnumerable<int> numbers)
    {
      //return numbers.Aggregate(0, (a, b) => a + b);
      return numbers.Sum();
    }
  }
}
