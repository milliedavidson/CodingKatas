using CodingKatas.Enums;
using CodingKatas.Interfaces;

namespace CodingKatas.Services
{
    public class AccountNumber : IAccountNumber
    {
        public string Number { get; private set; }
        public bool ChecksumIsValid { get; private set; }
        public bool NumberBlockIsIllegible { get; private set; }
        string? IAccountNumber.AccountNumber { get; set; }
        bool IAccountNumber.IsValid { get; set; }
        string? IAccountNumber.Status { get; set; }
        public StatusEnum Status => CalculateStatus(Number);

        public AccountNumber(string number)
        {
            if (number.Length != 9)
            {
                throw new ArgumentException("The account number must have 9 digits.");
            }

            Number = number;

            CalculateResult();
        }

        public void CalculateResult()
        {
            NumberBlockIsIllegible = IsIllegible(Number);
            ChecksumIsValid = IsValidChecksum(Number);
        }

        public override string ToString()
        {
            var possibleNumber = GeneratePossibleNumberCorrection()
                .Where(n => new AccountNumber(n).ChecksumIsValid)
                .ToList();

            return Status switch
            {
                StatusEnum.Valid => Number,
                StatusEnum.AMB => $"{Number} AMB [{string.Join(", ", possibleNumber)}]",
                StatusEnum.ILL => $"{Number} ILL",
                StatusEnum.ERR => $"{Number} ERR",
                _ => Number
            };
        }

        private StatusEnum CalculateStatus(string accountNumber)
        {
            if (IsIllegible(accountNumber))
            {
                return StatusEnum.ILL;
            }

            return !IsValidChecksum(accountNumber) ? StatusEnum.ERR : StatusEnum.Valid;
        }

        private static bool IsValidChecksum(string accountNumber)
        {
            var checksum = accountNumber
                .Select((c, i) => (accountNumber.Length - i) * int.Parse(c.ToString()))
                .Sum();

            return checksum % 11 == 0;
        }

        private static bool IsIllegible(string accountNumber)
        {
            return accountNumber.Contains('?');
        }

        private List<string> GeneratePossibleNumberCorrection()
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
                    var possibleCharacter = new List<char>
                    {
                        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
                    };
                }
            }

            return possibleNumber;
        }
    }
}
