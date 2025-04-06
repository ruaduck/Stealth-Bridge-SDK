using Python.Runtime;

namespace StealthBridgeSDK.Skills
{
    public static class SkillWrapper
    {
        private static dynamic _stealth => PythonImport.Stealth;

        public static double GetSkillValue(SkillName skill) =>
            _stealth.GetSkillValue(skill.ToString());

        public static double GetSkillCurrentValue(SkillName skill) =>
            _stealth.GetSkillCurrentValue(skill.ToString());

        public static double GetSkillCap(SkillName skill) =>
            _stealth.GetSkillCap(skill.ToString());

        public static string GetSkillLockState(SkillName skill) =>
            _stealth.GetSkillLockState(skill.ToString());

        public static void SetSkillLockState(SkillName skill, string state) =>
            _stealth.SetSkillLockState(skill.ToString(), state);

        public static void UseSkill(SkillName skill) =>
            _stealth.UseSkill(skill.ToString());
    }
}