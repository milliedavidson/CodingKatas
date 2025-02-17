﻿using CodingKatas.Services;
using Xunit;

namespace CodingKatasTests.Helpers
{
    public class NumberBlockTests
    {
        [Fact]
        public void Invalid_Number_Of_Lines_Throws_Argument_Exception()
        {
            var lines = new List<string>
            {
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|"
            };

            Assert.Throws<ArgumentException>(() => new NumberBlock(lines));
        }

        [Fact]
        public void Valid_Number_Of_Lines_Creates_Number_Block()
        {
            var lines = new List<string>
            {
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|",
                "                           "
            };

            var numberBlock = new NumberBlock(lines); // TODO: put this at top of file - gets reused a lot

            Assert.Equal(4, numberBlock.GetNumberCharacters().Count);
        }

        [Fact]
        public void Get_Account_Number_Returns_Account_Number()
        {
            var lines = new List<string>
            {
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|",
                "                           "
            };

            var numberBlock = new NumberBlock(lines);
            var accountNumber = numberBlock.GetAccountNumber();

            Assert.Equal("123456789", accountNumber);
        }
    }
}
