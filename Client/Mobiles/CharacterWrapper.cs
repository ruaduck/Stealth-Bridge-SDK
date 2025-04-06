using Python.Runtime;

namespace StealthBridgeSDK.Character
{
    public static class CharacterWrapper
    {
        private static dynamic _stealth => PythonImport.Stealth;

        public static int GetMana()
        {
            using (Py.GIL())
            {
                return _stealth.GetMana();
            }
        }

        public static int GetMaxMana()
        {
            using (Py.GIL())
            {
                return _stealth.GetMaxMana();
            }
        }

        public static bool IsParalyzed()
        {
            using (Py.GIL())
            {
                return _stealth.IsParalyzed();
            }
        }

        public static bool IsPoisoned()
        {
            using (Py.GIL())
            {
                return _stealth.IsPoisoned();
            }
        }

        public static bool IsDead()
        {
            using (Py.GIL())
            {
                return _stealth.Dead();
            }
        }

        public static bool IsWarMode()
        {
            using (Py.GIL())
            {
                return _stealth.IsWarMode();
            }
        }
    }
}