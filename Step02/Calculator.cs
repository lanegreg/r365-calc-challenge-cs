using System.Linq;


namespace Step02
{
  public static class Calculator
  {
    public static int Add(int[] numbers)
    {
      //return numbers.Aggregate(0, (a, b) => a + b);
      return numbers.Sum();
    }
  }
}
