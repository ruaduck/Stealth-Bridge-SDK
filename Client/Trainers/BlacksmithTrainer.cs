using System;
using System.Threading;
using StealthBridgeSDK.Crafting;
using StealthBridgeSDK.Gumps;
using StealthBridgeSDK.Skills;
using StealthBridgeSDK.Miscellaneous;
using StealthBridgeSDK.Inventory;
using StealthBridgeSDK.Characters;
using StealthBridgeSDK.Targeting;
using static StealthBridgeSDK.Crafting.BSCrafting;

namespace StealthBridgeSDK.Trainers
{
    public static class BlacksmithTrainer
    {
        public static void Train()
        {
            uint ingots;
            uint ingotstype = 0x1BF2; //ingots
            uint smithtools;
            List<uint> smithtooltypes = new List<uint> { 0x0FBB, 0x13E3  }; //tongs, smith hammer
            uint tooltype = 0x0FBB; //tongs

            if (CheckBackPack(smithtooltypes) == false) return;
            else { smithtools = Inventories.FindTypes(smithtooltypes, Character.Backpack()); } //Tongs
            if (CheckBackPack(0x1766) == false) return;
            else { ingots= Inventories.FindType(ingotstype, Character.Backpack()); }
            Inventories.UseObject(smithtools);
            Console.Write("Enter target Smithy skill to stop at (e.g., 100.0): ");
            string? skillInput = Console.ReadLine();
            if (!float.TryParse(skillInput, out float targetSkill))
            {
                Logger.Error("Invalid skill target input.");
                return;
            }
            Console.WriteLine($"> Starting Tailor training until {targetSkill:F1} skill...");
            float skill = SkillWrapper.GetSkillValue(SkillName.Blacksmithy);
            BSCraftable item = GetOptimalCraftable(skill);
            BSCraftGump.Craft(item);

            while (true)
            {
                skill = SkillWrapper.GetSkillValue(SkillName.Blacksmithy);
                if (skill >= targetSkill)
                {
                    
                    Console.WriteLine($"> Target reached: {skill:F1}");
                    break;
                }
                var originalsmithtools = smithtools;
                if (CheckBackPack(0x0F9D) == false) { return; }
                else {smithtools = Inventories.FindTypes(smithtooltypes, Character.Backpack()); if ( !(smithtools == originalsmithtools)) { Inventories.UseObject(smithtools); Thread.Sleep(500); BSCraftGump.Initialize(); }}

                if (CheckBackPack(0x1766) == false) break;
                else { ingots = Inventories.FindType(ingotstype, Character.Backpack()); }

                var originalitem = item;
                item = GetOptimalCraftable(skill);                
                Console.WriteLine($"> Smithing {item} at skill {skill:F1}");
                if (!(item == originalitem))
                    BSCraftGump.Craft(item);
                else BSCraftGump.ClickMakeLast();

                    // Wait a bit before repeating
                    Thread.Sleep(1500);
                
               
            }
        }
        /// <summary>
        /// Checks to see if the item is in the backpack.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>bool</returns>
        private static bool CheckBackPack(uint item)
        {            
            if (!Inventories.HasItem(item))
            {
               return false;
            }
            return true;
        }
        /// <summary>
        /// Checks List of items to see if the item is in the backpack.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>bool</returns>
        private static bool CheckBackPack(List<uint> item)
        {
            foreach (var i in item)
            {
                
                if (Inventories.FindIteminBackpack(i))
                {
                    return true;
                }
            }
            return false;            
        }
        private static BSCraftable GetOptimalCraftable(float skill)
        {
            if (skill < 45f) return BSCraftable.Mace;
            if (skill < 50f) return BSCraftable.Maul;
            if (skill < 55f) return BSCraftable.Cutlass;
            if (skill < 59.5f) return BSCraftable.Katana;
            if (skill < 70.5f) return BSCraftable.Scimitar;
            if (skill < 106.4f) return BSCraftable.PlatemailGorget;
            if (skill < 108.9f) return BSCraftable.PlatemailGloves;
            if (skill < 116.3f) return BSCraftable.PlatemailArms;
            if (skill < 118.8f) return BSCraftable.PlatemailLegs;
            if (skill <= 120f) return BSCraftable.PlatemailTunic;

            return BSCraftable.Mace; // fallback
        }
    }
}
