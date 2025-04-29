using StealthBridgeSDK.Targeting;
using StealthBridgeSDK.Characters;
using StealthBridgeSDK.Finding;
using StealthBridgeSDK.Movement;
using StealthBridgeSDK.Skills;
using StealthBridgeSDK.Journal;
using StealthBridgeSDK.Helpers;
using StealthBridgeSDK.Mobiles;
using StealthBridgeSDK.Spells;
using StealthBridgeSDK.Gumps;


namespace StealthBridgeSDK.Trainers
{
    public static class AnimalTaming
    {
        public static int BrittPenSpot;
        public static int Home;
        public static ushort[] MobTypes = { };
        public static uint MaxDistance = 7;
        public static bool Debug = false; // Set to true for debug messages
        public static bool TameSuccess = false;
        public static bool TameFail = false;
        public static bool StartTame = false;
        public static bool _Magery = false;

        public static void CheckEntries(JournalEntry entry)
        {
                if (entry.Text.Contains("accepts you as"))
                {
                    TameSuccess = true;
                    StartTame = false;
                    TameFail = false;
                    Logger.Info("Tame success!");
                }
                else if (entry.Text.Contains("You failed to tame the creature"))
                {
                    TameFail = true;
                    StartTame = false;
                    TameSuccess = false;
                    Logger.Info("Tame failed.");
                }
                else if (entry.Text.Contains("You are too far away"))
                {
                    StartTame = true;
                    TameSuccess = false;
                    TameFail = false;
                    Logger.Info("Start tame.");
                }
            else
            {
                Logger.Info($"Unhandled entry: {entry.ToString}"); // Debug message for unhandled entries
            }
            
        }
        public static void Train()
        {
            if (Debug) Logger.SetLevel(LogLevel.Info);
            else Logger.SetLevel(LogLevel.Warn);
            //JournalWrapper.ClearJournal();
            //JournalWatcher.OnNewEntry += (sender, entry) =>
            //{
            //    CheckEntries(entry);
            //};
            //JournalWatcher.StartWatching(100);
            var self = Character.Self();

            Console.Write("Enter target Taming skill to stop at (e.g., 100.0): ");
            string? skillInput = Console.ReadLine();
            if (!float.TryParse(skillInput, out float skillTarget))
            {
                Logger.Error("Invalid skill target input.");
                return;
            }
            Console.Write("Use Magery to kill tames?: ");
            skillInput = Console.ReadLine();
            if (skillInput == "y" || skillInput == "Y" || skillInput == "Yes" || skillInput == "yes" || skillInput == "YES")
            {
                _Magery = true;
            }
            else if (skillInput == "n" || skillInput == "N")
            {
                _Magery = false;
            }
            else
            {
                Logger.Error("Invalid input. Please enter 'y' or 'n'.");
                return;
            }
            float skill = SkillWrapper.GetSkillValue(SkillName.AnimalTaming);
            GetTrainingLevel(skill);
            //Console.WriteLine("Select your runebook.");
            //Target.ClientRequestObjectTarget();
            //Target.WaitForClientTargetResponse(2000);
            //var runebook = Target.LastTarget();

            //Console.Write("What Number Spot for your Home?");
            //Home = Convert.ToInt32(Console.ReadLine());
            //Console.Write("What Number Spot for Britt Pens?");
            //BrittPenSpot = Convert.ToInt32(Console.ReadLine());

            //Logger.Info($"Starting Animal Taming training until skill reaches {skillTarget:F1}...");

            //Travel.Recall(runebook, BrittPenSpot);
            var found = GetTargetSerials();
            while (true)
            {
                skill = SkillWrapper.GetSkillValue(SkillName.AnimalTaming);

                if (skill >= skillTarget)
                {
                    Logger.Info($"Reached target skill {skill:F1}. Stopping training.");
                    break;
                }

                var oldmobtypes = MobTypes;
                GetTrainingLevel(skill);
                if(oldmobtypes != MobTypes)
                {
                    found = GetTargetSerials();
                }


                if (found == null || found.Count == 0)
                {
                    if (Debug) Console.WriteLine("No tamable creatures found nearby. Waiting...");
                    Thread.Sleep(1000);
                    continue;
                }

                // Step 2: Pick first one (or closest one if you want to sort)
                if (found.Count == 0)
                {
                    found = GetTargetSerials();
                }
                var targetSerial = found.First();
                found.RemoveAt(0); // Remove the first one from the list
                if (Debug) Console.WriteLine($"Found target: 0x{targetSerial:X}");
                var pets = Character.PetsCurrent();
                while (!TameSuccess)
                {
                    // Step 3: Move to target
                    MovementHelper.MoveTo(Mobile.GetX(targetSerial), Mobile.GetY(targetSerial));
                    // Step 4: Attempt to tame
                    TryTame(targetSerial);
                }
                TameSuccess = false;
                KillTame(targetSerial);
                
            }
            //Travel.Recall(runebook, Home);
            Logger.SetLevel(LogLevel.Info);
        }

