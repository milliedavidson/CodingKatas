using Xunit; // TODO: see what we have installed

namespace CodingKatasTest
{
    public class ReadFileTests
    {
        [Fact]
        public void File_Not_Found_Throws_File_Not_Found_Exception()
        {
            var readFile = new ReadFile();
            readFile.ReadFileLines("");
        }

        [Fact]
        public void Incorrect_File_Format_Throws_Invalid_Operation_Exception()
        {
            var readFile = new ReadFile();
            readFile.ReadFileLines(
                "Line 0 n/" +
                "Line 1 n/" +
                "Line 2 n/" +
                "Line 3 n/"
                );
        }
    }
}
