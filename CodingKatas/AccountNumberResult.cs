namespace CodingKatas
{
    public class AccountNumberResult
    {
        public string Number { get; } 
        public int Length { get; set;} // TODO: Create an interface?
        public bool ChecksumIsValid => CalculateChecksum() == 0;
        public bool NumberBlockIsIllegible => Number.Contains('?');
        public string Status => NumberBlockIsIllegible ? "ILL" : (!ChecksumIsValid ? "ERR" : string.Empty);

        public AccountNumberResult(string number)
        {
            if (number.Length != 9)
            {
                throw new ArgumentException("The account number must have 9 digits.");
            }

            Number = number;
        }

        private int CalculateChecksum()
        {
            var checksum = 0;

            for (var i = 0; i < Number.Length; i++)
            {
                checksum += (Number.Length - i) * (Number[i] - '0');
            }

            return checksum % 11;
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Status) ? Number : $"{Number} {Status}";
        }
    }
}
