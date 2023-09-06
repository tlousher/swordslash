using Items;
using UnityEngine;

public static class Boots
{
    public const int Count = 5;
    public const string ItemType = "Boots";

    public enum BootsName
    {
        Inicial,
        Sigilo,
        Leñador,
        Carmesi,
        Mercenario,
        Acorazado
    }

    public static Armor.Armor_Data GetData(BootsName boots)
    {
        switch (boots)
        {
            case BootsName.Inicial:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{BootsName.Inicial}",
                    itemName = Language.GetText(Language.Text.Boots_NameInicial),
                    description = Language.GetText(Language.Text.Boots_DescInicial),
                    price = 5,
                    starterState = ItemData.ItemState.Equipped,
                    resistance = 0,
                    sprite = Resources.Load<Sprite>("Items/Boots/Inicial"),
                    spriteBack = Resources.Load<Sprite>("Items/BootsBack/Inicial")
                };
            case BootsName.Sigilo:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{BootsName.Sigilo}",
                    itemName = Language.GetText(Language.Text.Boots_NameSigilo),
                    description = Language.GetText(Language.Text.Boots_DescSigilo),
                    price = 25,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 0,
                    sprite = Resources.Load<Sprite>("Items/Boots/Sigilo"),
                    spriteBack = Resources.Load<Sprite>("Items/BootsBack/Sigilo")
                };
            case BootsName.Leñador:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{BootsName.Leñador}",
                    itemName = Language.GetText(Language.Text.Boots_NameLeñador),
                    description = Language.GetText(Language.Text.Boots_DescLeñador),
                    price = 50,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 1,
                    sprite = Resources.Load<Sprite>("Items/Boots/Leñador"),
                    spriteBack = Resources.Load<Sprite>("Items/BootsBack/Leñador")
                };
            case BootsName.Carmesi:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{BootsName.Carmesi}",
                    itemName = Language.GetText(Language.Text.Boots_NameCarmesi),
                    description = Language.GetText(Language.Text.Boots_DescCarmesi),
                    price = 50,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 1,
                    sprite = Resources.Load<Sprite>("Items/Boots/Carmesi"),
                    spriteBack = Resources.Load<Sprite>("Items/BootsBack/Carmesi")
                };
            case BootsName.Mercenario:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{BootsName.Mercenario}",
                    itemName = Language.GetText(Language.Text.Boots_NameMercenario),
                    description = Language.GetText(Language.Text.Boots_DescMercenario),
                    price = 100,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 2,
                    sprite = Resources.Load<Sprite>("Items/Boots/Mercenario"),
                    spriteBack = Resources.Load<Sprite>("Items/BootsBack/Mercenario")
                };
            case BootsName.Acorazado:
                return new Armor.Armor_Data
                {
                    itemID = $"{ItemType}_{BootsName.Acorazado}",
                    itemName = Language.GetText(Language.Text.Boots_NameAcorazado),
                    description = Language.GetText(Language.Text.Boots_DescAcorazado),
                    price = 150,
                    starterState = ItemData.ItemState.OnSale,
                    resistance = 3,
                    sprite = Resources.Load<Sprite>("Items/Boots/Acorazado"),
                    spriteBack = Resources.Load<Sprite>("Items/BootsBack/Acorazado")
                };
            default:
                return null;
        }
    }
}
