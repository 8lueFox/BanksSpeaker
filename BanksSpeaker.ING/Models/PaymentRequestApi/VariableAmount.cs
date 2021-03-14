using System;
using System.Collections.Generic;
using System.Text;

namespace BanksSpeaker.ING.Models.PaymentRequestApi
{
    class VariableAmount
    {
        public float minimumValue { get; set; }
        public float maximumValue { get; set; }
        public float suggestedValue { get; set; }
        public string currency { get; set; }
    }
}
