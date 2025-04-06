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
    }
}