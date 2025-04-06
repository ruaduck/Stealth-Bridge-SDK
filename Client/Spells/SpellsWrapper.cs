using System;
using Python.Runtime;

namespace StealthBridgeSDK.Spells
{
    public static class SpellsWrapper
    {
        private static dynamic _stealth => PythonImport.Stealth;
        public static void Cast(string spellName)
        {
            using (Py.GIL())
            {
                _stealth.Cast(spellName);
            }
        }

        public static bool WaitForTarget(int timeout)
        {
            using (Py.GIL())
            {
                return _stealth.WaitForTarget(timeout);
            }
        }

        public static void TargetToObject(uint serial)
        {
            using (Py.GIL())
            {
                _stealth.TargetToObject(serial);
            }
        }

        public static uint LastTarget()
        {
            using (Py.GIL())
            {
                return _stealth.LastTarget();
            }
        }

        public static void CastToObject(string spellName, uint serial)
        {
            using (Py.GIL())
            {
                _stealth.CastToObject(spellName, serial);
            }
        }
        public static void TargetToTile(ushort x, ushort y, sbyte z)
        {
            using (Py.GIL())
            {
                _stealth.TargetToTile(x, y, z);
            }
        }

    }
}