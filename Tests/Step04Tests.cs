using System;
using NUnit.Framework;
using Step04.Parsers;
using Step04.Enums;
using Step04;


namespace Step04Tests
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

      result = NumbersParser.Parse("1,2,3,4,5,6,7,8,9,10,11,12");
      Assert.AreEqual(result, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });

      // Test for using a `\n` delimiter.
      result = NumbersParser.Parse("3,4\n5,6\n9");
      Assert.AreEqual(result, new int[] { 3, 4, 5, 6, 9 });

      // Should throw exception on a negative number.
      Assert.Throws(Is.TypeOf<Exception>()
        .And.Message.EqualTo("Numbers can not be less than zero.\n[-4,-9]"),
        delegate { NumbersParser.Parse("3,-4,-9"); });
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
