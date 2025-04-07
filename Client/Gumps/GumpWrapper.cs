
namespace StealthBridgeSDK.Gumps
{
    public static class GumpWrapper
    {
        private static dynamic _stealth => PythonImport.Stealth;

        public static int GetGumpsCount() => _stealth.GetGumpsCount();

        public static int GetGumpID(int index) => _stealth.GetGumpID(index);

        public static int GetGumpSerial(int index) => _stealth.GetGumpSerial(index);

        public static string[] GetGumpTextLines(int index) => _stealth.GetGumpTextLines(index).As<string[]>();

        public static string[] GetGumpShortLines(int index) => _stealth.GetGumpShortLines(index).As<string[]>();

        public static string[] GetGumpFullLines(int index) => _stealth.GetGumpFullLines(index).As<string[]>();

        public static string[] GetGumpButtonsDescription(int index) => _stealth.GetGumpButtonsDescription(index).As<string[]>();

        public static int NumGumpButton(int index) => _stealth.NumGumpButton(index);

        public static void CloseSimpleGump(int index) => _stealth.CloseSimpleGump(index);

        public static void CloseClientGump(int index) => _stealth.CloseClientGump(index);

        public static void ClickGumpButton(int gumpIndex, int buttonID) => _stealth.NumGumpButton(gumpIndex, buttonID);

        public static dynamic GetGumpInfo(int index) => _stealth.GetGumpInfo(index);

        public static void SetGumpCheckBox(int gumpIndex, int checkBoxIndex, bool value) =>
            _stealth.GumpAutoCheckBox(gumpIndex, checkBoxIndex, value);

        public static void SetGumpRadioButton(int gumpIndex, int radioIndex, bool value) =>
            _stealth.GumpAutoRadiobutton(gumpIndex, radioIndex, value);

        public static void SetGumpTextEntry(int gumpIndex, int entryIndex, string text) =>
            _stealth.GumpAutoTextEntry(gumpIndex, entryIndex, text);
    }
}
