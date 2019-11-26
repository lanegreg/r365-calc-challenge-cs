using System;
using NUnit.Framework;
using Step11.Common;
using Step11.Parsers;
using Step11.Enums;


namespace Step11Tests
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
      var result = NumbersParser.Parse("4,tytyt");
      Assert.AreEqual(result, new int[] { 4, 0 });

      result = NumbersParser.Parse("1,2,3,4,5,6,7,8,9,10,11,12");
      Assert.AreEqual(result, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });

      // Test for using a `\n` delimiter.
      result = NumbersParser.Parse("3,4\n5,6\n9");
      Assert.AreEqual(result, new int[] { 3, 4, 5, 6, 9 });

      // Test for using a custom delimiters.
      result = NumbersParser.Parse("//*\n2*ff*100");
      Assert.AreEqual(result, new int[] { 2, 0, 100 });

      result = NumbersParser.Parse("//[***]\n2***5***13");
      Assert.AreEqual(result, new int[] { 2, 5, 13 });

      result = NumbersParser.Parse("//[@@][**]\n17@@8**3");
      Assert.AreEqual(result, new int[] { 17, 8, 3 });

      result = NumbersParser.Parse("1,5000,5", new Options { MaxInt = "1000" });
      Assert.AreEqual(result, new int[] { 1, 5 });

      result = NumbersParser.Parse("//[@@][**]\n17!8!3", new Options { Delimiter = "!" });
      Assert.AreEqual(result, new int[] { 17, 8, 3 });

      // Should throw exception on a negative number.
      Assert.Throws(Is.TypeOf<Exception>()
        .And.Message.EqualTo("Numbers can not be less than zero.\n[-4,-9]"),
        delegate { NumbersParser.Parse("3,-4,-9", new Options { NoNegativeNumbers = true }); });
    }


    [Test]
    public void test_delimiters_parser()
    {
      var result = DelimitersParser.Parse(new InputFormat("//#\n2#5"));
      Assert.AreEqual(result, new string[] { "#" });

      result = DelimitersParser.Parse(new InputFormat("//[@@@]\n2@@@5@@@13"));
      Assert.AreEqual(result, new string[] { "@@@" });

      result = DelimitersParser.Parse(new InputFormat("//[@@][**]\n17@@8**3"));
      Assert.AreEqual(result, new string[] { "@@", "**" });
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


    [Test]
    public void test_calculator_print_equation()
    {
      var result = Calculator.CalcAndPrintEquation(OperationEnum.Add, NumbersParser.Parse("//[@@][**]\n17@@8**3"));
      Assert.AreEqual(result, "17+8+3 = 28");

      result = Calculator.CalcAndPrintEquation(OperationEnum.Add, NumbersParser.Parse("1,2,3,4,5,6,7,8,9,10,11,12"));
      Assert.AreEqual(result, "1+2+3+4+5+6+7+8+9+10+11+12 = 78");
    }
  }
}
