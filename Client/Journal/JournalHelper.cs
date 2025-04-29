using System;
using System.Collections.Generic;

namespace StealthBridgeSDK.Journal
{
    public static class JournalHelper
    {
        public static bool ScanForText(string text)
        {
            for (int i = JournalWrapper.LowJournal(); i <= JournalWrapper.HighJournal(); i++)
            {
                var entry = JournalWrapper.GetEntry(i);
                if (entry.Text.Contains(text, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        public static JournalEntry FindFirstEntryContaining(string text)
        {
            for (int i = JournalWrapper.LowJournal(); i <= JournalWrapper.HighJournal(); i++)
            {
                var entry = JournalWrapper.GetEntry(i);
                if (entry.Text.Contains(text, StringComparison.OrdinalIgnoreCase))
                    return entry;
            }
            return null;
        }

        public static List<JournalEntry> GetAllEntries()
        {
            var entries = new List<JournalEntry>();
            for (int i = JournalWrapper.LowJournal(); i <= JournalWrapper.HighJournal(); i++)
            {
                entries.Add(JournalWrapper.GetEntry(i));
            }
            return entries;
        }
    }
}
