using Python.Runtime;

namespace StealthBridgeSDK.Skills
{
    public static class SkillWrapper
    {
        private static dynamic _stealth => PythonImport.Stealth;

        public static float GetSkillValue(string skillName)
        {
            using (Py.GIL())
            {
                return _stealth.GetSkillValue(skillName);
            }
        }

        public static float GetSkillCap(string skillName)
        {
            using (Py.GIL())
            {
                return _stealth.GetSkillCap(skillName);
            }
        }

        public static float GetSkillCurrentValue(string skillName)
        {
            using (Py.GIL())
            {
                return _stealth.GetSkillCurrentValue(skillName);
            }
        }
    }
}