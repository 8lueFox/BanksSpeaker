using System;
using System.Collections.Generic;
using System.Text;

namespace BanksSpeaker.ING.Models.PaymentRequestApi
{
    class PaymentRequest
    {
        public FixedAmount fixedAmount { get; set; }
        public VariableAmount variableAmount { get; set; }
        public string validUntil { get; set; }
        public int maximumAllowedPayments { get; set; }
        public FixedAmount maximumReceivableAmount { get; set; }
        public string purchaseId { get; set; }
        public string description { get; set; }
        public string returnUrl { get; set; }
    }
}
