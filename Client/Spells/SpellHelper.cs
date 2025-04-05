using System.Collections.Generic;
using System.Xml.Linq;

namespace StealthBridgeSDK.Spells
{
    public enum Magery
    {
        Clumsy,
        CreateFood,
        Feeblemind,
        Heal,
        MagicArrow,
        NightSight,
        ReactiveArmor,
        Weaken,
        Agility,
        Cunning,
        Cure,
        Harm,
        MagicTrap,
        MagicUntrap,
        Protection,
        Strength,
        Bless,
        Fireball,
        MagicLock,
        Poison,
        Telekinesis,
        Teleport,
        Unlock,
        WallofStone,
        ArchCure,
        ArchProtection,
        Curse,
        FireField,
        GreaterHeal,
        Lightning,
        ManaDrain,
        Recall,
        BladeSpirits,
        DispelField,
        Incognito,
        MagicReflection,
        MindBlast,
        Paralyze,
        PoisonField,
        SummonCreature,
        Dispel,
        EnergyBolt,
        Explosion,
        Invisibility,
        Mark,
        MassCurse,
        ParalyzeField,
        Reveal,
        ChainLightning,
        EnergyField,
        FlameStrike,
        GateTravel,
        ManaVampire,
        MassDispel,
        MeteorSwarm,
        Polymorph,
        Earthquake,
        EnergyVortex,
        Resurrection,
        SummonAirElemental,
        SummonDaemon,
        SummonEarthElemental,
        SummonFireElemental,
        SummonWaterElemental,
    }

