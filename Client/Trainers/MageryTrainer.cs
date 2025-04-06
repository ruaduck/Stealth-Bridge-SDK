using System;
using System.Threading;
using StealthBridgeSDK.Skills;
using StealthBridgeSDK.Spells;
using StealthBridgeSDK.Targeting;
using StealthBridgeSDK.Character;
using StealthBridgeSDK;

namespace StealthBridgeSDK.Trainers
{
    public static class MageryTrainer
    {
        private static readonly int CastDelayMs = 1000;
        private static readonly int LogInterval = 10;
        private static readonly int ManaThresholdBuffer = 5;

        public static void Train()
        {
            Console.Write("Enter self/target serial (hex, e.g., 0x40012345 or $0006F2B6): ");
            string? serialInput = Console.ReadLine();
            serialInput = serialInput?.Trim().Replace("0x", "").Replace("$", "");

            if (!uint.TryParse(serialInput, System.Globalization.NumberStyles.HexNumber, null, out uint targetSerial))
            {
                Logger.Error("Invalid serial input.");
                return;
            }
            
            Console.Write("Enter target Magery skill to stop at (e.g., 100.0): ");
            string? skillInput = Console.ReadLine();
            if (!float.TryParse(skillInput, out float skillTarget))
            {
                Logger.Error("Invalid skill target input.");
                return;
            }

            TargetingHelper.RememberObject(targetSerial);
            Logger.Info($"Starting Magery training on 0x{targetSerial:X} until skill reaches {skillTarget:F1}...");

            int castCount = 0;
            while (true)
            {
                float skill = SkillWrapper.GetSkillValue(SkillName.Magery);

                if (skill >= skillTarget)
                {
                    Logger.Info($"Reached target skill {skill:F1}. Stopping training.");
                    break;
                }

                var Magespell = GetTrainingSpell(skill);
                if (Magespell == Magery.None)
                {
                    Logger.Info($"Current Magery skill is too low ({skill:F1}) to train further. Stopping.");
                    break;
                }
                string spell = MageryHelper.SpellMap[Magespell].Name;

                int requiredMana = MageryHelper.GetManaCost(Magespell);
                int currentMana = CharacterWrapper.GetMana(CharacterWrapper.Self());

                if (currentMana < requiredMana + ManaThresholdBuffer)
                {
                    Logger.Info("Low mana. Attempting to meditate...");
                    SkillHelper.UseSkill(SkillName.Meditation);
                    //SpellHelper.CastByName("Meditation");
                    Thread.Sleep(10000); // give time to regain mana
                    continue;
                }

                SpellHelper.CastAtTarget(spell, targetSerial, SkillName.Magery);
                castCount++;

                if (castCount % LogInterval == 0)
                {
                    Logger.Info($"Casts: {castCount} | Current Magery: {skill:F1} | Mana: {currentMana}");
                }

                Thread.Sleep(CastDelayMs);
            }
        }

        private static Magery GetTrainingSpell(float skill)
        {
            if (skill < 30f) return Magery.None; // NPC training required
            if (skill < 45f) return Magery.Fireball;//"Fireball";
            if (skill < 55f) return Magery.GreaterHeal;//"Lightning";
            if (skill < 65f) return Magery.Paralyze;//"Paralyze";
            if (skill < 75f) return Magery.Reveal;//"Reveal";
            if (skill < 90f) return Magery.FlameStrike;//"Flamestrike";
            return Magery.Earthquake; //"Earthquake";
        }
    }
}