using System.Reflection.Metadata.Ecma335;
using Python.Runtime;
using StealthBridgeSDK.Skills;

namespace StealthBridgeSDK.Characters
{
   
    /// <summary>
    /// This class provides methods to interact with the character's status and actions in the game. Use Mobile class for other mobiles.
    /// </summary>
    public static class Character
    {
        private static dynamic _stealth => PythonImport.Stealth;
        /// <summary>
        /// Gets the current character's mana.
        /// </summary>
        /// <returns></returns>
        public static int GetMana()
        {
            using (Py.GIL())
            {
                return _stealth.GetMana(Self());
            }
        }
        /// <summary>
        /// Gets the current character's maximum mana.
        /// </summary>
        /// <returns></returns>
        public static int GetMaxMana()
        {
            using (Py.GIL())
            {
                return _stealth.GetMaxMana(Self());
            }
        }
        /// <summary>
        /// Checks if the character is in a state of paralysis. This is used to determine if the character is paralyzed.
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsParalyzed()
        {
            using (Py.GIL())
            {
                return _stealth.IsParalyzed();
            }
        }
        /// <summary>
        /// Checks if the character is poisoned. This is used to determine if the character is in a state of poison or not.
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsPoisoned()
        {
            using (Py.GIL())
            {
                return _stealth.IsPoisoned();
            }
        }
        /// <summary>
        /// Checks if the character is dead. This is used to determine if the character is in a state of death or not.
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsDead()
        {
            using (Py.GIL())
            {
                return _stealth.Dead();
            }
        }
        public static void SetWarMode(bool warMode)
        {
            using (Py.GIL())
            {
                _stealth.SetWarMode(warMode);
            }
        }
        /// <summary>
        /// Gets the ID of the target for attack.
        /// </summary>
        /// <returns>uint</returns>
        public static uint WarTargetID()
        {
            using (Py.GIL())
            {
                return _stealth.WarTargetID();
            }
        }

        /// <summary>
        /// Checks if the character is in war mode. This is used to determine if the character is in a state of combat or not.
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsWarMode()
        {
            using (Py.GIL())
            {
                return _stealth.IsWarMode();
            }
        }
        /// <summary>
        /// Gets the current character's serial number.
        /// </summary>
        /// <returns>uint</returns>
        public static uint Self()
        {
            using (Py.GIL())
            {
                return _stealth.Self();
            }
        }
        /// <summary>
        /// Gets the current character's HP.
        /// </summary>
        /// <returns>int</returns>
        public static int GetHP()
        {
            using (Py.GIL())
            {
                return _stealth.GetHP(Self());
            }
        }
        /// <summary>
        /// Gets the current character's max HP.
        /// </summary>
        /// <returns>int</returns>
        public static int GetMaxHP()
        {
            using (Py.GIL())
            {
                return _stealth.GetMaxHP(Self());
            }
        }
        /// <summary>
        /// Gets the current character's backpack ID.
        /// </summary>
        /// <returns>uint</returns>
        public static uint Backpack()
        {
            using (Py.GIL())
            {
                return _stealth.Backpack();
            }
        }
        /// <summary>
        /// Sends a bandage self command to the stealth client. This is used for healing.
        /// </summary>
        /// <returns>bool</returns>
        public static bool BandageSelf()
        {
            using (Py.GIL())
            {
                _stealth.BandageSelf();
                return true;
            }
        }
        /// <summary>
        /// Sends the attack command to the stealth client. This is used for attacking other players or NPCs. Always returns true to show that the command was sent.
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns>bool</returns>
        public static bool Attack(uint mobile)
        {
            using (Py.GIL())
            {
                _stealth.Attack(mobile);
                return true;
            }
        }
        /// <summary>
        /// Gets the current character's buffs from the buffbar
        /// </summary>
        /// <returns>A List of type BuffInfo</returns>
        public static List<BuffInfo> GetBuffBarInfo()
        {
            var buffs = new List<BuffInfo>();

            using (Py.GIL())
            {
                dynamic pyBuffs = PythonImport.Stealth.GetBuffBarInfo();
                foreach (dynamic item in pyBuffs)
                {
                    buffs.Add(new BuffInfo
                    {
                        AttributeID = (int)item["Attribute_ID"],
                        TimeStart = (DateTime)item["TimeStart"],
                        Seconds = (ushort)item["Seconds"],
                        ClilocID1 = (uint)item["ClilocID1"],
                        ClilocID2 = (uint)item["ClilocID2"]
                    });
                }
            }

            return buffs;
        }
        /// <summary>
        /// Gets the current character's strength.
        /// </summary>
        /// <returns>int</returns>
        public static int Strength()
        {
            using (Py.GIL())
            {
                return _stealth.Str();
            }
        }
        /// <summary>
        /// Gets the current character's dexterity.
        /// </summary>
        /// <returns>int</returns>
        public static int Dexterity()
        {
            using (Py.GIL())
            {
                return _stealth.Dex();
            }
        }
        /// <summary>
        /// Gets the current character's intelligence.
        /// </summary>
        /// <returns>int</returns>
        public static int Intelligence()
        {
            using (Py.GIL())
            {
                return _stealth.Int();
            }
        }

