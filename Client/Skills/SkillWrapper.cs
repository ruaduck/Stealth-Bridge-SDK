using Python.Runtime;

namespace StealthBridgeSDK.Skills
{
    public static class SkillWrapper
    {
        private static dynamic _stealth => PythonImport.Stealth;

        public static float GetSkillValue(SkillName skill) =>
            _stealth.GetSkillValue(SkillHelper.GetName(skill));

        public static double GetSkillCurrentValue(SkillName skill) =>
            _stealth.GetSkillCurrentValue(SkillHelper.GetName(skill));

        public static double GetSkillCap(SkillName skill) =>
            _stealth.GetSkillCap(SkillHelper.GetName(skill));

        public static string GetSkillLockState(SkillName skill) =>
            _stealth.GetSkillLockState(SkillHelper.GetName(skill));

        public static void SetSkillLockState(SkillName skill, string state) =>
            _stealth.SetSkillLockState(SkillHelper.GetName(skill), state);

        public static void UseSkill(SkillName skill) =>
            _stealth.UseSkill(SkillHelper.GetName(skill));
    }
}