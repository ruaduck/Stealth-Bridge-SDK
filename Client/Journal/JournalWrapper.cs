using Python.Runtime;

namespace StealthBridgeSDK.Journal
{
    public static class JournalWrapper
    {
        private static dynamic _stealth => PythonImport.Stealth;

        public static void ClearJournal()
        {
            using (Py.GIL())
            {
                Logger.Info("Journal cleared.");
                _stealth.ClearJournal();
            }
        }

        public static bool InJournal(string text)
        {
            using (Py.GIL())
            {
                bool found = _stealth.InJournal(text);
                Logger.Info(found ? $"Journal match found for: '{text}'" : $"No match in journal for: '{text}'");
                return found;
            }
        }

        public static int WaitJournalLine(string text, int timeoutMs)
        {
            using (Py.GIL())
            {
                Logger.Info($"Waiting for journal line: '{text}'");
                int result = _stealth.WaitJournalLine(text, timeoutMs);
                if (result != -1)
                    Logger.Info($"Journal line matched: index {result}");
                else
                    Logger.Warn("Journal wait timed out.");
                return result;
            }
        }

        public static string GetJournalLine(int index)
        {
            using (Py.GIL())
            {
                string line = _stealth.LineText(index);
                Logger.Info($"Journal line {index}: {line}");
                return line;
            }
        }
    }
}