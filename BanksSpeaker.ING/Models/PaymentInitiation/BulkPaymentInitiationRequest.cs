namespace BanksSpeaker.ING.Models.PaymentInitiation
{
    public class BulkPaymentInitiationRequest
    {
        public string requestedExecutionDate { get; set; }
        public Account debtorAccount { get; set; }
        public string debtorName { get; set; }
        public string debtorAgent { get; set; }
        public string batchBookingPreferred { get; set; }
        public string chargeBearer { get; set; }
        public string instructionPriority { get; set; }
        public string serviceLevelCode { get; set; }
        public string localInstrumentCode { get; set; }
        public string categoryPurposeCode { get; set; }
        public Payment[] payments { get; set; }
    }
}
