
namespace StealthBridgeSDK.Gumps
{
    public static class GumpHelper
    {
        public static void ListAllGumps()
        {
            int count = GumpWrapper.GetGumpsCount();
            Logger.Info($">>> Found {count} Gump(s)");

            for (int i = 0; i < count; i++)
            {
                int id = GumpWrapper.GetGumpID(i);
                int serial = GumpWrapper.GetGumpSerial(i);
                Logger.Info($"[Gump {i}] ID: {id} | Serial: {serial}");

                var lines = GumpWrapper.GetGumpFullLines(i);
                if (lines.Any())
                {
                    Logger.Info("  Text:");
                    foreach (var text in lines)
                        Logger.Info($"    - {text}");
                }

                var buttons = GumpWrapper.GetGumpButtonsDescription(i);
                if (buttons.Any())
                {
                    Logger.Info("  Buttons:");
                    for (int b = 0; b < buttons.Length; b++)
                        Logger.Info($"    [{b}] {buttons[b]}");
                }
            }
        }

        public static void ClickButtonByIndex(int gumpIndex, int buttonIndex)
        {
            Logger.Info($"> Clicking button #{buttonIndex} on Gump {gumpIndex}");
            GumpWrapper.ClickGumpButton(gumpIndex, buttonIndex);
        }

        public static void ClickButtonByLabel(int gumpIndex, string label)
        {
            var buttons = GumpWrapper.GetGumpButtonsDescription(gumpIndex);
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Contains(label, StringComparison.OrdinalIgnoreCase))
                {
                    Logger.Info($"> Clicking button \"{label}\" (#{i}) on Gump {gumpIndex}");
                    ClickButtonByIndex(gumpIndex, i);
                    return;
                }
            }
            Logger.Warn($"> Button with label \"{label}\" not found in Gump {gumpIndex}");
        }

        public static int? FindGumpById(int gumpId)
        {
            int count = GumpWrapper.GetGumpsCount();
            for (int i = 0; i < count; i++)
            {
                if (GumpWrapper.GetGumpID(i) == gumpId)
                    return i;
            }
            return null;
        }

        public static void CloseAllGumps()
        {
            int count = GumpWrapper.GetGumpsCount();
            for (int i = 0; i < count; i++)
            {
                GumpWrapper.CloseClientGump(i);
                Logger.Info($"> Closed Gump {i}");
            }
        }

        public static void CheckCheckbox(int gumpIndex, int checkboxIndex)
        {
            Logger.Info($"> Checking checkbox #{checkboxIndex} on Gump {gumpIndex}");
            GumpWrapper.SetGumpCheckBox(gumpIndex, checkboxIndex, true);
        }

        public static void SelectRadioButton(int gumpIndex, int radioIndex)
        {
            Logger.Info($"> Selecting radio button #{radioIndex} on Gump {gumpIndex}");
            GumpWrapper.SetGumpRadioButton(gumpIndex, radioIndex, true);
        }

        public static void EnterText(int gumpIndex, int entryIndex, string text)
        {
            Logger.Info($"> Entering text at entry #{entryIndex} on Gump {gumpIndex}: \"{text}\"");
            GumpWrapper.SetGumpTextEntry(gumpIndex, entryIndex, text);
        }
    }
}
