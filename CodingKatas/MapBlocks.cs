namespace CodingKatas
{
    public class MapBlocks
    {
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
