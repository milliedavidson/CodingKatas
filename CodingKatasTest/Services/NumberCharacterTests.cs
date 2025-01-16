using CodingKatas.Services;
using Xunit;

namespace CodingKatasTest.Helpers
{
    public class NumberCharacterTests
    {
        [Fact]
        public void Invalid_Number_Character_Length_Throws_Argument_Exception()
        {
            Assert.Throws<ArgumentException>(() => new NumberCharacter("|||||||||||"));
        }


        // TODO: Finish tests
        [Fact]
        public void Valid_Number_Character_Length_Creates_Number_Character()
        {
            var numberCharacter = new NumberCharacter(" _ | ||_|   ");
        }
    }
}
