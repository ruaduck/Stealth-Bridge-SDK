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
        public static int GetHP(uint mobile)
        {
            using (Py.GIL())
            {
                return _stealth.GetHP(mobile);
            }
        }
        public static int GetMaxHP(uint mobile)
        {
            using (Py.GIL())
            {
                return _stealth.GetMaxHP(mobile);
            }
        }
        public static uint Backpack()
        {
            using (Py.GIL())
            {
                return _stealth.Backpack();
            }
        }
        public static bool BandageSelf()
        {
            using (Py.GIL())
            {
                _stealth.BandageSelf();
                return true;
            }
        }
        public static bool Attack(uint mobile)
        {
            using (Py.GIL())
            {
                _stealth.Attack(mobile);
                return true;
            }
        }
    }
}