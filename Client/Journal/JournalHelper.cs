
using System;
using System.Text.RegularExpressions;
using StealthBridgeSDK.Journal;

namespace StealthBridgeSDK.Helpers
{
    public static class JournalHelper
    {
        /// <summary>
        /// Checks if a journal entry exists containing the specified text.
        /// </summary>
        public static bool Contains(string text)
        {
            return JournalWrapper.InJournal(text) >= 0;
        }

        /// <summary>
        /// Waits for a journal entry to appear within a time window (in milliseconds).
        /// </summary>
        public static bool WaitFor(string text, int timeoutMs = 10000)
        {
            return JournalWrapper.WaitJournalLine(DateTime.Now, text, timeoutMs);
        }

        /// <summary>
        /// Waits for a system journal entry to appear within a time window (in milliseconds).
        /// </summary>
        public static bool WaitForSystem(string text, int timeoutMs = 10000)
        {
            return JournalWrapper.WaitJournalLineSystem(DateTime.Now, text, timeoutMs);
        }

        /// <summary>
        /// Checks if the last journal message matches the expected text.
        /// </summary>
        public static bool LastMessageEquals(string text)
        {
            return JournalWrapper.LastJournalMessage()?.Trim() == text.Trim();
        }

        /// <summary>
        /// Checks if the last journal message contains a specific substring.
        /// </summary>
        public static bool LastMessageContains(string text)
        {
            return JournalWrapper.LastJournalMessage()?.Contains(text) ?? false;
        }

        public static IEnumerable<string> GetAllLines()
        {
            int low = JournalWrapper.LowJournal();
            int high = JournalWrapper.HighJournal();

            for (uint i = (uint)low; i <= high; i++)
            {
                yield return JournalWrapper.Journal(i);
            }
        }

        public static IEnumerable<string> GetLinesMatching(Func<string, bool> predicate)
        {
            return GetAllLines().Where(predicate);
        }

        public static bool AnyMatch(Func<string, bool> predicate)
        {
            return GetAllLines().Any(predicate);
        }

        public static string? FirstMatch(string text)
        {
            return GetAllLines().FirstOrDefault(line => line.Contains(text));
        }

        public static bool ContainsRegex(string pattern)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return GetAllLines().Any(line => regex.IsMatch(line));
        }

        public static string? FirstLineFrom(string speaker)
        {
            return GetAllLines().FirstOrDefault(line => JournalWrapper.LineName() == speaker);
        }
    }
}
