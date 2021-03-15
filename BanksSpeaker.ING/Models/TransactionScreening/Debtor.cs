namespace BanksSpeaker.ING.Models.TransactionScreening
{
    public class Debtor
    {
        public string Name { get; set; }
        public PostalAddress ultimateDebtor { get; set; }
        public string payInMethod { get; set; }
        public AccountInfo accountInfo { get; set; }
        public BankInfo bankInfo { get; set; }
    }
}
