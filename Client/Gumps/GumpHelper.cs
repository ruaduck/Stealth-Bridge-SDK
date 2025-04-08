using System;
using System.Collections.Generic;
using Python.Runtime;

namespace StealthBridgeSDK.Gumps
{
    public static class GumpHelper
    {
        public static int GetGumpID(Dictionary<string, dynamic> gumpInfo)
            => gumpInfo.TryGetValue("GumpID", out var id) ? (int)id.AsManagedObject(typeof(int)) : 0;

        public static int GetGumpSerial(Dictionary<string, dynamic> gumpInfo)
            => gumpInfo.TryGetValue("Serial", out var id) ? (int)id.AsManagedObject(typeof(int)) : 0;

        public static List<Dictionary<string, object>> GetElements(Dictionary<string, dynamic> gumpInfo, string key)
        {
            var elements = new List<Dictionary<string, object>>();

            if (gumpInfo.TryGetValue(key, out var value))
            {
                foreach (PyObject entry in value)   
                {
                    // Skip if it's not a dict
                    if (!PyDict.IsDictType(entry))
                        continue;
                    
                    var keys = new PyDict(entry); // Convert dict_keys to a list
                    var dict = new Dictionary<string, object>();
                    
                    int len = (int)keys.Length();

                    foreach (var k in keys)
                    {
                        PyObject val = entry.GetItem(k);
                        dict[k.ToString()] = val.AsManagedObject(typeof(object));
                    }

                    elements.Add(dict);
                }
            }

            return elements;
        }

        public static List<Dictionary<string, object>> GetButtons(Dictionary<string, dynamic> gumpInfo)
            => GetElements(gumpInfo, "GumpButtons");

        public static List<Dictionary<string, object>> GetTextEntries(Dictionary<string, dynamic> gumpInfo)
            => GetElements(gumpInfo, "TextEntries");

        public static List<Dictionary<string, object>> GetCheckboxes(Dictionary<string, dynamic> gumpInfo)
            => GetElements(gumpInfo, "CheckBoxes");

        public static List<Dictionary<string, object>> GetRadioButtons(Dictionary<string, dynamic> gumpInfo)
            => GetElements(gumpInfo, "RadioButtons");

        public static List<Dictionary<string, object>> GetTooltips(Dictionary<string, dynamic> gumpInfo)
            => GetElements(gumpInfo, "Tooltips");
        public static List<Dictionary<string, object>> GetText(Dictionary<string, dynamic> gumpInfo)
            => GetElements(gumpInfo, "Text");
    }
}
