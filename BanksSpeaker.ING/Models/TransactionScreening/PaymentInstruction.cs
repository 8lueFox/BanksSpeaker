namespace BanksSpeaker.ING.Models.TransactionScreening
{
    public class PaymentInstruction
    {
        public string messageId { get; set; }
        public string reconciliationId { get; set; }
        public string endToEndIdentification { get; set; }
        public string legId { get; set; }
        public string requestedExecutionDate { get; set; }
        public Debtor ultimateDebtor { get; set; }
        public Debtor ultimateCreditor { get; set; }
        public IntermediatePSPLeg intermediatePSPLeg1 { get; set; }
        public PSPLeg pspLeg1 { get; set; }
        public PSPLeg pspLeg2 { get; set; }
        public IntermediatePSPLeg intermediatePSPLeg2 { get; set; }
        public RemittanceInfo remittanceInfo { get; set; }
    }
}
