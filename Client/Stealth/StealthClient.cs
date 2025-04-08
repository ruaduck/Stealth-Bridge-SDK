using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;

namespace StealthBridgeSDK.Stealth
{
    public class StealthInfo
    {
        public Version StealthVersion { get; set; }     // Parsed from ushort[3]
        public ushort Build { get; set; }
        public DateTime BuildDate { get; set; }
        public ushort GitRevisionNumber { get; set; }
        public string GitRevision { get; set; } = string.Empty;
    }
    public class StealthClient
    {
        public static dynamic _stealth => PythonImport.Stealth;

        /// <summary>
        /// Checks whether you are currently connected to the server.
        /// </summary>
        /// <returns>bool</returns>
        public bool Connected() => _stealth.Connected();

        /// <summary>
        /// Connects to the server.
        /// </summary>
        /// <returns>No Return Value</returns>
        public static void Connect() => _stealth.Connect();
        /// <summary>
        /// Disconnects from the server.
        /// </summary>
        public static void Disconnect() => _stealth.Disconnect();
        /// <summary>
        /// Not sure yet. In testing
        /// </summary>
        public static StealthInfo GetStealthInfo()
        {
            using (Py.GIL())
            {
                dynamic result = PythonImport.Stealth.GetStealthInfo();

                var versionTuple = result["StealthVersion"];
                var version = new Version((int)versionTuple[0], (int)versionTuple[1], (int)versionTuple[2]);

                return new StealthInfo
                {
                    StealthVersion = version,
                    Build = (ushort)result["Build"],
                    BuildDate = (DateTime)result["BuildDate"],
                    GitRevisionNumber = (ushort)result["GITRevNumber"],
                    GitRevision = (string)result["GITRevision"]
                };
            }
        }
    }
}
