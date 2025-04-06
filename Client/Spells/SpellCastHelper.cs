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

        public static bool CanCast(string spellName, int manaCost, float skillRequired, string skillName)
        {
            float skill = SkillWrapper.GetSkillValue(skillName);
            int mana = CharacterWrapper.GetMana();
            return skill >= skillRequired && mana >= manaCost;
        }

        public static void CastByName(string spellName, string skill = "Magery", int manaCost = 0, float minSkill = 0)
        {
            if (!CanCast(spellName, manaCost, minSkill, skill))
            {
                Console.WriteLine($"Cannot cast {spellName}: not enough skill or mana.");
                return;
            }

            SpellsWrapper.Cast(spellName);
            SetCooldown(spellName);
        }

        public static void CastAtTarget(string spellName, uint serial, string skill = "Magery", int manaCost = 0, float minSkill = 0, int timeout = 5000)
        {
            if (!CanCast(spellName, manaCost, minSkill, skill))
            {
                Console.WriteLine($"Cannot cast {spellName}: not enough skill or mana.");
                return;
            }

            SpellsWrapper.Cast(spellName);
            SetCooldown(spellName);

            if (SpellsWrapper.WaitForTarget(timeout))
                SpellsWrapper.TargetToObject(serial);
            else
                Console.WriteLine("Targeting timeout.");
        }

        public static void CastAtTile(string spellName, ushort x, ushort y, sbyte z, string skill = "Magery", int manaCost = 0, float minSkill = 0, int timeout = 5000)
        {
            if (!CanCast(spellName, manaCost, minSkill, skill))
            {
                Console.WriteLine($"Cannot cast {spellName}: not enough skill or mana.");
                return;
            }

            SpellsWrapper.Cast(spellName);
            SetCooldown(spellName);

            if (SpellsWrapper.WaitForTarget(timeout))
                SpellsWrapper.TargetToTile(x, y, z);
            else
                Console.WriteLine("Targeting timeout.");
        }

        public static void ChainCast(string spellName, uint serial, int repeat = 3, int delayMs = 2000, string skill = "Magery", int manaCost = 0, float minSkill = 0)
        {
            for (int i = 0; i < repeat; i++)
            {
                if (!CanCast(spellName, manaCost, minSkill, skill))
                {
                    Console.WriteLine($"[{i + 1}] Cannot cast {spellName}: not enough skill or mana.");
                    break;
                }

                CastAtTarget(spellName, serial, skill, manaCost, minSkill);
                Thread.Sleep(delayMs);
            }
        }
    }
}