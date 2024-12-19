using CodingKatas;
using Xunit;

namespace CodingKatasTest
{
    public class AccountNumberResultTests
    {
        [Fact]
        public void Invalid_Length_Of_Account_Number_Result_Throws_Argument_Exception()
        {
            var invalidNumber = "12345678";

            Assert.Throws<ArgumentException>(() => new AccountNumberResult(invalidNumber));
        }

        [Fact]
        public void Number_Property_Is_Set()
        {
            var validNumber = "123456789";

            var accountNumberResult = new AccountNumberResult(validNumber);

            Assert.Equal(validNumber, accountNumberResult.Number);
        }

        [Theory]
        [InlineData("123456789")]
        [InlineData("345882865")]
        [InlineData("457508000")]
        public void Valid_Checksum_Returns_True(string validChecksum)
        {
            var accountNumberResult = new AccountNumberResult(validChecksum);

            Assert.True(accountNumberResult.ChecksumIsValid);
        }

        [Theory]
        [InlineData ("987654321")]
        [InlineData("123456788")]
        [InlineData("664371495")]
        public void Invalid_Checksum_Returns_False(string invalidChecksum)
        {
            var accountNumberResult = new AccountNumberResult(invalidChecksum);

            Assert.False(accountNumberResult.ChecksumIsValid);
        }

        [Fact]
        public void Illegible_Number_Block_Returns_True_When_Number_Is_Illegible()
        {
            var illegibleNumber = "12345678?";

            var accountNumberResult = new AccountNumberResult(illegibleNumber);

            Assert.True(accountNumberResult.NumberBlockIsIllegible);
        }

        [Fact]
        public void Illegible_Number_Block_Returns_False_When_Number_Is_Legible()
        {
            var legibleNumber = "123456789"; // TODO: Convert these test numbers to constants?

            var accountNumberResult = new AccountNumberResult(legibleNumber);

            Assert.False(accountNumberResult.NumberBlockIsIllegible);
        }

        [Fact]
        public void Status_Returns_ILL_For_Illegible_Number()
        {
            var illegibleNumber = "12345678?";

            var accountNumberResult = new AccountNumberResult(illegibleNumber);

            Assert.Equal(StatusEnum.ILL, accountNumberResult.Status);
        }

    }
}
