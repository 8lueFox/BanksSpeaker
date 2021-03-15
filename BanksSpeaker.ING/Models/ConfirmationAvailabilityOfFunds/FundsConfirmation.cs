namespace BanksSpeaker.ING.Models.ConfirmationAvailabilityOfFunds
{
    public class FundsConfirmation
    {
        public string cardNumber { get; set; }
        public PsuAccount psuAccount { get; set; }
        public string payee { get; set; }
        public Amount instructedAmount { get; set; }
    }
}
