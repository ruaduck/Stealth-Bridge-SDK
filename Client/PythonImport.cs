using Python.Runtime;
using System;
using System.IO;

namespace StealthBridgeSDK
{
    public static class PythonImport
    {
        private static dynamic? _stealth;

        public static void Initialize()
        {
            var config = BridgeConfig.Current;

            Console.WriteLine("Setting up Python.NET...");
            Console.WriteLine("PythonHome: " + config.PythonHome);
            Console.WriteLine("StealthPath: " + config.StealthPath);
            Console.WriteLine("PythonDLL: " + config.PythonDll);

            // Force use of specific DLL
            Runtime.PythonDLL = config.PythonDll;

            PythonEngine.PythonHome = config.PythonHome;
            PythonEngine.Initialize();

            using (Py.GIL())
            {
                dynamic sys = Py.Import("sys");
                sys.path.append(config.StealthPath);

                Console.WriteLine("Python sys.path:");
                foreach (var path in sys.path)
                {
                    Console.WriteLine(" - " + path);
                }
            }

            Console.WriteLine("Python initialized successfully.");
        }

        public static dynamic Stealth
        {
            get
            {
                if (_stealth == null)
                {
                    using (Py.GIL())
                    {
                        _stealth = Py.Import("py_stealth.methods");
                        Console.WriteLine("py_stealth.methods imported successfully.");
                    }
                }

                return _stealth;
            }
        }
    }
}