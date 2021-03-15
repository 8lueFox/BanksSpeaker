namespace BanksSpeaker.ING.Models.PaymentInitiation
{
    public class Payment
    {
        public string endToEndIdentification { get; set; }
        public Amount instructedAmount { get; set; }
        public Account creditorAccount { get; set; }
        public string creditorAgent { get; set; }
        public string creditorName { get; set; }
        public Address creditorAddress { get; set; }
        public string remittanceInformationUnstructured { get; set; }
        public string chargeBearer { get; set; }
        public string instructionPriority { get; set; }
        public string serviceLevelCode { get; set; }
        public string localInstrumentCode { get; set; }
        public string categoryPurposeCode { get; set; }
    }
}
