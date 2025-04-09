using StealthBridgeSDK.Gumps;
using StealthBridgeSDK.Inventory;
using StealthBridgeSDK.Characters;


namespace StealthBridgeSDK.Crafting
{
    public enum TailorCraftCategory
    {
        LastTen,
        Materials,
        Hats,
        ShirtsandPants,
        Miscellaneous,
        Footwear,
        LeatherArmor,
        ClothArmor,
        StuddedArmor,
        FemaleArmor,
        BoneArmor
    }
    public enum TailorButtons
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
    public enum TailorCraftable
    {
        CutupCloth,
        CombineCloth,
        PowderCharge,
        AbyssalCloth,
        Skullcap,
        Bandana,
        FloppyHat,
        Cap,
        WideBrimHat,
        StrawHat,
        TallStrawHat,
        WizardHat,
        Bonnet,
        FeatheredHat,
        TricorneHat,
        JesterHat,
        FlowerGarland,
        ClothNinjaHood,
        Kasa,
        OrcMask,
        BearMask,
        DeedMask,
        TribalMask,
        ChefsToque,
        KrampusMinionHat,
        AssassinsCowl,
        MageHood,
        CowloftheMaceandShield,
        MagesHoodofScholarlyInsight,
        Doublet,
        Shirt,
        FancyShirt,
        Tunic,
        Surcoat,
        PlainDress,
        FancyDress,
        Cloak,
        Robe,
        JesterSuit,
        FurCape,
        GildedDress,
        FormalShirt,
        ClothNinjaJacket,
        Kamishimo,
        HakamaShita,
        MaleKimono,
        FemaleKimono,
        JinBaori,
        ShortPants,
        LongPants,
        Kilt,
        Skirt,
        FurSarong,
        Hakama,
        TattsukeHakama,
        ElvenShirt,
        ElvenPants,
        ElvenRobe,
        FemaleElvenRobe,
        WoodlandBelt,
        GargishRobe,
        GargishFancyRobe,
        RobeofRite,
        GildedKilt,
        CheckeredKilt,
        FancyKilt,
        FloweredDress,
        EveningGown,
        BodySash,
        HalfApron,
        FullApron,
        Obi,
        ElvenQuiver,
        QuiverofFire,
        QuiverofIce,
        QuiverofBlight,
        QuiverofLightning,
        LeatherArmorEngravingTool,
        GargishHalFApron,
        GargishSash,
        OilCloth,
        GozaEast,
        GozaSouth,
        SquareGozaEast,
        SquareGozaSouth,
        BrocadeGozaEast,
        BrocadeGozaSouth,
        SquareBrocadeGozaEast,
        SquareBrocadeGozaSouth,
        SquareGoza,
        MaceBelt,
        SwordBelt,
        DaggerBelt,
        ElegantCollar,
        CrimsonMaceBelt,
        CrimsonSwordBelt,
        CrimsonDaggerBelt,
        ElegantCollarofFortune,
        ElvenBoots,
        FurBoots,
        NinjaTabi,
        WarajiandTabi,
        Sandals,
        Shoes,
        Boots,
        ThighBoots,
        GargishLeatherTalons,
        JesterShoes,
        KrampusMinionBoots,
        KrampusMinionTalons,
        SpellWovenBritches,
        SongWovenMantle,
        StitchersMittens,
        LeatherGorget,
        LeatherCap,
        LeatherGloves,
        LeatherSleeves,
        LeatherLeggings,
        LeatherTunic,
        LeatherJingasa,
        LeatherMempo,
        LeatherDo,
        LeatherHiroSode,
        LeatherSuneate,
        LeatherHaidate,
        LeatherNinjaPants,
        LeatherNinjaJacket,
        LeatherNinjaBelt,
        LeatherNinjaMitts,
        LeatherNinjaHood,
        LeafTunic,
        LeafArms,
        LeafGloves,
        LeafLeggings,
        LeafGorget,
        LeafTonlet,
        GargishLeatherArms,
        GargishLeatherChest,
        GargishLeatherLeggings,
        GargishLeatherkilt,
        GargishLeatherWingArmor,
        TigerPeltChest,
        TigerPeltLeggings,
        TigerPeltShorts,
        TigerPeltHelm,
        TigerPetCollar,
        DragonTurtuleHideChest,
        DragonTurtuleHideLeggings,
        DragonTurtuleHideHelm,
        DragonTurtuleHideArms,
        GargishClothArms,
        GargishClothChest,
        GargishClothLeggings,
        GargishClothKilt,
        GargishWingArmor,
        StuddedGorget,
        StuddedGloves,
        StuddedSleeves,
        StuddedLeggings,
        StuddedTunic,
        StuddedMempo,
        StuddedDo,
        StuddedHiroSode,
        StuddedSuneate,
        StuddedHaidate,
        HideTunic,
        HidePauldrons,
        HideGloves,
        HidePants,
        HideGorget,
        LeatherShorts,
        LeatherSkirt,
        LeatherBustier,
        FemaleLeatherArmor,
        StuddedArmor,
        TigerPeltBustier,
        TigerPeltLongSkirt,
        TigerPeltSkirt,
        DragonTurtuleHideBustier,
        BoneHelmet,
        BoneGloves,
        BoneArms,
        BoneLeggings,
        BoneArmor,
        OrcHelm,
        CuffsoftheArchmage

    }
    public class TailorCrafting
    {
        public static uint GetTool(uint tooltype)
        { 
            return Inventories.FindType(tooltype,Character.Backpack());
        }
        public static readonly Dictionary<TailorCraftCategory, (int ReturnValue, int PressedID, int ReleasedID)> TailorCategory = new()
        {      
            {TailorCraftCategory.LastTen,(28,4007,4005) },
            {TailorCraftCategory.Materials,(1,4007,4005) },
            {TailorCraftCategory.Hats,(8,4007,4005) },
            {TailorCraftCategory.ShirtsandPants,(15,4007,4005) },
            {TailorCraftCategory.Miscellaneous,(22,4007,4005) },
            {TailorCraftCategory.Footwear,(29,4007,4005) },
            {TailorCraftCategory.LeatherArmor,(36,4007,4005) },
            {TailorCraftCategory.ClothArmor,(43,4007,4005) },
            {TailorCraftCategory.StuddedArmor,(50,4007,4005) },
            {TailorCraftCategory.FemaleArmor,(57,4007,4005) },
            {TailorCraftCategory.BoneArmor,(64,4007,4005) }
        };
        public static readonly Dictionary<MiscButtons, (int ReturnValue, int PressedID, int ReleasedID)> MiscButton = new()
        {

            {MiscButtons.CraftResource,(14,4007,4005) },
            {MiscButtons.Exit,(0,4019,4017) },
            {MiscButtons.CancelMake,(84,4019,4017) },
            {MiscButtons.RepairItem,(42,4007,4005) },
            {MiscButtons.MarkItem,(49,4007,4005) },
            {MiscButtons.EnhanceItem,(63,4007,4005) },
            {MiscButtons.AlterItem,(70,4007,4005) },
            {MiscButtons.NonQuestItem,(77,4007,4005) },
            {MiscButtons.MakeLast,(21,4007,4005) }
        };
        public static readonly Dictionary<TailorCraftable, (int ReturnValue, int PressedID, int ReleasedID, TailorCraftCategory CraftCategory)> CraftButton = new()
        {
            {TailorCraftable.CutupCloth,(2,4007,4005,TailorCraftCategory.Materials)},
            {TailorCraftable.CombineCloth,(9,4007,4005,TailorCraftCategory.Materials)},
            {TailorCraftable.PowderCharge,(16,4007,4005,TailorCraftCategory.Materials)},
            {TailorCraftable.AbyssalCloth,(23,4007,4005,TailorCraftCategory.Materials)},
            {TailorCraftable.Skullcap,(2,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.Bandana,(9,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.FloppyHat,(16,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.Cap,(23,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.WideBrimHat,(30,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.StrawHat,(37,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.TallStrawHat,(44,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.WizardHat,(51,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.Bonnet,(58,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.FeatheredHat,(65,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.TricorneHat,(72,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.JesterHat,(79,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.FlowerGarland,(86,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.ClothNinjaHood,(93,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.Kasa,(100,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.OrcMask,(107,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.BearMask,(114,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.DeedMask,(121,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.TribalMask,(128,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.ChefsToque,(135,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.KrampusMinionHat,(142,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.AssassinsCowl,(149,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.MageHood,(156,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.CowloftheMaceandShield,(163,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.MagesHoodofScholarlyInsight,(170,4007,4005,TailorCraftCategory.Hats)},
            {TailorCraftable.Doublet,(2,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.Shirt,(9,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.FancyShirt,(16,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.Tunic,(23,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.Surcoat,(30,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.PlainDress,(37,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.FancyDress,(44,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.Cloak,(51,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.Robe,(58,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.JesterSuit,(65,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.FurCape,(72,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.GildedDress,(79,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.FormalShirt,(86,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.ClothNinjaJacket,(93,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.Kamishimo,(100,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.HakamaShita,(107,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.MaleKimono,(114,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.FemaleKimono,(121,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.JinBaori,(128,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.ShortPants,(135,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.LongPants,(142,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.Kilt,(149,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.Skirt,(156,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.FurSarong,(163,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.Hakama,(170,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.TattsukeHakama,(177,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.ElvenShirt,(191,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.ElvenRobe,(198,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.FemaleElvenRobe,(205,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.WoodlandBelt,(212,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.GargishRobe,(219,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.GargishFancyRobe,(226,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.RobeofRite,(233,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.GildedKilt,(240,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.CheckeredKilt,(247,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.FancyKilt,(254,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.FloweredDress,(261,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.EveningGown,(268,4007,4005,TailorCraftCategory.ShirtsandPants)},
            {TailorCraftable.BodySash,(2,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.HalfApron,(9,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.FullApron,(16,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.Obi,(23,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.ElvenQuiver,(30,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.QuiverofFire,(37,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.QuiverofIce,(44,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.QuiverofBlight,(51,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.QuiverofLightning,(58,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.LeatherArmorEngravingTool,(65,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.GargishHalFApron,(72,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.GargishSash,(79,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.OilCloth,(86,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.GozaEast,(93,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.GozaSouth,(100,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.SquareGozaEast,(107,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.SquareGozaSouth,(114,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.BrocadeGozaEast,(121,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.BrocadeGozaSouth,(128,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.SquareBrocadeGozaEast,(135,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.SquareBrocadeGozaSouth,(142,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.SquareGoza,(149,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.MaceBelt,(156,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.SwordBelt,(163,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.DaggerBelt,(170,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.ElegantCollar,(177,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.CrimsonMaceBelt,(191,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.CrimsonSwordBelt,(198,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.CrimsonDaggerBelt,(205,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.ElegantCollarofFortune,(212,4007,4005,TailorCraftCategory.Miscellaneous)},
            {TailorCraftable.ElvenBoots,(2,4007,4005,TailorCraftCategory.Footwear)},
            {TailorCraftable.FurBoots,(9,4007,4005,TailorCraftCategory.Footwear)},
            {TailorCraftable.NinjaTabi,(16,4007,4005,TailorCraftCategory.Footwear)},
            {TailorCraftable.WarajiandTabi,(23,4007,4005,TailorCraftCategory.Footwear)},
            {TailorCraftable.Sandals,(30,4007,4005,TailorCraftCategory.Footwear)},
            {TailorCraftable.Shoes,(37,4007,4005,TailorCraftCategory.Footwear)},
            {TailorCraftable.Boots,(44,4007,4005,TailorCraftCategory.Footwear)},
            {TailorCraftable.ThighBoots,(51,4007,4005,TailorCraftCategory.Footwear)},
            {TailorCraftable.GargishLeatherTalons,(58,4007,4005,TailorCraftCategory.Footwear)},
            {TailorCraftable.JesterShoes,(65,4007,4005,TailorCraftCategory.Footwear)},
            {TailorCraftable.KrampusMinionBoots,(72,4007,4005,TailorCraftCategory.Footwear)},
            {TailorCraftable.KrampusMinionTalons,(79,4007,4005,TailorCraftCategory.Footwear)},
            {TailorCraftable.SpellWovenBritches,(2,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.SongWovenMantle,(9,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.StitchersMittens,(16,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeatherGorget,(23,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeatherCap,(30,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeatherGloves,(37,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeatherSleeves,(44,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeatherLeggings,(51,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeatherTunic,(58,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeatherJingasa,(65,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeatherMempo,(72,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeatherDo,(79,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeatherHiroSode,(86,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeatherSuneate,(93,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeatherHaidate,(100,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeatherNinjaPants,(107,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeatherNinjaJacket,(114,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeatherNinjaBelt,(121,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeatherNinjaMitts,(128,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeatherNinjaHood,(135,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeafTunic,(142,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeafArms,(149,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeafGloves,(156,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeafLeggings,(163,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeafGorget,(170,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.LeafTonlet,(177,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.GargishLeatherArms,(184,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.GargishLeatherChest,(191,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.GargishLeatherLeggings,(198,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.GargishLeatherkilt,(205,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.GargishLeatherWingArmor,(240,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.TigerPeltChest,(247,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.TigerPeltLeggings,(254,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.TigerPeltShorts,(261,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.TigerPeltHelm,(268,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.TigerPetCollar,(275,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.DragonTurtuleHideChest,(282,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.DragonTurtuleHideLeggings,(289,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.DragonTurtuleHideHelm,(296,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.DragonTurtuleHideArms,(303,4007,4005,TailorCraftCategory.LeatherArmor)},
            {TailorCraftable.GargishClothArms,(30,4007,4005,TailorCraftCategory.ClothArmor)},
            {TailorCraftable.GargishClothChest,(37,4007,4005,TailorCraftCategory.ClothArmor)},
            {TailorCraftable.GargishClothLeggings,(44,4007,4005,TailorCraftCategory.ClothArmor)},
            {TailorCraftable.GargishClothKilt,(51,4007,4005,TailorCraftCategory.ClothArmor)},
            {TailorCraftable.GargishWingArmor,(58,4007,4005,TailorCraftCategory.ClothArmor)},
            {TailorCraftable.StuddedGorget,(2,4007,4005,TailorCraftCategory.StuddedArmor)},
            {TailorCraftable.StuddedGloves,(9,4007,4005,TailorCraftCategory.StuddedArmor)},
            {TailorCraftable.StuddedSleeves,(16,4007,4005,TailorCraftCategory.StuddedArmor)},
            {TailorCraftable.StuddedLeggings,(23,4007,4005,TailorCraftCategory.StuddedArmor)},
            {TailorCraftable.StuddedTunic,(30,4007,4005,TailorCraftCategory.StuddedArmor)},
            {TailorCraftable.StuddedMempo,(37,4007,4005,TailorCraftCategory.StuddedArmor)},
            {TailorCraftable.StuddedDo,(44,4007,4005,TailorCraftCategory.StuddedArmor)},
            {TailorCraftable.StuddedHiroSode,(51,4007,4005,TailorCraftCategory.StuddedArmor)},
            {TailorCraftable.StuddedSuneate,(58,4007,4005,TailorCraftCategory.StuddedArmor)},
            {TailorCraftable.StuddedHaidate,(65,4007,4005,TailorCraftCategory.StuddedArmor)},
            {TailorCraftable.HideTunic,(72,4007,4005,TailorCraftCategory.StuddedArmor)},
            {TailorCraftable.HidePauldrons,(79,4007,4005,TailorCraftCategory.StuddedArmor)},
            {TailorCraftable.HideGloves,(86,4007,4005,TailorCraftCategory.StuddedArmor)},
            {TailorCraftable.HidePants,(93,4007,4005,TailorCraftCategory.StuddedArmor)},
            {TailorCraftable.HideGorget,(100,4007,4005,TailorCraftCategory.StuddedArmor)},
            {TailorCraftable.LeatherShorts,(2,4007,4005,TailorCraftCategory.FemaleArmor)},
            {TailorCraftable.LeatherSkirt,(9,4007,4005,TailorCraftCategory.FemaleArmor)},
            {TailorCraftable.LeatherBustier,(16,4007,4005,TailorCraftCategory.FemaleArmor)},
            {TailorCraftable.FemaleLeatherArmor,(23,4007,4005,TailorCraftCategory.FemaleArmor)},
            {TailorCraftable.StuddedArmor,(30,4007,4005,TailorCraftCategory.FemaleArmor)},
            {TailorCraftable.TigerPeltBustier,(37,4007,4005,TailorCraftCategory.FemaleArmor)},
            {TailorCraftable.TigerPeltLongSkirt,(44,4007,4005,TailorCraftCategory.FemaleArmor)},
            {TailorCraftable.TigerPeltSkirt,(51,4007,4005,TailorCraftCategory.FemaleArmor)},
            {TailorCraftable.DragonTurtuleHideBustier,(58,4007,4005,TailorCraftCategory.FemaleArmor)},
            {TailorCraftable.BoneHelmet,(2,4007,4005,TailorCraftCategory.BoneArmor)},
            {TailorCraftable.BoneGloves,(9,4007,4005,TailorCraftCategory.BoneArmor)},
            {TailorCraftable.BoneArms,(16,4007,4005,TailorCraftCategory.BoneArmor)},
            {TailorCraftable.BoneLeggings,(23,4007,4005,TailorCraftCategory.BoneArmor)},
            {TailorCraftable.BoneArmor,(30,4007,4005,TailorCraftCategory.BoneArmor)},
            {TailorCraftable.OrcHelm,(37,4007,4005,TailorCraftCategory.BoneArmor)},
            {TailorCraftable.CuffsoftheArchmage,(44,4007,4005,TailorCraftCategory.BoneArmor)},
        };
        public class TailorCraftGump
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
            public static void Craft(TailorCraftable craft)
            {
                if (!Initialized) Initialize();
                Gump g = MainGump;
                if (g == null) { Logger.Warn($"Craft Gump came Back Null"); return; }
                ClickCategory(CraftButton[craft].CraftCategory);
                Thread.Sleep(1000); // Wait for the category to load
                foreach (var e in g.Buttons)
                {
                    if (e.ReturnValue == CraftButton[craft].ReturnValue && e.ReleasedID == CraftButton[craft].ReleasedID &&
                        e.PressedID == CraftButton[craft].PressedID)
                    {
                        GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(CraftButton[craft].ReturnValue));
                        Logger.Info($"The Item Return Value is {Button.ReturnValue}");
                        GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            public static void ClickCategory(TailorCraftCategory cat)
            {
                if (!Initialized) Initialize();
                Gump g = MainGump;

                foreach (var e in g.Buttons)
                {
                    if (e.ReturnValue == TailorCategory[cat].ReturnValue && e.ReleasedID == TailorCategory[cat].ReleasedID &&
                        e.PressedID == TailorCategory[cat].PressedID)
                    {
                        GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(TailorCategory[cat].ReturnValue));
                        Logger.Info($"The Category Return Value is {Button.ReturnValue}");
                        GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                        break;
                    }

                    else
                    {
                        continue;
                    }
                }
            }
            public static void ClickRepairItem()
            {
                if (!Initialized) Initialize();
                Gump g = MainGump;

                foreach (var e in g.Buttons)
                {
                    if (!e.ReturnValue.Equals(MiscButton[MiscButtons.RepairItem].ReturnValue) && !e.ReleasedID.Equals(MiscButton[MiscButtons.RepairItem].ReleasedID) &&
                        !e.PressedID.Equals(MiscButton[MiscButtons.RepairItem].PressedID)) continue;

                    GumpButton Button = g.Buttons.First(i => i.ReturnValue.Equals(MiscButton[MiscButtons.RepairItem].ReturnValue));
                    GumpWrapper.PressButton(g.GumpIndex, Button.ReturnValue);
                    break;
                }
            }
            public static void ClickMarkItem()
            {
                if (!Initialized) Initialize();
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
                if (!Initialized) Initialize();
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
                if (!Initialized) Initialize();
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
                if (!Initialized) Initialize();
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
                if (!Initialized) Initialize();
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
            
            public static void ClickCraftResource() 
            {
                if (!Initialized) Initialize();
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
        }
    }
}
