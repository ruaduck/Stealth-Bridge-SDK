using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StealthBridgeSDK.Miscellaneous
{
    class Misc
    {
        private static dynamic _stealth => PythonImport.Stealth;


        /// <summary>
        /// Uses (double-clicks) an object by serial.
        /// </summary>
        public static void UseObject(uint objectId)
        {
            _stealth.UseObject(objectId);
        }

        /// <summary>
        /// Uses an item by type and color.
        /// </summary>
        public static uint UseType(ushort type, ushort color)
        {
            return _stealth.UseType(type, color);
        }

        /// <summary>
        /// Uses an item by type with any color.
        /// </summary>
        public static uint UseType(ushort type)
        {
            return _stealth.UseType2(type);
        }

        /// <summary>
        /// Uses an item from the ground by type and color.
        /// </summary>
        public static uint UseFromGround(ushort type, ushort color)
        {
            return _stealth.UseFromGround(type, color);
        }

        /// <summary>
        /// Simulates a single-click on an object.
        /// </summary>
        public static void ClickOnObject(uint objectId)
        {
            _stealth.ClickOnObject(objectId);
        }

        /// <summary>
        /// Gets the parameter index of the last found object.
        /// </summary>
        public static int GetFoundedParamID()
        {
            return _stealth.GetFoundedParamID();
        }
    }
}
