namespace CodingKatas.UserStory1
{
    public class ParseFileEntry
    {
        public List<NumberBlock> ParseFileEntryToBlocks(string[] lines)
        {
            var numberBlocks = new List<NumberBlock>();
            var numberOfLines = lines.Length;
            var currentLine = 0;

            while (currentLine < numberOfLines)
            {
                var nextFourLines = lines.Skip(currentLine).Take(4);
                var newNumberBlock = new NumberBlock(nextFourLines.ToList());

                numberBlocks.Add(newNumberBlock);
                currentLine += 4; // TODO: create constant
            }

            return numberBlocks;
        }
    }
}
 