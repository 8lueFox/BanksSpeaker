namespace BanksSpeaker.ING.Models.TransactionScreening
{
    public class TransactionInfo
    {
        public string type { get; set; }
        public Pay payIn { get; set; }
        public Pay payOut { get; set; }

    }
}
