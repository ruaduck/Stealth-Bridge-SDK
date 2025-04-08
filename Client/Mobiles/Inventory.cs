using Python.Runtime;

namespace StealthBridgeSDK.Inventory
{
    public static class Inventory
    {
        private static dynamic _stealth => PythonImport.Stealth;

        public static void UseObject(uint serial)
        {
            using (Py.GIL())
            {
                Logger.Info($"Using object: 0x{serial:X}");
                _stealth.UseObject(serial);
            }
        }

        public static void MoveItem(uint itemSerial, int quantity, uint containerSerial)
        {
            using (Py.GIL())
            {
                Logger.Info($"Moving item 0x{itemSerial:X} (x{quantity}) to container 0x{containerSerial:X}");
                _stealth.MoveItem(itemSerial, quantity, containerSerial);
            }
        }

        public static int Count(uint type, int color = -1)
        {
            using (Py.GIL())
            {
                return _stealth.Count(type, color);
            }
        }

        public static uint FindType(uint type, int color = -1, uint container = 0)
        {
            using (Py.GIL())
            {
                return _stealth.FindType(type, color, container);
            }
        }

        public static uint FindItemInBackpack(uint type, int color = -1)
        {
            using (Py.GIL())
            {
                uint backpack = _stealth.Backpack();
                uint found = _stealth.FindType(type, color, backpack);
                Logger.Info(found != 0 ? $"Found item 0x{found:X} in backpack." : $"Item 0x{type:X} not found in backpack.");
                return found;
            }
        }

        public static bool HasItem(uint type, int color = -1)
        {
            return FindItemInBackpack(type, color) != 0;
        }
    }
}