namespace BanksSpeaker.ING.Models.TransactionScreening
{
    public class RequestHeader
    {
        public string requestId { get; set; }
        public string transactionType { get; set; }
        public string transactionDirection { get; set; }
        public string applicationCode { get; set; }
        public string businessUnit { get; set; }
        public string blockingFlag { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }
        public string alertGenerationRequired { get; set; }
    }
}
