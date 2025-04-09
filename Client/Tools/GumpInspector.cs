
using System;
using StealthBridgeSDK.Gumps;

namespace StealthBridgeSDK.Tools
{
    public static class GumpInspector
    {
        public static void InspectAllOpenGumps()
        {
            uint gumpCount = GumpWrapper.GetGumpsCount();
            Console.WriteLine($"> Found {gumpCount} open gump(s).");

            for (int i = 0; i < gumpCount; i++)
            {
                var gump = GumpWrapper.DumpGumpInfo(i);

                Console.WriteLine($"==== Gump [{i}] ====");
                Console.WriteLine($"ID      : {gump.GumpID}");
                Console.WriteLine($"Serial  : {gump.Serial}");
                Console.WriteLine($"Pages   : {gump.Pages}");
                Console.WriteLine($"X,Y     : {gump.X},{gump.Y}");
                Console.WriteLine($"Flags   : NoMove={gump.NoMove}, NoResize={gump.NoResize}, NoDispose={gump.NoDispose}, NoClose={gump.NoClose}");

                Dump("Groups", gump.Groups, g => $"  GroupNumber={g.GroupNumber}, Page={g.Page}, ElemNum={g.ElemNum}");
                Dump("EndGroups", gump.EndGroups, eg => $"  Page={eg.Page}, ElemNum={eg.ElemNum}");
                Dump("Buttons", gump.Buttons, b => $"  ReturnValue={b.ReturnValue}, Page={b.Page}, PageID={b.PageID}, Quit={b.Quit}, PressedID={b.PressedID}, ReleasedID={b.ReleasedID} at ({b.X},{b.Y})");
                Dump("ButtonTileArts", gump.ButtonTileArts, b => $"  ReturnValue={b.ReturnValue}, ArtID={b.ArtID}, Hue={b.Hue} at ({b.X},{b.Y})");
                Dump("CheckBoxes", gump.CheckBoxes, cb => $"  ReturnValue={cb.ReturnValue}, Status={cb.Status} at ({cb.X},{cb.Y})");
                Dump("ChekerTrans", gump.ChekerTrans, c => $"  Size=({c.Width}x{c.Height}) at ({c.X},{c.Y}) Page={c.Page}");
                Dump("CroppedText", gump.CroppedText, t => $"  TextID={t.TextID}, Color={t.Color}, Size=({t.Width}x{t.Height}) at ({t.X},{t.Y})");
                Dump("GumpPics", gump.GumpPics, p => $"  ID={p.ID}, Hue={p.Hue} at ({p.X},{p.Y})");
                Dump("GumpPicTiled", gump.GumpPicTiled, p => $"  GumpID={p.GumpID}, Size=({p.Width}x{p.Height}) at ({p.X},{p.Y})");
                Dump("RadioButtons", gump.RadioButtons, r => $"  ReturnValue={r.ReturnValue}, Status={r.Status} at ({r.X},{r.Y})");
                Dump("ResizePics", gump.ResizePics, r => $"  GumpID={r.GumpID}, Size=({r.Width}x{r.Height}) at ({r.X},{r.Y})");
                Dump("GumpText", gump.GumpText, t => $"  TextID={t.TextID}, Color={t.Color} at ({t.X},{t.Y})");
                Dump("TextEntries", gump.TextEntries, t => $"  ReturnValue={t.ReturnValue}, Text={t.RealValue}, Color={t.Color} at ({t.X},{t.Y})");
                Dump("TextEntriesLimited", gump.TextEntriesLimited, t => $"  ReturnValue={t.ReturnValue}, Limit={t.Limit}, Color={t.Color} at ({t.X},{t.Y})");
                Dump("TilePics", gump.TilePics, t => $"  ID={t.ID} at ({t.X},{t.Y})");
                Dump("TilePicHue", gump.TilePicHue, t => $"  ID={t.ID}, Hue={t.Color} at ({t.X},{t.Y})");
                Dump("Tooltips", gump.Tooltips, t => $"  ClilocID={t.ClilocID}, Arguments={t.Arguments}, Page={t.Page}");
                Dump("HtmlGump", gump.HtmlGump, h => $"  TextID={h.TextID}, Size=({h.Width}x{h.Height}) at ({h.X},{h.Y})");
                Dump("XmfHtmlGump", gump.XmfHtmlGump, x => $"  ClilocID={x.ClilocID}, Size=({x.Width}x{x.Height}) at ({x.X},{x.Y})");
                Dump("XmfHTMLGumpColor", gump.XmfHTMLGumpColor, x => $"  ClilocID={x.ClilocID}, Hue={x.Hue}, Size=({x.Width}x{x.Height}) at ({x.X},{x.Y})");
                Dump("XmfHTMLTok", gump.XmfHTMLTok, x => $"  ClilocID={x.ClilocID}, Args={x.Arguments}, Color={x.Color} at ({x.X},{x.Y})");
                Dump("ItemProperties", gump.ItemProperties, ip => $"  Prop={ip.Prop}, ElemNum={ip.ElemNum}");

                Console.WriteLine();
            }
        }

        private static void Dump<T>(string label, List<T> items, Func<T, string> formatter)
        {
            if (items?.Count > 0)
            {
                Console.WriteLine($"-- {label} --");
                foreach (var item in items)
                    Console.WriteLine(formatter(item));
            }
        }
    }

}
