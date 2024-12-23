using Xunit;
using CodingKatas.Helpers;

namespace CodingKatasTest.Helpers
{
    public class ReadFileContentsTests
    {
        [Fact]
        public void File_Not_Found_Throws_File_Not_Found_Exception()
        {
            var readFile = new ReadFileContents();
            ReadFileContents.ReadFileLines("");
        }

        [Fact]
        public void Incorrect_File_Format_Throws_Invalid_Operation_Exception()
        {
            var readFileContents = new ReadFileContents(); // TODO: Finish

            ReadFileContents.ReadFileLines(
                "Line 0 n/" +
                "Line 1 n/" +
                "Line 2 n/" +
                "Line 3 n/"
                );
        }
    }
}
