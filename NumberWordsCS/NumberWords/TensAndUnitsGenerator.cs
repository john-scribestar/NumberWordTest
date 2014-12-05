namespace NumberWords
{
  using System.Collections.Generic;

  internal class TensAndUnitsGenerator
  {
    private readonly Dictionary<int, string> tensTwentyToNinetyStrings = new Dictionary<int, string>
                                                      {
                                                        { 2, "twenty" },
                                                        { 3, "thirty" },
                                                        { 4, "fourty" },
                                                        { 5, "fifty" },
                                                        { 6, "sixty" },
                                                        { 7, "seventy" },
                                                        { 8, "eighty" },
                                                        { 9, "ninety" }
                                                      };

    private readonly Dictionary<int, string> unitsAndTeens = new Dictionary<int, string>()
                                              {
                                                 { 1, "one" }, 
                                                 { 2, "two" }, 
                                                 { 3, "three" }, 
                                                 { 4, "four" }, 
                                                 { 5, "five" }, 
                                                 { 6, "six" }, 
                                                 { 7, "seven" }, 
                                                 { 8, "eight" }, 
                                                 { 9, "nine" }, 
                                                 { 10, "ten" }, 
                                                 { 11, "eleven" }, 
                                                 { 12, "twelve" }, 
                                                 { 13, "thirteen" }, 
                                                 { 14, "fourteen" }, 
                                                 { 15, "fithteen" }, 
                                                 { 16, "sixteen" }, 
                                                 { 17, "seventeen" }, 
                                                 { 18, "eighteen" }, 
                                                 { 19, "nineteen" },
                                              };

    public Dictionary<int, string> UnitsAndTeens
    {
      get
      {
        return this.unitsAndTeens;
      }
    }

    public string Generate(int tens, int units)
    {
      string result = this.WordifyInput(tens, units);

      return result;
    }

    private string WordifyInput(int tens, int units)
    {
      if (tens < 2)
      {
        return this.UnitsAndTeens[(tens * 10) + units];
      }

      if (units == 0)
      {
        return this.tensTwentyToNinetyStrings[tens];
      }

      return string.Format("{0} {1}", this.tensTwentyToNinetyStrings[tens], this.UnitsAndTeens[units]);
    }
  }
}
