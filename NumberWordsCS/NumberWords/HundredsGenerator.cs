namespace NumberWords
{
  internal class HundredsGenerator
  {
    public string Generate(int hundreds, int tens, int units)
    {
      string result = this.WordifyInput(hundreds, tens, units);

      return result;
    }

    private string WordifyInput(int hundreds, int tens, int units)
    {
      var input = (hundreds * 100) + (tens * 10) + units;

      var generator = new TensAndUnitsGenerator();

      string result = string.Empty;

      if (hundreds != 0)
      {
        result = generator.UnitsAndTeens[hundreds] + " hundred";
        if (input % 100 == 0)
        {
          return result;
        }
        
        result += " and ";
      }

      // Note John: if our number is greater than 100 we remove 100 to get tens and units
      result += generator.Generate(tens, units);

      return result;
    }
  }
}
