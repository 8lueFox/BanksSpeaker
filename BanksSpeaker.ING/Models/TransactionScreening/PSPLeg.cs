namespace BanksSpeaker.ING.Models.TransactionScreening
{
    public class PSPLeg
    {
        public string name { get; set; }
        public AccountInfo accountInfo { get; set; }
        public BankInfo bankInfo { get; set; }
    }
}
