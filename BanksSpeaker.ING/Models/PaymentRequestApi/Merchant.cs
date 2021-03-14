using System;
using System.Collections.Generic;
using System.Text;

namespace BanksSpeaker.ING.Models.PaymentRequestApi
{
    class Merchant
    {
        public string merchantId { get; set; }
        public string merchantSubId { get; set; }
        public string merchantName { get; set; }
        public string merchantIBAN { get; set; }
        public string merchantLogo { get; set; }
        public DailyReceivableLimit dailyReceivableLimit { get; set; }
        public string allowIngAppPayments { get; set; }
    }
}
