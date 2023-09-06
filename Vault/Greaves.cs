using Items;
using UnityEngine;

public static class Greaves
{
    public const int Count = 4;
    public const string ItemType = "Greaves";

    public enum GreaveName
    {
        Inicial,
        Leñador,
        Carmesi,
        Mercenario,
        Acorazado

    }

    public static Armor.Armor_Data GetData(GreaveName greave)
    {
        switch (greave)
        {
            case GreaveName.Inicial:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{GreaveName.Inicial}",
                    itemName = Language.GetText(Language.Text.Greave_NameInicial),
                    description = Language.GetText(Language.Text.Greave_DescInicial),
                    price = 5,
                    starterState = ItemData.ItemState.Equipped,
                    resistance = 0,
                    sprite = Resources.Load<Sprite>("Items/Greaves/Inicial"),
                    spriteBack = Resources.Load<Sprite>("Items/GreavesBack/Inicial")
                };
            case GreaveName.Leñador:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{GreaveName.Leñador}",
                    itemName = Language.GetText(Language.Text.Greave_NameLeñador),
                    description = Language.GetText(Language.Text.Greave_DescLeñador),
                    price = 50,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 1,
                    sprite = Resources.Load<Sprite>("Items/Greaves/Leñador"),
                    spriteBack = Resources.Load<Sprite>("Items/GreavesBack/Leñador")
                };
            case GreaveName.Carmesi:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{GreaveName.Carmesi}",
                    itemName = Language.GetText(Language.Text.Greave_NameCarmesi),
                    description = Language.GetText(Language.Text.Greave_DescCarmesi),
                    price = 50,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 1,
                    sprite = Resources.Load<Sprite>("Items/Greaves/Carmesi"),
                    spriteBack = Resources.Load<Sprite>("Items/GreavesBack/Carmesi")
                };
            case GreaveName.Mercenario:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{GreaveName.Mercenario}",
                    itemName = Language.GetText(Language.Text.Greave_NameMercenario),
                    description = Language.GetText(Language.Text.Greave_DescMercenario),
                    price = 100,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 2,
                    sprite = Resources.Load<Sprite>("Items/Greaves/Mercenario"),
                    spriteBack = Resources.Load<Sprite>("Items/GreavesBack/Mercenario")
                };
            case GreaveName.Acorazado:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{GreaveName.Acorazado}",
                    itemName = Language.GetText(Language.Text.Greave_NameAcorazado),
                    description = Language.GetText(Language.Text.Greave_DescAcorazado),
                    price = 150,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 3,
                    sprite = Resources.Load<Sprite>("Items/Greaves/Acorazado"),
                    spriteBack = Resources.Load<Sprite>("Items/GreavesBack/Acorazado")
                };
            default:
                return null;
        }
    }
}
