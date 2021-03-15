namespace BanksSpeaker.ING.Models.VirtualLedgerAccounts
{
    public class FundReservation
    {
        public DebtorAccount debtorAccount { get; set; }
        public VirtualLedgerAccount virtualLedgerAccount { get; set; }
        public Amount amount { get; set; }
        public string endToEndId { get; set; }
    }
}
