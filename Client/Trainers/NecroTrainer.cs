
using System;
using System.Threading;
using StealthBridgeSDK.Skills;
using StealthBridgeSDK.Spells;
using StealthBridgeSDK.Targeting;
using StealthBridgeSDK.Characters;

namespace StealthBridgeSDK.Trainers
{
    public static class NecroTrainer
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

            Console.Write("Enter target Necromancy skill to stop at (e.g., 100.0): ");
            string? skillInput = Console.ReadLine();
            if (!float.TryParse(skillInput, out float skillTarget))
            {
                Logger.Error("Invalid skill target input.");
                return;
            }

            TargetingHelper.RememberObject(targetSerial);
            Logger.Info($"Starting Necromancy training on 0x{targetSerial:X} until skill reaches {skillTarget:F1}...");

            int castCount = 0;
            while (true)
            {
                float skill = SkillWrapper.GetSkillValue(SkillName.Necromancy);

                if (skill >= skillTarget)
                {
                    Logger.Info($"Reached target skill {skill:F1}. Stopping training.");
                    break;
                }

                var spell = GetTrainingSpell(skill);
                if (spell == NecromancySpell.None)
                {
                    Logger.Info($"Current Necromancy skill is too low ({skill:F1}) to train further. Stopping.");
                    break;
                }

                string spellName = NecromancyHelper.SpellMap[spell].Name;
                int requiredMana = NecromancyHelper.GetManaCost(spell);
                int currentMana = Character.GetMana();

                int hp = Character.GetHP();
                int maxHp = Character.GetMaxHP();
                double hpPercent = (double)hp / maxHp;

                if (spell == NecromancySpell.PainSpike && hpPercent < 0.5)
                {
                    Logger.Warn($"HP is low ({hp}/{maxHp}). Skipping Pain Spike and casting heal...");

                    if (SpellHelper.CanCast(MageryHelper.GetName(Magery.GreaterHeal),MageryHelper.GetManaCost(Magery.GreaterHeal) ,MageryHelper.GetMinSkill(Magery.GreaterHeal),SkillName.Magery))
                    {
                        SpellHelper.CastAtTarget(MageryHelper.GetName(Magery.GreaterHeal), targetSerial,SkillName.Magery);
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Logger.Warn("No Greater Heal available. Waiting to regenerate...");
                        Thread.Sleep(5000);
                    }

                    continue;
                }

                if (currentMana < requiredMana + ManaThresholdBuffer)
                {
                    Logger.Info("Low mana. Attempting to meditate...");
                    SkillHelper.UseSkill(SkillName.Meditation);
                    Thread.Sleep(10000);
                    continue;
                }

                if (NecromancyHelper.RequiresTarget(spell))
                {
                    SpellHelper.CastAtTarget(spellName, targetSerial, SkillName.Necromancy);
                }
                else
                {
                    SpellHelper.CastByName(spellName, SkillName.Necromancy);
                    Thread.Sleep(CastDelayMs);
                }

                castCount++;

                if (castCount % LogInterval == 0)
                {
                    Logger.Info($"Casts: {castCount} | Current Necromancy: {skill:F1} | Mana: {currentMana}");
                }
            }
        }

        private static NecromancySpell GetTrainingSpell(float skill)
        {
            if (skill < 20f) return NecromancySpell.None;
            if (skill < 30f) return NecromancySpell.CorpseSkin;
            if (skill < 50f) return NecromancySpell.PainSpike;
            if (skill < 70f) return NecromancySpell.HorrificBeast;
            if (skill < 90f) return NecromancySpell.Wither;
            if (skill < 100f) return NecromancySpell.LichForm;
            return NecromancySpell.VampiricEmbrace;
        }
    }
}
