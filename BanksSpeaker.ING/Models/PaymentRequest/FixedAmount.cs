using System;
using System.Collections.Generic;
using System.Text;

namespace BanksSpeaker.ING.Models.PaymentRequestApi
{
    class FixedAmount
    {
        public float value { get; set; }
        public string currency { get; set; }
    }
}
