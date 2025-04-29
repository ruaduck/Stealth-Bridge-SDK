using System.Collections.Generic;
using Python.Runtime;

namespace StealthBridgeSDK.Finding
{
    public static class FindWrapper
    {
        private static dynamic _stealth => PythonImport.Stealth;

        // Search Settings
        public static void SetFindDistance(uint distance) => _stealth.SetFindDistance(distance);
        public static uint GetFindDistance() => _stealth.GetFindDistance();

        public static void SetFindVertical(uint vertical) => _stealth.SetFindVertical(vertical);
        public static uint GetFindVertical() => _stealth.GetFindVertical();

        public static void SetFindInNullPoint(bool value) => _stealth.SetFindInNulPoint(value);
        public static bool GetFindInNullPoint() => _stealth.GetFindInNulPoint();

        // Searching
        public static uint FindTypeEx(ushort objType, ushort color, uint container = 0, bool inSub = true)
            => _stealth.FindTypeEx(objType, color, container, inSub);

        public static uint FindType(ushort objType, uint container = 0)
            => _stealth.FindTypeEx(objType, 0xFFFF, container, false);

        public static uint FindTypesArrayEx(ushort[] objTypes, ushort[] colors, uint[] containers, bool inSub)
        {
            using (Py.GIL())
            {
                var pyTypes = new PyList();
                foreach (var t in objTypes) pyTypes.Append(new PyInt(t));

                var pyColors = new PyList();
                foreach (var c in colors) pyColors.Append(new PyInt(c));

                var pyContainers = new PyList();
                foreach (var con in containers) pyContainers.Append(new PyInt(con));

                return _stealth.FindTypesArrayEx(pyTypes, pyColors, pyContainers, inSub);
            }
        }

        public static uint FindNotoriety(ushort objType, byte notoriety)
            => _stealth.FindNotoriety(objType, notoriety);

        public static uint FindAtCoord(ushort x, ushort y)
            => _stealth.FindAtCoord(x, y);

        // Found Items
        public static List<uint> GetFoundList()
        {
            var result = new List<uint>();
            using (Py.GIL())
            {
                var pyList = _stealth.GetFoundList();
                foreach (var pyItem in pyList)
                    result.Add(pyItem.As<uint>());
            }
            return result;
        }

        public static uint FindItem()
            => _stealth.GetFindItem();

        public static int FindCount()
            => _stealth.GetFindCount();

        public static int FindQuantity()
            => _stealth.GetFindQuantity();

        public static int FindFullQuantity()
            => _stealth.FindFullQuantity();

        // Convenience Aliases
        public static List<uint> GetFindedList() => GetFoundList();
    }
}
