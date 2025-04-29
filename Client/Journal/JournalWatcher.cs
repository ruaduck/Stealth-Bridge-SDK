using System;
using System.Diagnostics;
using System.Timers;

namespace StealthBridgeSDK.Journal
{
    public static class JournalWatcher
    {
        private static System.Timers.Timer _timer;
        private static int _lastIndex = 0;
        
        public static event EventHandler<JournalEntry> OnNewEntry;

        public static void StartWatching(int intervalMs = 100)
        {
            //Logger.Info($"Last Index:{_lastIndex}");
            _timer = new System.Timers.Timer(intervalMs);
            _timer.Elapsed += TimerElapsed;
            _timer.AutoReset = true;
            _timer.Start();
        }

        private static void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            int currentHigh = JournalWrapper.LineIndex();
            //Logger.Info($"Current High: {currentHigh}   Last Index: {_lastIndex}");
            if (currentHigh > _lastIndex)
            {
                for (int i = _lastIndex + 1; i <= currentHigh; i++)
                {
                    var entry = JournalWrapper.GetEntry(i);
                    OnNewEntry?.Invoke(null, entry);
                }
                _lastIndex = currentHigh;
            }
        }

        public static void StopWatching()
        {
            _timer?.Stop();
            _timer?.Dispose();
            _timer = null;
        }
        public static class CommonJournalEvents
        {
            public static bool IsEncumbered(JournalEntry entry)
                => entry.Text.Contains("Thou art too encumbered");

            public static bool IsNoReagents(JournalEntry entry)
                => entry.Text.Contains("not enough reagents");

            public static bool IsLowMana(JournalEntry entry)
                => entry.Text.Contains("You do not have enough mana");

            public static bool IsTargetOutOfSight(JournalEntry entry)
                => entry.Text.Contains("Target cannot be seen");

            public static bool IsHarvestFailed(JournalEntry entry)
                => entry.Text.Contains("There's not enough wood");

            public static bool IsBlocked(JournalEntry entry)
                => entry.Text.Contains("That location is blocked");

            public static bool FailedTame(JournalEntry entry)
                => entry.Text.Contains("You faile to tame the creature");

            public static bool StartTame(JournalEntry entry)
                => entry.Text.Contains("You start to tame the creature");

            public static bool SuccessTame(JournalEntry entry)
                => entry.Text.Contains("It seems to accept you as master");

            // Add as many as you like!
        }
    }
}
