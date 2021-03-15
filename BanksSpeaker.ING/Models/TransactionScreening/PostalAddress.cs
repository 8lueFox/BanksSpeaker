namespace BanksSpeaker.ING.Models.TransactionScreening
{
    public class PostalAddress
    {
        public string[] addressLines { get; set; }
        public string postalCode { get; set; }
        public string cityName { get; set; }
        public string countryCode { get; set; }
    }
}
