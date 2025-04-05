using System.Net.Http.Json;
using System.Threading.Tasks;

namespace StealthBridgeSDK.Journal
{
    public class JournalClient : StealthBridgeClient
    {
        public JournalClient(string baseAddress = "http://localhost:5000") : base(baseAddress) { }

        public async Task<bool> InJournalAsync(string text)
        {
            var response = await _http.PostAsJsonAsync("/in_journal", new { text });
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<JournalResponse>();
            return result?.Result ?? false;
        }

        public async Task<bool> WaitJournalLineAsync(string text, int timeout)
        {
            var response = await _http.PostAsJsonAsync("/wait_journal_line", new { text, timeout });
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<JournalResponse>();
            return result?.Result ?? false;
        }

        private class JournalResponse
        {
            public bool Result { get; set; }
        }
    }
}