namespace CodingKatas.Helpers
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
                "664371495",
                "987654321",
                "123456788",
                "49006771?",
                "86110??36",
                "000000051",
                "1234?678?"
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
            var ocrLines = new[] { "", "", "", "" };

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

            return [.. ocrLines];
        }
    }
}