    public static class MageryHelper
    {
        private static readonly Dictionary<Magery, (string Name, bool RequiresTarget, int ManaCost, float MinSkill)>
            SpellMap = new()
            {
                { Magery.Clumsy, ("Clumsy", true, 4, 0.0f) },
                { Magery.CreateFood, ("Create Food", false, 4, 0.1f) },
                { Magery.Feeblemind, ("Feeblemind", true, 4, 0.2f) },
                { Magery.Heal, ("Heal", true, 4, 0.5f) },
                { Magery.MagicArrow, ("Magic Arrow", true, 4, 0.7f) },
                { Magery.NightSight, ("Night Sight", false, 4, 1.0f) },
                { Magery.ReactiveArmor, ("Reactive Armor", false, 4, 1.2f) },
                { Magery.Weaken, ("Weaken", true, 4, 1.4f) },
                { Magery.Agility, ("Agility", true, 6, 10.0f) },
                { Magery.Cunning, ("Cunning", true, 6, 11.0f) },
                { Magery.Cure, ("Cure", true, 6, 12.0f) },
                { Magery.Harm, ("Harm", true, 6, 13.0f) },
                { Magery.MagicTrap, ("Magic Trap", false, 6, 14.0f) },
                { Magery.MagicUntrap, ("Magic Untrap", false, 6, 15.0f) },
                { Magery.Protection, ("Protection", false, 6, 16.0f) },
                { Magery.Strength, ("Strength", true, 6, 17.0f) },
                { Magery.Bless, ("Bless", true, 9, 25.0f) },
                { Magery.Fireball, ("Fireball", true, 9, 26.0f) },
                { Magery.MagicLock, ("Magic Lock", false, 9, 27.0f) },
                { Magery.Poison, ("Poison", true, 9, 28.0f) },
                { Magery.Telekinesis, ("Telekinesis", true, 9, 29.0f) },
                { Magery.Teleport, ("Teleport", true, 9, 30.0f) },
                { Magery.Unlock, ("Unlock", true, 9, 31.0f) },
                { Magery.WallofStone, ("Wall of Stone", true, 9, 32.0f) },
                { Magery.ArchCure, ("Arch Cure", true, 11, 40.0f) },
                { Magery.ArchProtection, ("Arch Protection", false, 11, 41.0f) },
                { Magery.Curse, ("Curse", true, 11, 42.0f) },
                { Magery.FireField, ("Fire Field", true, 11, 43.0f) },
                { Magery.GreaterHeal, ("Greater Heal", true, 11, 44.0f) },
                { Magery.Lightning, ("Lightning", true, 11, 45.0f) },
                { Magery.ManaDrain, ("Mana Drain", true, 11, 46.0f) },
                { Magery.Recall, ("Recall", false, 11, 47.0f) },
                { Magery.BladeSpirits, ("Blade Spirits", true, 14, 50.0f) },
                { Magery.DispelField, ("Dispel Field", true, 14, 51.0f) },
                { Magery.Incognito, ("Incognito", false, 14, 52.0f) },
                { Magery.MagicReflection, ("Magic Reflection", false, 14, 53.0f) },
                { Magery.MindBlast, ("Mind Blast", true, 14, 54.0f) },
                { Magery.Paralyze, ("Paralyze", true, 14, 55.0f) },
                { Magery.PoisonField, ("Poison Field", true, 14, 56.0f) },
                { Magery.SummonCreature, ("Summon Creature", false, 14, 57.0f) },
                { Magery.Dispel, ("Dispel", true, 20, 60.0f) },
                { Magery.EnergyBolt, ("Energy Bolt", true, 20, 61.0f) },
                { Magery.Explosion, ("Explosion", true, 20, 62.0f) },
                { Magery.Invisibility, ("Invisibility", true, 20, 63.0f) },
                { Magery.Mark, ("Mark", true, 20, 64.0f) },
                { Magery.MassCurse, ("Mass Curse", true, 20, 65.0f) },
                { Magery.ParalyzeField, ("Paralyze Field", true, 20, 66.0f) },
                { Magery.Reveal, ("Reveal", false, 20, 67.0f) },
                { Magery.ChainLightning, ("Chain Lightning", true, 40, 75.0f) },
                { Magery.EnergyField, ("Energy Field", true, 40, 76.0f) },
                { Magery.FlameStrike, ("Flame Strike", true, 40, 77.0f) },
                { Magery.GateTravel, ("Gate Travel", true, 40, 78.0f) },
                { Magery.ManaVampire, ("Mana Vampire", true, 40, 79.0f) },
                { Magery.MassDispel, ("Mass Dispel", true, 40, 80.0f) },
                { Magery.MeteorSwarm, ("Meteor Swarm", true, 40, 81.0f) },
                { Magery.Polymorph, ("Polymorph", true, 40, 82.0f) },
                { Magery.Earthquake, ("Earthquake", false, 50, 90.0f) },
                { Magery.EnergyVortex, ("Energy Vortex", true, 50, 91.0f) },
                { Magery.Resurrection, ("Resurrection", true, 50, 92.0f) },
                { Magery.SummonAirElemental, ("Summon Air Elemental", false, 50, 93.0f) },
                { Magery.SummonDaemon, ("Summon Daemon", false, 50, 94.0f) },
                { Magery.SummonEarthElemental, ("Summon Earth Elemental", false, 50, 95.0f) },
                { Magery.SummonFireElemental, ("Summon Fire Elemental", false, 50, 96.0f) },
                { Magery.SummonWaterElemental, ("Summon Water Elemental", false, 50, 97.0f) },
            };

        public static string GetName(Magery spell) => SpellMap[spell].Name;

        public static bool RequiresTarget(Magery spell) => SpellMap[spell].RequiresTarget;

        public static int GetManaCost(Magery spell) => SpellMap[spell].ManaCost;

        public static float GetMinSkill(Magery spell) => SpellMap[spell].MinSkill;
        public static bool IsCastableBy(Magery spell, float currentSkill) =>
            currentSkill >= SpellMap[spell].MinSkill;
    }


    public enum ChivalrySpell
    {
        CleanseByFire,
        CloseWounds,
        ConsecrateWeapon,
        DispelEvil,
        DivineFury,
        EnemyOfOne,
        HolyLight,
        NobleSacrifice,
        RemoveCurse,
        SacredJourney,
    }

