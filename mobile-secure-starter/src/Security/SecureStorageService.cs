using System;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace MobileSecureStarter.Security
{
    public interface ISecureStorageService
    {
        Task SetAsync(string key, string value);
        Task<string?> GetAsync(string key);
        void Remove(string key);
        void RemoveAll();
    }

    public class SecureStorageService : ISecureStorageService
    {
        private readonly string _ns;
        public SecureStorageService(string @namespace = "app")
        {
            _ns = @namespace;
        }

        private string N(string key) => $"{_ns}:{key}";

        public async Task SetAsync(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("key");
            await SecureStorage.Default.SetAsync(N(key), value);
        }

        public async Task<string?> GetAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("key");
            return await SecureStorage.Default.GetAsync(N(key));
        }

        public void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("key");
            SecureStorage.Default.Remove(N(key));
        }

        public void RemoveAll()
        {
            SecureStorage.Default.RemoveAll();
        }
    }
}
