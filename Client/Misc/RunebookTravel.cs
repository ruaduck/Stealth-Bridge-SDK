using StealthBridgeSDK.Gumps;
using StealthBridgeSDK.Spells;


namespace StealthBridgeSDK.Miscellaneous
{
    public static class RuneBookConfigs
    {
        public enum RBConfig
        {
            OSI,
            RunUO,
            Sphere,
            DantesInferno,
            Custom2
        }
        public static RuneBookConfig Get(RBConfig config)
        {
            return config switch
            {
                RBConfig.OSI => new RuneBookConfig
                {
                    GumpID = 89,
                    ScrollOffset = 10,
                    DropOffset = 200,
                    DefaultOffset = 300,
                    RecallOffset = 50,
                    GateOffset = 100,
                    SacredOffset = 75,
                    Jumper = 1
                },

                RBConfig.RunUO => new RuneBookConfig
                {
                    GumpID = 89,
                    ScrollOffset = 0,
                    DropOffset = 2,
                    DefaultOffset = 3,
                    RecallOffset = 4,
                    GateOffset = 5,
                    SacredOffset = 6,
                    Jumper = 10
                },

                RBConfig.Sphere => new RuneBookConfig
                {
                    GumpID = 89,
                    ScrollOffset = 1,
                    DropOffset = 3,
                    DefaultOffset = 4,
                    RecallOffset = 5,
                    GateOffset = 6,
                    SacredOffset = 7,
                    Jumper = 12
                },

                RBConfig.DantesInferno => new RuneBookConfig
                {
                    GumpID = 89,
                    ScrollOffset = 10,
                    DropOffset = 200,
                    DefaultOffset = 300,
                    RecallOffset = 50,
                    GateOffset = 100,
                    SacredOffset = 75,
                    Jumper = 1
                },

                RBConfig.Custom2 => new RuneBookConfig
                {
                    GumpID = 89,
                    ScrollOffset = 1,
                    DropOffset = 1,
                    DefaultOffset = 1,
                    RecallOffset = 1,
                    GateOffset = 1,
                    SacredOffset = 1,
                    Jumper = 1
                },

                _ => throw new ArgumentOutOfRangeException(nameof(config), config, null)
            };
        }
        
    }
    public struct RuneBookConfig
    {
        public uint GumpID { get; set; }
        public int ScrollOffset { get; set; }
        public int DropOffset { get; set; }
        public int DefaultOffset { get; set; }
        public int RecallOffset { get; set; }
        public int GateOffset { get; set; }
        public int SacredOffset { get; set; }
        public int Jumper { get; set; }
    }
    public class Travel
    {
        public static void Recall(uint runebook, int bookspot)
        {
            Recall(runebook, bookspot, false);
        }
        public static void Gate(uint runebook, int bookspot)
        {
            Recall(runebook, bookspot, false);
        }
        public static void SacredJourney(uint runebook, int bookspot)
        {
            Recall(runebook, bookspot, false);
        }

        public static void Gate(uint runebook, int bookspot, bool usedefault)
        {
            RuneBookConfig config = RuneBookConfigs.Get(RuneBookConfigs.RBConfig.DantesInferno);
            Misc.UseObject(runebook);
            Thread.Sleep(500);
            Gump g = GetGump(89);  //UODantesInferno GumpID
            if (g == null)
                Console.WriteLine("Gump was null");
            foreach (var e in g.Buttons)
            {
                if (!usedefault) 
                { 
                    if (!e.ReturnValue.Equals(config.GateOffset + bookspot - 1) && !e.ReleasedID.Equals(2103) &&
                        !e.PressedID.Equals(2104)) continue;

                    GumpButton recallButton = g.Buttons.First(i => i.ReturnValue.Equals(config.GateOffset + (bookspot - 1)));
                    GumpWrapper.PressButton(g.GumpIndex, recallButton.ReturnValue);
                    break;
                }
                else
                {
                    if (!e.ReturnValue.Equals(config.DefaultOffset + bookspot - 1) && !e.ReleasedID.Equals(2103) &&
                        !e.PressedID.Equals(2104)) continue;

                    GumpButton recallButton = g.Buttons.First(i => i.ReturnValue.Equals(config.DefaultOffset + (bookspot - 1)));
                    GumpWrapper.PressButton(g.GumpIndex, recallButton.ReturnValue);
                    SpellHelper.CastAtTarget(MageryHelper.GetName(Magery.GateTravel), runebook, SkillName.Magery);
                }
            }
        }

        public static void SacredJourney(uint runebook, int bookspot, bool usedefault)
        {
            RuneBookConfig config = RuneBookConfigs.Get(RuneBookConfigs.RBConfig.DantesInferno);
            Misc.UseObject(runebook);
            Thread.Sleep(500);
            Gump g = GetGump(89);  //UODantesInferno GumpID
            if (g == null)
                Console.WriteLine("Gump was null");
            foreach (var e in g.Buttons)
            {
                if (!usedefault)
                {
                    if (!e.ReturnValue.Equals(config.SacredOffset + bookspot - 1) && !e.ReleasedID.Equals(2103) &&
                        !e.PressedID.Equals(2104)) continue;

                    GumpButton recallButton = g.Buttons.First(i => i.ReturnValue.Equals(config.SacredOffset + (bookspot - 1)));
                    GumpWrapper.PressButton(g.GumpIndex, recallButton.ReturnValue);
                    break;
                }
                else
                {
                    if (!e.ReturnValue.Equals(config.DefaultOffset + bookspot - 1) && !e.ReleasedID.Equals(2103) &&
                        !e.PressedID.Equals(2104)) continue;

                    GumpButton recallButton = g.Buttons.First(i => i.ReturnValue.Equals(config.DefaultOffset + (bookspot - 1)));
                    GumpWrapper.PressButton(g.GumpIndex, recallButton.ReturnValue);
                    SpellHelper.CastAtTarget(ChivalryHelper.GetName(ChivalrySpell.SacredJourney), runebook, SkillName.Chivalry);
                }
            }
        }

        public static void Recall(uint runebook, int bookspot, bool usedefault)
        {
            RuneBookConfig config = RuneBookConfigs.Get(RuneBookConfigs.RBConfig.DantesInferno);
            Misc.UseObject(runebook);
            Thread.Sleep(500);
            Gump g = GetGump(89);  //UODantesInferno GumpID
            if (g == null)
                Console.WriteLine("Gump was null");
            foreach (var e in g.Buttons)
            {
                if (!usedefault)
                {
                    if (!e.ReturnValue.Equals(config.SacredOffset + bookspot - 1) && !e.ReleasedID.Equals(2103) &&
                        !e.PressedID.Equals(2104)) continue;

                    GumpButton recallButton = g.Buttons.First(i => i.ReturnValue.Equals(config.SacredOffset + (bookspot - 1)));
                    GumpWrapper.PressButton(g.GumpIndex, recallButton.ReturnValue);
                    break;
                }
                else
                {
                    if (!e.ReturnValue.Equals(config.DefaultOffset + bookspot - 1) && !e.ReleasedID.Equals(2103) &&
                        !e.PressedID.Equals(2104)) continue;

                    GumpButton recallButton = g.Buttons.First(i => i.ReturnValue.Equals(config.DefaultOffset + (bookspot - 1)));
                    GumpWrapper.PressButton(g.GumpIndex, recallButton.ReturnValue);
                    SpellHelper.CastAtTarget(MageryHelper.GetName(Magery.Recall), runebook, SkillName.Magery);
                }
            }
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
    }
}
