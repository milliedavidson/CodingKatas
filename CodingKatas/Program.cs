namespace CodingKatas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filePath = args[0];
            var readFile = new ReadFile();
            var parseFileEntry = new ParseFileEntry();
            var mapBlocks = new MapBlocks();

            try
            {
                var lines = readFile.ReadFileLines(filePath);
                var numberBlocks = parseFileEntry.ParseFileEntryToBlocks(lines);

                foreach (var numberBlock in numberBlocks)
                {
                    var accountNumber = mapBlocks.MapBlocksToCharacters(numberBlock);

                    Console.WriteLine(accountNumber);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
