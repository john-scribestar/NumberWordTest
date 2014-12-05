namespace NumberWordTest
{
  using System;

  using NumberWords;

  using NUnit.Framework;

  [TestFixture]
  public class First
  {
    [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
    [TestCase(1000000000)]
    [TestCase(-1000000000)]
    public void GeneratorDoesntAcceptsNumbersOutOfRange(int input)
    {
      var generator = new Generator();
      generator.Generate(input);
    }

    [Test]
    [TestCase(-999999999)]
    [TestCase(999999999)]
    public void GeneratorDoesAcceptNumbersInRange(int input)
    {
      var generator = new Generator();
      generator.Generate(input);
    }

    [Test]
    public void InputIsZero()
    {
      var generator = new Generator();
      string result = generator.Generate(0);

      Assert.IsTrue(result.Equals("zero"));
    }

    [Test]
    public void HundredsColumnEqualsZero()
    {
      var generator = new Generator();
      string result = generator.Generate(010);

      Assert.IsTrue(result.Equals("ten"));
    }

    [Test]
    public void HundredsColumnDoesNotDivideByOneHundred()
    {
      var generator = new Generator();
      string result = generator.Generate(101);

      Assert.IsTrue(result.Equals("one hundred and one"));
    }

    [Test]
    public void HundredsColumnDoesDivideByOneHundred()
    {
      var generator = new Generator();
      string result = generator.Generate(100);

      Assert.IsTrue(result.Equals("one hundred"));
    }

    [Test]
    public void TensColumnIsZero()
    {
      var generator = new Generator();
      string result = generator.Generate(001);

      Assert.IsTrue(result.Equals("one"));
    }

    [Test]
    public void TensColumnIsEqualOrHigherThanTwo()
    {
      var generator = new Generator();
      string result = generator.Generate(030);

      Assert.IsTrue(result.Equals("thirty"));
    }

    [Test]
    public void TensColumnIsLowerThanTwo()
    {
      var generator = new Generator();
      string result = generator.Generate(010);

      Assert.IsTrue(result.Equals("ten"));
    }

    [Test]
    public void UnitColumnNotZero()
    {
      var generator = new Generator();
      string result = generator.Generate(1);

      Assert.IsTrue(result.Equals("one"));
    }

    [Test]
    public void RecombiningNumberGroupsLastGroupContainsAnd()
    {
      var generator = new Generator();
      string result = generator.Generate(100101);

      Assert.IsTrue(result.Equals("one hundred thousand and one hundred and one"));
    }

    [Test]
    public void RecombiningNumberGroupsContainingBlankGroups()
    {
      var generator = new Generator();
      string result = generator.Generate(100000101);

      Assert.IsTrue(result.Equals("one hundred million and one hundred and one"));
    }

    [Test]
    public void RecombiningNumberGroups()
    {
      var generator = new Generator();
      string result = generator.Generate(100000);

      Assert.IsTrue(result.Equals("one hundred thousand"));
    }

    [Test]
    public void NegativeNumberTest()
    {
      var generator = new Generator();
      string result = generator.Generate(-1);

      Assert.IsTrue(result.Equals("negative one"));
    }
  }
}
