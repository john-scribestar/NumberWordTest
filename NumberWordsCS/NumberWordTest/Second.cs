namespace NumberWordTest
{
  using System;

  using NumberWords;

  using NUnit.Framework;

  [TestFixture]
  public class Second
  {
    private Generator generator;

    [SetUp]
    public void Setup()
    {
      this.generator = new Generator();
    }

    [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
    [TestCase(1000000000)]
    [TestCase(-1000000000)]
    public void GeneratorDoesntAcceptsNumbersOutOfRange(int input)
    {
      this.generator.Generate(input);
    }

    [Test]
    [TestCase(-999999999)]
    [TestCase(999999999)]
    public void GeneratorDoesAcceptNumbersInRange(int input)
    {
      this.generator.Generate(input);
    }

    [Test]
    [TestCase(0, Result = "zero")]
    [TestCase(3, Result = "three")]
    [TestCase(9, Result = "nine")]
    public string GeneratorReturnsCorrectTextForSingleDigitNumbersInRange(int input)
    {
      var result = this.generator.Generate(input);
      return result;
    }

    [Test]
    [TestCase(10, Result = "ten")]
    [TestCase(14, Result = "fourteen")]
    [TestCase(19, Result = "nineteen")]
    public string GeneratorReturnsCorrectTextForDoubledDigitNumbersInRangeBelowTwenty(int input)
    {
      var result = this.generator.Generate(input);
      return result;
    }

    [Test]
    [TestCase(21, Result = "twenty one")]
    [TestCase(53, Result = "fifty three")]
    [TestCase(99, Result = "ninety nine")]
    public string GeneratorReturnsCorrectTextForDoubledDigitNumbersInRangeAboveTwenty(int input)
    {
      var result = this.generator.Generate(input);
      return result;
    }

    [Test]
    [TestCase(20, Result = "twenty")]
    [TestCase(50, Result = "fifty")]
    [TestCase(90, Result = "ninety")]
    public string GeneratorReturnsCorrectTextForDoubledDigitNumbersInRangeAboveTwentyAndMultiplesOfTen(int input)
    {
      var result = this.generator.Generate(input);
      return result;
    }

    [Test]
    [TestCase(100, Result = "one hundred")]
    [TestCase(525, Result = "five hundred and twenty five")]
    [TestCase(999, Result = "nine hundred and ninety nine")]
    public string GeneratorReturnsCorrectTextForNumbersInTheHundreds(int input)
    {
      var result = this.generator.Generate(input);
      return result;
    }

    [Test]
    [TestCase(1000, Result = "one thousand")]
    [TestCase(5012, Result = "five thousand and twelve")]
    [TestCase(9999, Result = "nine thousand and nine hundred and ninety nine")]
    public string GeneratorReturnsCorrectTextForNumbersInTheThousands(int input)
    {
      var result = this.generator.Generate(input);
      return result;
    }

    [Test]
    [TestCase(1000000, Result = "one million")]
    [TestCase(5050505, Result = "five million fifty thousand and five hundred and five")]
    [TestCase(999999999, Result = "nine hundred and ninety nine million nine hundred and ninety nine thousand and nine hundred and ninety nine")]
    public string GeneratorReturnsCorrectTextForNumbersInTheMillions(int input)
    {
      var result = this.generator.Generate(input);
      return result;
    }

    [Test]
    [TestCase(1000123, Result = "one million and one hundred and twenty three")]
    [TestCase(9120002, Result = "nine million one hundred and twenty thousand and two")]
    public string GeneratorReturnsCorrectTextForNumbersInRangeWith000Groups(int input)
    {
      var result = this.generator.Generate(input);
      return result;
    }

    [Test]
    [TestCase(-1000123, Result = "negative one million and one hundred and twenty three")]
    [TestCase(-9120002, Result = "negative nine million one hundred and twenty thousand and two")]
    public string GeneratorReturnsCorrectTextForNegativeNumbersInRange(int input)
    {
      var result = this.generator.Generate(input);
      return result;
    }

    [TestCase(1000001, Result = "one million and one")]
    public string OneMillionAndOne(int input)
    {
      var result = this.generator.Generate(input);
      return result;
    }
  }
}
