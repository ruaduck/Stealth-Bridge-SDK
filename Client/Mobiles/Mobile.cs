using Python.Runtime;

namespace StealthBridgeSDK.Mobiles
{
    public static class Mobile
    {
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
    }
}