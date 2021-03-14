using BanksSpeaker.ING.Models.PaymentRequestApi;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BanksSpeaker.ING
{
    public class Speaker
    {
        public string KeyId { get; set; }
        public string CertsPath { get; set; }
        public string CertsPass { get; set; }
        public string CertSignName { get; set; }
        public string CertTlsName { get; set; }
        public string HttpHost { get; set; }
        public string AccessToken { get; set; }

        public Speaker()
        {
            KeyId = "e77d776b-90af-4684-bebc-521e5b2614dd";
            CertsPath = @"E:\Projects\INGCommunicator\ING-Communicator\ING-Communicator.ConsoleApp";
            CertsPass = "kacper";
            HttpHost = "https://api.sandbox.ing.com";
            CertSignName = "sign.pfx";
            CertTlsName = "tls.pfx";
        }

        public Speaker(string keyId, string certsPath, string certsPass, string certSignName, string certTlsName)
        {
            KeyId = keyId;
            CertsPath = certsPath;
            CertsPass = certsPass;
            CertSignName = certSignName;
            CertTlsName = certTlsName;
        }

        public async Task SetAccessToken()
        {
            using (var cert = Helper.GetX509Certificate2(CertTlsName, CertsPath, CertsPass))
            {
                var clientHandler = new HttpClientHandler();
                clientHandler.ClientCertificates.Add(cert);
                clientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
                clientHandler.SslProtocols = SslProtocols.Tls12;

                var dataToSend = new Dictionary<string, string>
                {
                    { "grant_type", "client_credentials" }
                };

                using (var content = new FormUrlEncodedContent(dataToSend))
                using (var client = new HttpClient(clientHandler))
                {
                    bool isSuccess = false;
                    while (!isSuccess)
                    {
                        var request = new HttpRequestMessage(HttpMethod.Post, $"{HttpHost}/oauth2/token");
                        request.Content = content;
                        request.AddHeaders(Helper.GetX509Certificate2(CertSignName, CertsPath, CertsPass), await content.DigestValue(), "/oauth2/token", KeyId);
                        System.Console.WriteLine($"===========REQUEST========\n{request}");
                        using (HttpResponseMessage response = await client.SendAsync(request))
                        {
                            isSuccess = response.IsSuccessStatusCode;
                            if (isSuccess)
                            {
                                System.Console.WriteLine($"===========RESPONSE========\n{response}");
                                var responseContent = await response.Content.ReadAsStringAsync();
                                var indexOfEndAccessToken = responseContent.IndexOf(",", 16);
                                AccessToken = responseContent.Substring(17, indexOfEndAccessToken - 18);
                            }
                            else
                            {
                                Thread.Sleep(100);
                            }
                        }
                    }
                }
            }
        }

        public async Task RegisterMarchant()
        {
            using (var cert = Helper.GetX509Certificate2(CertTlsName, CertsPath, CertsPass))
            {
                var clientHandler = new HttpClientHandler();
                clientHandler.ClientCertificates.Add(cert);
                clientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
                clientHandler.SslProtocols = SslProtocols.Tls12;

                var merchant = new Merchant
                {
                    merchantId = "991234567",
                    merchantSubId = "993456",
                    merchantName = "Repcak sp. z o.o.",
                    merchantIBAN = "NL26INGB0003275331",
                    merchantLogo = "iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAYAAACNMs+9AAAAW0lEQVR42mJgYGDYC8L///9ngLKPAXEgiI+MQQBE/ody/iPhM0jsCnwKYXg7IRNhWB2bwu1AfA+IL+E1Ec3xukiKSxmhDJAkIwMewMRAJCBaIQsQ7yBGIUCAAQDZgFqi05MKyQAAAABJRU5ErkJggg==",
                    dailyReceivableLimit = new DailyReceivableLimit
                    {
                        value = 50000.00F,
                        currency = "EUR"
                    },
                    allowIngAppPayments = "Y"
                };

                using (var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(merchant), Encoding.UTF8, "application/json"))
                using (var client = new HttpClient(clientHandler))
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{HttpHost}/payment-requests/registrations");
                    request.Content = content;
                    request.AddHeadersWithAccessToken(Helper.GetX509Certificate2(CertSignName, CertsPath, CertsPass), await content.DigestValue(), "/payment-requests/registrations", KeyId, AccessToken);
                    System.Console.WriteLine($"===========REQUEST========\n{request}");
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        System.Console.WriteLine($"===========RESPONSe========\n{response}");
                        var responseContent = await response.Content.ReadAsStringAsync();
                        System.Console.WriteLine(responseContent);
                    }
                }
            }
        }

        public async Task UpdateRegistration()
        {
            using (var cert = Helper.GetX509Certificate2(CertTlsName, CertsPath, CertsPass))
            {
                var clientHandler = new HttpClientHandler();
                clientHandler.ClientCertificates.Add(cert);
                clientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
                clientHandler.SslProtocols = SslProtocols.Tls12;

                var merchant = new Merchant
                {
                    merchantId = "002345678",
                    merchantSubId = "234567",
                    merchantName = "Another Company BV",
                    merchantIBAN = "NL33INGB8694892022",
                    merchantLogo = "",
                    dailyReceivableLimit = new DailyReceivableLimit
                    {
                        value = 20000.00F,
                        currency = "EUR"
                    },
                    allowIngAppPayments = "N"
                };

                using (var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(merchant), Encoding.UTF8, "application/json"))
                using (var client = new HttpClient(clientHandler))
                {
                    var request = new HttpRequestMessage(HttpMethod.Patch, $"{HttpHost}/payment-requests/registrations");
                    request.Content = content;
                    request.AddHeadersWithAccessTokenWithpatch(Helper.GetX509Certificate2(CertSignName, CertsPath, CertsPass), await content.DigestValue(), "/payment-requests/registrations", KeyId, AccessToken);
                    System.Console.WriteLine($"===========REQUEST========\n{request}");
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        System.Console.WriteLine($"===========RESPONSE========\n{response}");
                        var responseContent = await response.Content.ReadAsStringAsync();
                        System.Console.WriteLine(responseContent);
                    }
                }
            }
        }

        public async Task CreatePaymentRequest()
        {
            using (var cert = Helper.GetX509Certificate2(CertTlsName, CertsPath, CertsPass))
            {
                var clientHandler = new HttpClientHandler();
                clientHandler.ClientCertificates.Add(cert);
                clientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
                clientHandler.SslProtocols = SslProtocols.Tls12;

                var paymentRequest = new PaymentRequest
                {
                    fixedAmount = new FixedAmount
                    {
                        value = 99.95f,
                        currency = "EUR"
                    },
                    variableAmount = new VariableAmount
                    {
                        minimumValue = 90,
                        maximumValue = 100,
                        suggestedValue = 99.95f,
                        currency = "EUR"
                    },
                    validUntil = "2021-3-15T00:00:00.000+01:00",
                    maximumAllowedPayments = 10,
                    maximumReceivableAmount = new FixedAmount
                    {
                        value = 100,
                        currency = "EUR"
                    },
                    purchaseId = "abcdefg1234567890",
                    description = "Your purchase reference abcdefg1234567890",
                    returnUrl = "https://www.webshop.com/return?purchaseId=abcdefg1234567890"
                };

                using (var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(paymentRequest), Encoding.UTF8, "application/json"))
                using (var client = new HttpClient(clientHandler))
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{HttpHost}/payment-requests");
                    request.Content = content;
                    request.AddHeadersWithAccessToken(Helper.GetX509Certificate2(CertSignName, CertsPath, CertsPass), await content.DigestValue(), "/payment-requests", KeyId, AccessToken);

                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        System.Console.WriteLine(responseContent);
                    }
                }
            }
        }
    }
}

