using StealthBridgeSDK.Crafting;
using StealthBridgeSDK;
using StealthBridgeSDK.Gumps;

namespace StealthBridgeSDK.Crafting
{
    public enum BSCraftCategory
    {
        LastTen,
        MetalArmor,
        Helmets,
        Shields,
        Bladed,
        Axes,
        Polearms,
        Bashing,
        Cannons,
        Throwing,
        Miscellaneous,
    }
    public enum MiscButtons
    {
        SmeltItem,
        CraftResource,
        Scales,
        RepairItem,
        MarkItem,
        EnhanceItem,
        AlterItem,
        NonQuestItem,
        MakeLast,
        Exit,
        CancelMake,
    }
    public enum BSCraftable
    {
        RingmailGloves,
        RingmailLeggings,
        RingmailSleeves,
        RingmailTunic,
        ChainmailCoif,
        ChainmailLeggings,
        ChainmailTunic,
        PlatemailArms,
        PlatemailGloves,
        PlatemailGorget,
        PlatemailLegs,
        PlatemailTunic,
        PlatemailFemale,
        DragonBardingDeed,
        PlatemailMempo,
        PlatemailDo,
        PlatemailHiroSode,
        PlatemailSuneate,
        PlatemailHaidate,
        PlatemailGargishArms,
        PlatemailGargishChest,
        PlatemailGargishLeggings,
        PlatemailGargishKilt,
        GargishAmulet,
        BritchesOfWarding,
        Bascinet,
        CloseHelmet,
        Helmet,
        NorseHelmet,
        PlateHelm,
        ChainmailHatsuburi,
        PlatemailHatsuburi,
        HeavyPlatemailJingasa,
        LightPlatemailJingasa,
        SmallPlatemailJingasa,
        DecorativePlatemailKabuto,
        PlatemailBattleKabuto,
        StandardPlatemailKabuto,
        Circlet,
        RoyalCirclet,
        GemmedCirclet,
        Buckler,
        BronzeShield,
        HeaterShield,
        MetalShield,
        MetalKiteShield,
        TearKiteShield,
        ChaosShield,
        OrderShield,
        SmallPlateShield,
        GargishKiteShield,
        LargePlateShield,
        MediumPlateShield,
        GargishChaosShield,
        GargishOrderShield,
        ShieldOrb,
        BoneHarvester,
        BroadSword,
        CrescentBlade,
        Cutlass,
        Dagger,
        Katana,
        Kryss,
        Longsword,
        Scimitar,
        VikingSword,
        NoDachi,
        Wakizashi,
        Lajatang,
        Daisho,
        Tekagi,
        Shuriken,
        Kama,
        Sai,
        RadiantScimitar,
        WarCleaver,
        ElvenSpellblade,
        AssassinSpike,
        LeafBlade,
        RuneBlade,
        ElvenMachete,
        RuneCarvingKnife,
        ColdForgedBlade,
        OverseerSunderedBlade,
        LuminousRuneBlade,
        TrueSpellblade,
        IcySpellblade,
        FierySpellblade,
        SpellbladeofDefense,
        TrueAssassinSpike,
        ChargedAssassinSpike,
        MagekillerAssassinSpike,
        WoundingAssassinSpike,
        TrueLeafblade,
        LuckBlade,
        MagekillerLeafblade,
        LeafbladeofEase,
        KnightsWarCleaver,
        ButchersWarCleaver,
        SerratedWarCleaver,
        TrueWarCleaver,
        AdventurersMachete,
        OrcishMachete,
        MacheteofDefense,
        DiseasedMachete,
        RuneSabre,
        MageRuneBlade,
        RuneBladeofKnowledge,
        CorrupedRUneBlade,
        TrueRadiantScimitar,
        DarkglowScimitar,
        IcyScimitar,
        TwinklingScimitar,
        BoneMachete,
        GargishKatana,
        GargishKryss,
        GargishBoneHarvester,
        GargishTekagi,
        GargishDaisho,
        DreadSword,
        GargishTalwar,
        GargishDagger,
        Bloodblade,
        Shortblade,
        Axe,
        BattleAxe,
        DoubleAxe,
        ExecutionerAxe,
        LargeBattleAxe,
        TwoHandedAxe,
        WarAxe,
        OrnateAxe,
        GuardianAxe,
        SingingAxe,
        ThunderingAxe,
        HeavyOrnateAxe,
        GargishBattleAxe,
        GargishAxe,
        DualShortAxes,
        Bardiche,
        BladedStaff,
        DoubleBladedStaff,
        Halberd,
        Lance,
        Pike,
        ShortSpear,
        Scythe,
        Spear,
        WarFork,
        GargishBardiche,
        GargishWarFork,
        GargishScythe,
        GargishPike,
        GargishLance,
        DualPointedSpear,
        HammerPick,
        Mace,
        Maul,
        Scepter,
        WarMace,
        WarHammer,
        Tessen,
        DiamondMace,
        ShardThrasher,
        RubyMace,
        EmeraldMace,
        SapphireMace,
        SilverEtchedMace,
        GargishWarHammer,
        GargishMaul,
        GargishTessen,
        DiscMace,
        Cannonball,
        Grapeshot,
        Culverin,
        Carronade,
        Boomerang,
        Cyclone,
        SoulGlaive,
        DragonGloves,
        DragonHelm,
        DragonLeggings,
        DragonSleeves,
        DragonBreastplate,
        CrushedGlass,
        PowderedIron,
        MetalKeg,
        ExodusSacrificialDagger,
        GlovesofFeudalGrip
    }
    public class BSCrafting
    {
        private static readonly Dictionary<BSCraftCategory, (int ReturnValue, int PressedID, int ReleasedID)> BlackSmithCategory = new()
        {
            {BSCraftCategory.LastTen,(28,4007,4005) },
            {BSCraftCategory.MetalArmor,(1,4007,4005) },
            {BSCraftCategory.Helmets,(8,4007,4005) },
            {BSCraftCategory.Shields,(15,4007,4005) },
            {BSCraftCategory.Bladed,(22,4007,4005) },
            {BSCraftCategory.Axes,(29,4007,4005) },
            {BSCraftCategory.Polearms,(36,4007,4005) },
            {BSCraftCategory.Bashing,(43,4007,4005) },
            {BSCraftCategory.Cannons,(50,4007,4005) },
            {BSCraftCategory.Throwing,(57,4007,4005) },
            {BSCraftCategory.Miscellaneous,(64,4007,4005) }
        };
        private static readonly Dictionary<MiscButtons, (int ReturnValue, int PressedID, int ReleasedID)> MiscButton = new()
        {
            {MiscButtons.SmeltItem,(14,4007,4005) },
            {MiscButtons.CraftResource,(7,4007,4005) },
            {MiscButtons.Scales,(56,4007,4005) },
            {MiscButtons.Exit,(0,4019,4017) },
            {MiscButtons.CancelMake,(84,4019,4017) },
            {MiscButtons.RepairItem,(42,4007,4005) },
            {MiscButtons.MarkItem,(49,4007,4005) },
            {MiscButtons.EnhanceItem,(63,4007,4005) },
            {MiscButtons.AlterItem,(70,4007,4005) },
            {MiscButtons.NonQuestItem,(77,4007,4005) },
            {MiscButtons.MakeLast,(21,4007,4005) }
        };
        private static readonly Dictionary<BSCraftable, (int ReturnValue, int PressedID, int ReleasedID, BSCraftCategory CraftCategory)> CraftButton = new()
        {
            {BSCraftable.RingmailGloves,(2,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.RingmailLeggings,(9,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.RingmailSleeves,(16,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.RingmailTunic,(23,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.ChainmailCoif,(30,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.ChainmailLeggings,(37,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.ChainmailTunic,(44,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.PlatemailArms,(51,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.PlatemailGloves,(58,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.PlatemailGorget,(65,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.PlatemailLegs,(72,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.PlatemailTunic,(79,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.PlatemailFemale,(86,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.DragonBardingDeed,(93,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.PlatemailMempo,(100,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.PlatemailDo,(107,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.PlatemailHiroSode,(114,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.PlatemailSuneate,(121,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.PlatemailHaidate,(128,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.PlatemailGargishArms,(135,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.PlatemailGargishChest,(142,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.PlatemailGargishLeggings,(149,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.PlatemailGargishKilt,(156,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.GargishAmulet,(191,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.BritchesOfWarding,(198,4007,4005,BSCraftCategory.MetalArmor)},
            {BSCraftable.Bascinet,(2,4007,4005,BSCraftCategory.Helmets)},
            {BSCraftable.CloseHelmet,(9,4007,4005,BSCraftCategory.Helmets)},
            {BSCraftable.Helmet,(16,4007,4005,BSCraftCategory.Helmets)},
            {BSCraftable.NorseHelmet,(23,4007,4005,BSCraftCategory.Helmets)},
            {BSCraftable.PlateHelm,(30,4007,4005,BSCraftCategory.Helmets)},
            {BSCraftable.ChainmailHatsuburi,(37,4007,4005,BSCraftCategory.Helmets)},
            {BSCraftable.PlatemailHatsuburi,(44,4007,4005,BSCraftCategory.Helmets)},
            {BSCraftable.HeavyPlatemailJingasa,(51,4007,4005,BSCraftCategory.Helmets)},
            {BSCraftable.LightPlatemailJingasa,(58,4007,4005,BSCraftCategory.Helmets)},
            {BSCraftable.SmallPlatemailJingasa,(65,4007,4005,BSCraftCategory.Helmets)},
            {BSCraftable.DecorativePlatemailKabuto,(72,4007,4005,BSCraftCategory.Helmets)},
            {BSCraftable.PlatemailBattleKabuto,(79,4007,4005,BSCraftCategory.Helmets)},
            {BSCraftable.StandardPlatemailKabuto,(86,4007,4005,BSCraftCategory.Helmets)},
            {BSCraftable.Circlet,(93,4007,4005,BSCraftCategory.Helmets)},
            {BSCraftable.RoyalCirclet,(100,4007,4005,BSCraftCategory.Helmets)},
            {BSCraftable.GemmedCirclet,(107,4007,4005,BSCraftCategory.Helmets)},
            {BSCraftable.Buckler,(2,4007,4005,BSCraftCategory.Shields)},
            {BSCraftable.BronzeShield,(9,4007,4005,BSCraftCategory.Shields)},
            {BSCraftable.HeaterShield,(16,4007,4005,BSCraftCategory.Shields)},
            {BSCraftable.MetalShield,(23,4007,4005,BSCraftCategory.Shields)},
            {BSCraftable.MetalKiteShield,(30,4007,4005,BSCraftCategory.Shields)},
            {BSCraftable.TearKiteShield,(37,4007,4005,BSCraftCategory.Shields)},
            {BSCraftable.ChaosShield,(44,4007,4005,BSCraftCategory.Shields)},
            {BSCraftable.OrderShield,(51,4007,4005,BSCraftCategory.Shields)},
            {BSCraftable.SmallPlateShield,(58,4007,4005,BSCraftCategory.Shields)},
            {BSCraftable.GargishKiteShield,(65,4007,4005,BSCraftCategory.Shields)},
            {BSCraftable.LargePlateShield,(72,4007,4005,BSCraftCategory.Shields)},
            {BSCraftable.MediumPlateShield,(79,4007,4005,BSCraftCategory.Shields)},
            {BSCraftable.GargishChaosShield,(86,4007,4005,BSCraftCategory.Shields)},
            {BSCraftable.GargishOrderShield,(93,4007,4005,BSCraftCategory.Shields)},
            {BSCraftable.ShieldOrb,(100,4007,4005,BSCraftCategory.Shields)},
            {BSCraftable.BoneHarvester,(2,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.BroadSword,(9,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.CrescentBlade,(16,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.Cutlass,(23,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.Dagger,(30,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.Katana,(37,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.Kryss,(44,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.Longsword,(51,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.Scimitar,(58,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.VikingSword,(65,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.NoDachi,(72,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.Wakizashi,(79,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.Lajatang,(86,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.Daisho,(93,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.Tekagi,(100,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.Shuriken,(107,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.Kama,(114,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.Sai,(121,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.RadiantScimitar,(128,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.WarCleaver,(135,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.ElvenSpellblade,(142,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.AssassinSpike,(149,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.LeafBlade,(156,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.RuneBlade,(163,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.ElvenMachete,(170,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.RuneCarvingKnife,(177,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.ColdForgedBlade,(184,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.OverseerSunderedBlade,(191,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.LuminousRuneBlade,(198,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.TrueSpellblade,(205,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.IcySpellblade,(212,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.FierySpellblade,(219,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.SpellbladeofDefense,(226,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.TrueAssassinSpike,(233,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.ChargedAssassinSpike,(240,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.MagekillerAssassinSpike,(247,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.WoundingAssassinSpike,(254,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.TrueLeafblade,(261,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.LuckBlade,(268,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.MagekillerLeafblade,(275,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.LeafbladeofEase,(282,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.KnightsWarCleaver,(289,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.ButchersWarCleaver,(296,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.SerratedWarCleaver,(303,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.TrueWarCleaver,(310,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.AdventurersMachete,(317,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.OrcishMachete,(324,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.MacheteofDefense,(331,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.DiseasedMachete,(338,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.RuneSabre,(345,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.MageRuneBlade,(352,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.RuneBladeofKnowledge,(359,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.CorrupedRUneBlade,(366,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.TrueRadiantScimitar,(373,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.DarkglowScimitar,(380,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.IcyScimitar,(387,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.TwinklingScimitar,(394,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.BoneMachete,(401,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.GargishKatana,(408,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.GargishKryss,(415,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.GargishBoneHarvester,(422,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.GargishTekagi,(429,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.GargishDaisho,(436,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.DreadSword,(443,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.GargishTalwar,(450,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.GargishDagger,(457,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.Bloodblade,(464,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.Shortblade,(471,4007,4005,BSCraftCategory.Bladed)},
            {BSCraftable.Axe,(2,4007,4005,BSCraftCategory.Axes)},
            {BSCraftable.BattleAxe,(9,4007,4005,BSCraftCategory.Axes)},
            {BSCraftable.DoubleAxe,(16,4007,4005,BSCraftCategory.Axes)},
            {BSCraftable.ExecutionerAxe,(23,4007,4005,BSCraftCategory.Axes)},
            {BSCraftable.LargeBattleAxe,(30,4007,4005,BSCraftCategory.Axes)},
            {BSCraftable.TwoHandedAxe,(37,4007,4005,BSCraftCategory.Axes)},
            {BSCraftable.WarAxe,(44,4007,4005,BSCraftCategory.Axes)},
            {BSCraftable.OrnateAxe,(51,4007,4005,BSCraftCategory.Axes)},
            {BSCraftable.GuardianAxe,(58,4007,4005,BSCraftCategory.Axes)},
            {BSCraftable.SingingAxe,(65,4007,4005,BSCraftCategory.Axes)},
            {BSCraftable.ThunderingAxe,(72,4007,4005,BSCraftCategory.Axes)},
            {BSCraftable.HeavyOrnateAxe,(79,4007,4005,BSCraftCategory.Axes)},
            {BSCraftable.GargishBattleAxe,(86,4007,4005,BSCraftCategory.Axes)},
            {BSCraftable.GargishAxe,(93,4007,4005,BSCraftCategory.Axes)},
            {BSCraftable.DualShortAxes,(100,4007,4005,BSCraftCategory.Axes)},
            {BSCraftable.Bardiche,(2,4007,4005,BSCraftCategory.Polearms)},
            {BSCraftable.BladedStaff,(9,4007,4005,BSCraftCategory.Polearms)},
            {BSCraftable.DoubleBladedStaff,(16,4007,4005,BSCraftCategory.Polearms)},
            {BSCraftable.Halberd,(23,4007,4005,BSCraftCategory.Polearms)},
            {BSCraftable.Lance,(30,4007,4005,BSCraftCategory.Polearms)},
            {BSCraftable.Pike,(37,4007,4005,BSCraftCategory.Polearms)},
            {BSCraftable.ShortSpear,(44,4007,4005,BSCraftCategory.Polearms)},
            {BSCraftable.Scythe,(51,4007,4005,BSCraftCategory.Polearms)},
            {BSCraftable.Spear,(58,4007,4005,BSCraftCategory.Polearms)},
            {BSCraftable.WarFork,(65,4007,4005,BSCraftCategory.Polearms)},
            {BSCraftable.GargishBardiche,(72,4007,4005,BSCraftCategory.Polearms)},
            {BSCraftable.GargishWarFork,(79,4007,4005,BSCraftCategory.Polearms)},
            {BSCraftable.GargishScythe,(86,4007,4005,BSCraftCategory.Polearms)},
            {BSCraftable.GargishPike,(93,4007,4005,BSCraftCategory.Polearms)},
            {BSCraftable.GargishLance,(100,4007,4005,BSCraftCategory.Polearms)},
            {BSCraftable.DualPointedSpear,(107,4007,4005,BSCraftCategory.Polearms)},
            {BSCraftable.HammerPick,(2,4007,4005,BSCraftCategory.Bashing)},
            {BSCraftable.Mace,(9,4007,4005,BSCraftCategory.Bashing)},
            {BSCraftable.Maul,(16,4007,4005,BSCraftCategory.Bashing)},
            {BSCraftable.Scepter,(23,4007,4005,BSCraftCategory.Bashing)},
            {BSCraftable.WarMace,(30,4007,4005,BSCraftCategory.Bashing)},
            {BSCraftable.WarHammer,(37,4007,4005,BSCraftCategory.Bashing)},
            {BSCraftable.Tessen,(44,4007,4005,BSCraftCategory.Bashing)},
            {BSCraftable.DiamondMace,(51,4007,4005,BSCraftCategory.Bashing)},
            {BSCraftable.ShardThrasher,(58,4007,4005,BSCraftCategory.Bashing)},
            {BSCraftable.RubyMace,(65,4007,4005,BSCraftCategory.Bashing)},
            {BSCraftable.EmeraldMace,(72,4007,4005,BSCraftCategory.Bashing)},
            {BSCraftable.SapphireMace,(79,4007,4005,BSCraftCategory.Bashing)},
            {BSCraftable.SilverEtchedMace,(86,4007,4005,BSCraftCategory.Bashing)},
            {BSCraftable.GargishWarHammer,(93,4007,4005,BSCraftCategory.Bashing)},
            {BSCraftable.GargishMaul,(100,4007,4005,BSCraftCategory.Bashing)},
            {BSCraftable.GargishTessen,(107,4007,4005,BSCraftCategory.Bashing)},
            {BSCraftable.DiscMace,(114,4007,4005,BSCraftCategory.Bashing)},
            {BSCraftable.Cannonball,(2,4007,4005,BSCraftCategory.Cannons)},
            {BSCraftable.Grapeshot,(9,4007,4005,BSCraftCategory.Cannons)},
            {BSCraftable.Culverin,(16,4007,4005,BSCraftCategory.Cannons)},
            {BSCraftable.Carronade,(23,4007,4005,BSCraftCategory.Cannons)},
            {BSCraftable.Boomerang,(2,4007,4005,BSCraftCategory.Throwing)},
            {BSCraftable.Cyclone,(9,4007,4005,BSCraftCategory.Throwing)},
            {BSCraftable.SoulGlaive,(16,4007,4005,BSCraftCategory.Throwing)},
            {BSCraftable.DragonGloves,(2,4007,4005,BSCraftCategory.Miscellaneous)},
            {BSCraftable.DragonHelm,(9,4007,4005,BSCraftCategory.Miscellaneous)},
            {BSCraftable.DragonLeggings,(16,4007,4005,BSCraftCategory.Miscellaneous)},
            {BSCraftable.DragonSleeves,(23,4007,4005,BSCraftCategory.Miscellaneous)},
            {BSCraftable.DragonBreastplate,(30,4007,4005,BSCraftCategory.Miscellaneous)},
            {BSCraftable.CrushedGlass,(37,4007,4005,BSCraftCategory.Miscellaneous)},
            {BSCraftable.PowderedIron,(44,4007,4005,BSCraftCategory.Miscellaneous)},
            {BSCraftable.MetalKeg,(51,4007,4005,BSCraftCategory.Miscellaneous)},
            {BSCraftable.ExodusSacrificialDagger,(58,4007,4005,BSCraftCategory.Miscellaneous)},
            {BSCraftable.GlovesofFeudalGrip,(65,4007,4005,BSCraftCategory.Miscellaneous)}
        };
        public class BSCraftGump
        {
            public static Gump MainGump { get; set; }
            public static bool Initialized { get; set; } = false;


            public static void Initialize()
            {
                MainGump = GetGump(2653346093);
                Initialized = true;
            }

            private static Gump GetGump(uint gumpid)
            {
                uint gumpCount = GumpWrapper.GetGumpsCount();
                for (int i = 0; i < gumpCount; i++)
                {
                    var gump = GumpWrapper.DumpGumpInfo(i);
                    if (gump.GumpID == gumpid)
                    {
                        gump.GumpIndex = i;
                        return gump;
                    }
                }
                return null;
            }
            public static void Craft(BSCraftable craft)
            {

                Gump g = MainGump;
                if (g == null) { Logger.Warn($"Craft Gump came Back Null"); return; }
                ClickCategory(BSCrafting.CraftButton[craft].CraftCategory);
                foreach (var e in g.Buttons)
                {
                    if (!e.ReturnValue.Equals(BSCrafting.CraftButton[craft].ReturnValue) && !e.ReleasedID.Equals(BSCrafting.CraftButton[craft].ReleasedID) &&
                        !e.PressedID.Equals(BSCrafting.CraftButton[craft].PressedID)) continue;

                    GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(BSCrafting.CraftButton[craft].ReturnValue));
                    GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                    break;
                }
            }

            public static void ClickCategory(BSCraftCategory cat)
            {
                Gump g = MainGump;

                foreach (var e in g.Buttons)
                {
                    if (!e.ReturnValue.Equals(BSCrafting.BlackSmithCategory[cat].ReturnValue) && !e.ReleasedID.Equals(BSCrafting.BlackSmithCategory[cat].ReleasedID) &&
                        !e.PressedID.Equals(BSCrafting.BlackSmithCategory[cat].PressedID)) continue;

                    GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(BSCrafting.BlackSmithCategory[cat].ReturnValue));
                    GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                    break;
                }
            }
            public static void ClickRepairItem()
            {
                Gump g = MainGump;

                foreach (var e in g.Buttons)
                {
                    if (!e.ReturnValue.Equals(BSCrafting.MiscButton[MiscButtons.RepairItem].ReturnValue) && !e.ReleasedID.Equals(BSCrafting.MiscButton[MiscButtons.RepairItem].ReleasedID) &&
                        !e.PressedID.Equals(BSCrafting.MiscButton[MiscButtons.RepairItem].PressedID)) continue;

                    GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(BSCrafting.MiscButton[MiscButtons.RepairItem].ReturnValue));
                    GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                    break;
                }
            }
            public static void ClickMarkItem()
            {
                Gump g = MainGump;

                foreach (var e in g.Buttons)
                {
                    if (!e.ReturnValue.Equals(MiscButton[MiscButtons.MarkItem].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.MarkItem].ReleasedID) &&
                        !e.PressedID.Equals(MiscButton[MiscButtons.MarkItem].PressedID)) continue;

                    GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.MarkItem].ReturnValue));
                    GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                    break;
                }
            }
            public static void ClickEnhanceItem()
            {
                Gump g = MainGump;

                foreach (var e in g.Buttons)
                {
                    if (!e.ReturnValue.Equals(MiscButton[MiscButtons.EnhanceItem].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.EnhanceItem].ReleasedID) &&
                        !e.PressedID.Equals(MiscButton[MiscButtons.EnhanceItem].PressedID)) continue;

                    GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.EnhanceItem].ReturnValue));
                    GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                    break;
                }
            }
            public static void ClickAlterItem()
            {
                Gump g = MainGump;

                foreach (var e in g.Buttons)
                {
                    if (!e.ReturnValue.Equals(MiscButton[MiscButtons.AlterItem].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.AlterItem].ReleasedID) &&
                        !e.PressedID.Equals(MiscButton[MiscButtons.AlterItem].PressedID)) continue;

                    GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.AlterItem].ReturnValue));
                    GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                    break;
                }
            }
            public static void ClickNonQuestItem()
            {
                Gump g = MainGump;

                foreach (var e in g.Buttons)
                {
                    if (!e.ReturnValue.Equals(MiscButton[MiscButtons.NonQuestItem].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.NonQuestItem].ReleasedID) &&
                        !e.PressedID.Equals(MiscButton[MiscButtons.NonQuestItem].PressedID)) continue;

                    GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.NonQuestItem].ReturnValue));
                    GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                    break;
                }
            }
            public static void ClickMakeLast()
            {
                Gump g = MainGump;

                foreach (var e in g.Buttons)
                {
                    if (!e.ReturnValue.Equals(MiscButton[MiscButtons.MakeLast].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.MakeLast].ReleasedID) &&
                        !e.PressedID.Equals(MiscButton[MiscButtons.MakeLast].PressedID)) continue;

                    GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.MakeLast].ReturnValue));
                    GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                    break;
                }
            }
            public static void ClickSmeltItem()
            {
                Gump g = MainGump;

                foreach (var e in g.Buttons)
                {
                    if (!e.ReturnValue.Equals(MiscButton[MiscButtons.SmeltItem].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.SmeltItem].ReleasedID) &&
                        !e.PressedID.Equals(MiscButton[MiscButtons.SmeltItem].PressedID)) continue;

                    GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.SmeltItem].ReturnValue));
                    GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                    break;
                }
            }
            public static void ClickCraftResource()
            {
                Gump g = MainGump;

                foreach (var e in g.Buttons)
                {
                    if (!e.ReturnValue.Equals(MiscButton[MiscButtons.CraftResource].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.CraftResource].ReleasedID) &&
                        !e.PressedID.Equals(MiscButton[MiscButtons.CraftResource].PressedID)) continue;

                    GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.CraftResource].ReturnValue));
                    GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                    break;
                }
            }
            public static void ClickScales()
            {
                Gump g = MainGump;

                foreach (var e in g.Buttons)
                {
                    if (!e.ReturnValue.Equals(MiscButton[MiscButtons.Scales].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.Scales].ReleasedID) &&
                        !e.PressedID.Equals(MiscButton[MiscButtons.Scales].PressedID)) continue;

                    GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.Scales].ReturnValue));
                    GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                    break;
                }
            }
        }
    }
    
}

