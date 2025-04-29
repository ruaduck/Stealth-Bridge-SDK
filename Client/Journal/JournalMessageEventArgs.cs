using System;

namespace StealthBridgeSDK.Journal
{
    public class JournalMessageEventArgs : EventArgs
    {
        public int Line { get; }
        public string Name { get; }
        public string Text { get; }
        public int Color { get; }
        public int Font { get; }
        public DateTime Time { get; }

        public JournalMessageEventArgs(int line, string name, string text, int color, int font, DateTime time)
        {
            Line = line;
            Name = name;
            Text = text;
            Color = color;
            Font = font;
            Time = time;
        }
    }
}
