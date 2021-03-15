namespace BanksSpeaker.ING.Models.PaymentInitiation
{
    public class PaymentInitiationRequest
    {
        public string endToEndIdentification { get; set; }
        public Account debtorAccount { get; set; }
        public Amount instructedAmount { get; set; }
        public ExtensionAccount creditorAccount { get; set; }
        public string creditorAgent { get; set; }
        public string creditorName { get; set; }
        public Address creditorAddress { get; set; }
        public string chargeBearer { get; set; }
        public string remittanceInformationUnstructured { get; set; }
        public MemberIdentification clearingSystemMemberIdentification { get; set; }
        public string debtorName { get; set; }
        public string debtorAgent { get; set; }
        public string instructionPriority { get; set; }
        public string serviceLevelCode { get; set; }
        public string localInstrumentCode { get; set; }
        public string categoryPurposeCode { get; set; }
        public string requestedExecutionDate { get; set; }

    }
}
