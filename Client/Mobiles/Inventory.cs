using Python.Runtime;

namespace StealthBridgeSDK.Inventory
{
    public static class Inventories
    {
        private static dynamic _stealth => PythonImport.Stealth;
        /// <summary>
        /// Uses an object based on its serial number.
        /// </summary>
        /// <param name="serial"></param>
        public static void UseObject(uint serial)
        {
            using (Py.GIL())
            {
                Logger.Info($"Using object: 0x{serial:X}");
                _stealth.UseObject(serial);
            }
        }
        /// <summary>
        /// Moves an item from one container to another. Ground = 0, Backpack is the BackpackID
        /// </summary>
        /// <param name="itemSerial"></param>
        /// <param name="quantity"></param>
        /// <param name="containerSerial"></param>
        public static void MoveItem(uint itemSerial, int quantity, uint containerSerial)
        {
            using (Py.GIL())
            {
                Logger.Info($"Moving item 0x{itemSerial:X} (x{quantity}) to container 0x{containerSerial:X}");
                _stealth.MoveItem(itemSerial, quantity, containerSerial);
            }
        }
        /// <summary>
        /// Counts the number of items of a specific type in the specified container or on the ground. Ground = 0, Backpack is the BackpackID
        /// </summary>
        /// <param name="type"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static int Count(uint type, int color = -1)
        {
            using (Py.GIL())
            {
                return _stealth.Count(type);
            }
        }
        /// <summary>
        /// Finds an item by its Type in the specified container or on the ground. Ground = 0, Backpack is the BackpackID
        /// </summary>
        /// <param name="type"></param>
        /// <param name="color"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public static uint FindTypeEx(uint type, int color = -1, uint container = 0)
        {
            using (Py.GIL())
            {
                return _stealth.FindTypeEx(type, color, container);
            }
        }
        /// <summary>
        /// Finds an item by its Type in the specified container or on the ground. Ground = 0, Backpack is the BackpackID
        /// </summary>
        /// <param name="type"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public static uint FindType(uint type, uint container = 0)
        {
            using (Py.GIL())
            {
                return _stealth.FindType(type, container);
            }
        }
        /// <summary>
        /// Finds an item in the specified container or on the ground. Ground = 0, Backpack is the BackpackID
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="container"></param>
        /// <returns>uint</returns>
        public static uint FindItem(uint itemid, uint container = 0) //container 0 means GROUND
        {
            using (Py.GIL())
            {
                return _stealth.FindItem(itemid, container);
            }
        }
        /// <summary>
        /// Finds an item in the specified container or on the ground. Ground = 0, Backpack is the BackpackID
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="color"></param>
        /// <param name="container"></param>
        /// <returns>uint</returns>
        public static uint FindItemEx(uint itemid, int color = -1, uint container = 0)
        {
            using (Py.GIL())
            {
                return _stealth.FindItemEx(itemid, color, container);
            }
        }
        /// <summary>
        /// Finds an item in the backpack. Backpack is the BackpackID
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="color"></param>
        /// <returns>uint</returns>
        public static bool FindIteminBackpack(uint itemid, int color = -1)
        {
            using (Py.GIL())
            {
                uint found;
                uint backpack = _stealth.Backpack();
                if (color == -1)
                {
                    found = _stealth.FindItem(itemid, backpack);
                }
                else
                { found = _stealth.FindItemEx(itemid, color, backpack); }
                Logger.Info(found != 0 ? $"Found item 0x{found:X} in backpack." : $"Item 0x{itemid:X} not found in backpack.");
                if (found != 0) return true;              
                return false;
                

            }
        }
        /// <summary>
        /// Finds an item by its Type in the backpack. Backpack is the BackpackID. WIll always return the first item found.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="color"></param>
        /// <returns>uint</returns>
        public static uint FindTypeInBackpack(uint type, int color = -1)
        {
            using (Py.GIL())
            {
                uint found;
                uint backpack = _stealth.Backpack();
                if (color == -1)
                {
                    found = _stealth.FindType(type, backpack);
                }
                else
                { found = _stealth.FindTypeEx(type, color, backpack); }

                Logger.Info(found != 0 ? $"Found item 0x{found:X} in backpack." : $"Item 0x{type:X} not found in backpack.");
                return found;
            }
        }
        /// <summary>
        /// Checks if an item of a specific type exists in the backpack. Backpack is the BackpackID.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static bool HasItem(uint type, int color = -1)
        {
            return FindTypeInBackpack(type, color) != 0;
        }
    }
}