namespace CodingKatas
{
    public class ParseFileEntry
    {
        private const int LinesPerBlock = 4;

        public List<NumberBlock> ParseFileEntryToBlocks(string[] lines)
        {
            var numberBlocks = new List<NumberBlock>();
            var numberOfLines = lines.Length;
            var currentLine = 0;

            while (currentLine < numberOfLines)
            {
                var nextFourLines = lines.Skip(currentLine).Take(LinesPerBlock);
                var newNumberBlock = new NumberBlock(nextFourLines.ToList());

                numberBlocks.Add(newNumberBlock);
                currentLine += LinesPerBlock;
            }

            return numberBlocks;
        }
    }
}
