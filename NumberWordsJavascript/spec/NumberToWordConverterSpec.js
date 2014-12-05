describe("GeneratorDoesntAcceptsNumbersOutOfRange", function() {
    it("UpperLimit", function() {
        expect(function(){generator(1000000000)}).toThrow(new Error("1000000000 is greater than 999999999 and out of range."));
    });

	it("LowerLimit", function() {
        expect(function(){generator(-1000000000)}).toThrow(new Error("-1000000000 is less than -999999999 and out of range."));
    });
});

describe("GeneratorDoesAcceptsNumbersInRange", function() {
    it("UpperLimit", function() {
        expect(generator(999999999)).toEqual("999999999");
    });
	
	it("LowerLimit", function() {
        expect(generator(-999999999)).toEqual("-999999999");
    });
});

describe("GeneratorReturnsCorrectTextForSingleDigitNumbersInRange", function() {
    it("0", function() {
        expect(generator(0)).toEqual("zero");
    });
	
	it("3", function() {
        expect(generator(3)).toEqual("three");
    });
	
	it("9", function() {
        expect(generator(9)).toEqual("nine");
    });
});

describe("GeneratorReturnsCorrectTextForDoubledDigitNumbersInRangeBelowTwenty", function() {
    it("10", function() {
        expect(generator(10)).toEqual("ten");
    });
	
	it("14", function() {
        expect(generator(14)).toEqual("fourteen");
    });
	
	it("19", function() {
        expect(generator(19)).toEqual("nineteen");
    });
});

describe("GeneratorReturnsCorrectTextForDoubledDigitNumbersInRangeAboveTwenty", function() {
    it("21", function() {
        expect(generator(21)).toEqual("twenty one");
    });
	
	it("53", function() {
        expect(generator(53)).toEqual("fifty three");
    });
	
	it("99", function() {
        expect(generator(99)).toEqual("ninety nine");
    });
});

describe("GeneratorReturnsCorrectTextForDoubledDigitNumbersInRangeAboveTwentyAndMultiplesOfTen", function() {
    it("20", function() {
        expect(generator(20)).toEqual("twenty");
    });
	
	it("50", function() {
        expect(generator(50)).toEqual("fifty");
    });
	
	it("90", function() {
        expect(generator(90)).toEqual("ninety");
    });
});

describe("GeneratorReturnsCorrectTextForNumbersInTheHundreds", function() {
    it("100", function() {
        expect(generator(100)).toEqual("one hundred");
    });
	
	it("525", function() {
        expect(generator(525)).toEqual("five hundred and twenty five");
    });
	
	it("999", function() {
        expect(generator(999)).toEqual("nine hundred and ninety nine");
    });
});

describe("GeneratorReturnsCorrectTextForNumbersInTheThousands", function() {
    it("1000", function() {
        expect(generator(1000)).toEqual("one thousand");
    });
	
	it("5012", function() {
        expect(generator(5012)).toEqual("five thousand and twelve");
    });
	
	it("9999", function() {
        expect(generator(9999)).toEqual("nine thousand and nine hundred and ninety nine");
    });
});

describe("GeneratorReturnsCorrectTextForNumbersInTheMillions", function() {
    it("1000000", function() {
        expect(generator(1000000)).toEqual("one million");
    });
	
	it("5050505", function() {
        expect(generator(5050505)).toEqual("five million fifty thousand and five hundred and five");
    });
	
	it("999999999", function() {
        expect(generator(999999999)).toEqual("nine hundred and ninety nine million nine hundred and ninety nine thousand and nine hundred and ninety nine");
    });
});

describe("GeneratorReturnsCorrectTextForNumbersInRangeWith000Groups", function() {
    it("1000123", function() {
        expect(generator(1000123)).toEqual("one million and one hundred and twenty three");
    });
	
	it("9120002", function() {
        expect(generator(9120002)).toEqual("nine million one hundred and twenty thousand and two");
    });
});

describe("GeneratorReturnsCorrectTextForNegativeNumbersInRange", function() {
    it("-1000123", function() {
        expect(generator(-1000123)).toEqual("negative one million and one hundred and twenty three");
    });
	
	it("-9120002", function() {
        expect(generator(-9120002)).toEqual("negative nine million one hundred and twenty thousand and two");
    });
});
