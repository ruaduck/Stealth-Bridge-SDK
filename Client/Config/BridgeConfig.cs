using System.Text.Json;

namespace StealthBridgeSDK
{
    public class BridgeConfig
    {
        public string? StealthPath { get; set; }
        public string? PythonHome { get; set; }
        public string? PythonDll { get; set; }

        private static BridgeConfig? _current;
        private static string path = Path.Combine(AppContext.BaseDirectory, "bridgeconfig.json");
        public static BridgeConfig Current => _current ??= Load();

        public static BridgeConfig Load()
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Missing config file", path);

            string json = File.ReadAllText(path);
            var config = JsonSerializer.Deserialize<BridgeConfig>(json)!;

            if (string.IsNullOrWhiteSpace(config.StealthPath) || !Directory.Exists(config.StealthPath))
                throw new DirectoryNotFoundException($"StealthPath does not exist: {config.StealthPath}");

            if (!Directory.EnumerateDirectories(config.StealthPath, "py_stealth", SearchOption.TopDirectoryOnly).Any() &&
                !Directory.EnumerateFiles(config.StealthPath, "py_stealth*", SearchOption.TopDirectoryOnly).Any())
            {
                throw new InvalidOperationException($"StealthPath does not contain 'py_stealth' module: {config.StealthPath}");
            }

            if (string.IsNullOrWhiteSpace(config.PythonHome) || !Directory.Exists(config.PythonHome))
                throw new DirectoryNotFoundException($"PythonHome does not exist: {config.PythonHome}");

            if (string.IsNullOrWhiteSpace(config.PythonDll) || !File.Exists(config.PythonDll))
                throw new FileNotFoundException($"PythonDll not found: {config.PythonDll}");

            return config;
        }
    }
}