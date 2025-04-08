using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;

namespace StealthBridgeSDK.Client.Targeting
{

    public static class Target
    {
        private static dynamic _stealth => PythonImport.Stealth;
        /// <summary>
        /// Gets the current target ID.
        /// </summary>
        /// <returns>uint</returns>
        public static uint TargetID()
        {
            using (Py.GIL())
            {
                return _stealth.TargetID();
            }
        }
        /// <summary>
        /// Lets you know if the target cursor is up
        /// </summary>
        /// <returns>bool</returns>
        public static bool TargetPresent()
        {
            using (Py.GIL())
            {
                return _stealth.TargetPresent();
            }
        }

        /// <summary>
        /// Waits maximum timeout milliseconds for a target cursor to show up
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns>bool</returns>
        public static bool WaitForTarget(int timeout)
        {
            using (Py.GIL())
            {
                return _stealth.WaitForTarget(timeout);
            }
        }
        /// <summary>
        /// Sets the target cursor to a specific object
        /// </summary>
        /// <param name="serial"></param>
        public static void TargetToObject(uint serial)
        {
            using (Py.GIL())
            {
                _stealth.TargetToObject(serial);
            }
        }

        /// <summary>
        /// Selects Last Target with the Target Cursor.
        /// </summary>
        /// <returns></returns>
        public static uint LastTarget()
        {
            using (Py.GIL())
            {
                return _stealth.LastTarget();
            }
        }

        /// <summary>
        /// Sets the target cursor to a specific tile
        /// </summary>
        /// <param name="tileid"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void TargetToTile(ushort tileid,ushort x, ushort y, sbyte z)
        {
            using (Py.GIL())
            {
                _stealth.TargetToTile(tileid,x, y, z);
            }
        }
        /// <summary>
        /// Cancels the target cursor.
        /// </summary>
        public static void CancelTarget()
        {
            using (Py.GIL())
            {
                _stealth.CancelTarget();
            }
        }
        /// <summary>
        /// Sets the target cursor to a specific location in the world.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void TargetToXYZ(ushort x, ushort y, sbyte z)
        {
            using (Py.GIL())
            {
                _stealth.TargetToXYZ(x, y, z);
            }
        }
    }
}
