namespace StealthBridgeSDK.Journal
{
    public class JournalEntry
    {
        public int Index { get; set; }
        public int ID { get; set; } // LineID (Serial)
        public int Type { get; set; } // Message type (0 = System, 1 = Speech, etc.)
        public string Name { get; set; } // Speaker Name or 'System'
        public DateTime Timestamp { get; set; }
        public string Text { get; set; }
        public int TextColor { get; set; }
        public int Font { get; set; }

        public override string ToString()
        {
            return $"[{Index}] {Timestamp:HH:mm:ss} [{Name}] {Text}";
        }
    }
}
