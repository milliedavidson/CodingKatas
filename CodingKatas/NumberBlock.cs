namespace CodingKatas
{
    public class NumberBlock
    {
        public List<NumberCharacter> NumberCharacters { get; }

        public NumberBlock(List<string> lines)
        {
            if (lines is not { Count: 4 })
            {
                throw new ArgumentException("The number block must have 4 lines.");
            }

            NumberCharacters = new List<NumberCharacter>();

            for (var i = 0; i < 9; i++)
            {
                var block =
                    lines[0].Substring(i * 3, 3) +
                    lines[1].Substring(i * 3, 3) +
                    lines[2].Substring(i * 3, 3) +
                    lines[3].Substring(i * 3, 3);
                
                NumberCharacters.Add(new NumberCharacter(block));
            }
        }

        public string GetAccountNumber()
        {
            var accountNumber = new char[9];

            for (var i = 0; i < NumberCharacters.Count; i++)
            {
                accountNumber[i] = NumberCharacters[i].MappedCharacter;
            }

            return new string(accountNumber);
        }

        public bool ValidAccountNumber()
        {
            var accountNumber = GetAccountNumber();

            var checksum = 0;

            for (var i = 0; i < accountNumber.Length; i++)
            {
                checksum += (accountNumber.Length - i) * (accountNumber[i] - '0');
            }

            return checksum == 0;
        }
    }
}
