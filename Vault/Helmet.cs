using Gui;
using Items;
using UnityEngine;

public static class Helmets
{
    public const int Count = 13;
    public const string ItemType = "Helmet";

    public enum HelmetName
    {
        Leñador,
        Hierro,
        Aqua,
        Mercenario,
        Celestial,
        Demoniaco,
        Samurai,
        Volcanico,
        Cristal,
        Paladin,
        Hidro,
        Bosque,
        RebanadorSlimes,
        Inferno
    }

    public static string HelmetID(HelmetName helmetName)
    {
        return $"{ItemType}_{helmetName}";
    }

    public static Armor.Armor_Data GetData(HelmetName helmet)
    {
        switch (helmet)
        {
            case HelmetName.Leñador:
                return new Armor.Armor_Data
                {
                    itemID = HelmetID(HelmetName.Leñador),
                    itemName = Language.GetText(Language.Text.Helmet_NameLeñador),
                    description = Language.GetText(Language.Text.Helmet_DescLeñador),
                    price = 50,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 1,
                    sprite = Resources.Load<Sprite>("Items/Helmets/Leñador"),
                    spriteBack = Resources.Load<Sprite>("Items/HelmetsBack/Leñador")
                };
            case HelmetName.Hierro:
                return new Armor.Armor_Data
                {
                    itemID = HelmetID(HelmetName.Hierro),
                    itemName = Language.GetText(Language.Text.Helmet_NameHierro),
                    description = Language.GetText(Language.Text.Helmet_DescHierro),
                    price = 100,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 2,
                    sprite = Resources.Load<Sprite>("Items/Helmets/Hierro"),
                    spriteBack = Resources.Load<Sprite>("Items/HelmetsBack/Hierro")
                };
            case HelmetName.Aqua:
                return new Armor.Armor_Data
                {
                    itemID = HelmetID(HelmetName.Aqua),
                    itemName = Language.GetText(Language.Text.Helmet_NameAqua),
                    description = Language.GetText(Language.Text.Helmet_DescAqua),
                    price = 140,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 3,
                    sprite = Resources.Load<Sprite>("Items/Helmets/Aqua"),
                    spriteBack = Resources.Load<Sprite>("Items/HelmetsBack/Aqua")
                };
            case HelmetName.Mercenario:
                return new Armor.Armor_Data
                {
                    itemID = HelmetID(HelmetName.Mercenario),
                    itemName = Language.GetText(Language.Text.Helmet_NameMercenario),
                    description = Language.GetText(Language.Text.Helmet_DescMercenario),
                    price = 150,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 3,
                    sprite = Resources.Load<Sprite>("Items/Helmets/Mercenario"),
                    sprite2 = Resources.Load<Sprite>("Items/Helmets/Mercenario2"),
                    spriteBack = Resources.Load<Sprite>("Items/HelmetsBack/Mercenario"),
                    sprite2Back = Resources.Load<Sprite>("Items/HelmetsBack/Mercenario2")
                };
            case HelmetName.Celestial:
                return new Armor.Armor_Data
                {
                    itemID = HelmetID(HelmetName.Celestial),
                    itemName = Language.GetText(Language.Text.Helmet_NameCelestial),
                    description = Language.GetText(Language.Text.Helmet_DescCelestial),
                    price = 170,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 3,
                    sprite = Resources.Load<Sprite>("Items/Helmets/Celestial"),
                    spriteBack = Resources.Load<Sprite>("Items/HelmetsBack/Celestial")
                };
            case HelmetName.Demoniaco:
                return new Armor.Armor_Data
                {
                    itemID = HelmetID(HelmetName.Leñador),
                    itemName = Language.GetText(Language.Text.Helmet_NameDemoniaco),
                    description = Language.GetText(Language.Text.Helmet_DescDemoniaco),
                    price = 200,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 4,
                    sprite = Resources.Load<Sprite>("Items/Helmets/Demoniaco"),
                    spriteBack = Resources.Load<Sprite>("Items/HelmetsBack/Demoniaco")
                };
            case HelmetName.Samurai:
                return new Armor.Armor_Data
                {
                    itemID = HelmetID(HelmetName.Samurai),
                    itemName = Language.GetText(Language.Text.Helmet_NameSamurai),
                    description = Language.GetText(Language.Text.Helmet_DescSamurai),
                    price = 230,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 4,
                    sprite = Resources.Load<Sprite>("Items/Helmets/Samurai"),
                    sprite2 = Resources.Load<Sprite>("Items/Helmets/Samurai2"),
                    spriteBack = Resources.Load<Sprite>("Items/HelmetsBack/Samurai"),
                    sprite2Back = Resources.Load<Sprite>("Items/HelmetsBack/Samurai2")
                };
            case HelmetName.Volcanico:
                return new Armor.Armor_Data
                {
                    itemID = HelmetID(HelmetName.Volcanico),
                    itemName = Language.GetText(Language.Text.Helmet_NameVolcanico),
                    description = Language.GetText(Language.Text.Helmet_DescVolcanico),
                    price = 300,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 5,
                    sprite = Resources.Load<Sprite>("Items/Helmets/Volcanico"),
                    spriteBack = Resources.Load<Sprite>("Items/HelmetsBack/Volcanico")
                };
            case HelmetName.Cristal:
                return new Armor.Armor_Data
                {
                    itemID = HelmetID(HelmetName.Cristal),
                    itemName = Language.GetText(Language.Text.Helmet_NameCristal),
                    description = Language.GetText(Language.Text.Helmet_DescCristal),
                    price = 400,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 6,
                    sprite = Resources.Load<Sprite>("Items/Helmets/Cristal"),
                    sprite2 = Resources.Load<Sprite>("Items/Helmets/Cristal2"),
                    spriteBack = Resources.Load<Sprite>("Items/HelmetsBack/Cristal"),
                    sprite2Back = Resources.Load<Sprite>("Items/HelmetsBack/Cristal2")
                };
            case HelmetName.Paladin:
                return new Armor.Armor_Data
                {
                    itemID = HelmetID(HelmetName.Paladin),
                    itemName = Language.GetText(Language.Text.Helmet_NamePaladin),
                    description = Language.GetText(Language.Text.Helmet_DescPaladin),
                    price = 400,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 6,
                    sprite = Resources.Load<Sprite>("Items/Helmets/Paladin"),
                    spriteBack = Resources.Load<Sprite>("Items/HelmetsBack/Paladin")
                };
            case HelmetName.Hidro:
                return new Armor.Armor_Data
                {
                    itemID = HelmetID(HelmetName.Hidro),
                    itemName = Language.GetText(Language.Text.Helmet_NameHidro),
                    description = Language.GetText(Language.Text.Helmet_DescHidro),
                    price = -1,
                    starterState = ItemData.ItemState.Locked,
                    resistance = 3,
                    sprite = Resources.Load<Sprite>("Items/Helmets/Hidro"),
                    sprite2 = Resources.Load<Sprite>("Items/Helmets/Hidro2"),
                    spriteBack = Resources.Load<Sprite>("Items/HelmetsBack/Hidro"),
                    sprite2Back = Resources.Load<Sprite>("Items/HelmetsBack/Hidro2")
                };
            case HelmetName.Bosque:
                return new Armor.Armor_Data
                {
                    itemID = HelmetID(HelmetName.Bosque),
                    itemName = Language.GetText(Language.Text.Helmet_NameBosque),
                    description = Language.GetText(Language.Text.Helmet_DescBosque),
                    price = -1,
                    starterState = ItemData.ItemState.Locked,
                    resistance = 4,
                    sprite = Resources.Load<Sprite>("Items/Helmets/Bosque"),
                    spriteBack = Resources.Load<Sprite>("Items/HelmetsBack/Bosque")
                };
            case HelmetName.RebanadorSlimes:
                return new Armor.Armor_Data
                {
                    itemID = HelmetID(HelmetName.RebanadorSlimes),
                    itemName = Language.GetText(Language.Text.Helmet_NameRebanadorSlimes),
                    description = Language.GetText(Language.Text.Helmet_DescRebanadorSlimes),
                    price = -1,
                    starterState = ItemData.ItemState.Locked,
                    resistance = 5,
                    sprite = Resources.Load<Sprite>("Items/Helmets/RebanadorSlimes"),
                    sprite2 = Resources.Load<Sprite>("Items/Helmets/RebanadorSlimes2"),
                    spriteBack = Resources.Load<Sprite>("Items/HelmetsBack/RebanadorSlimes"),
                    sprite2Back = Resources.Load<Sprite>("Items/HelmetsBack/RebanadorSlimes2")
                };
            case HelmetName.Inferno:
                return new Armor.Armor_Data
                {
                    itemID = HelmetID(HelmetName.Inferno),
                    itemName = Language.GetText(Language.Text.Helmet_NameInferno),
                    description = Language.GetText(Language.Text.Helmet_DescInferno),
                    price = -1,
                    starterState = ItemData.ItemState.Locked,
                    resistance = 6,
                    sprite = Resources.Load<Sprite>("Items/Helmets/Inferno"),
                    sprite2 = Resources.Load<Sprite>("Items/Helmets/Inferno2"),
                    spriteBack = Resources.Load<Sprite>("Items/HelmetsBack/Inferno"),
                    sprite2Back = Resources.Load<Sprite>("Items/HelmetsBack/Inferno2")
                };
            default:
                return null;
        }
    }
}
