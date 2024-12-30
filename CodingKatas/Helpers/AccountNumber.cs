using CodingKatas.Enums;
using CodingKatas.Interfaces;

namespace CodingKatas.Helpers
{
    public class AccountNumber : IAccountNumber
    {
        // TODO: Make into private sets
        public string Number { get; }
        public bool ChecksumIsValid => CalculateChecksum() == 0; // TODO: normal method, return false if number block illegible
        public bool NumberBlockIsIllegible { get; private set; }
        public StatusEnum Status => CalculateStatus(accountNumber);

        public AccountNumber(string number)
        {
            if (number.Length != 9)
            {
                throw new ArgumentException("The account number must have 9 digits.");
            }

            Number = number;

            CalculateResult();
        }

        private bool IsIllegible(string accountNumber)
        {
            return accountNumber.Contains('?');
        }

        private string CalculateStatus(string accountNumber)
        {
            if (IsIllegible(accountNumber))
            {
                return "ILL";
            }

            else
            {
                var possibleNumber = GeneratePossibleNumberCorrection(); // TODO: order is wrong (status happens first, if ILL, i should generate number correction then check possible number)
                var validNumber = possibleNumber.Where(n => new AccountNumber(n).ChecksumIsValid).ToList();

                return (NumberBlockIsIllegible, ChecksumIsValid, validNumber.Count) switch
                {
                    (true, _, 1) => StatusEnum.Valid,
                    (true, _, > 1) => StatusEnum.AMB,
                    (true, _, 0) => StatusEnum.ILL,
                    (false, false, 1) => StatusEnum.Valid,
                    (false, false, > 1) => StatusEnum.AMB,
                    (false, false, 0) => StatusEnum.ERR,
                    _ => StatusEnum.Valid // TODO: make default case invalid? Add the enum
                };
            }
        }

        private List<string> GeneratePossibleNumberCorrection() // TODO: don't do this if more than 1 ?
        {
            var possibleNumber = new List<string>();

            for (var i = 0; i < Number.Length; i++)
            {
                if (Number[i] == '?')
                {
                    for (var n = 0; n <= 9; n++)
                    {
                        var numberCorrected = Number[..i] + n + Number[(i + 1)..];
                        possibleNumber.Add(numberCorrected);
                    }
                }

                else
                {
                    var originalCharacter = Number[i];
                    var possibleCharacters = new List<char>
                    {
                        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
                    };

                    possibleCharacters.Remove(originalCharacter);

                    possibleNumber.AddRange(possibleCharacters.Select(possibleCharacter =>
                        Number[..i] + possibleCharacter + Number[(i + 1)..]));
                }
            }

            return possibleNumber;
        }
        private string CorrectSingleError(string accountNumber)
        {
        }

        private bool IsValidChecksum(string accountNumber)
        {

        }

        public void CalculateResult()
        {
            var accountNumber = GetAccountNumber();
            var status = CalculateStatus(accountNumber);

            if (status == "ILL")
            {
                var possibleNumbers = GeneratePossibleNumberCorrection();
            }

            var isValid = IsValidChecksum(accountNumber);
        }

        private bool CalculateChecksum()
        {
            return Number
                .Select((c, i) => (Number.Length - i) * int.Parse(c.ToString()))
                .Sum() % 11;
        }

        // TODO: calculate checksum is valid (incl. numberblock ill)
        // TODO: DecideNumberBlockStatus. If ILL, work out if there's another possibleNumber
        // TODO: find position of ? (iterate 0 - 9, swap ?), calculate checksum
        private string DecideStatus(string accountNumber)
        {
            if (IsIllegible(accountNumber))
            {
                return "ILL";
            }

            return !IsValidChecksum(accountNumber) ? "ERR" : "VALID";
        }

        public override string ToString()
        {
            return Status switch
            {
                StatusEnum.Valid => Number,
                StatusEnum.AMB => $"{Number} AMB [{string.Join(", ", GeneratePossibleNumberCorrection().Where(n =>
                    new AccountNumber(n).ChecksumIsValid))}]",
                StatusEnum.ILL => $"{Number} ILL",
                StatusEnum.ERR => $"{Number} ERR",
                _ => Number
            };
        }
    }
}
