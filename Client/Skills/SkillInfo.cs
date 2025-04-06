using System.Collections.Generic;

namespace StealthBridgeSDK.Skills
{
    public class SkillMetadata
    {
        public string Name { get; }
        public string Tooltip { get; }
        public string Category { get; }

        public SkillMetadata(string name, string tooltip, string category)
        {
            Name = name;
            Tooltip = tooltip;
            Category = category;
        }
    }

    public static class SkillInfo
    {
        public static readonly Dictionary<SkillName, SkillMetadata> SkillMap = new()
        {
            { SkillName.Alchemy, new SkillMetadata("Alchemy", "Create potions using reagents and bottles.", "Crafting") },
            { SkillName.Anatomy, new SkillMetadata("Anatomy", "Grants insight into physical damage and healing efficiency.", "Combat") },
            { SkillName.AnimalLore, new SkillMetadata("Animal Lore", "Gives information about animals and helps with taming/control.", "Misc") },
            { SkillName.AnimalTaming, new SkillMetadata("Animal Taming", "Tame wild animals and creatures.", "Misc") },
            { SkillName.Archery, new SkillMetadata("Archery", "Increases effectiveness with bows and crossbows.", "Combat") },
            { SkillName.ArmsLore, new SkillMetadata("Arms Lore", "Provides item identification and improves crafted gear.", "Crafting") },
            { SkillName.Begging, new SkillMetadata("Begging", "Request gold or items from NPCs.", "Misc") },
            { SkillName.Blacksmithy, new SkillMetadata("Blacksmithy", "Forge weapons, armor, and tools.", "Crafting") },
            { SkillName.Bowcraft, new SkillMetadata("Bowcraft", "Craft bows and crossbows.", "Crafting") },
            { SkillName.Camping, new SkillMetadata("Camping", "Create campfires and log out safely.", "Misc") },
            { SkillName.Carpentry, new SkillMetadata("Carpentry", "Build furniture, weapons, and house add-ons.", "Crafting") },
            { SkillName.Cartography, new SkillMetadata("Cartography", "Decode treasure maps and create world maps.", "Crafting") },
            { SkillName.Cooking, new SkillMetadata("Cooking", "Create edible food and meals.", "Crafting") },
            { SkillName.DetectHidden, new SkillMetadata("Detect Hidden", "Reveal hidden items, traps, or characters.", "Stealth") },
            { SkillName.Discordance, new SkillMetadata("Discordance", "Weaken enemies with music.", "Bard") },
            { SkillName.EvaluatingIntelligence, new SkillMetadata("Evaluating Intelligence", "Increases spell damage and provides target info.", "Magic") },
            { SkillName.Fencing, new SkillMetadata("Fencing", "Increases effectiveness with short melee weapons.", "Combat") },
            { SkillName.Fishing, new SkillMetadata("Fishing", "Catch fish, boots, treasure, and SOS bottles.", "Misc") },
            { SkillName.Forensics, new SkillMetadata("Forensics", "Examine corpses and items to discover information.", "Misc") },
            { SkillName.Healing, new SkillMetadata("Healing", "Use bandages to heal damage or cure poison.", "Combat") },
            { SkillName.Herding, new SkillMetadata("Herding", "Move animals using a shepherd’s crook.", "Misc") },
            { SkillName.Hiding, new SkillMetadata("Hiding", "Become invisible while standing still.", "Stealth") },
            { SkillName.Inscription, new SkillMetadata("Inscription", "Craft spell scrolls and spellbooks.", "Magic") },
            { SkillName.ItemID, new SkillMetadata("ItemID", "Identify magical or special items.", "Misc") },
            { SkillName.Lockpicking, new SkillMetadata("Lockpicking", "Unlock locked containers and treasure chests.", "Stealth") },
            { SkillName.Lumberjacking, new SkillMetadata("Lumberjacking", "Chop wood and increase axe weapon damage.", "Crafting") },
            { SkillName.MaceFighting, new SkillMetadata("MaceFighting", "Increases effectiveness with blunt weapons.", "Combat") },
            { SkillName.Magery, new SkillMetadata("Magery", "Casts powerful spells using reagents.", "Magic") },
            { SkillName.Meditation, new SkillMetadata("Meditation", "Regenerate mana faster.", "Magic") },
            { SkillName.Mining, new SkillMetadata("Mining", "Dig ore for blacksmithing and smelting.", "Crafting") },
            { SkillName.Musicianship, new SkillMetadata("Musicianship", "Required for all bard skills to function.", "Bard") },
            { SkillName.Necromancy, new SkillMetadata("Necromancy", "Cast necromantic spells using dark reagents.", "Magic") },
            { SkillName.Parrying, new SkillMetadata("Parrying", "Block attacks with shields or weapons.", "Combat") },
            { SkillName.Peacemaking, new SkillMetadata("Peacemaking", "Calm creatures using music.", "Bard") },
            { SkillName.Poisoning, new SkillMetadata("Poisoning", "Apply poison to weapons or food.", "Stealth") },
            { SkillName.Provocation, new SkillMetadata("Provocation", "Cause creatures to attack each other with music.", "Bard") },
            { SkillName.RemoveTrap, new SkillMetadata("RemoveTrap", "Disarm traps on chests or doors.", "Stealth") },
            { SkillName.ResistingSpells, new SkillMetadata("ResistingSpells", "Reduce duration and effect of magic spells.", "Magic") },
            { SkillName.Snooping, new SkillMetadata("Snooping", "Peek inside containers held by others.", "Stealth") },
            { SkillName.SpiritSpeak, new SkillMetadata("SpiritSpeak", "Speak with ghosts and enhance Necromancy.", "Magic") },
            { SkillName.Stealing, new SkillMetadata("Stealing", "Take items from others without being seen.", "Stealth") },
            { SkillName.Stealth, new SkillMetadata("Stealth", "Move unseen after hiding.", "Stealth") },
            { SkillName.Swordsmanship, new SkillMetadata("Swordsmanship", "Increases effectiveness with swords and blades.", "Combat") },
            { SkillName.Tactics, new SkillMetadata("Tactics", "Boost damage with all melee and ranged attacks.", "Combat") },
            { SkillName.Tailoring, new SkillMetadata("Tailoring", "Craft clothing, armor, and leather goods.", "Crafting") },
            { SkillName.TasteIdentification, new SkillMetadata("TasteID", "Identify potions or food contents.", "Misc") },
            { SkillName.Tinkering, new SkillMetadata("Tinkering", "Craft tools, traps, and mechanical devices.", "Crafting") },
            { SkillName.Tracking, new SkillMetadata("Tracking", "Follow the trail of creatures or players.", "Misc") },
            { SkillName.Veterinary, new SkillMetadata("Veterinary", "Heal animals with bandages.", "Misc") },
            { SkillName.Wrestling, new SkillMetadata("Wrestling", "Bare-handed combat skill.", "Combat") },
            { SkillName.Bushido, new SkillMetadata("Bushido", "Enhances samurai abilities and combat style.", "Combat") },
            { SkillName.Chivalry, new SkillMetadata("Chivalry", "Cast paladin spells using tithing points.", "Magic") },
            { SkillName.Focus, new SkillMetadata("Focus", "Enhances stamina and mana regeneration.", "Magic") },
            { SkillName.Mysticism, new SkillMetadata("Mysticism", "Cast arcane spells using magical gems.", "Magic") },
            { SkillName.Ninjitsu, new SkillMetadata("Ninjitsu", "Use stealthy and deceptive abilities.", "Stealth") },
            { SkillName.Spellweaving, new SkillMetadata("Spellweaving", "Use circle magic spells with arcane focus.", "Magic") },
            { SkillName.Throwing, new SkillMetadata("Throwing", "Combat with throwing weapons like soul glaives.", "Combat") },
        };

        public static SkillMetadata Get(SkillName skill) => SkillMap[skill];
    }
}