using CodingKatas.Services;

namespace CodingKatas
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var filePath = args[0];

            if (args.Length != 1)
            {
                Console.WriteLine(filePath);

                return;
            }

            var inputFilePath = args[0];

            if (!File.Exists(inputFilePath))
            {
                GenerateInputFile.CreateInputFile(inputFilePath);
                Console.WriteLine($@"Input file created here: {inputFilePath}");
            }

            var parseFileContents = new ParseFileContents();

            try
            {
                var lines = ReadFileContents.ReadFileLines(inputFilePath);
                var numberBlocks = parseFileContents.ParseFileContentsToBlocks(lines);
                var results = new List<string>();

                foreach (var numberBlock in numberBlocks)
                {
                    try
                    {
                        var accountNumber = numberBlock.GetAccountNumber();
                        var accountNumberResult = new AccountNumber(accountNumber);

                        results.Add(accountNumberResult.ToString());
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine($@"Error processing number block: {ex.Message}");
                    }
                }

                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($@"{ex.Message}");
            }
        }
    }
}
