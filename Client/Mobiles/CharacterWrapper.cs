using Python.Runtime;

namespace StealthBridgeSDK.Character
{
    public static class CharacterWrapper
    {
        private static dynamic _stealth => PythonImport.Stealth;

        public static int GetMana(uint mobile)
        {
            using (Py.GIL())
            {
                return _stealth.GetMana(mobile);
            }
        }

        public static int GetMaxMana(uint mobile)
        {
            using (Py.GIL())
            {
                return _stealth.GetMaxMana(mobile);
            }
        }

        public static bool IsParalyzed(uint mobile)
        {
            using (Py.GIL())
            {
                return _stealth.IsParalyzed(mobile);
            }
        }

        public static bool IsPoisoned(uint mobile)
        {
            using (Py.GIL())
            {
                return _stealth.IsPoisoned(mobile);
            }
        }

        public static bool IsDead(uint mobile)
        {
            using (Py.GIL())
            {
                return _stealth.Dead(mobile);
            }
        }

        public static bool IsWarMode(uint mobile)
        {
            using (Py.GIL())
            {
                return _stealth.IsWarMode(mobile);
            }
        }
        public static uint Self()
        {
            using (Py.GIL())
            {
                return _stealth.Self();
            }
        }
    }
}