        /// <summary>
        /// Used when wanting to state to look at ground items. Used usually with FindItem.
        /// </summary>
        /// <returns>int</returns>
        public static int Ground() => 0;

        /// <summary>
        /// Gets the current character's life. This is same a GetHP() method.
        /// </summary>
        /// <returns>int</returns>
        public static int Life() => GetHP();

        /// <summary>
        /// Gets the current character's max life. This is same as GetMaxHP() method.
        /// </summary>
        /// <returns>int</returns>
        public static int MaxLife() => GetMaxHP();

        /// <summary>
        /// Gets the current character's stamina.
        /// </summary>
        /// <returns>int</returns>
        public static int Stamina()
        {
            using (Py.GIL())
            {
                return _stealth.Stam();
            }
        }

        /// <summary>
        /// Gets the current character's max stamina.
        /// </summary>
        /// <returns></returns>
        public static int MaxStamina()
        {
            using (Py.GIL())
            {
                return _stealth.MaxStam();
            }
        }
        /// <summary>
        /// Gets the current character's luck.
        /// </summary>
        /// <returns>ushort</returns>
        public static ushort Luck()
        {
            using (Py.GIL())
            {
                return _stealth.Luck();
            }
        }
        /// <summary>
        /// Checks if the character is hidden.
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsHidden()
        {
            using (Py.GIL())
            {
                return _stealth.Hidden();
            }
        }

        public static void UsePrimaryAbility()
        {
            using (Py.GIL())
            {
                _stealth.UsePrimaryAbility();
            }
        }

        public static void UseSecondaryAbility()
        {
            using (Py.GIL())
            {
                _stealth.UseSecondaryAbility();
            }
        }

        public static dynamic GetActiveAbility()
        {
            using (Py.GIL())
            {
                return _stealth.GetActiveAbility();
            }
        }
        /// <summary>
        /// Toggles the fly mode of the character. This is used to enable or disable the fly mode. Only usable on Gargoyles.
        /// </summary>
        public static void ToggleFly()
        {
            using (Py.GIL())
            {
                _stealth.ToggleFly();
            }
        }
        /// <summary>
        /// Requests the Virtue Gump window from the server.
        /// </summary>
        public static void RequestVirtueGump()
        {
            using (Py.GIL())
            {
                _stealth.ReqVirtuesGump();
            }
        }

        /// <summary>
        /// Uses the specified virtue (e.g., Compassion, Valor).
        /// </summary>
        /// <param name="virtue">The virtue to activate.</param>
        public static void UseVirtue(Virtue virtue)
        {
            using (Py.GIL())
            {
                _stealth.UseVirtue(virtue.ToString().ToLower());
            }
        }

