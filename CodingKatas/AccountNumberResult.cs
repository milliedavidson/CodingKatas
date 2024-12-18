namespace CodingKatas
{
    public class AccountNumberResult
    {
        public string Number { get; } 
        public bool ChecksumIsValid => CalculateChecksum() == 0;
        public bool NumberBlockIsIllegible => Number.Contains('?');
        public string Status => NumberBlockIsIllegible ? "ILL" : (!ChecksumIsValid ? "ERR" : string.Empty); // TODO: enum for status (switch statement?)

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
            return Number
                .Select((t, i) => (Number.Length - i) * int.Parse(t.ToString()))
                .Sum() % 11;
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Status) ? Number : $"{Number} {Status}";
        }
    }
}
