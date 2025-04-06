using System;
using System.IO;

namespace StealthBridgeSDK
{
    public enum LogLevel
    {
        Info = 0,
        Warn = 1,
        Error = 2
    }

    public static class Logger
    {
        private static LogLevel _minLogLevel = LogLevel.Info;
        private static string _logFilePath = "stealthbridge.log";

        public static Action<string>? LogToUIPanel { get; set; }

        public static void SetLevel(LogLevel level)
        {
            _minLogLevel = level;
        }

        public static void SetLogFile(string path)
        {
            _logFilePath = path;
        }

        public static void Info(string message) => Log(message, LogLevel.Info);
        public static void Warn(string message) => Log(message, LogLevel.Warn);
        public static void Error(string message) => Log(message, LogLevel.Error);

        private static void Log(string message, LogLevel level)
        {
            if (level < _minLogLevel)
                return;

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string prefix = $"[{level.ToString().ToUpper()}] [{timestamp}]";
            string fullMessage = $"{prefix} {message}";

            // Send to UI if hooked
            LogToUIPanel?.Invoke(fullMessage);

            // Console color
            ConsoleColor originalColor = Console.ForegroundColor;
            switch (level)
            {
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case LogLevel.Warn:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            Console.WriteLine(fullMessage);
            Console.ForegroundColor = originalColor;

            try
            {
                File.AppendAllText(_logFilePath, fullMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[LOGGER ERROR] Could not write to log file: {ex.Message}");
                Console.ForegroundColor = originalColor;
            }
        }
    }
}