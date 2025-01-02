using CodingKatas.Enums;
using CodingKatas.Interfaces;

namespace CodingKatas.Helpers
{
    public class AccountNumber : IAccountNumber
    {
        public string Number { get; private set; }
        public bool ChecksumIsValid { get; private set; } // TODO: normal method, return false if number block illegible
        public bool NumberBlockIsIllegible { get; private set; }
        string? IAccountNumber.AccountNumber { get; set; }
        bool IAccountNumber.IsValid { get; set; }

        string? IAccountNumber.Status { get; set; }

        public StatusEnum Status => CalculateStatus(accountNumber);

        // TODO: status happens first, if ILL, i should generate number correction then check possible number)

        public AccountNumber(string number)
        {
            if (number.Length != 9)
            {
                throw new ArgumentException("The account number must have 9 digits.");
            }

            Number = number;

            CalculateResult();
        }

        private StatusEnum CalculateStatus(string accountNumber)
        {
            if (IsIllegible(accountNumber))
            {
                // Generate the number correction

                var possibleNumber = new List<string>();
                if (possibleNumber == null) throw new ArgumentNullException(nameof(possibleNumber));

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
            }

            // var validNumber = possibleNumber.Where(n => new AccountNumber(n).ChecksumIsValid).ToList();

            return (NumberBlockIsIllegible, ChecksumIsValid, validNumber.Count) switch
            {
                (true, _, 1) => StatusEnum.Valid,
                (true, _, > 1) => StatusEnum.AMB,
                (true, _, 0) => StatusEnum.ILL,
                (false, false, 1) => StatusEnum.Valid,
                (false, false, > 1) => StatusEnum.AMB,
                (false, false, 0) => StatusEnum.ERR,
                _ => StatusEnum.Invalid // TODO: make default case invalid? Add the enum
            };
        }

        private static bool IsIllegible(string accountNumber)
        {
            return accountNumber.Contains('?');
        }

        private string CorrectSingleError(string accountNumber)
        {
            // TODO: Implement
        }

        private bool IsValidChecksum(string accountNumber)
        {
            // TODO: Implement
        }

        public void CalculateResult()
        {
            var accountNumber = AccountNumber();
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

        // TODO: do I need this?

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
