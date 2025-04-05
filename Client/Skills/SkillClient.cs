using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace StealthBridgeSDK.Skills
{
    public class SkillClient : StealthBridgeClient
    {
        private static readonly HttpClient _http = new HttpClient();

        public SkillClient(string baseAddress = "http://localhost:5000") : base(baseAddress)
        {
            _http.BaseAddress = new Uri(baseAddress);
        }

        public async Task<float> GetSkillValueAsync(string skill)
        {
            var response = await _http.PostAsJsonAsync("/get_skill_value", new { skill });
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<SkillResponse>();
            return result?.Value ?? 0f;
        }

        public async Task<float> GetSkillCapAsync(string skill)
        {
            var response = await _http.PostAsJsonAsync("/get_skill_cap", new { skill });
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<SkillResponse>();
            return result?.Value ?? 0f;
        }

        private class SkillResponse
        {
            public float Value { get; set; }
        }
    }
}