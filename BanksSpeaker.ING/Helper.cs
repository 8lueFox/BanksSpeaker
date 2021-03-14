using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BanksSpeaker.ING
{
    public static class Helper
    {
        public static X509Certificate2 GetX509Certificate2(string certName, string certPath, string certPass)
        {
            return new X509Certificate2($@"{certPath}\{certName}", certPass);
        }

        public static string SignData(this X509Certificate2 cert, string stringToSign)
        {
            var dataToSign = Encoding.UTF8.GetBytes(stringToSign);
            var signedData = cert.GetRSAPrivateKey().SignData(dataToSign, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            var base64Signature = Convert.ToBase64String(signedData);
            return base64Signature;
        }

        public static string ComputeSHA256HashAsBase64String(this string stringToHash)
        {
            using (var hash = SHA256.Create())
            {
                byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
                return Convert.ToBase64String(result);
            }
        }

        public static async Task<string> DigestValue(this FormUrlEncodedContent content)
        {
            var payload = await content.ReadAsStringAsync();
            return "SHA-256=" + payload.ComputeSHA256HashAsBase64String();
        }
        
        public static async Task<string> DigestValue(this StringContent content)
        {
            var payload = await content.ReadAsStringAsync();
            return "SHA-256=" + payload.ComputeSHA256HashAsBase64String();
        }

        public static void AddHeaders(this HttpRequestMessage request, X509Certificate2 cert, string digest, string reqPath, string keyId)
        {
            var currentDate = DateTime.Now.ToUniversalTime().ToString("r");

            var signingString = $"(request-target): post {reqPath}\ndate: {currentDate}\ndigest: {digest}";
            var signature = cert.SignData(signingString);

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Digest", digest);
            request.Headers.Add("Date", currentDate);
            request.Headers.Add("authorization", $"Signature keyId=\"{keyId}\",algorithm=\"rsa-sha256\",headers=\"(request-target) date digest\",signature=\"{signature}\"");
        }

        public static void AddHeadersWithAccessToken(this HttpRequestMessage request, X509Certificate2 cert, string digest, string reqPath, string keyId, string accessToken)
        {
            var currentDate = DateTime.Now.ToUniversalTime().ToString("r");

            var signingString = $"(request-target): post {reqPath}\ndate: {currentDate}\ndigest: {digest}";
            var signature = cert.SignData(signingString);

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Digest", digest);
            request.Headers.Add("Date", currentDate);
            request.Headers.Add("Authorization", $"Bearer {accessToken}");
            request.Headers.Add("Signature", $"keyId=\"{keyId}\",algorithm=\"rsa-sha256\",headers=\"(request-target) date digest\",signature=\"{signature}\"");
        }

        public static void AddHeadersWithAccessTokenWithpatch(this HttpRequestMessage request, X509Certificate2 cert, string digest, string reqPath, string keyId, string accessToken)
        {
            var currentDate = DateTime.Now.ToUniversalTime().ToString("r");

            var signingString = $"(request-target): patch {reqPath}\ndate: {currentDate}\ndigest: {digest}";
            var signature = cert.SignData(signingString);

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Digest", digest);
            request.Headers.Add("Date", currentDate);
            request.Headers.Add("Authorization", $"Bearer {accessToken}");
            request.Headers.Add("Signature", $"keyId=\"{keyId}\",algorithm=\"rsa-sha256\",headers=\"(request-target) date digest\",signature=\"{signature}\"");
        }
    }
}
