using System;
using System.Threading;
using StealthBridgeSDK.Crafting;
using StealthBridgeSDK.Gumps;
using StealthBridgeSDK.Skills;
using StealthBridgeSDK.Miscellaneous;
using StealthBridgeSDK.Inventory;
using StealthBridgeSDK.Characters;
using StealthBridgeSDK.Targeting;
using static StealthBridgeSDK.Crafting.TailorCrafting;

namespace StealthBridgeSDK.Trainers
{
    public static class TailorTrainer
    {
        public static void Train()
        {
            uint scissors;
            uint cloth;
            uint sewingKit;
            if (CheckBackPack(0x0F9F) == false) return;
            else { scissors = Inventories.FindType(0x0F9F, Character.Backpack()); }
            if (CheckBackPack(0x0F9D) == false) return;
            else { sewingKit = Inventories.FindType(0x0F9D, Character.Backpack()); }
            if (CheckBackPack(0x1766) == false) return;
            else { cloth = Inventories.FindType(0x1766, Character.Backpack()); }
            Inventories.UseObject(sewingKit);
            Console.Write("Enter target Tailor skill to stop at (e.g., 100.0): ");
            string? skillInput = Console.ReadLine();
            if (!float.TryParse(skillInput, out float targetSkill))
            {
                Logger.Error("Invalid skill target input.");
                return;
            }
            Console.WriteLine($"> Starting Tailor training until {targetSkill:F1} skill...");
            float skill = SkillWrapper.GetSkillValue(SkillName.Tailoring);
            TailorCraftable item = GetOptimalCraftable(skill);
            TailorCraftGump.Craft(item);

            while (true)
            {
                skill = SkillWrapper.GetSkillValue(SkillName.Tailoring);
                if (skill >= targetSkill)
                {
                    
                    Console.WriteLine($"> Target reached: {skill:F1}");
                    break;
                }
                var originalsewingKit = sewingKit;
                if (CheckBackPack(0x0F9D) == false) { return; }
                else {sewingKit = Inventories.FindType(0x0F9D, Character.Backpack()); if ( !(sewingKit == originalsewingKit)) { Inventories.UseObject(sewingKit); Thread.Sleep(500); TailorCraftGump.Initialize(); }}
                if (CheckBackPack(0x0F9F) == false) break;
                else { scissors = Inventories.FindType(0x0F9F, Character.Backpack()); }
                if (CheckBackPack(0x1766) == false) break;
                else { cloth = Inventories.FindType(0x1766, Character.Backpack()); }

                var originalitem = item;
                item = GetOptimalCraftable(skill);                
                Console.WriteLine($"> Tailoring {item} at skill {skill:F1}");
                if (!(item == originalitem))
                    TailorCraftGump.Craft(item);
                else TailorCraftGump.ClickMakeLast();

                    // Wait a bit before repeating
                    Thread.Sleep(1500);
                CutItem(item, scissors);
               
            }
        }
        private static void CutItem(TailorCraftable item, uint scissors)
        {
            
            if (item == TailorCraftable.ShortPants)
            {
                var count = Inventories.Count(0x152E);
                for (int i = 0; i < count; i++)
                {
                    var cutitem = Inventories.FindType(0x152E, Character.Backpack());
                    if (cutitem != 0)
                    {
                        Inventories.UseObject(scissors);
                        Target.WaitForTarget(1000);
                        Target.TargetToObject(cutitem);
                    }
                }
            }
            else if (item == TailorCraftable.FurCape)
            {
                var count = Inventories.Count(0x230A);
                for (int i = 0; i < count; i++)
                {
                    var cutitem = Inventories.FindType(0x230A, Character.Backpack());
                    if (cutitem != 0)
                    {
                        Inventories.UseObject(scissors);
                        Target.WaitForTarget(1000);
                        Target.TargetToObject(cutitem);
                        Thread.Sleep(1000);
                    }
                }
                
            }
            else if (item == TailorCraftable.NinjaTabi)
            {
                var count = Inventories.Count(0x2797);
                for (int i = 0; i < count; i++)
                {
                    var cutitem = Inventories.FindType(0x2797, Character.Backpack());
                    if (cutitem != 0)
                    {
                        Inventories.UseObject(scissors);
                        Target.WaitForTarget(1000);
                        Target.TargetToObject(cutitem);
                        Thread.Sleep(1000);
                    }
                }

            }
            else if (item == TailorCraftable.Cloak)
            {
                var count = Inventories.Count(0x1515);
                for (int i = 0; i < count; i++)
                {
                    var cutitem = Inventories.FindType(0x1515, Character.Backpack());
                    if (cutitem != 0)
                    {
                        Inventories.UseObject(scissors);
                        Target.WaitForTarget(1000);
                        Target.TargetToObject(cutitem);
                        Thread.Sleep(1000);
                    }
                }

            }
            else if (item == TailorCraftable.FurBoots)
            {
                var count = Inventories.Count(0x2307);
                for (int i = 0; i < count; i++)
                {
                    var cutitem = Inventories.FindType(0x2307, Character.Backpack());
                    if (cutitem != 0)
                    {
                        Inventories.UseObject(scissors);
                        Target.WaitForTarget(1000);
                        Target.TargetToObject(cutitem);
                        Thread.Sleep(1000);
                    }
                }

            }
            else if (item == TailorCraftable.Robe)
            {
                var count = Inventories.Count(0x1F03);
                for (int i = 0; i < count; i++)
                {
                    var cutitem = Inventories.FindType(0x1F03, Character.Backpack());
                    if (cutitem != 0)
                    {
                        Inventories.UseObject(scissors);
                        Target.WaitForTarget(1000);
                        Target.TargetToObject(cutitem);
                        Thread.Sleep(1000);
                    }
                }

            }
            else if (item == TailorCraftable.OilCloth)
            {
                var count = Inventories.Count(0x175D);
                for (int i = 0; i < count; i++)
                {
                    var cutitem = Inventories.FindType(0x175D, Character.Backpack());
                    if (cutitem != 0)
                    {
                        Inventories.UseObject(scissors);
                        Target.WaitForTarget(1000);
                        Target.TargetToObject(cutitem);
                        Thread.Sleep(1000);
                    }
                }

            }
            else if (item == TailorCraftable.Kasa)
            {
                var count = Inventories.Count(0x2798);
                for (int i = 0; i < count; i++)
                {
                    var cutitem = Inventories.FindType(0x2798, Character.Backpack());
                    if (cutitem != 0)
                    {
                        Inventories.UseObject(scissors);
                        Target.WaitForTarget(1000);
                        Target.TargetToObject(cutitem);
                        Thread.Sleep(1000);
                    }
                }

            }
            else if (item == TailorCraftable.ElvenShirt)
            {
                var count = Inventories.Count(0x3176);
                for (int i = 0; i < count; i++)
                {
                    var cutitem = Inventories.FindType(0x3176, Character.Backpack());
                    if (cutitem != 0)
                    {
                        Inventories.UseObject(scissors);
                        Target.WaitForTarget(1000);
                        Target.TargetToObject(cutitem);
                        Thread.Sleep(1000);
                    }
                }

            }

        }
        private static bool CheckBackPack(uint item)
        {            
            if (!Inventories.HasItem(item))
            {
                switch (item)
                {
                    case 0x0F9F:
                        Console.WriteLine("Scissors not found in backpack.");
                        break;
                    case 0x0F9D:
                        Console.WriteLine("Sewing kit not found in backpack.");
                        break;
                    case 0x1766:
                        Console.WriteLine("Cloth not found in backpack.");
                        break;
                }
                return false;
            }
            return true;
        }
        private static bool VerifyTool(uint item)
        {
            return Inventories.FindIteminBackpack(item);
        }
        private static TailorCraftable GetOptimalCraftable(float skill)
        {
            if (skill < 35f) return TailorCraftable.ShortPants;
            if (skill < 41.4f) return TailorCraftable.FurCape;
            if (skill < 50f) return TailorCraftable.Cloak;
            if (skill < 54f) return TailorCraftable.FurBoots;
            if (skill < 65f) return TailorCraftable.Robe;
            if (skill < 72f) return TailorCraftable.Kasa;
            if (skill < 78f) return TailorCraftable.NinjaTabi;
            if (skill < 99f) return TailorCraftable.OilCloth;
            if (skill < 115f) return TailorCraftable.ElvenShirt;
            if (skill <= 120f) return TailorCraftable.StuddedHiroSode;

            return TailorCraftable.ShortPants; // fallback
        }
    }
}
