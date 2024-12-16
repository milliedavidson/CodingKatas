namespace CodingKatas.UserStory1
{
    public class MapBlocks
    {
        private static readonly Dictionary<string, char> Grid = new Dictionary<string, char>
        {
            { " _ | ||_|   ", '0' },
            { "     |  |   ", '1' },
            { " _  _||_    ", '2' },
            { " _  _| _|   ", '3' },
            { "   |_|  |   ", '4' },
            { " _ |_  _|   ", '5' },
            { " _ |_ |_|   ", '6' },
            { " _   |  |   ", '7' },
            { " _ |_||_|   ", '8' },
            { " _ |_| _|   ", '9' }
        };

        public string MapBlocksToCharacters(NumberBlock numberBlock)
        {
            var accountNumber = new char[9];
            var blocks = numberBlock.GetBlocks();

            for (int i = 0; i < blocks.Count; i++)
            {
                accountNumber[i] = Grid.ContainsKey(blocks[i]) ? Grid[blocks[i]] : '?';
            }

            return new string(accountNumber);
        }
    }
}