        public static void SetSkillLockState(SkillName skill, bool lockSkill)
        {
            using (Py.GIL())
            {
                _stealth.SetSkillLockState(SkillInfo.SkillMap[skill].Name, lockSkill);
            }
        }
        /// <summary>
        /// Gets All the basic info of the character.  Should use this on loading the character and then use the other methods to get the specific info.
        /// </summary>
        /// <returns>ExtendedInfo</returns>
        public static ExtendedInfo GetExtendedInfo()
        {
            using (Py.GIL())
            {
                dynamic pyInfo = PythonImport.Stealth.GetExtInfo();

                return new ExtendedInfo
                {
                    MaxWeight = (ushort)pyInfo["MaxWeight"],
                    Race = (byte)pyInfo["Race"],
                    StatCap = (ushort)pyInfo["StatCap"],
                    PetsCurrent = (byte)pyInfo["PetsCurrent"],
                    PetsMax = (byte)pyInfo["PetsMax"],

                    FireResist = (ushort)pyInfo["FireResist"],
                    ColdResist = (ushort)pyInfo["ColdResist"],
                    PoisonResist = (ushort)pyInfo["PoisonResist"],
                    EnergyResist = (ushort)pyInfo["EnergyResist"],

                    Luck = (short)pyInfo["Luck"],
                    DamageMin = (short)pyInfo["DamageMin"],
                    DamageMax = (short)pyInfo["DamageMax"],
                    TithingPoints = (int)pyInfo["Tithing_points"],

                    ArmorMax = (ushort)pyInfo["ArmorMax"],
                    FireResistMax = (ushort)pyInfo["fireresistMax"],
                    ColdResistMax = (ushort)pyInfo["coldresistMax"],
                    PoisonResistMax = (ushort)pyInfo["poisonresistMax"],
                    EnergyResistMax = (ushort)pyInfo["energyresistMax"],

                    DefenseChance = (ushort)pyInfo["DefenseChance"],
                    DefenseChanceMax = (ushort)pyInfo["DefensceChanceMax"],
                    HitChanceIncrease = (ushort)pyInfo["Hit_Chance_Incr"],
                    DamageIncrease = (ushort)pyInfo["Damage_Incr"],
                    SwingSpeedIncrease = (ushort)pyInfo["Swing_Speed_Incr"],
                    LowerReagentCost = (ushort)pyInfo["Lower_Reagent_Cost"],
                    SpellDamageIncrease = (ushort)pyInfo["Spell_Damage_Incr"],
                    FasterCastRecovery = (ushort)pyInfo["Faster_Cast_Recovery"],
                    FasterCasting = (ushort)pyInfo["Faster_Casting"],
                    LowerManaCost = (ushort)pyInfo["Lower_Mana_Cost"],

                    HpRegen = (ushort)pyInfo["HP_Regen"],
                    StamRegen = (ushort)pyInfo["Stam_Regen"],
                    ManaRegen = (ushort)pyInfo["Mana_Regen"],

                    ReflectPhysicalDamage = (ushort)pyInfo["Reflect_Phys_Damage"],
                    EnhancePotions = (ushort)pyInfo["Enhance_Potions"],

                    StrengthIncrease = (ushort)pyInfo["Strength_Incr"],
                    DexIncrease = (ushort)pyInfo["Dex_Incr"],
                    IntIncrease = (ushort)pyInfo["Int_Incr"],

                    HpIncrease = (ushort)pyInfo["HP_Incr"],
                    ManaIncrease = (ushort)pyInfo["Mana_Incr"]
                };
            }
        }

    }
    #region Classes for Enums and Lists
    public class ExtendedInfo
    {
        public ushort MaxWeight { get; set; }
        public byte Race { get; set; }
        public ushort StatCap { get; set; }
        public byte PetsCurrent { get; set; }
        public byte PetsMax { get; set; }

        public ushort FireResist { get; set; }
        public ushort ColdResist { get; set; }
        public ushort PoisonResist { get; set; }
        public ushort EnergyResist { get; set; }

        public short Luck { get; set; }
        public short DamageMin { get; set; }
        public short DamageMax { get; set; }

        public int TithingPoints { get; set; }

        public ushort ArmorMax { get; set; }
        public ushort FireResistMax { get; set; }
        public ushort ColdResistMax { get; set; }
        public ushort PoisonResistMax { get; set; }
        public ushort EnergyResistMax { get; set; }

        public ushort DefenseChance { get; set; }
        public ushort DefenseChanceMax { get; set; }
        public ushort HitChanceIncrease { get; set; }
        public ushort DamageIncrease { get; set; }
        public ushort SwingSpeedIncrease { get; set; }
        public ushort LowerReagentCost { get; set; }
        public ushort SpellDamageIncrease { get; set; }
        public ushort FasterCastRecovery { get; set; }
        public ushort FasterCasting { get; set; }
        public ushort LowerManaCost { get; set; }

        public ushort HpRegen { get; set; }
        public ushort StamRegen { get; set; }
        public ushort ManaRegen { get; set; }

        public ushort ReflectPhysicalDamage { get; set; }
        public ushort EnhancePotions { get; set; }

        public ushort StrengthIncrease { get; set; }
        public ushort DexIncrease { get; set; }
        public ushort IntIncrease { get; set; }

        public ushort HpIncrease { get; set; }
        public ushort ManaIncrease { get; set; }
    }
    public enum Virtue
    {
        Compassion = 0x69,
        Honesty = 0x6A,
        Honor = 0x6B,
        Humility = 0x6C,
        Justice = 0x6D,
        Sacrifice = 0x6E,
        Spirituality = 0x6F,
        Valor = 0x70
    }
    /// <summary>
    /// This class represents a buff on the character. It contains information about the buff's ID, start time, duration, and localization IDs.
    /// </summary>
    public class BuffInfo
    {
        public int AttributeID { get; set; }        // Buff ID
        public DateTime TimeStart { get; set; }     // When it began
        public ushort Seconds { get; set; }         // Duration
        public uint ClilocID1 { get; set; }         // Localization ID
        public uint ClilocID2 { get; set; }         // Additional loc ID
    }

#endregion
}