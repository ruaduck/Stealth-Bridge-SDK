
using System;
using System.Collections.Generic;
using Python.Runtime;

namespace StealthBridgeSDK.Gumps
{
    public static class GumpWrapper
    {
        private static dynamic _stealth => PythonImport.Stealth;

        public static uint GetGumpsCount() => _stealth.GetGumpsCount().As<uint>();
        public static uint GetGumpID(int index) => _stealth.GetGumpID(index).As<uint>();
        public static uint GetGumpSerial(int index) => _stealth.GetGumpSerial(index).As<uint>();

        //public static PyObject GetGumpInfo(int index) => _stealth.GetGumpInfo(index);
        public static Dictionary<string, dynamic> GetGumpInfo(int gumpIndex)
        {
            using (Py.GIL())
            {
                dynamic result = _stealth.GetGumpInfo(gumpIndex);
                var gumpData = new Dictionary<string, dynamic>();
                foreach (PyObject key in result)
                {
                    gumpData[key.ToString()] = result[key];
                }
                return gumpData;
            }
        }
        public static Gump DumpGumpInfo(int index)
        {
            using (Py.GIL())
            {
                dynamic pyInfo = _stealth.GetGumpInfo(index);
                var gump = new Gump
                {
                    Serial = pyInfo["Serial"].As<uint>(),
                    GumpID = pyInfo["GumpID"].As<uint>(),
                    X = pyInfo["X"].As<short>(),
                    Y = pyInfo["Y"].As<short>(),
                    Pages = pyInfo["Pages"].As<int>(),
                    NoMove = pyInfo["NoMove"].As<bool>(),
                    NoResize = pyInfo["NoResize"].As<bool>(),
                    NoDispose = pyInfo["NoDispose"].As<bool>(),
                    NoClose = pyInfo["NoClose"].As<bool>()
                };

                gump.Buttons = GumpReader.GetGumpButton(pyInfo);
                gump.Groups = GumpReader.GetGroup(pyInfo);
                gump.EndGroups = GumpReader.GetEndGroup(pyInfo);
                gump.ButtonTileArts = GumpReader.GetButtonTileArt(pyInfo);
                gump.CheckBoxes = GumpReader.GetCheckBox(pyInfo);
                gump.ChekerTrans = GumpReader.GetChekerTrans(pyInfo);
                gump.CroppedText = GumpReader.GetCroppedText(pyInfo);
                gump.GumpPics = GumpReader.GetGumpPic(pyInfo);
                gump.GumpPicTiled = GumpReader.GetGumpPicTiled(pyInfo);
                gump.RadioButtons = GumpReader.GetRadiobutton(pyInfo);
                gump.ResizePics = GumpReader.GetResizePic(pyInfo);
                gump.GumpText = GumpReader.GetGumpText(pyInfo);
                gump.TextEntries = GumpReader.GetTextEntry(pyInfo);
                gump.TextEntriesLimited = GumpReader.GetTextEntryLimited(pyInfo);
                gump.TilePics = GumpReader.GetTilePic (pyInfo);
                gump.TilePicHue = GumpReader.GetTilePicHue(pyInfo);
                gump.Tooltips = GumpReader.GetTooltip(pyInfo);
                gump.HtmlGump = GumpReader.GetHtmlGump(pyInfo);
                gump.XmfHtmlGump = GumpReader.GetXmfHtmlGump(pyInfo);
                gump.XmfHTMLGumpColor = GumpReader.GetXmfHTMLGumpColor(pyInfo);
                gump.XmfHTMLTok = GumpReader.GetXmfHTMLTok(pyInfo);
                gump.ItemProperties = GumpReader.GetItemProperty(pyInfo);

                return gump;
            }
        }

        //public static string[] GetGumpTextLines(int index)
        //{
        //    using (Py.GIL())
        //    {
        //        PyObject gumpInfo = GetGumpInfo(index);
        //        var dict = new PyDict(gumpInfo);

        //        if (!dict.HasKey("Text".ToPython()))
        //            return Array.Empty<string>();

        //        var textList = dict["Text"];
        //        var result = new string[textList.Length()];
        //        for (int i = 0; i < result.Length; i++)
        //            result[i] = textList[i].ToString();
        //        return result;
        //    }
        //}

        

