namespace CodingKatas
{
    public class MapBlocks
    {
        public string MapBlocksToCharacters(NumberBlock numberBlock)
        {
            var accountNumber = new char[9];
            var numberCharacters = numberBlock.NumberCharacters;

            for (int i = 0; i < numberCharacters.Count; i++)
            {
                accountNumber[i] = numberCharacters[i].MappedCharacter;
            }

            return new string(accountNumber);
        }
    }
}
