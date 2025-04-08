
using Python.Runtime;
using System;

namespace StealthBridgeSDK.Journal
{
    public static class JournalWrapper
    {
        private static dynamic _stealth => PythonImport.Stealth;

        public static void AddJournalIgnore(string text) => _stealth.AddJournalIgnore(text);
        public static void ClearJournalIgnore() => _stealth.ClearJournalIgnore();
        public static void ClearJournal() => _stealth.ClearJournal();
        public static void ClearSystemJournal() => _stealth.ClearSystemJournal();
        public static void AddToJournal(string message) => _stealth.AddToJournal(message);

        public static string LastJournalMessage() => _stealth.LastJournalMessage();
        public static int InJournal(string text) => _stealth.InJournal(text);

        public static int InJournalBetweenTimes(string text, DateTime start, DateTime end)
        {
            using (Py.GIL())
            {
                dynamic datetime = Py.Import("datetime");
                var pyStart = datetime.datetime(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second);
                var pyEnd = datetime.datetime(end.Year, end.Month, end.Day, end.Hour, end.Minute, end.Second);
                return _stealth.InJournalBetweenTimes(text, pyStart, pyEnd);
            }
        }

        public static string Journal(uint index) => _stealth.Journal(index);
        public static void SetJournalLine(uint index, string text) => _stealth.SetJournalLine(index, text);
        public static int LowJournal() => _stealth.LowJournal();
        public static int HighJournal() => _stealth.HighJournal();

        public static bool WaitJournalLine(DateTime startTime, string text, int maxWaitMs = 0)
        {
            DateTime end = (maxWaitMs > 0) ? startTime.AddMilliseconds(maxWaitMs) : startTime.AddMinutes(10);
            while (DateTime.Now <= end)
            {
                if (InJournalBetweenTimes(text, startTime, DateTime.Now) >= 0)
                    return true;

                System.Threading.Thread.Sleep(10);
            }
            return false;
        }

        public static bool WaitJournalLineSystem(DateTime startTime, string text, int maxWaitMs = 0)
        {
            DateTime end = (maxWaitMs > 0) ? startTime.AddMilliseconds(maxWaitMs) : startTime.AddMinutes(10);
            while (DateTime.Now <= end)
            {
                if (InJournalBetweenTimes(text, startTime, DateTime.Now) >= 0)
                {
                    if (LineName() == "System")
                        return true;
                }
                System.Threading.Thread.Sleep(10);
            }
            return false;
        }

        public static void AddChatUserIgnore(string user) => _stealth.AddChatUserIgnore(user);
        public static void ClearChatUserIgnore() => _stealth.ClearChatUserIgnore();

        public static string LineName() => _stealth.LineName(); // used in WaitJournalLineSystem
    }
}