        private static List<uint> GetTargetSerials()
        {
            List<uint> found = new List<uint>();
            // Step 1: Search for nearby mobs
            FindWrapper.SetFindDistance(MaxDistance);
            foreach (var mobType in MobTypes)
            {
                FindWrapper.FindType(mobType, 0);
                var objects = FindWrapper.GetFoundList();
                foreach (var obj in objects)
                {
                    if (obj != 0 && !found.Contains(obj))
                    {
                        found.Add(obj);
                    }
               
                }
            }
            return found;
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
        private static void KillTame(uint target)
        {
            var name = Mobile.GetName(target);
            Character.Say($"{name} release");
            Thread.Sleep(500);
            var g = GetGump(3432224886);
            GumpWrapper.PressButton(g.GumpIndex, 2);
            if (_Magery) 
            { 
                string spell = MageryHelper.SpellMap[Magery.Fireball].Name;
                while (Mobile.GetHP(target) > 0)
                {
                    SpellHelper.CastAtTarget(spell, target, SkillName.Magery);
                }
                Target.CancelTarget();
            }
            else
            {
                while (Mobile.GetHP(target) > 0)
                {
                    Character.Attack(target);
                }
            }
        }
        private static void TryTame(uint serial)
        {
            var tries = 0;
            var pets = Character.PetsCurrent();
            while (!TameSuccess)
            {
                if (tries > 0)
                {
                    Logger.Warn($"Tame failed. Retrying... ({tries})");                    
                }
                if(tries > 15)
                {
                    Logger.Error($"Tame failed. Exiting after ({tries}) tries");
                    break;
                }
                Logger.Info($"Trying to tame 0x{serial:X}");

                // Target the mob
                SkillWrapper.UseSkill(SkillName.AnimalTaming);

                if (Target.WaitForTarget(2000))
                {
                    Target.TargetToObject(serial);
                    Logger.Info("Sent tame target.");
                }
                else
                {
                    Logger.Info("No tame target prompt appeared.");
                }
                var startTime = DateTime.Now;
                while (!TameSuccess || !TameFail)
                {                    
                    Logger.Info("Waiting for tame to finish...");
                    if (pets != Character.PetsCurrent())
                    {
                        TameSuccess = true;
                    }
                    if ((DateTime.Now - startTime).TotalMilliseconds >= 16000)
                    {
                        TameFail = true;
                        Logger.Info("Tame failed.");
                        break;
                    }
                    AutoFollow(serial, 1, 1000, false);

                }
                tries++;
            }
        }
        public static void AutoFollow(uint targetSerial, int stopDistance = 1, int maxFollowTimeMs = 0, bool run = false)
        {
            //Console.WriteLine($"[AutoFollow] Starting follow of 0x{targetSerial:X} with stop distance {stopDistance}");

            var startTime = DateTime.Now;

            while (true)
            {
                // Check for timeout
                if (maxFollowTimeMs > 0 && (DateTime.Now - startTime).TotalMilliseconds >= maxFollowTimeMs)
                {
                    Logger.Info("[AutoFollow] Timed out.");
                    break;
                }

                // Check if target still exists
                var mobile = Mobile.GetHP(targetSerial);
                if (mobile == null || mobile == 0)
                {
                    if (Debug) Console.WriteLine("[AutoFollow] Target disappeared.");
                    break;
                }

                // Calculate distance
                int dx = Math.Abs(Character.GetX() - Mobile.GetX(targetSerial));
                int dy = Math.Abs(Character.GetY() - Mobile.GetY(targetSerial));
                int distance = Math.Max(dx, dy);

                // Are we already close enough?
                //if (distance <= stopDistance)
                //{
                //    continue;
                //}

                // Move closer
                MovementWrapper.MoveXY(Mobile.GetX(targetSerial), Mobile.GetY(targetSerial), true, stopDistance, run);

            }

            Logger.Info("[AutoFollow] Done following.");
        }
        private static void GetTrainingLevel(float skill)
        {

            if (skill < 30f) MobTypes = new ushort[] { 0xD0 };// Chickens
            else if (skill < 45f) MobTypes = new ushort[] { 0xD8, 0xE7, 0xCF, 0xCB };// Cows, Pigs, and Sheep
            else if (skill < 55f) MobTypes = new ushort[] { 0xD7,81, 0x122, 211 }; // Giant Rat, BullFrog, Boar, BlackBear
            else if (skill < 70f) MobTypes = new ushort[] { 63, 167, 47}; //Cougar, BrownBear, Alligator
            else MobTypes = new ushort[] { 0xE8, 0xE9, 80};//Bulls,Giant Toad
        }
    }
}
