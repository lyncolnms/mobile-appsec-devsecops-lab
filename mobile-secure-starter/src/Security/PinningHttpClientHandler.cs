using System;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace MobileSecureStarter.Security
{
    // Pinning por SPKI (SHA-256) conforme recomendações modernas
    // Gere o hash SPKI com: openssl s_client -connect example.com:443 -servername example.com </dev/null 2>/dev/null \
    //   | openssl x509 -pubkey -noout | openssl pkey -pubin -outform der \
    //   | openssl dgst -sha256 -binary | openssl base64
    public class PinningHttpClientHandler : HttpClientHandler
    {
        private readonly string[] _allowedSpkiPins; // ex: "sha256/AbCdEf..."
        private readonly string[] _allowedHosts;

        public PinningHttpClientHandler(string[] allowedSpkiPins, params string[] allowedHosts)
        {
            _allowedSpkiPins = allowedSpkiPins ?? Array.Empty<string>();
            _allowedHosts = allowedHosts?.Select(h => h.ToLowerInvariant()).ToArray() ?? Array.Empty<string>();
            ServerCertificateCustomValidationCallback = ValidateServerCertificate;
        }

        private bool ValidateServerCertificate(HttpRequestMessage _, X509Certificate2? cert, X509Chain? __, SslPolicyErrors sslErrors)
        {
            if (sslErrors != SslPolicyErrors.None)
                return false;

            if (cert == null)
                return false;

            // Hostname check é feito pelo handler antes; podemos reforçar se necessário (SNI/alt names).
            string spkiPin = GetSpkiPin(cert);
            return _allowedSpkiPins.Any(pin => pin.Equals(spkiPin, StringComparison.Ordinal));
        }

        private static string GetSpkiPin(X509Certificate2 cert)
        {
            byte[] spki;
            var rsa = cert.GetRSAPublicKey();
            if (rsa != null)
            {
                spki = rsa.ExportSubjectPublicKeyInfo();
            }
            else
            {
                var ecdsa = cert.GetECDsaPublicKey();
                if (ecdsa != null)
                {
                    spki = ecdsa.ExportSubjectPublicKeyInfo();
                }
                else
                {
                    throw new InvalidOperationException("Chave pública não suportada.");
                }
            }
            
            using var sha = SHA256.Create();
            var hash = sha.ComputeHash(spki);
            var b64 = Convert.ToBase64String(hash);
            return $"sha256/{b64}";
        }
    }
}
