using CodingKatas.Enums;
using CodingKatas.Services;
using Xunit;

namespace CodingKatasTest.Helpers
{
    public class AccountNumberTests
    {
        [Fact]
        public void Invalid_Length_Of_Account_Number_Result_Throws_Argument_Exception()
        {
            var invalidNumber = "12345678";

            Assert.Throws<ArgumentException>(() => new AccountNumber(invalidNumber));
        }

        [Fact]
        public void Number_Property_Is_Set()
        {
            var validNumber = "123456789";

            var accountNumber = new AccountNumber(validNumber);

            Assert.Equal(validNumber, accountNumber.Number);
        }

        [Theory]
        [InlineData("123456789")]
        [InlineData("345882865")]
        [InlineData("457508000")]
        public void Valid_Checksum_Returns_True(string validChecksum)
        {
            var accountNumber = new AccountNumber(validChecksum);

            Assert.True(accountNumber.ChecksumIsValid);
        }

        [Theory]
        [InlineData("987654321")]
        [InlineData("123456788")]
        [InlineData("664371495")]
        public void Invalid_Checksum_Returns_False(string invalidChecksum)
        {
            var accountNumber = new AccountNumber(invalidChecksum);

            Assert.False(accountNumber.ChecksumIsValid);
        }

        [Fact]
        public void Illegible_Number_Block_Returns_True_When_Number_Is_Illegible()
        {
            var illegibleNumber = "12345678?";

            var accountNumber = new AccountNumber(illegibleNumber);

            Assert.True(accountNumber.NumberBlockIsIllegible);
        }

        [Fact]
        public void Illegible_Number_Block_Returns_False_When_Number_Is_Legible()
        {
            var legibleNumber = "123456789"; // TODO: Convert these test numbers to constants?

            var accountNumber = new AccountNumber(legibleNumber);

            Assert.False(accountNumber.NumberBlockIsIllegible);
        }

        [Fact]
        public void Status_Returns_ILL_For_Illegible_Number()
        {
            var illegibleNumber = "12345678?";

            var accountNumber = new AccountNumber(illegibleNumber);

            Assert.Equal(StatusEnum.ILL, accountNumber.Status);
        }

    }
}
