using System;
using System.Collections.Generic;
using Python.Runtime;

namespace StealthBridgeSDK.Gumps
{
    public static class GumpUtility
    {
        public static Dictionary<int, Dictionary<string, object>> GumpCache = new();

        public static Dictionary<string, object> ParseGump(PyObject gumpInfo)
        {
            var result = new Dictionary<string, object>();

            using (Py.GIL())
            {
                var pyDictType = Py.Import("builtins").GetAttr("dict");

                if (PyDict.IsDictType(gumpInfo))
                {
                    var dict = new PyDict(gumpInfo);
                    foreach (PyObject key in dict.Keys())
                    {
                        string k = key.ToString();
                        PyObject value = dict[key];

                        result[k] = value.AsManagedObject(typeof(object));
                    }
                }
                else
                {
                    throw new InvalidOperationException("Expected a Python dict.");
                }
            }

            return result;
        }


        public static void CacheGumpInfo(int gumpIndex, PyObject gumpInfo)
        {
            var parsed = ParseGump(gumpInfo);
            GumpCache[gumpIndex] = parsed;
        }

        public static object GetGumpElement(int gumpIndex, string key)
        {
            return GumpCache.ContainsKey(gumpIndex) && GumpCache[gumpIndex].ContainsKey(key)
                ? GumpCache[gumpIndex][key]
                : null;
        }
    }
}
