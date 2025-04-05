using System.Net.Http.Json;
using System.Threading.Tasks;

namespace StealthBridgeSDK.Spells
{
    public class SpellClient : StealthBridgeSDK.StealthBridgeClient
    {
        private static readonly HttpClient _http = new HttpClient();

        public SpellClient(string baseAddress = "http://localhost:5000") : base(baseAddress) {
            _http.BaseAddress = new Uri(baseAddress);
        }

        public async Task<bool> CastSpellAsync(string spell)
        {
            var response = await _http.PostAsJsonAsync("/cast_spell", new { spell });
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<SpellResponse>();
            return result?.Result ?? false;
        }

        public async Task<bool> CastSpellToObjectAsync(string spell, uint serial)
        {
            var response = await _http.PostAsJsonAsync("/cast_spell_to_obj", new { spell, serial });
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<SpellResponse>();
            return result?.Result ?? false;
        }
        public async Task<string?> GetLastSpellCastAsync()
        {
            var response = await _http.GetAsync("/get_last_spell_cast");
            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<SpellCastResponse>();
            return result?.Spell;
        }

        private class SpellCastResponse
        {
            public string? Spell { get; set; }
        }
        private class SpellResponse
        {
            public bool Result { get; set; }
        }
    }
}

