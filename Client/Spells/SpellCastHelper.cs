using System;
using System.Collections.Generic;
using System.Threading;
using StealthBridgeSDK.Skills;
using StealthBridgeSDK.Character;

namespace StealthBridgeSDK.Spells
{
    public static class SpellHelper
    {
        private static readonly Dictionary<string, DateTime> Cooldowns = new();

        private static bool IsOnCooldown(string spellName, int cooldownMs)
        {
            if (Cooldowns.TryGetValue(spellName, out var lastCast))
            {
                return (DateTime.UtcNow - lastCast).TotalMilliseconds < cooldownMs;
            }
            return false;
        }

        private static void SetCooldown(string spellName)
        {
            Cooldowns[spellName] = DateTime.UtcNow;
        }

        public static bool CanCast(string spellName, int manaCost, float skillRequired, SkillName skillName)
        {
            float skill = SkillWrapper.GetSkillValue(skillName);
            int mana = CharacterWrapper.GetMana(CharacterWrapper.Self());
            return skill >= skillRequired && mana >= manaCost;
        }

        public static void CastByName(string spellName, SkillName skill, int manaCost = 0, float minSkill = 0)
        {
            if (!CanCast(spellName, manaCost, minSkill, skill))
            {
                Logger.Warn($"Cannot cast {spellName}: not enough skill or mana.");
                return;
            }

            Logger.Info($"Casting {spellName}");
            SpellsWrapper.Cast(spellName);
            SetCooldown(spellName);
        }
        

        public static void CastAtTarget(string spellName, uint serial, SkillName skill, int manaCost = 0, float minSkill = 0, int timeout = 5000)
        {
            
            if (!CanCast(spellName, manaCost, minSkill, skill))
            {
                Logger.Warn($"Cannot cast {spellName}: not enough skill or mana.");
                return;
            }

            Logger.Info($"Casting {spellName} at target 0x{serial:X}");
            SpellsWrapper.Cast(spellName);
            SetCooldown(spellName);

            if (SpellsWrapper.WaitForTarget(timeout))
                SpellsWrapper.TargetToObject(serial);
            else
                Logger.Warn("Targeting timeout.");
        }

        public static void CastAtTile(string spellName, ushort x, ushort y, sbyte z, SkillName skill, int manaCost = 0, float minSkill = 0, int timeout = 5000)
        {
            if (!CanCast(spellName, manaCost, minSkill, skill))
            {
                Logger.Warn($"Cannot cast {spellName}: not enough skill or mana.");
                return;
            }

            Logger.Info($"Casting {spellName} at tile {x}, {y}, {z}");
            SpellsWrapper.Cast(spellName);
            SetCooldown(spellName);

            if (SpellsWrapper.WaitForTarget(timeout))
                SpellsWrapper.TargetToTile(x, y, z);
            else
                Logger.Warn("Targeting timeout.");
        }

        public static void ChainCast(string spellName, uint serial, int repeat = 3, int delayMs = 2000, SkillName skill = SkillName.Magery, int manaCost = 0, float minSkill = 0)
        {
            for (int i = 0; i < repeat; i++)
            {
                if (!CanCast(spellName, manaCost, minSkill, skill))
                {
                    Logger.Warn($"[{i + 1}] Cannot cast {spellName}: not enough skill or mana.");
                    break;
                }

                Logger.Info($"[{i + 1}] Chain casting {spellName} at 0x{serial:X}");
                CastAtTarget(spellName, serial, skill, manaCost, minSkill);
                Thread.Sleep(delayMs);
            }
        }
    }
}