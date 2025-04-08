using System;
using System.Collections.Generic;
using Python.Runtime;
using StealthBridgeSDK.Gumps;

namespace StealthBridgeSDK.Gumps
{
    public static class GumpReader
    {
        public static List<Group> GetGroup(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<Group> result = new List<Group>();
                if (!dict.HasKey("Groups".ToPython()))
                    return result;

                var list = dict["Groups"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    Group item = new Group();
                    item.GroupNumber = list[i].GetItem("GroupNumber").As<int>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<EndGroup> GetEndGroup(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<EndGroup> result = new List<EndGroup>();
                if (!dict.HasKey("EndGroups".ToPython()))
                    return result;

                var list = dict["EndGroups"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    EndGroup item = new EndGroup();
                    item.GroupNumber = list[i].GetItem("GroupNumber").As<int>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<GumpButton> GetGumpButton(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<GumpButton> result = new List<GumpButton>();
                if (!dict.HasKey("GumpButtons".ToPython()))
                    return result;

                var list = dict["GumpButtons"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    GumpButton item = new GumpButton();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.ReleasedID = list[i].GetItem("ReleasedID").As<int>();
                    item.PressedID = list[i].GetItem("PressedID").As<int>();
                    item.Quit = list[i].GetItem("Quit").As<int>();
                    item.PageID = list[i].GetItem("PageID").As<int>();
                    item.ReturnValue = list[i].GetItem("ReturnValue").As<int>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<ButtonTileArt> GetButtonTileArt(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<ButtonTileArt> result = new List<ButtonTileArt>();
                if (!dict.HasKey("ButtonTileArts".ToPython()))
                    return result;

                var list = dict["ButtonTileArts"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    ButtonTileArt item = new ButtonTileArt();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.ReleasedID = list[i].GetItem("ReleasedID").As<int>();
                    item.PressedID = list[i].GetItem("PressedID").As<int>();
                    item.Quit = list[i].GetItem("Quit").As<int>();
                    item.PageID = list[i].GetItem("PageID").As<int>();
                    item.ReturnValue = list[i].GetItem("ReturnValue").As<int>();
                    item.ArtID = list[i].GetItem("ArtID").As<int>();
                    item.Hue = list[i].GetItem("Hue").As<int>();
                    item.ArtX = list[i].GetItem("ArtX").As<int>();
                    item.ArtY = list[i].GetItem("ArtY").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<CheckBox> GetCheckBox(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<CheckBox> result = new List<CheckBox>();
                if (!dict.HasKey("CheckBoxes".ToPython()))
                    return result;

                var list = dict["CheckBoxes"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    CheckBox item = new CheckBox();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.ReleasedID = list[i].GetItem("ReleasedID").As<int>();
                    item.PressedID = list[i].GetItem("PressedID").As<int>();
                    item.Status = list[i].GetItem("Status").As<int>();
                    item.ReturnValue = list[i].GetItem("ReturnValue").As<int>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<ChekerTrans> GetChekerTrans(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<ChekerTrans> result = new List<ChekerTrans>();
                if (!dict.HasKey("ChekerTrans".ToPython()))
                    return result;

                var list = dict["ChekerTrans"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    ChekerTrans item = new ChekerTrans();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.Width = list[i].GetItem("Width").As<int>();
                    item.Height = list[i].GetItem("Height").As<int>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<CroppedText> GetCroppedText(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<CroppedText> result = new List<CroppedText>();
                if (!dict.HasKey("CroppedText".ToPython()))
                    return result;

                var list = dict["CroppedText"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    CroppedText item = new CroppedText();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.Width = list[i].GetItem("Width").As<int>();
                    item.Height = list[i].GetItem("Height").As<int>();
                    item.Color = list[i].GetItem("Color").As<int>();
                    item.TextID = list[i].GetItem("TextID").As<int>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<GumpPic> GetGumpPic(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<GumpPic> result = new List<GumpPic>();
                if (!dict.HasKey("GumpPics".ToPython()))
                    return result;

                var list = dict["GumpPics"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    GumpPic item = new GumpPic();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.ID = list[i].GetItem("ID").As<int>();
                    item.Hue = list[i].GetItem("Hue").As<int>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<GumpPicTiled> GetGumpPicTiled(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<GumpPicTiled> result = new List<GumpPicTiled>();
                if (!dict.HasKey("GumpPicTiled".ToPython()))
                    return result;

                var list = dict["GumpPicTiled"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    GumpPicTiled item = new GumpPicTiled();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.Width = list[i].GetItem("Width").As<int>();
                    item.Height = list[i].GetItem("Height").As<int>();
                    item.GumpID = list[i].GetItem("GumpID").As<int>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<Radiobutton> GetRadiobutton(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<Radiobutton> result = new List<Radiobutton>();
                if (!dict.HasKey("RadioButtons".ToPython()))
                    return result;

                var list = dict["RadioButtons"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    Radiobutton item = new Radiobutton();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.ReleasedID = list[i].GetItem("ReleasedID").As<int>();
                    item.PressedID = list[i].GetItem("PressedID").As<int>();
                    item.Status = list[i].GetItem("Status").As<int>();
                    item.ReturnValue = list[i].GetItem("ReturnValue").As<int>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<ResizePic> GetResizePic(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<ResizePic> result = new List<ResizePic>();
                if (!dict.HasKey("ResizePics".ToPython()))
                    return result;

                var list = dict["ResizePics"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    ResizePic item = new ResizePic();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.GumpID = list[i].GetItem("GumpID").As<int>();
                    item.Width = list[i].GetItem("Width").As<int>();
                    item.Height = list[i].GetItem("Height").As<int>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<GumpText> GetGumpText(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<GumpText> result = new List<GumpText>();
                if (!dict.HasKey("GumpText".ToPython()))
                    return result;

                var list = dict["GumpText"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    GumpText item = new GumpText();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.Color = list[i].GetItem("Color").As<int>();
                    item.TextID = list[i].GetItem("TextID").As<int>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<TextEntry> GetTextEntry(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<TextEntry> result = new List<TextEntry>();
                if (!dict.HasKey("TextEntries".ToPython()))
                    return result;

                var list = dict["TextEntries"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    TextEntry item = new TextEntry();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.Width = list[i].GetItem("Width").As<int>();
                    item.Height = list[i].GetItem("Height").As<int>();
                    item.Color = list[i].GetItem("Color").As<int>();
                    item.ReturnValue = list[i].GetItem("ReturnValue").As<int>();
                    item.DefaultTextID = list[i].GetItem("DefaultTextID").As<int>();
                    item.RealValue = list[i].GetItem("RealValue").As<string>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<TextEntryLimited> GetTextEntryLimited(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<TextEntryLimited> result = new List<TextEntryLimited>();
                if (!dict.HasKey("TextEntryLimited".ToPython()))
                    return result;

                var list = dict["TextEntryLimited"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    TextEntryLimited item = new TextEntryLimited();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.Width = list[i].GetItem("Width").As<int>();
                    item.Height = list[i].GetItem("Height").As<int>();
                    item.Color = list[i].GetItem("Color").As<int>();
                    item.ReturnValue = list[i].GetItem("ReturnValue").As<int>();
                    item.DefaultTextID = list[i].GetItem("DefaultTextID").As<int>();
                    item.Limit = list[i].GetItem("Limit").As<int>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<TilePic> GetTilePic(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<TilePic> result = new List<TilePic>();
                if (!dict.HasKey("TilePics".ToPython()))
                    return result;

                var list = dict["TilePics"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    TilePic item = new TilePic();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.ID = list[i].GetItem("ID").As<int>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<TilePicHue> GetTilePicHue(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<TilePicHue> result = new List<TilePicHue>();
                if (!dict.HasKey("TilePicHue".ToPython()))
                    return result;

                var list = dict["TilePicHue"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    TilePicHue item = new TilePicHue();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.ID = list[i].GetItem("ID").As<int>();
                    item.Color = list[i].GetItem("Color").As<int>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<Tooltip> GetTooltip(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<Tooltip> result = new List<Tooltip>();
                if (!dict.HasKey("Tooltips".ToPython()))
                    return result;

                var list = dict["Tooltips"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    Tooltip item = new Tooltip();
                    item.ClilocID = list[i].GetItem("ClilocID").As<uint>();
                    item.Arguments = list[i].GetItem("Arguments").As<string>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<HtmlGump> GetHtmlGump(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<HtmlGump> result = new List<HtmlGump>();
                if (!dict.HasKey("HtmlGump".ToPython()))
                    return result;

                var list = dict["HtmlGump"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    HtmlGump item = new HtmlGump();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.Width = list[i].GetItem("Width").As<int>();
                    item.Height = list[i].GetItem("Height").As<int>();
                    item.TextID = list[i].GetItem("TextID").As<int>();
                    item.Background = list[i].GetItem("Background").As<int>();
                    item.Scrollbar = list[i].GetItem("Scrollbar").As<int>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<XmfHtmlGump> GetXmfHtmlGump(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<XmfHtmlGump> result = new List<XmfHtmlGump>();
                if (!dict.HasKey("XmfHtmlGump".ToPython()))
                    return result;

                var list = dict["XmfHtmlGump"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    XmfHtmlGump item = new XmfHtmlGump();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.Width = list[i].GetItem("Width").As<int>();
                    item.Height = list[i].GetItem("Height").As<int>();
                    item.ClilocID = list[i].GetItem("ClilocID").As<uint>();
                    item.Background = list[i].GetItem("Background").As<int>();
                    item.Scrollbar = list[i].GetItem("Scrollbar").As<int>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<XmfHTMLGumpColor> GetXmfHTMLGumpColor(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<XmfHTMLGumpColor> result = new List<XmfHTMLGumpColor>();
                if (!dict.HasKey("XmfHTMLGumpColor".ToPython()))
                    return result;

                var list = dict["XmfHTMLGumpColor"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    XmfHTMLGumpColor item = new XmfHTMLGumpColor();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.Width = list[i].GetItem("Width").As<int>();
                    item.Height = list[i].GetItem("Height").As<int>();
                    item.ClilocID = list[i].GetItem("ClilocID").As<uint>();
                    item.Background = list[i].GetItem("Background").As<int>();
                    item.Scrollbar = list[i].GetItem("Scrollbar").As<int>();
                    item.Hue = list[i].GetItem("Hue").As<int>();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<XmfHTMLTok> GetXmfHTMLTok(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<XmfHTMLTok> result = new List<XmfHTMLTok>();
                if (!dict.HasKey("XmfHTMLTok".ToPython()))
                    return result;

                var list = dict["XmfHTMLTok"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    XmfHTMLTok item = new XmfHTMLTok();
                    item.X = list[i].GetItem("X").As<int>();
                    item.Y = list[i].GetItem("Y").As<int>();
                    item.Width = list[i].GetItem("Width").As<int>();
                    item.Height = list[i].GetItem("Height").As<int>();
                    item.Background = list[i].GetItem("Background").As<int>();
                    item.Scrollbar = list[i].GetItem("Scrollbar").As<int>();
                    item.Color = list[i].GetItem("Color").As<int>();
                    item.ClilocID = list[i].GetItem("ClilocID").As<uint>();
                    item.Arguments = list[i].GetItem("Arguments").ToString();
                    item.Page = list[i].GetItem("Page").As<int>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<ItemProperty> GetItemProperty(PyObject gumpInfo)
        {
            using (Py.GIL())
            {
                var dict = new PyDict(gumpInfo);
                List<ItemProperty> result = new List<ItemProperty>();
                if (!dict.HasKey("ItemProperties".ToPython()))
                    return result;

                var list = dict["ItemProperties"];
                for (int i = 0; i < (int)list.Length(); i++)
                {
                    ItemProperty item = new ItemProperty();
                    item.Prop = list[i].GetItem("Prop").As<uint>();
                    item.ElemNum = list[i].GetItem("ElemNum").As<int>();
                    result.Add(item);
                }
                return result;
            }
        }
    }
}