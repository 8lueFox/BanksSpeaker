namespace BanksSpeaker.ING.Models.VirtualLedgerAccounts
{
    public class AccountBalance
    {
        public DebtorAccount account { get; set; }
        public VirtualLedgerAccount virtualLedgerAccount { get; set; }
    }
}
