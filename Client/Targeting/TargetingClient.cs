using System.Net.Http.Json;
using System.Threading.Tasks;

namespace StealthBridgeSDK.Targeting
{
    public class TargetingClient : StealthBridgeClient
    {
        public TargetingClient(string baseAddress = "http://localhost:5000") : base(baseAddress) { }

        public async Task<bool> WaitForTargetAsync(int timeout)
        {
            var response = await _http.PostAsJsonAsync("/wait_for_target", new { timeout });
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<BoolResponse>();
            return result?.Result ?? false;
        }

        public async Task<bool> TargetToObjectAsync(uint serial)
        {
            var response = await _http.PostAsJsonAsync("/target_to_object", new { serial });
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<BoolResponse>();
            return result?.Result ?? false;
        }

        public async Task<TargetResponse?> GetLastTargetResponseAsync()
        {
            var response = await _http.GetAsync("/get_target_response");
            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<TargetResponse>();
            return result;
        }

        private class BoolResponse
        {
            public bool Result { get; set; }
        }

        public class TargetResponse
        {
            public uint Serial { get; set; }
            public ushort X { get; set; }
            public ushort Y { get; set; }
            public sbyte Z { get; set; }
            public ushort Graphic { get; set; }
            public byte Type { get; set; }
        }


        public async Task<uint> GetLastSelectedAsync()
        {
            var response = await _http.GetAsync("/get_last_selected");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<LastSelectedResponse>();
            return result?.Serial ?? 0;
        }

        private class LastSelectedResponse
        {
            public uint Serial { get; set; }
        }
    }
}