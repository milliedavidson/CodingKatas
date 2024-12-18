namespace CodingKatas
{
    public class NumberBlock
    {
        private readonly List<string> _lines;

        private const int RequiredNumberOfLines = 4;

        public NumberBlock(List<string> lines)
        {
            if (lines is not { Count: RequiredNumberOfLines })
            {
                throw new ArgumentException($"The number block must have {RequiredNumberOfLines} lines.");
            }

            _lines = lines;
        }

        public List<NumberCharacter> GetNumberCharacters()
        {
            var numberCharacters = new List<NumberCharacter>();

            for (var i = 0; i < 9; i++)
            {
                var block =
                    _lines[0].Substring(i * 3, 3) +
                    _lines[1].Substring(i * 3, 3) +
                    _lines[2].Substring(i * 3, 3) +
                    _lines[3].Substring(i * 3, 3);

                numberCharacters.Add(new NumberCharacter(block));
            }

            return numberCharacters;
        }

        public AccountNumberResult GetAccountNumberResult()
        {
            var accountNumber = string.Empty;

            foreach (var numberCharacter in GetNumberCharacters())
            {
                accountNumber += numberCharacter.MappedCharacter;
            }

            return new AccountNumberResult(accountNumber);
        }
    }
}
