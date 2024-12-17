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

            var parseFileEntry = new ParseFileEntry();

            try
            {
                var lines = ReadFile.ReadFileLines(filePath);
                var numberBlocks = parseFileEntry.ParseFileEntryToBlocks(lines);

                foreach (var numberBlock in numberBlocks)
                {
                    try
                    {
                        var accountNumber = numberBlock.GetAccountNumber();

                        Console.WriteLine(accountNumber);
                    }

                    catch { }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
