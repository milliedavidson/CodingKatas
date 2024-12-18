namespace CodingKatas
{
    public static class GenerateInputFile
    {
        public static void CreateInputFile(string filePath)
        {
            var accountNumbers = new List<string>
            {
                "123456789",
                "345882865",
                "457508000",
            };

            var lines = new List<string>();

            foreach (var accountNumber in accountNumbers)
            {
                lines.AddRange(ConvertToOcrFormat(accountNumber));
                lines.Add("");
            }

            File.WriteAllLines(filePath, lines);
        }

        private static List<string> ConvertToOcrFormat(string accountNumber)
        {
            var ocrLines = new string[4] { "", "", "", "" };

            var ocrDigits = new Dictionary<char, string[]>
            {
                { '0', [" _ ", "| |", "|_|", "   "] },
                { '1', ["   ", "  |", "  |", "   "] },
                { '2', [" _ ", " _|", "|_ ", "   "] },
                { '3', [" _ ", " _|", " _|", "   "] },
                { '4', ["   ", "|_|", "  |", "   "] },
                { '5', [" _ ", "|_ ", " _|", "   "] },
                { '6', [" _ ", "|_ ", "|_|", "   "] },
                { '7', [" _ ", "  |", "  |", "   "] },
                { '8', [" _ ", "|_|", "|_|", "   "] },
                { '9', [" _ ", "|_|", " _|", "   "] },
                { '?', ["   ", "   ", "   ", "   "] }
            };

            foreach (var digit in accountNumber)
            {
                for (var i = 0; i < 4; i++)
                {
                    ocrLines[i] += ocrDigits[digit][i];
                }
            }

            return [..ocrLines];
        }
    }
}
