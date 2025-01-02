namespace CodingKatas.Interfaces
{
    public interface IAccountNumber
    {
        public string? AccountNumber { get; set; }
        public bool IsValid { get; set; }
        public string? Status { get; set; }
    }
}
