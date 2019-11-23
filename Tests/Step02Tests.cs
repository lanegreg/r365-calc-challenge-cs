using NUnit.Framework;
using Step02.Parsers;
using Step02.Enums;
using Step02;
using System;


namespace Step02Tests
{
  [TestFixture]
  public class Tests
  {
    [SetUp]
    public void Setup()
    {
    }


    [Test]
    public void test_calculator_add()
    {
      var result = Calculator.Add(new int[] { 1, 5000 });
      Assert.AreEqual(result, 5001);

      result = Calculator.Add(new int[] { 4, -3 });
      Assert.AreEqual(result, 1);

      result = Calculator.Add(new int[] { -4, -3 });
      Assert.AreEqual(result, -7);
    }


    [Test]
    public void test_numbers_parser()
    {
      var result = NumbersParser.Parse("1,5000");
      Assert.AreEqual(result, new int[] { 1, 5000 });

      result = NumbersParser.Parse("4,tytyt");
      Assert.AreEqual(result, new int[] { 4, 0 });

      result = NumbersParser.Parse("6,3,7,2");
      Assert.AreEqual(result, new int[] { 6, 3, 7, 2 });
    }


    [Test]
    public void test_operation_parse()
    {
      var result = OperationParser.Parse("add");
      Assert.AreEqual(result, OperationEnum.Add);

      result = OperationParser.Parse("ADD");
      Assert.AreEqual(result, OperationEnum.Add);

      // Should throw exception b/c of invalid `Operation` rule.
      Assert.Throws(Is.TypeOf<Exception>()
        .And.Message.EqualTo("Operation command is invalid."),
        delegate { OperationParser.Parse("dda"); });
    }
  }
}