    public static class ChivalryHelper
    {
        private static readonly
            Dictionary<ChivalrySpell, (string Name, bool RequiresTarget, int ManaCost, float MinSkill)> SpellMap = new()
            {
                { ChivalrySpell.CleanseByFire, ("Cleanse by Fire", true, 10, 0.0f) },
                { ChivalrySpell.CloseWounds, ("Close Wounds", true, 6, 0.0f) },
                { ChivalrySpell.ConsecrateWeapon, ("Consecrate Weapon", false, 6, 0.0f) },
                { ChivalrySpell.DispelEvil, ("Dispel Evil", false, 10, 5.0f) },
                { ChivalrySpell.DivineFury, ("Divine Fury", false, 10, 15.0f) },
                { ChivalrySpell.EnemyOfOne, ("Enemy of One", false, 11, 25.0f) },
                { ChivalrySpell.HolyLight, ("Holy Light", false, 12, 35.0f) },
                { ChivalrySpell.NobleSacrifice, ("Noble Sacrifice", false, 20, 45.0f) },
                { ChivalrySpell.RemoveCurse, ("Remove Curse", true, 20, 55.0f) },
                { ChivalrySpell.SacredJourney, ("Sacred Journey", true, 20, 65.0f) },
            };

        public static string GetName(ChivalrySpell spell) => SpellMap[spell].Name;
        public static bool RequiresTarget(ChivalrySpell spell) => SpellMap[spell].RequiresTarget;
        public static int GetManaCost(ChivalrySpell spell) => SpellMap[spell].ManaCost;
        public static float GetMinSkill(ChivalrySpell spell) => SpellMap[spell].MinSkill;

        public static bool IsCastableBy(ChivalrySpell spell, float currentSkill) =>
            currentSkill >= SpellMap[spell].MinSkill;
    }

    public enum NecromancySpell
    {
        AnimateDead,
        BloodOath,
        CorpseSkin,
        CurseWeapon,
        EvilOmen,
        HorrificBeast,
        LichForm,
        MindRot,
        PainSpike,
        PoisonStrike,
        Strangle,
        SummonFamiliar,
        VampiricEmbrace,
        VengefulSpirit,
        Wither,
        WraithForm,
    }

    public static class NecromancyHelper
    {
        private static readonly
            Dictionary<NecromancySpell, (string Name, bool RequiresTarget, int ManaCost, float MinSkill)> SpellMap =
                new()
                {
                    { NecromancySpell.AnimateDead, ("Animate Dead", false, 23, 40.0f) },
                    { NecromancySpell.BloodOath, ("Blood Oath", true, 13, 0.0f) },
                    { NecromancySpell.CorpseSkin, ("Corpse Skin", true, 11, 0.0f) },
                    { NecromancySpell.CurseWeapon, ("Curse Weapon", false, 11, 0.0f) },
                    { NecromancySpell.EvilOmen, ("Evil Omen", true, 9, 20.0f) },
                    { NecromancySpell.HorrificBeast, ("Horrific Beast", false, 11, 40.0f) },
                    { NecromancySpell.LichForm, ("Lich Form", false, 23, 70.0f) },
                    { NecromancySpell.MindRot, ("Mind Rot", true, 17, 50.0f) },
                    { NecromancySpell.PainSpike, ("Pain Spike", true, 14, 30.0f) },
                    { NecromancySpell.PoisonStrike, ("Poison Strike", true, 17, 60.0f) },
                    { NecromancySpell.Strangle, ("Strangle", true, 23, 80.0f) },
                    { NecromancySpell.SummonFamiliar, ("Summon Familiar", false, 20, 20.0f) },
                    { NecromancySpell.VampiricEmbrace, ("Vampiric Embrace", false, 23, 99.0f) },
                    { NecromancySpell.VengefulSpirit, ("Vengeful Spirit", true, 24, 85.0f) },
                    { NecromancySpell.Wither, ("Wither", false, 21, 80.0f) },
                    { NecromancySpell.WraithForm, ("Wraith Form", false, 17, 20.0f) }
                };

        public static string GetName(NecromancySpell spell) => SpellMap[spell].Name;
        public static bool RequiresTarget(NecromancySpell spell) => SpellMap[spell].RequiresTarget;
        public static int GetManaCost(NecromancySpell spell) => SpellMap[spell].ManaCost;
        public static float GetMinSkill(NecromancySpell spell) => SpellMap[spell].MinSkill;

        public static bool IsCastableBy(NecromancySpell spell, float currentSkill) =>
            currentSkill >= SpellMap[spell].MinSkill;
    }
    public enum MysticismSpell
    {
        NetherBolt,
        HealingStone,
        PurgeMagic,
        Enchant,
        Sleep,
        EagleStrike,
        AnimatedWeapon,
        StoneForm,
        SpellTrigger,
        MassSleep,
        CleansingWinds,
        Bombard,
        SpellPlague,
        HailStorm,
        NetherCyclone,
        RisingColossus
    }
    public static class MysticismHelper
    {
        

