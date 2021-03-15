namespace BanksSpeaker.ING.Models.PaymentInitiation
{
    public class PeriodicPaymentInitiation : PaymentInitiationRequest
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string frequency { get; set; }
        public string dayOfExecution { get; set; }
    }
}
