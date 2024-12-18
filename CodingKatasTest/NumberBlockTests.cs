using CodingKatas;
using Xunit;

namespace CodingKatasTest
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
            var accountNumberResult = numberBlock.GetAccountNumberResult();

            Assert.Equal("123456789", accountNumberResult.Number);
        }

        [Fact]
        public void Valid_Account_Number_Returns_True()
        {
            var lines = new List<string>
            {
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|",
                "                           "
            };

            var numberBlock = new NumberBlock(lines);
            var accountNumberResult = numberBlock.GetAccountNumberResult();

            Assert.True(accountNumberResult.ChecksumIsValid);
        }

        [Fact]
        public void Invalid_Account_Number_Returns_False()
        {
            var lines = new List<string>
            {
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_|| |",
                "  ||_  _|  | _||_|  ||_|| |",
                "                           "
            };

            var numberBlock = new NumberBlock(lines);
            var accountNumberResult = numberBlock.GetAccountNumberResult();

            Assert.False(accountNumberResult.ChecksumIsValid);
        }
    }
}
