using Items;
using UnityEngine;

public static class Shirts
{
    public const int Count = 7;
    public const string ItemType = "Shirt";

    public enum ShirtName
    {
        Inicial,
        Campesino,
        MangasCortas,
        Chaleco,
        CuelloAlto,
        JubonCamisa,
        Leñador,
        Mercenario

    }

    public static Armor.Armor_Data GetData(ShirtName shirt)
    {
        switch (shirt)
        {
            case ShirtName.Campesino:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{ShirtName.Campesino}",
                    itemName = Language.GetText(Language.Text.Shirt_NameCampesino),
                    description = Language.GetText(Language.Text.Shirt_DescCampesino),
                    price = 20,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 0,
                    sprite = Resources.Load<Sprite>("Items/Shirts/Campesino"),
                    spriteBack = Resources.Load<Sprite>("Items/ShirtsBack/Campesino")
                };
            case ShirtName.Chaleco:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{ShirtName.Chaleco}",
                    itemName = Language.GetText(Language.Text.Shirt_NameChaleco),
                    description = Language.GetText(Language.Text.Shirt_DescChaleco),
                    price = 50,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 1,
                    sprite = Resources.Load<Sprite>("Items/Shirts/Chaleco"),
                    spriteBack = Resources.Load<Sprite>("Items/ShirtsBack/Chaleco")
                };
            case ShirtName.CuelloAlto:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{ShirtName.CuelloAlto}",
                    itemName = Language.GetText(Language.Text.Shirt_NameCuelloAlto),
                    description = Language.GetText(Language.Text.Shirt_DescCuelloAlto),
                    price = 50,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 2,
                    sprite = Resources.Load<Sprite>("Items/Shirts/CuelloAlto"),
                    spriteBack = Resources.Load<Sprite>("Items/ShirtsBack/CuelloAlto")
                };
            case ShirtName.Inicial:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{ShirtName.Inicial}",
                    itemName = Language.GetText(Language.Text.Shirt_NameInicial),
                    description = Language.GetText(Language.Text.Shirt_DescInicial),
                    price = 5,
                    starterState = ItemData.ItemState.Equipped,
                    resistance = 0,
                    sprite = Resources.Load<Sprite>("Items/Shirts/Inicial"),
                    spriteBack = Resources.Load<Sprite>("Items/ShirtsBack/Inicial")
                };
            case ShirtName.JubonCamisa:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{ShirtName.JubonCamisa}",
                    itemName = Language.GetText(Language.Text.Shirt_NameJubonCamisa),
                    description = Language.GetText(Language.Text.Shirt_DescJubonCamisa),
                    price = 70,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 2,
                    sprite = Resources.Load<Sprite>("Items/Shirts/JubonCamisa"),
                    spriteBack = Resources.Load<Sprite>("Items/ShirtsBack/JubonCamisa")
                };
            case ShirtName.Leñador:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{ShirtName.Leñador}",
                    itemName = Language.GetText(Language.Text.Shirt_NameLeñador),
                    description = Language.GetText(Language.Text.Shirt_DescLeñador),
                    price = 100,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 3,
                    sprite = Resources.Load<Sprite>("Items/Shirts/Leñador"),
                    spriteBack = Resources.Load<Sprite>("Items/ShirtsBack/Leñador")
                };
            case ShirtName.MangasCortas:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{ShirtName.MangasCortas}",
                    itemName = Language.GetText(Language.Text.Shirt_NameMangasCortas),
                    description = Language.GetText(Language.Text.Shirt_DescMangasCortas),
                    price = 30,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 1,
                    sprite = Resources.Load<Sprite>("Items/Shirts/MangasCortas"),
                    spriteBack = Resources.Load<Sprite>("Items/ShirtsBack/MangasCortas")
                };
            case ShirtName.Mercenario:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{ShirtName.Mercenario}",
                    itemName = Language.GetText(Language.Text.Shirt_NameMercenario),
                    description = Language.GetText(Language.Text.Shirt_DescMercenario),
                    price = 100,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 3,
                    sprite = Resources.Load<Sprite>("Items/Shirts/Mercenario"),
                    spriteBack = Resources.Load<Sprite>("Items/ShirtsBack/Mercenario")
                };
            default:
                return null;
        }
    }
}
