namespace CodingKatas
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: "); // TODO: add file path here

                return;
            }

            var filePath = args[0];
            var readFile = new ReadFile();
            var parseFileEntry = new ParseFileEntry();
            var mapBlocks = new MapBlocks();

            try
            {
                var lines = ReadFile.ReadFileLines(filePath);
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
