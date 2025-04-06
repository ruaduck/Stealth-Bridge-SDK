using StealthBridgeSDK.Spells;
using System;

namespace StealthBridgeSDK.Skills
{
    public static class SkillHelper
    {
        public static bool IsSkillCapped(SkillName skill)
        {
            double current = SkillWrapper.GetSkillValue(skill);
            double cap = SkillWrapper.GetSkillCap(skill);
            return current >= cap;
        }

        public static void TryUseSkill(SkillName skill)
        {
            if (!IsSkillCapped(skill))
            {
                Console.WriteLine($"Using skill: {skill}");
                SkillWrapper.UseSkill(skill);
            }
            else
            {
                Console.WriteLine($"{skill} is already at cap.");
            }
        }

        public static void UseSkill(SkillName skill)
        {
            SkillWrapper.UseSkill(skill);
        }

        public static string GetName(SkillName skill) => SkillInfo.SkillMap[skill].Name;
    }
}