        //public static int[] GetGumpCheckBoxes(int index)
        //{
        //    using (Py.GIL())
        //    {
        //        PyObject gumpInfo = GetGumpInfo(index);
        //        var dict = new PyDict(gumpInfo);

        //        if (!dict.HasKey("CheckBoxes".ToPython()))
        //            return Array.Empty<int>();

        //        var list = dict["CheckBoxes"];
        //        var result = new int[list.Length()];
        //        for (int i = 0; i < result.Length; i++)
        //            result[i] = list[i].GetItem("ID").As<int>();
        //        return result;
        //    }
        //}

        //public static int[] GetGumpRadioButtons(int index)
        //{
        //    using (Py.GIL())
        //    {
        //        PyObject gumpInfo = GetGumpInfo(index);
        //        var dict = new PyDict(gumpInfo);

        //        if (!dict.HasKey("Radiobuttons".ToPython()))
        //            return Array.Empty<int>();

        //        var list = dict["Radiobuttons"];
        //        var result = new int[list.Length()];
        //        for (int i = 0; i < result.Length; i++)
        //            result[i] = list[i].GetItem("ID").As<int>();
        //        return result;
        //    }
        //}

        //public static int[] GetGumpTextEntries(int index)
        //{
        //    using (Py.GIL())
        //    {
        //        PyObject gumpInfo = GetGumpInfo(index);
        //        var dict = new PyDict(gumpInfo);

        //        if (!dict.HasKey("TextEntries".ToPython()))
        //            return Array.Empty<int>();

        //        var list = dict["TextEntries"];
        //        var result = new int[list.Length()];
        //        for (int i = 0; i < result.Length; i++)
        //            result[i] = list[i].GetItem("ID").As<int>();
        //        return result;
        //    }
        //}

        public static void PressButton(int gumpIndex, int buttonIndex)
        {
            _stealth.NumGumpButton((ushort)gumpIndex, buttonIndex);
        }

        public static void EnterText(int gumpIndex, int entryIndex, string text)
        {
            _stealth.NumGumpTextEntry((ushort)gumpIndex, entryIndex, text);
        }

        public static void SelectRadioButton(int gumpIndex, int radioIndex)
        {
            _stealth.NumGumpRadiobutton((ushort)gumpIndex, radioIndex, 1);
        }

        public static void CheckCheckbox(int gumpIndex, int checkboxIndex)
        {
            _stealth.NumGumpCheckBox((ushort)gumpIndex, checkboxIndex, 1);
        }

        public static void WaitGump()
        {
            _stealth.WaitGump();
        }

        public static void CloseGump(int index)
        {
            _stealth.CloseSimpleGump(index);
        }
    }

    public class Gump
    {
        public uint Serial { get; set; }
        public uint GumpID { get; set; }
        public short X { get; set; }
        public short Y { get; set; }
        public int Pages { get; set; }
        public bool NoMove { get; set; }
        public bool NoResize { get; set; }
        public bool NoDispose { get; set; }
        public bool NoClose { get; set; }

        public List<Group> Groups { get; set; } = new();
        public List<EndGroup> EndGroups { get; set; } = new();
        public List<GumpButton> Buttons { get; set; } = new();
        public List<ButtonTileArt> ButtonTileArts { get; set; } = new();
        public List<CheckBox> CheckBoxes { get; set; } = new();
        public List<ChekerTrans> ChekerTrans { get; set; } = new();
        public List<CroppedText> CroppedText { get; set; } = new();
        public List<GumpPic> GumpPics { get; set; } = new();
        public List<GumpPicTiled> GumpPicTiled { get; set; } = new();
        public List<Radiobutton> RadioButtons { get; set; } = new();
        public List<ResizePic> ResizePics { get; set; } = new();
        public List<GumpText> GumpText { get; set; } = new();
        public List<TextEntry> TextEntries { get; set; } = new();
        public List<TextEntryLimited> TextEntriesLimited { get; set; } = new();
        public List<TilePic> TilePics { get; set; } = new();
        public List<TilePicHue> TilePicHue { get; set; } = new();
        public List<Tooltip> Tooltips { get; set; } = new();
        public List<HtmlGump> HtmlGump { get; set; } = new();
        public List<XmfHtmlGump> XmfHtmlGump { get; set; } = new();
        public List<XmfHTMLGumpColor> XmfHTMLGumpColor { get; set; } = new();
        public List<XmfHTMLTok> XmfHTMLTok { get; set; } = new();
        public List<ItemProperty> ItemProperties { get; set; } = new();
    }

