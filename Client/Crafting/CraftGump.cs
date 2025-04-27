using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StealthBridgeSDK.Crafting;
using StealthBridgeSDK.Gumps;

namespace StealthBridgeSDK.Crafting
{
    public enum CraftCategory
    {
        Category1,
        Category2,
        Category3,
        Category4,
        Category5,
        Category6,
        Category7,
        Category8,
        Category9,
        Category10,
        Category11,
    }
    public enum Craftable
    {    
        Item1Page1,
        Item2Page1,
        Item3Page1,
        Item4Page1,
        Item5Page1,
        Item6Page1,
        Item7Page1,
        Item8Page1,
        Item9Page1,
        Item10Page1,
        Item1Page2,
        Item2Page2,
        Item3Page2,
        Item4Page2,
        Item5Page2,
        Item6Page2,
        Item7Page2,
        Item8Page2,
        Item9Page2,
        Item10Page2,
        Item1Page3,
        Item2Page3,
        Item3Page3,
        Item4Page3,
        Item5Page3,
        Item6Page3,
        Item7Page3,
        Item8Page3,
        Item9Page3,
        Item10Page3,
        Item1Page4,
        Item2Page4,
        Item3Page4,
        Item4Page4,
        Item5Page4,
        Item6Page4,
        Item7Page4,
        Item8Page4,
        Item9Page4,
        Item10Page4,
        Item1Page5,
        Item2Page5,
        Item3Page5,
        Item4Page5,
        Item5Page5,
        Item6Page5,
        Item7Page5,
        Item8Page5,
        Item9Page5,
        Item10Page5,
        Item1Page6,
        Item2Page6,
        Item3Page6,
        Item4Page6,
        Item5Page6,
        Item6Page6,
        Item7Page6,
        Item8Page6,
        Item9Page6,
        Item10Page6,
        Item1Page7,
        Item2Page7,
        Item3Page7,
        Item4Page7,
        Item5Page7,
        Item6Page7,
        Item7Page7,
        Item8Page7
    }
public class CraftGump
    {
        public static readonly Dictionary<CraftCategory, (int ReturnValue, int PressedID, int ReleasedID)> CraftingCategory = new()
        {
            {CraftCategory.Category1,(28,4007,4005) },
            {CraftCategory.Category2,(1,4007,4005) },
            {CraftCategory.Category3,(8,4007,4005) },
            {CraftCategory.Category4,(15,4007,4005) },
            {CraftCategory.Category5,(22,4007,4005) },
            {CraftCategory.Category6,(29,4007,4005) },
            {CraftCategory.Category7,(36,4007,4005) },
            {CraftCategory.Category8,(43,4007,4005) },
            {CraftCategory.Category9,(50,4007,4005) },
            {CraftCategory.Category10,(57,4007,4005) },
            {CraftCategory.Category11,(64,4007,4005) }
        };
        private static readonly Dictionary<Craftable, (int ReturnValue, int PressedID, int ReleasedID)> CraftButton = new()
        {
            {Craftable.Item1Page1,(2,4007,4005)},
            {Craftable.Item2Page1,(9,4007,4005)},
            {Craftable.Item3Page1,(16,4007,4005)},
            {Craftable.Item4Page1,(23,4007,4005)},
            {Craftable.Item5Page1,(30,4007,4005)},
            {Craftable.Item6Page1,(37,4007,4005)},
            {Craftable.Item7Page1,(44,4007,4005)},
            {Craftable.Item8Page1,(51,4007,4005)},
            {Craftable.Item9Page1,(58,4007,4005)},
            {Craftable.Item10Page1,(65,4007,4005)},
            {Craftable.Item1Page2,(72,4007,4005)},
            {Craftable.Item2Page2,(79,4007,4005)},
            {Craftable.Item3Page2,(86,4007,4005)},
            {Craftable.Item4Page2,(93,4007,4005)},
            {Craftable.Item5Page2,(100,4007,4005)},
            {Craftable.Item6Page2,(107,4007,4005)},
            {Craftable.Item7Page2,(114,4007,4005)},
            {Craftable.Item8Page2,(121,4007,4005)},
            {Craftable.Item9Page2,(128,4007,4005)},
            {Craftable.Item10Page2,(135,4007,4005)},
            {Craftable.Item1Page3,(142,4007,4005)},
            {Craftable.Item2Page3,(149,4007,4005)},
            {Craftable.Item3Page3,(156,4007,4005)},
            {Craftable.Item4Page3,(163,4007,4005)},
            {Craftable.Item5Page3,(170,4007,4005)},
            {Craftable.Item6Page3,(177,4007,4005)},
            {Craftable.Item7Page3,(184,4007,4005)},
            {Craftable.Item8Page3,(191,4007,4005)},
            {Craftable.Item9Page3,(198,4007,4005)},
            {Craftable.Item10Page3,(205,4007,4005)},
            {Craftable.Item1Page4,(212,4007,4005)},
            {Craftable.Item2Page4,(219,4007,4005)},
            {Craftable.Item3Page4,(226,4007,4005)},
            {Craftable.Item4Page4,(233,4007,4005)},
            {Craftable.Item5Page4,(240,4007,4005)},
            {Craftable.Item6Page4,(247,4007,4005)},
            {Craftable.Item7Page4,(254,4007,4005)},
            {Craftable.Item8Page4,(261,4007,4005)},
            {Craftable.Item9Page4,(268,4007,4005)},
            {Craftable.Item10Page4,(275,4007,4005)},
            {Craftable.Item1Page5,(282,4007,4005)},
            {Craftable.Item2Page5,(289,4007,4005)},
            {Craftable.Item3Page5,(296,4007,4005)},
            {Craftable.Item4Page5,(303,4007,4005)},
            {Craftable.Item5Page5,(310,4007,4005)},
            {Craftable.Item6Page5,(317,4007,4005)},
            {Craftable.Item7Page5,(324,4007,4005)},
            {Craftable.Item8Page5,(331,4007,4005)},
            {Craftable.Item9Page5,(338,4007,4005)},
            {Craftable.Item10Page5,(345,4007,4005)},
            {Craftable.Item1Page6,(352,4007,4005)},
            {Craftable.Item2Page6,(359,4007,4005)},
            {Craftable.Item3Page6,(366,4007,4005)},
            {Craftable.Item4Page6,(373,4007,4005)},
            {Craftable.Item5Page6,(380,4007,4005)},
            {Craftable.Item6Page6,(387,4007,4005)},
            {Craftable.Item7Page6,(394,4007,4005)},
            {Craftable.Item8Page6,(401,4007,4005)},
            {Craftable.Item9Page6,(408,4007,4005)},
            {Craftable.Item10Page6,(415,4007,4005)},
            {Craftable.Item1Page7,(422,4007,4005)},
            {Craftable.Item2Page7,(429,4007,4005)},
            {Craftable.Item3Page7,(436,4007,4005)},
            {Craftable.Item4Page7,(443,4007,4005)},
            {Craftable.Item5Page7,(450,4007,4005)},
            {Craftable.Item6Page7,(457,4007,4005)},
            {Craftable.Item7Page7,(464,4007,4005)},
            {Craftable.Item8Page7,(471,4007,4005)},

        };
        public enum MiscButtons
        {
            SmeltItem,
            CraftResource,
            Scales,
            RepairItem,
            MarkItem,
            EnhanceItem,
            AlterItem,
            NonQuestItem,
            MakeLast,
            Exit,
            CancelMake,
        }
        private static readonly Dictionary<MiscButtons, (int ReturnValue, int PressedID, int ReleasedID)> MiscButton = new()
        {
            {MiscButtons.SmeltItem,(14,4007,4005) },
            {MiscButtons.CraftResource,(7,4007,4005) },
            {MiscButtons.Scales,(56,4007,4005) },
            {MiscButtons.Exit,(0,4019,4017) },
            {MiscButtons.CancelMake,(84,4019,4017) },
            {MiscButtons.RepairItem,(42,4007,4005) },
            {MiscButtons.MarkItem,(49,4007,4005) },
            {MiscButtons.EnhanceItem,(63,4007,4005) },
            {MiscButtons.AlterItem,(70,4007,4005) },
            {MiscButtons.NonQuestItem,(77,4007,4005) },
            {MiscButtons.MakeLast,(21,4007,4005) }
        };
        public static Gump MainGump { get; set; }
        public static bool Initialized { get; set; } = false;


