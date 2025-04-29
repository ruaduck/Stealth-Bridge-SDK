using Python.Runtime;
using System;

namespace StealthBridgeSDK.Journal
{
    public static class JournalWrapper
    {
        private static dynamic _stealth => PythonImport.Stealth;

        public static int LowJournal()
        {
            using (Py.GIL())
            {
                return _stealth.LowJournal();
            }
        }

        public static int HighJournal()
        {
            using (Py.GIL())
            {
                return _stealth.HighJournal();
            }
        }

        public static string GetJournalLine(uint index)
        {
            using (Py.GIL())
            {
                return _stealth.Journal(index);
            }
        }

        public static string LineName()
        {
            using (Py.GIL())
            { 
                return _stealth.LineName(); 
            }
        }
        public static int LineCount()
        {
            using (Py.GIL())
            { 
                return _stealth.LineCount(); 
            }
        }
        public static int LineIndex()
        {
            using (Py.GIL())
            {
                return _stealth.LineIndex();
            }
        }
        public static ushort LineTextColor()
        {
            using (Py.GIL())
            {
            
            return _stealth.LineTextColor();
            } 
        }

        public static ushort LineTextFont()
        {
            using (Py.GIL())
            {
                return _stealth.LineTextFont();
            }
        }

        public static double LineTime()
        {
            using (Py.GIL())
            {
                return _stealth.LineTime();
            }
        }

        public static JournalEntry GetEntry(int index)
        {
            using (Py.GIL())
            {
                return new JournalEntry
                {
                    Index = index,
                    Text = GetJournalLine((uint)index),
                    Name = LineName(),
                    TextColor = LineTextColor(),
                    Font = LineTextFont(),
                    Timestamp = FromUODateTime(LineTime())
                };
            }
        }
        public static void ClearJournal()
        {
            using (Py.GIL())
            {
                _stealth.ClearJournal();
            }
        }
        private static DateTime FromUODateTime(double uoTimestamp)
        {
            DateTime baseTime = new DateTime(1899, 12, 30);
            return baseTime.AddDays(uoTimestamp);
        }
    }
}