    // Core Gump Metadata
    public class GumpInfo
    {
        public uint Serial { get; set; }
        public uint GumpID { get; set; }
        public short X { get; set; }
        public short Y { get; set; }
        public int Pages { get; set; }
        public bool NoMove { get; set; }
        public bool NoResize { get; set; }
        public bool NoDispose { get; set; }
        public bool NoClose { get; set; }
    }

    public class Group { public int GroupNumber { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }
    public class EndGroup : Group { }

    public class GumpButton { public int X { get; set; } public int Y { get; set; } public int ReleasedID { get; set; } public int PressedID { get; set; } public int Quit { get; set; } public int PageID { get; set; } public int ReturnValue { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }
    public class ButtonTileArt : GumpButton { public int ArtID { get; set; } public int Hue { get; set; } public int ArtX { get; set; } public int ArtY { get; set; } }

    public class CheckBox { public int X { get; set; } public int Y { get; set; } public int ReleasedID { get; set; } public int PressedID { get; set; } public int Status { get; set; } public int ReturnValue { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }
    public class ChekerTrans { public int X { get; set; } public int Y { get; set; } public int Width { get; set; } public int Height { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }

    public class CroppedText { public int X { get; set; } public int Y { get; set; } public int Width { get; set; } public int Height { get; set; } public int Color { get; set; } public int TextID { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }
    public class GumpPic { public int X { get; set; } public int Y { get; set; } public int ID { get; set; } public int Hue { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }

    public class GumpPicTiled { public int X { get; set; } public int Y { get; set; } public int Width { get; set; } public int Height { get; set; } public int GumpID { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }

    public class Radiobutton { public int X { get; set; } public int Y { get; set; } public int ReleasedID { get; set; } public int PressedID { get; set; } public int Status { get; set; } public int ReturnValue { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }

    public class ResizePic { public int X { get; set; } public int Y { get; set; } public int GumpID { get; set; } public int Width { get; set; } public int Height { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }
    public class GumpText { public int X { get; set; } public int Y { get; set; } public int Color { get; set; } public int TextID { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }

    public class TextEntry { public int X { get; set; } public int Y { get; set; } public int Width { get; set; } public int Height { get; set; } public int Color { get; set; } public int ReturnValue { get; set; } public int DefaultTextID { get; set; } public string RealValue { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }

    public class TextEntryLimited { public int X { get; set; } public int Y { get; set; } public int Width { get; set; } public int Height { get; set; } public int Color { get; set; } public int ReturnValue { get; set; } public int DefaultTextID { get; set; } public int Limit { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }

    public class TilePic { public int X { get; set; } public int Y { get; set; } public int ID { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }
    public class TilePicHue { public int X { get; set; } public int Y { get; set; } public int ID { get; set; } public int Color { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }

    public class Tooltip { public uint ClilocID { get; set; } public string Arguments { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }
    public class HtmlGump { public int X { get; set; } public int Y { get; set; } public int Width { get; set; } public int Height { get; set; } public int TextID { get; set; } public int Background { get; set; } public int Scrollbar { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }

    public class XmfHtmlGump { public int X { get; set; } public int Y { get; set; } public int Width { get; set; } public int Height { get; set; } public uint ClilocID { get; set; } public int Background { get; set; } public int Scrollbar { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }

    public class XmfHTMLGumpColor { public int X { get; set; } public int Y { get; set; } public int Width { get; set; } public int Height { get; set; } public uint ClilocID { get; set; } public int Background { get; set; } public int Scrollbar { get; set; } public int Hue { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }

    public class XmfHTMLTok { public int X { get; set; } public int Y { get; set; } public int Width { get; set; } public int Height { get; set; } public int Background { get; set; } public int Scrollbar { get; set; } public int Color { get; set; } public uint ClilocID { get; set; } public string Arguments { get; set; } public int Page { get; set; } public int ElemNum { get; set; } }

    public class ItemProperty { public uint Prop { get; set; } public int ElemNum { get; set; } }

}
