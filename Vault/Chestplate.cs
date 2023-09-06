using Gui;
using Items;
using UnityEngine;

public static class Chestplates
{
    public const int Count = 13;
    public const string ItemType = "Chestplate";

    public enum ChestplateName
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

    public static string ChestplateID(ChestplateName chestplateName)
    {
        return $"{ItemType}_{chestplateName}";
    }

    public static Armor.Armor_Data GetData(ChestplateName chestplate)
    {
        switch (chestplate)
        {
            case ChestplateName.Leñador:
                return new Armor.Armor_Data
                {
                    itemID = ChestplateID(ChestplateName.Leñador),
                    itemName = Language.GetText(Language.Text.Chestplate_NameLeñador),
                    description = Language.GetText(Language.Text.Chestplate_DescLeñador),
                    price = 50,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 1,
                    sprite = Resources.Load<Sprite>("Items/Chestplates/Leñador"),
                    spriteBack = Resources.Load<Sprite>("Items/ChestplatesBack/Leñador")
                };
            case ChestplateName.Hierro:
                return new Armor.Armor_Data
                {
                    itemID = ChestplateID(ChestplateName.Hierro),
                    itemName = Language.GetText(Language.Text.Chestplate_NameHierro),
                    description = Language.GetText(Language.Text.Chestplate_DescHierro),
                    price = 100,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 2,
                    sprite = Resources.Load<Sprite>("Items/Chestplates/Hierro"),
                    spriteBack = Resources.Load<Sprite>("Items/ChestplatesBack/Hierro")
                };
            case ChestplateName.Aqua:
                return new Armor.Armor_Data
                {
                    itemID = ChestplateID(ChestplateName.Aqua),
                    itemName = Language.GetText(Language.Text.Chestplate_NameAqua),
                    description = Language.GetText(Language.Text.Chestplate_DescAqua),
                    price = 140,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 3,
                    sprite = Resources.Load<Sprite>("Items/Chestplates/Aqua"),
                    spriteBack = Resources.Load<Sprite>("Items/ChestplatesBack/Aqua")
                };
            case ChestplateName.Mercenario:
                return new Armor.Armor_Data
                {
                    itemID = ChestplateID(ChestplateName.Mercenario),
                    itemName = Language.GetText(Language.Text.Chestplate_NameMercenario),
                    description = Language.GetText(Language.Text.Chestplate_DescMercenario),
                    price = 150,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 3,
                    sprite = Resources.Load<Sprite>("Items/Chestplates/Mercenario"),
                    spriteBack = Resources.Load<Sprite>("Items/ChestplatesBack/Mercenario")
                };
            case ChestplateName.Celestial:
                return new Armor.Armor_Data
                {
                    itemID = ChestplateID(ChestplateName.Celestial),
                    itemName = Language.GetText(Language.Text.Chestplate_NameCelestial),
                    description = Language.GetText(Language.Text.Chestplate_DescCelestial),
                    price = 170,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 3,
                    sprite = Resources.Load<Sprite>("Items/Chestplates/Celestial"),
                    spriteBack = Resources.Load<Sprite>("Items/ChestplatesBack/Celestial")
                };
            case ChestplateName.Demoniaco:
                return new Armor.Armor_Data
                {
                    itemID = ChestplateID(ChestplateName.Demoniaco),
                    itemName = Language.GetText(Language.Text.Chestplate_NameDemoniaco),
                    description = Language.GetText(Language.Text.Chestplate_DescDemoniaco),
                    price = 200,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 4,
                    sprite = Resources.Load<Sprite>("Items/Chestplates/Demoniaco"),
                    spriteBack = Resources.Load<Sprite>("Items/ChestplatesBack/Demoniaco")
                };
            case ChestplateName.Samurai:
                return new Armor.Armor_Data
                {
                    itemID = ChestplateID(ChestplateName.Samurai),
                    itemName = Language.GetText(Language.Text.Chestplate_NameSamurai),
                    description = Language.GetText(Language.Text.Chestplate_DescSamurai),
                    price = 230,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 4,
                    sprite = Resources.Load<Sprite>("Items/Chestplates/Samurai"),
                    spriteBack = Resources.Load<Sprite>("Items/ChestplatesBack/Samurai")
                };
            case ChestplateName.Volcanico:
                return new Armor.Armor_Data
                {
                    itemID = ChestplateID(ChestplateName.Volcanico),
                    itemName = Language.GetText(Language.Text.Chestplate_NameVolcanico),
                    description = Language.GetText(Language.Text.Chestplate_DescVolcanico),
                    price = 300,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 5,
                    sprite = Resources.Load<Sprite>("Items/Chestplates/Volcanico"),
                    spriteBack = Resources.Load<Sprite>("Items/ChestplatesBack/Volcanico")
                };
            case ChestplateName.Cristal:
                return new Armor.Armor_Data
                {
                    itemID = ChestplateID(ChestplateName.Cristal),
                    itemName = Language.GetText(Language.Text.Chestplate_NameCristal),
                    description = Language.GetText(Language.Text.Chestplate_DescCristal),
                    price = 400,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 6,
                    sprite = Resources.Load<Sprite>("Items/Chestplates/Cristal"),
                    spriteBack = Resources.Load<Sprite>("Items/ChestplatesBack/Cristal")
                };
            case ChestplateName.Paladin:
                return new Armor.Armor_Data
                {
                    itemID = ChestplateID(ChestplateName.Paladin),
                    itemName = Language.GetText(Language.Text.Chestplate_NamePaladin),
                    description = Language.GetText(Language.Text.Chestplate_DescPaladin),
                    price = 400,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 6,
                    sprite = Resources.Load<Sprite>("Items/Chestplates/Paladin"),
                    spriteBack = Resources.Load<Sprite>("Items/ChestplatesBack/Paladin")
                };
            case ChestplateName.Hidro:
                return new Armor.Armor_Data
                {
                    itemID = ChestplateID(ChestplateName.Hidro),
                    itemName = Language.GetText(Language.Text.Chestplate_NameHidro),
                    description = Language.GetText(Language.Text.Chestplate_DescHidro),
                    price = -1,
                    starterState = ItemData.ItemState.Locked,
                    resistance = 3,
                    sprite = Resources.Load<Sprite>("Items/Chestplates/Hidro"),
                    spriteBack = Resources.Load<Sprite>("Items/ChestplatesBack/Hidro")
                };
            case ChestplateName.Bosque:
                return new Armor.Armor_Data
                {
                    itemID = ChestplateID(ChestplateName.Bosque),
                    itemName = Language.GetText(Language.Text.Chestplate_NameBosque),
                    description = Language.GetText(Language.Text.Chestplate_DescBosque),
                    price = -1,
                    starterState = ItemData.ItemState.Locked,
                    resistance = 4,
                    sprite = Resources.Load<Sprite>("Items/Chestplates/Bosque"),
                    spriteBack = Resources.Load<Sprite>("Items/ChestplatesBack/Bosque")
                };
            case ChestplateName.RebanadorSlimes:
                return new Armor.Armor_Data
                {
                    itemID = ChestplateID(ChestplateName.RebanadorSlimes),
                    itemName = Language.GetText(Language.Text.Chestplate_NameRebanadorSlimes),
                    description = Language.GetText(Language.Text.Chestplate_DescRebanadorSlimes),
                    price = -1,
                    starterState = ItemData.ItemState.Locked,
                    resistance = 5,
                    sprite = Resources.Load<Sprite>("Items/Chestplates/RebanadorSlimes"),
                    spriteBack = Resources.Load<Sprite>("Items/ChestplatesBack/RebanadorSlimes")
                };
            case ChestplateName.Inferno:
                return new Armor.Armor_Data
                {
                    itemID = ChestplateID(ChestplateName.Inferno),
                    itemName = Language.GetText(Language.Text.Chestplate_NameInferno),
                    description = Language.GetText(Language.Text.Chestplate_DescInferno),
                    price = -1,
                    starterState = ItemData.ItemState.Locked,
                    resistance = 6,
                    sprite = Resources.Load<Sprite>("Items/Chestplates/Inferno"),
                    spriteBack = Resources.Load<Sprite>("Items/ChestplatesBack/Inferno")
                };
            default:
                return null;
        }
    }
}
