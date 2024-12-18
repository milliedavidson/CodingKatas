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

        [Fact]
        public void Valid_Checksum_Returns_True()
        {
            var validChecksum = "123456789";

            var accountNumberResult = new AccountNumberResult(validChecksum);

            Assert.True(accountNumberResult.ChecksumIsValid);
        }

        [Fact]
        public void Invalid_Checksum_Returns_False()
        {
            var invalidChecksum = "12345678";

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
            var legibleNumber = "123456789";

            var accountNumberResult = new AccountNumberResult(legibleNumber);

            Assert.False(accountNumberResult.NumberBlockIsIllegible);
        }

    }
}
