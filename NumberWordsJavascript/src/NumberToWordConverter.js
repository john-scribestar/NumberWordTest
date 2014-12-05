var numberToWordConverter = function (number) {

    // Equivalent To C# HundredsGenerator
    var wordifyHundreds = function (hundreds, tens, units) {

        var actualNumber = (hundreds * 100) + (tens * 10) + units;

        // Equivalent of the units tensAndUnitsGenerator form c#
        var wordifyTensAndUnits = function (tens, units) {

            // functional pattern without params
            // reason is i want these arrays readonly...right way or wrong way?
            // I also need to produce this twice/ share it so values must stay the same
            var unitsAndTeens = function () {
                var that = {};
                var items = [
                    "one",
                    "two",
                    "three",
                    "four",
                    "five",
                    "six",
                    "seven",
                    "eight",
                    "nine",
                    "ten",
                    "eleven",
                    "twelve",
                    "thirteen",
                    "fourteen",
                    "fifteen",
                    "sixteen",
                    "seventeen",
                    "eighteen",
                    "nineteen"
                ];

                that.getWord = function (number) {
                    return 20 > number && number >= 0 ? items[number - 1] : undefined;
                };

                return that;
            };

            var twentyToNinetyTens = function () {
                var that = {};
                var tensAboveTwenty = [
                    "twenty",
                    "thirty",
                    "forty",
                    "fifty",
                    "sixty",
                    "seventy",
                    "eighty",
                    "ninety"
                ];
                that.getWord = function (number) {
                        return tensAboveTwenty[number - 2];
                };

                return that;
            };

            var wordify = function (tens, unit) {
                if (tens < 2) {
                    return unitsAndTeens().getWord((tens * 10) + unit);
                }

                if (units === 0) {
                    return twentyToNinetyTens().getWord(tens);
                }

                return twentyToNinetyTens().getWord(tens) + " " + unitsAndTeens().getWord(unit)
            };

            return wordify(tens, units);
        };

        var result = "";

        if (hundreds !== 0) {
            result = wordifyTensAndUnits(0, hundreds) + " hundred";

            if (actualNumber % 100 === 0) {
                return result;
            }

            result += " and ";
        }

        result += wordifyTensAndUnits(tens, units);

        return result;
    };

    var splitNumberInToThreeDigitSections = function (numberToSplit) {
        var splitInput = [];

        var millions = 0;
        var thousands = 0;
        var hundreds;

        if (numberToSplit >= 1000000) {
            millions = Math.floor(numberToSplit / 1000000);
            splitInput.push(millions);
        }

        if (numberToSplit >= 1000) {
            thousands = Math.floor((numberToSplit - (1000000 * millions)) / 1000);
            splitInput.push(thousands);
        }

        hundreds = numberToSplit - (1000000 * millions) - (1000 * thousands);
        splitInput.push(hundreds);

        return splitInput;
    };

    var getLargeNumberName = function (input) {
        var largeNumberNames = ["thousand", "million"];
        return input === 0 ? undefined : largeNumberNames[input - 1];
    };

    var wordify = function (inputInThreeDigitSections) {

        var result = "";
        var hundredsColumn;
        var tensColumn;
        var unitsColumn;
        var numberPartOfResult;

        var recombine = function (originalValue, number,currentSection,numberOfSections) {
            var largeNumberName;
            largeNumberName = getLargeNumberName( numberOfSections - currentSection -1 );
            if (largeNumberName === undefined && currentSection === numberOfSections -1 && numberOfSections  > 1) {
                originalValue += "and " + number;
            } else {
                originalValue += numberPartOfResult;
            }

            if (largeNumberName !== undefined) {
                originalValue += " " + largeNumberName;
            }

            return originalValue;
        };

        for (var i = 0; i < inputInThreeDigitSections.length; i++) {
            if (i !== 0 && inputInThreeDigitSections[i] !== 0) {
                result += " ";
            }

            if (inputInThreeDigitSections[i] !== 0) {
                hundredsColumn = Math.floor(inputInThreeDigitSections[i] / 100);
                tensColumn = Math.floor((inputInThreeDigitSections[i] - (hundredsColumn * 100)) / 10);
                unitsColumn = inputInThreeDigitSections[i] - (hundredsColumn * 100) - (tensColumn * 10);

                numberPartOfResult = wordifyHundreds(hundredsColumn, tensColumn, unitsColumn);
                largeNumberName = getLargeNumberName(inputInThreeDigitSections.length - 1 - i);
                result = recombine(result, numberPartOfResult, i, inputInThreeDigitSections.length);
            }
        }

        return result;
    };

    // Basically above is defining classes and below is executing code
    var result;
    var inputIsNegative;

    if (number > 999999999) {
        throw number + " is greater than 999999999 and out of range."
    }

    if (number < -999999999) {
        throw number + " is less than -999999999 and out of range."
    }
    inputIsNegative = number < 0;

    if (number === 0) {
        return 'zero';
    }

    // This is the actual working part of this function
    number = Math.abs(number);

    var inputInThreeDigitSections = splitNumberInToThreeDigitSections(number);

    result = wordify(inputInThreeDigitSections);

    if (inputIsNegative) {
        result = "negative " + result;
    }

    return result;
};
