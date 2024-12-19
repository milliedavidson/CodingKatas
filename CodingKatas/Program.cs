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

            if (!File.Exists(inputFilePath))
            {
                GenerateInputFile.CreateInputFile(inputFilePath);
                Console.WriteLine($@"Input file created here: {inputFilePath}");
            }

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
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine($@"Error processing number block: {ex.Message}");
                    }
                }

                File.WriteAllLines(outputFilePath, results);
                Console.WriteLine($@"Results file created here: {outputFilePath}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($@"{ex.Message}");
            }
        }
    }
}