        private static readonly Dictionary<MysticismSpell, (string Name, bool RequiresTarget, int ManaCost, float MinSkill) > SpellMap = new()
        {
            { MysticismSpell.NetherBolt,("Nether Bolt", true, 6, 10.0f) },
            { MysticismSpell.HealingStone,("Healing Stone", false, 6, 10.0f) },
            { MysticismSpell.PurgeMagic,("Purge Magic", true, 9, 20.0f) },
            { MysticismSpell.Enchant,("Enchant", false, 9, 20.0f) },
            { MysticismSpell.Sleep,("Sleep", true, 12, 30.0f) },
            { MysticismSpell.EagleStrike,("Eagle Strike", true, 12, 30.0f) },
            { MysticismSpell.AnimatedWeapon,("Animated Weapon", false, 15, 40.0f) },
            { MysticismSpell.StoneForm,("Stone Form", false, 15, 40.0f) },
            { MysticismSpell.SpellTrigger,("Spell Trigger", false, 18, 50.0f) },
            { MysticismSpell.MassSleep,("Mass Sleep", true, 18, 50.0f) },
            { MysticismSpell.CleansingWinds,("Cleansing Winds", true, 21, 60.0f) },
            { MysticismSpell.Bombard,("Bombard", true, 21, 60.0f) },
            { MysticismSpell.SpellPlague,("Spell Plague", true, 24, 70.0f) },
            { MysticismSpell.HailStorm,("Hail Storm", true, 24, 70.0f) },
            { MysticismSpell.NetherCyclone,("Nether Cyclone", true, 27, 80.0f) },
            { MysticismSpell.RisingColossus,("Rising Colossus", false, 27, 80.0f) },
        };
        public static string GetName(MysticismSpell spell) => SpellMap[spell].Name;
        public static bool RequiresTarget(MysticismSpell spell) => SpellMap[spell].RequiresTarget;
        public static int GetManaCost(MysticismSpell spell) => SpellMap[spell].ManaCost;
        public static float GetMinSkill(MysticismSpell spell) => SpellMap[spell].MinSkill;
        public static bool IsCastableBy(MysticismSpell spell, float currentSkill) => currentSkill >= SpellMap[spell].MinSkill;
    }

    public enum BushidoSpell
    {
        HonorableExecution,
        Confidence,
        Evasion,
        CounterAttack,
        LightningStrike,
        MomentumStrike,
    }

    public static class BushidoHelper
    {
        private static readonly Dictionary<BushidoSpell,(string Name, bool RequiresTarget, int ManaCost, float MinSkill)> SpellMap = new()
        {
            { BushidoSpell.HonorableExecution,("Honorable Execution", false, 10, 25.0f) },
            { BushidoSpell.Confidence,("Confidence", false, 10, 25.0f) },
            { BushidoSpell.Evasion,("Evasion", false, 10, 35.0f) },
            { BushidoSpell.CounterAttack,("Counter Attack", false, 10, 40.0f) },
            { BushidoSpell.LightningStrike,("Lightning Strike", false, 10, 50.0f) },
            { BushidoSpell.MomentumStrike,("Momentum Strike", false, 10, 60.0f) },
        };
        public static string GetName(BushidoSpell spell) => SpellMap[spell].Name;
        public static bool RequiresTarget(BushidoSpell spell) => SpellMap[spell].RequiresTarget;
        public static int GetManaCost(BushidoSpell spell) => SpellMap[spell].ManaCost;
        public static float GetMinSkill(BushidoSpell spell) => SpellMap[spell].MinSkill;
        public static bool IsCastableBy(BushidoSpell spell, float currentSkill) => currentSkill >= SpellMap[spell].MinSkill;
    }
    public enum SpellweavingSpell
    {
        ArcaneCircle,
        GiftOfRenewal,
        ImmolatingWeapon,
        Attunement,
        Thunderstorm,
        NatureFury,
        SummonFiend,
        ReaperForm,
        Wildfire,
        EssenceOfWind,
        DryadAllure,
        EtherealVoyage,
        WordOfDeath,
        GiftOfLife,
        ArcaneEmpowerment,
    }

