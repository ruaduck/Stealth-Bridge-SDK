using System;
using System.Threading;
using StealthBridgeSDK.Skills;
using StealthBridgeSDK.Spells;
using StealthBridgeSDK.Character;

namespace StealthBridgeSDK.Trainers
{
    public static class SpiritSpeakTrainer
    {
        private static readonly int CastDelayMs = 1000;
        private static readonly int ManaThresholdBuffer = 5;

        public static void Train()
        {
            Console.Write("Enter Spirit Speak target skill (e.g., 100.0): ");
            if (!float.TryParse(Console.ReadLine(), out float skillTarget))
            {
                Logger.Error("Invalid Spirit Speak target input.");
                return;
            }

            float necroSkill = SkillWrapper.GetSkillValue(SkillName.Necromancy);

            if (necroSkill < 100f)
            {
                Logger.Info("Necromancy below 100. Let Spirit Speak raise passively during Necromancy training.");
                return;
            }

            Logger.Info("Necromancy maxed. Starting active Spirit Speak training using Curse Weapon...");

            // Cast Lich Form if possible
            if (SpellHelper.CanCast(NecromancyHelper.GetName(NecromancySpell.LichForm), NecromancyHelper.GetManaCost(NecromancySpell.LichForm),NecromancyHelper.GetMinSkill(NecromancySpell.LichForm),SkillName.Necromancy))
            {
                Logger.Info("Casting Lich Form...");
                SpellHelper.CastByName(NecromancyHelper.GetName(NecromancySpell.LichForm), SkillName.Necromancy);
                Thread.Sleep(3000);
            }

            int castCount = 0;

            while (true)
            {
                float skill = SkillWrapper.GetSkillValue(SkillName.SpiritSpeak);
                if (skill >= skillTarget)
                {
                    Logger.Info($"Reached Spirit Speak target {skill:F1}. Stopping.");
                    break;
                }

                int currentMana = CharacterWrapper.GetMana(CharacterWrapper.Self());
                int requiredMana = NecromancyHelper.GetManaCost(NecromancySpell.CurseWeapon);

                if (currentMana < requiredMana + ManaThresholdBuffer)
                {
                    Logger.Info("Low mana. Attempting to meditate...");
                    SkillHelper.UseSkill(SkillName.Meditation);
                    Thread.Sleep(10000);
                    continue;
                }

                SpellHelper.CastByName("Curse Weapon", SkillName.Necromancy);
                Thread.Sleep(CastDelayMs);
                castCount++;

                if (castCount % 5 == 0)
                {
                    Logger.Info($"Casts: {castCount} | Spirit Speak: {skill:F1} | Mana: {currentMana}");
                }
            }
        }
    }
}
