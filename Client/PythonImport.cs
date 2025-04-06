using Python.Runtime;

namespace StealthBridgeSDK
{
    public static class PythonImport
    {
        private static dynamic? _cached;

        public static dynamic Stealth => _cached ??= Load();

        private static dynamic Load()
        {
            using (Py.GIL())
            {
                dynamic sys = Py.Import("sys");
                sys.path.append(BridgeConfig.Current.StealthPath);
                return Py.Import("py_stealth.methods");
            }
        }
    }
}