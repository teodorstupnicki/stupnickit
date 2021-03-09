using System;
using Xunit;

namespace TDDlab.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_EmptyString_ShouldReturnZero()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("");
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_SingleNumer_ShouldReturnValue()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("5");
            Assert.Equal(5, result);
        }

        [Fact]
        public void Add_TwoNumersCommaDelimited_ShouldReturnSum()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("2,3");
            Assert.Equal(5, result);
        }

        [Fact]
        public void Add_TwoNumbersNewlineDelimited_ShouldReturnSum()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("2\n3");
            Assert.Equal(5, result);
        }

        [Theory]
        [InlineData("2\n3,7", 12)]
        [InlineData("1,1,8", 10)]
        public void Add_ThreeNumbersCommaOrNewlineDelimited_ShouldReturnSum(string input, int expectedResult)
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add(input);
            Assert.Equal(expectedResult, result);

        }

        [Fact]
        public void Add_NegativeNumbers_ShouldThrowArgumentOutOfRangeException()
        {
            StringCalculator calculator = new StringCalculator();
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.Add("-10,4\n-2"));
        }

        [Theory]
        [InlineData("2000\n3,7", 10)]
        [InlineData("1100,8", 8)]
        public void Add_NumbersGreaterThan1000_ShouldBeIgnored(string input, int expectedResult)
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add(input);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Add_SingleCharDelimiterDefined_ShouldBeAddedToDelimitersAndRetrunSum()
        {
            StringCalculator calculator = new StringCalculator();
            int result = calculator.Add("//#2#5#3");
            Assert.Equal(10, result);
        }
    }
}
