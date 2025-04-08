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

        public static void CastToObject(string spellName, uint serial)
        {
            using (Py.GIL())
            {
                _stealth.CastToObject(spellName, serial);
            }
        }
        

    }
}