        public static void Initialize()
        {
            MainGump = GetGump(2653346093);
            Initialized = true;
        }

        private static Gump GetGump(uint gumpid)
        {
            uint gumpCount = GumpWrapper.GetGumpsCount();
            for (int i = 0; i < gumpCount; i++)
            {
                var gump = GumpWrapper.DumpGumpInfo(i);
                if (gump.GumpID == gumpid)
                {
                    gump.GumpIndex = i;
                    return gump;
                }
            }
            return null;
        }
        public static void Craft(Craftable craft, CraftCategory cat )
        {
            Gump g = MainGump;
            if (g == null) { Logger.Warn($"Craft Gump came Back Null"); return; }
            ClickCategory(cat);
            foreach (var e in g.Buttons)
            {
                if (!e.ReturnValue.Equals(CraftButton[craft].ReturnValue) && !e.ReleasedID.Equals(CraftButton[craft].ReleasedID) &&
                    !e.PressedID.Equals(CraftButton[craft].PressedID)) continue;

                GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(CraftButton[craft].ReturnValue));
                GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                break;
            }
        }

        public static void ClickCategory(CraftCategory cat)
        {
            Gump g = MainGump;

            foreach (var e in g.Buttons)
            {
                if (!e.ReturnValue.Equals(CraftingCategory[cat].ReturnValue) && !e.ReleasedID.Equals(CraftingCategory[cat].ReleasedID) &&
                    !e.PressedID.Equals(CraftingCategory[cat].PressedID)) continue;

                GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(CraftingCategory[cat].ReturnValue));
                GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                break;
            }
        }
        public static void ClickRepairItem()
        {
            Gump g = MainGump;

            foreach (var e in g.Buttons)
            {
                if (!e.ReturnValue.Equals(MiscButton[MiscButtons.RepairItem].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.RepairItem].ReleasedID) &&
                    !e.PressedID.Equals(MiscButton[MiscButtons.RepairItem].PressedID)) continue;

                GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.RepairItem].ReturnValue));
                GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                break;
            }
        }
        public static void ClickMarkItem()
        {
            Gump g = MainGump;

            foreach (var e in g.Buttons)
            {
                if (!e.ReturnValue.Equals(MiscButton[MiscButtons.MarkItem].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.MarkItem].ReleasedID) &&
                    !e.PressedID.Equals(MiscButton[MiscButtons.MarkItem].PressedID)) continue;

                GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.MarkItem].ReturnValue));
                GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                break;
            }
        }
        public static void ClickEnhanceItem()
        {
            Gump g = MainGump;

            foreach (var e in g.Buttons)
            {
                if (!e.ReturnValue.Equals(MiscButton[MiscButtons.EnhanceItem].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.EnhanceItem].ReleasedID) &&
                    !e.PressedID.Equals(MiscButton[MiscButtons.EnhanceItem].PressedID)) continue;

                GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.EnhanceItem].ReturnValue));
                GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                break;
            }
        }
        public static void ClickAlterItem()
        {
            Gump g = MainGump;

            foreach (var e in g.Buttons)
            {
                if (!e.ReturnValue.Equals(MiscButton[MiscButtons.AlterItem].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.AlterItem].ReleasedID) &&
                    !e.PressedID.Equals(MiscButton[MiscButtons.AlterItem].PressedID)) continue;

                GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.AlterItem].ReturnValue));
                GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                break;
            }
        }
        public static void ClickNonQuestItem()
        {
            Gump g = MainGump;

            foreach (var e in g.Buttons)
            {
                if (!e.ReturnValue.Equals(MiscButton[MiscButtons.NonQuestItem].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.NonQuestItem].ReleasedID) &&
                    !e.PressedID.Equals(MiscButton[MiscButtons.NonQuestItem].PressedID)) continue;

                GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.NonQuestItem].ReturnValue));
                GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                break;
            }
        }
        public static void ClickMakeLast()
        {
            Gump g = MainGump;

            foreach (var e in g.Buttons)
            {
                if (!e.ReturnValue.Equals(MiscButton[MiscButtons.MakeLast].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.MakeLast].ReleasedID) &&
                    !e.PressedID.Equals(MiscButton[MiscButtons.MakeLast].PressedID)) continue;

                GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.MakeLast].ReturnValue));
                GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                break;
            }
        }
        public static void ClickSmeltItem()
        {
            Gump g = MainGump;

            foreach (var e in g.Buttons)
            {
                if (!e.ReturnValue.Equals(MiscButton[MiscButtons.SmeltItem].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.SmeltItem].ReleasedID) &&
                    !e.PressedID.Equals(MiscButton[MiscButtons.SmeltItem].PressedID)) continue;

                GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.SmeltItem].ReturnValue));
                GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                break;
            }
        }
        public static void ClickCraftResource()
        {
            Gump g = MainGump;

            foreach (var e in g.Buttons)
            {
                if (!e.ReturnValue.Equals(MiscButton[MiscButtons.CraftResource].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.CraftResource].ReleasedID) &&
                    !e.PressedID.Equals(MiscButton[MiscButtons.CraftResource].PressedID)) continue;

                GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.CraftResource].ReturnValue));
                GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                break;
            }
        }
        public static void ClickScales()
        {
            Gump g = MainGump;

            foreach (var e in g.Buttons)
            {
                if (!e.ReturnValue.Equals(MiscButton[MiscButtons.Scales].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.Scales].ReleasedID) &&
                    !e.PressedID.Equals(MiscButton[MiscButtons.Scales].PressedID)) continue;

                GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.Scales].ReturnValue));
                GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                break;
            }
        }
    }
}
