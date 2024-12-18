namespace CodingKatas
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var filePath = args[0];

            if (args.Length != 2)
            {
                Console.WriteLine(filePath);

                return;
            }

            var inputFilePath = args[0];
            var outputFilePath = args[1];
            var readFile = new ReadFile();
            var parseFileEntry = new ParseFileEntry();

            try
            {
                var lines = ReadFile.ReadFileLines(inputFilePath);
                var numberBlocks = parseFileEntry.ParseFileEntryToBlocks(lines);
                var results = new List<string>();

                foreach (var numberBlock in numberBlocks)
                {
                    try
                    {
                        var accountNumberResult = numberBlock.GetAccountNumberResult();
                        results.Add(accountNumberResult.ToString());

                        File.WriteAllLines(outputFilePath, results);

                        Console.WriteLine($@"Results shown here: {outputFilePath}");
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine($@"Error: {ex.Message}");
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($@"{ex.Message}");
            }
        }
    }
}
