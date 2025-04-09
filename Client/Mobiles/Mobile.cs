using Python.Runtime;

namespace StealthBridgeSDK.Mobiles
{
    public static class Mobile
    {
        public class ContextMenuEntry
        {
            public ushort Tag { get; set; }
            public int IntLocID { get; set; }
            public ushort Flags { get; set; }
            public ushort Color { get; set; }
        }

        public class ContextMenuRecord
        {
            public uint ID { get; set; }
            public byte EntriesNumber { get; set; }
            public bool NewCliloc { get; set; }
            public List<ContextMenuEntry> Entries { get; set; } = new();
        }
        private static dynamic _stealth => PythonImport.Stealth;

        public static int GetHP(uint serial)
        {
            using (Py.GIL())
            {
                return _stealth.GetHP(serial);
            }
        }

        public static int GetMana(uint serial)
        {
            using (Py.GIL())
            {
                return _stealth.GetMana(serial);
            }
        }

        public static string GetName(uint serial)
        {
            using (Py.GIL())
            {
                return _stealth.GetName(serial);
            }
        }

        public static int GetNotoriety(uint serial)
        {
            using (Py.GIL())
            {
                return _stealth.GetNotoriety(serial);
            }
        }

        public static bool IsFemale(uint serial)
        {
            using (Py.GIL())
            {
                return _stealth.IsFemale(serial);
            }
        }
        public static bool IsNPC(uint serial)
        {
            using (Py.GIL())
            {
                return _stealth.IsNPC(serial);
            }
        }
        public static uint FindNPC(string name)
        {
            using (Py.GIL())
            {
                return _stealth.FindNPC(name);
            }
        }
        public static void RequestContextMenu(uint serial)
        {

            _stealth.RequestContextMenu(serial);
        }
        public static void SetContextMenuHook(uint menuId, byte entryNumber)
        {
            _stealth.SetContextMenuHook(menuId, entryNumber);
        }
        public static List<string> GetContextMenu()
        {
            using (Py.GIL())
            {
                List<string> result = new();
                dynamic rawList = _stealth.GetContextMenu();
                foreach (var entry in rawList)
                {
                    result.Add(entry.ToString());
                }
                return result;
            }
        }
        public static ContextMenuRecord GetContextMenuRecord()
        {
            using (Py.GIL())
            {
                dynamic record = _stealth.GetContextMenuRec();
                ContextMenuRecord result = new()
                {
                    ID = (uint)record["ID"],
                    EntriesNumber = (byte)record["EntriesNumber"],
                    NewCliloc = record["NewCliloc"].ToString() == "True"
                };

                foreach (var e in record["Entries"])
                {
                    var entry = new ContextMenuEntry
                    {
                        Tag = (ushort)e["Tag"],
                        IntLocID = (int)e["IntLocID"],
                        Flags = (ushort)e["Flags"],
                        Color = (ushort)e["Color"]
                    };
                    result.Entries.Add(entry);
                }

                return result;
            }
        }
        public static class ContextMenuHelper
        {
            public static bool SelectContextMenuByText(uint serial, string labelToMatch)
            {
                using (Py.GIL())
                {
                    // Request the context menu from the target
                    _stealth.RequestContextMenu(serial);
                    Thread.Sleep(250); // wait for menu to populate

                    // Get the full context menu entries
                    var menuList = _stealth.GetContextMenu();
                    if (menuList == null)
                    {
                        Console.WriteLine("No context menu available.");
                        return false;
                    }

                    // Convert to list of strings
                    var entries = new List<string>();
                    foreach (var item in menuList)
                    {
                        entries.Add(item.ToString());
                    }

                    // Search for matching label
                    int index = entries.FindIndex(e => e.Equals(labelToMatch, StringComparison.OrdinalIgnoreCase));
                    if (index == -1)
                    {
                        Console.WriteLine($"> Context menu item '{labelToMatch}' not found.");
                        return false;
                    }

                    // Get metadata (menu ID)
                    dynamic menuRec = _stealth.GetContextMenuRec();
                    uint menuId = (uint)menuRec["ID"];

                    // Select the entry
                    _stealth.SetContextMenuHook(menuId, (byte)index);
                    Console.WriteLine($"> Selected '{labelToMatch}' at index {index} from context menu.");
                    return true;
                }
            }
        }
        public static class ShopHelper
        {
            public static bool OpenShopFromNPC(uint npcSerial)
            {
                using (Py.GIL())
                {
                    _stealth.RequestContextMenu(npcSerial);
                    Thread.Sleep(250);

                    var entries = _stealth.GetContextMenu();
                    int index = -1;
                    for (int i = 0; i < (int)entries.Length(); i++)
                    {
                        if (entries[i].ToString().Equals("Buy", StringComparison.OrdinalIgnoreCase))
                        {
                            index = i;
                            break;
                        }
                    }

                    if (index == -1)
                    {
                        Console.WriteLine("Buy option not found.");
                        return false;
                    }

                    var menuRec = _stealth.GetContextMenuRec();
                    uint menuId = (uint)menuRec["ID"];
                    _stealth.SetContextMenuHook(menuId, (byte)index);
                    Thread.Sleep(500); // Wait for shop to open
                    return true;
                }
            }

            public static List<string> GetShopInventory()
            {
                using (Py.GIL())
                {
                    var items = new List<string>();
                    var shopList = _stealth.GetShopList();

                    foreach (var entry in shopList)
                    {
                        items.Add(entry.ToString());
                    }

                    return items;
                }
            }

            public static void ClearShopInventory()
            {
                _stealth.ClearShopList();
            }
        }



    }
}