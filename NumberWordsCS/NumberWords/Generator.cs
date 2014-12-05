namespace NumberWords
{
  using System;
  using System.Collections.Generic;

  public class Generator
  {
    public string Generate(int input)
    {
      if (input > 999999999)
      {
        throw new ArgumentOutOfRangeException("input");
      }

      if (input < -999999999)
      {
        throw new ArgumentOutOfRangeException("input");
      }

      if (input == 0)
      {
        return "zero";
      }

      // Note John: remember the number is negative or not so we can return this info in the result
      bool inputIsNegative = input < 0;
      input = Math.Abs(input);

      List<int> inputInThreeDigitSections = this.SplitNumberInToThreeDigitSections(input);

      string result = this.WordifyInput(inputInThreeDigitSections);

      if (inputIsNegative)
      {
        result = "negative " + result;
      }

      return result;
    }

    private string GetLargeNumberName(int thousandGroupNumber)
    {
      // Note John: We only go up to millions at the moment
      var largeNumberNames = new Dictionary<int, string> { { 1, "thousand" }, { 2, "million" } };

      return thousandGroupNumber == 0 ? string.Empty : largeNumberNames[thousandGroupNumber];
    }

    private List<int> SplitNumberInToThreeDigitSections(int input)
    {
      var splitInput = new List<int>();

      int millions = input / 1000000;
      int thousands = (input - (1000000 * millions)) / 1000;
      int hundreds = input - (1000000 * millions) - (1000 * thousands);

      if (input >= 1000000)
      {
        splitInput.Add(millions);
      }

      if (input >= 1000)
      {
        splitInput.Add(thousands);
      }

      splitInput.Add(hundreds);

      return splitInput;
    }

    private string WordifyInput(List<int> inputInThreeDigitSections)
    {
      string result = string.Empty;

      for (int i = 0; i < inputInThreeDigitSections.Count; i++)
      {
        int currentValue = inputInThreeDigitSections[i];

        result = this.AddSpaceBeforeSection(currentValue, i, result);

        if (inputInThreeDigitSections[i] != 0)
        {
          int hundredsColumn = currentValue / 100;
          int tensColumn = (currentValue - (hundredsColumn * 100)) / 10;
          int unitsColumn = currentValue - (hundredsColumn * 100) - (tensColumn * 10);

          var hundredsGenerator = new HundredsGenerator();
          string numberPartOfResult = hundredsGenerator.Generate(hundredsColumn, tensColumn, unitsColumn);
          result = this.RecombineSections(result, numberPartOfResult, i, inputInThreeDigitSections.Count);
        }
      }

      return result;
    }

    private string AddSpaceBeforeSection(int value, int currentSection, string originalString)
    {
      string result = originalString;

      if (currentSection != 0 && value != 0)
      {
        result += " ";
      }

      return result;
    }

    private string RecombineSections(string originalValue, string word, int currentSection, int numberOfSections)
    {
      string largenumber = this.GetLargeNumberName(numberOfSections - currentSection - 1);

      if (string.IsNullOrWhiteSpace(largenumber) && currentSection == numberOfSections - 1 && numberOfSections > 1)
      {
        originalValue += "and " + word;
      }
      else
      {
        originalValue += word;
      }

      if (!string.IsNullOrWhiteSpace(largenumber))
      {
        originalValue += " " + largenumber;
      }

      return originalValue;
    }
  }
}