    public static class SpellweavingHelper
    {
        private static readonly Dictionary<SpellweavingSpell, (string Name, bool RequiresTarget, int ManaCost, float MinSkill)> SpellMap = new()
        {
            { SpellweavingSpell.ArcaneCircle,("Arcane Circle", false, 24, 0.0f) },
            { SpellweavingSpell.GiftOfRenewal,("Gift of Renewal", true, 14, 0.0f) },
            { SpellweavingSpell.ImmolatingWeapon,("Immolating Weapon", false, 16, 0.0f) },
            { SpellweavingSpell.Attunement,("Attunement", false, 18, 0.0f) },
            { SpellweavingSpell.Thunderstorm,("Thunderstorm", false, 20, 0.0f) },
            { SpellweavingSpell.NatureFury,("Nature's Fury", true, 22, 0.0f) },
            { SpellweavingSpell.SummonFiend,("Summon Fiend", false, 24, 0.0f) },
            { SpellweavingSpell.ReaperForm,("Reaper Form", false, 26, 0.0f) },
            { SpellweavingSpell.Wildfire,("Wildfire", true, 28, 0.0f) },
            { SpellweavingSpell.EssenceOfWind,("Essence of Wind", true, 30, 0.0f) },
            { SpellweavingSpell.DryadAllure,("Dryad Allure", true, 32, 0.0f) },
            { SpellweavingSpell.EtherealVoyage,("Ethereal Voyage", false, 34, 0.0f) },
            { SpellweavingSpell.WordOfDeath,("Word of Death", true, 36, 0.0f) },
            { SpellweavingSpell.GiftOfLife,("Gift of Life", true, 38, 0.0f) },
            { SpellweavingSpell.ArcaneEmpowerment,("Arcane Empowerment", false, 40, 0.0f) },
        };
        public static string GetName(SpellweavingSpell spell) => SpellMap[spell].Name;
        public static bool RequiresTarget(SpellweavingSpell spell) => SpellMap[spell].RequiresTarget;
        public static int GetManaCost(SpellweavingSpell spell) => SpellMap[spell].ManaCost;
        public static float GetMinSkill(SpellweavingSpell spell) => SpellMap[spell].MinSkill;
        public static bool IsCastableBy(SpellweavingSpell spell, float currentSkill) => currentSkill >= SpellMap[spell].MinSkill;
    }

    public enum NinjitsuSpell
    {
        FocusAttack,
        DeathStrike,
        AnimalForm,
        KiAttack,
        SurpriseAttack,
        Backstab,
        Shadowjump,
        MirrorImage,
    }

    public static class NinjitsuHelper
    {
        private static readonly Dictionary<NinjitsuSpell, (string Name, bool RequiresTarget, int ManaCost, float MinSkill)> SpellMap = new()
        {
            { NinjitsuSpell.FocusAttack,("Focus Attack", false, 6, 0.0f) },
            { NinjitsuSpell.DeathStrike,("Death Strike", true, 12, 85.0f) },
            { NinjitsuSpell.AnimalForm,("Animal Form", false, 10, 20.0f) },
            { NinjitsuSpell.KiAttack,("Ki Attack", true, 10, 50.0f) },
            { NinjitsuSpell.SurpriseAttack,("Surprise Attack", true, 12, 60.0f) },
            { NinjitsuSpell.Backstab,("Backstab", true, 10, 70.0f) },
            { NinjitsuSpell.Shadowjump,("Shadowjump", false, 14, 50.0f) },
            { NinjitsuSpell.MirrorImage,("Mirror Image", false, 10, 30.0f) },
        };
        public static string GetName(NinjitsuSpell spell) => SpellMap[spell].Name;
        public static bool RequiresTarget(NinjitsuSpell spell) => SpellMap[spell].RequiresTarget;
        public static int GetManaCost(NinjitsuSpell spell) => SpellMap[spell].ManaCost;
        public static float GetMinSkill(NinjitsuSpell spell) => SpellMap[spell].MinSkill;
        public static bool IsCastableBy(NinjitsuSpell spell, float currentSkill) => currentSkill >= SpellMap[spell].MinSkill;
    }
}