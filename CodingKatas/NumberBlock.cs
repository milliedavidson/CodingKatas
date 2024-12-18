namespace CodingKatas
{
    public class NumberBlock
    {
        private readonly List<string> _lines;

        const int RequiredNumberOfLines = 4;

        public NumberBlock(List<string> lines)
        {
            if (lines is not { Count: RequiredNumberOfLines })
            {
                throw new ArgumentException($"The number block must have {RequiredNumberOfLines} lines.");
            }

            _lines = lines;
        }

        public List<NumberCharacter> GetNumberCharacters() // TODO: check tests
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

        public AccountNumberResult GetAccountNumberResult() // TODO: this can be the account number object with checksum etc. Test this method
        {
            var accountNumber = string.Empty;

            foreach (var numberCharacter in GetNumberCharacters())
            {
                accountNumber += numberCharacter.MappedCharacter;
            }

            return new AccountNumberResult(accountNumber);
        }

        public bool ValidAccountNumber() // TODO: make private call internally
        {
            var accountNumberResult = GetAccountNumberResult();
            var accountNumber = accountNumberResult.Number;
            var checksum = 0;

            for (var i = 0; i < accountNumber.Length; i++)
            {
                checksum += (accountNumber.Length - i) * (accountNumber[i] - '0');
            }

            return checksum % 11 == 0;
        }


    }
}
