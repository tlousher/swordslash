using Collections;
using Gui;
using Items;
using UnityEngine;

public static class Swords
{
    public const int Count = 12;
    public const string ItemType = "Sword";

    //Las espadas en la tienda se ordenan segun esta lista
    public enum SwordName
    {
        EspadaMadera,
        EspadaHierro,
        Aqua,
        OscuridadDemoniaca,
        EspadaSombras,
        EspadonCelestial,
        Volcanora,
        EspadaPaladin,
        EspadaCristal,
        Hidroblade,
        Inferno,
        RebanadoraSlimes,
        EspadonBosque
    }

    public static string SwordID(SwordName swordName)
    {
        return $"{ItemType}_{swordName}";
    }

    public static Weapon.WeaponData GetData(SwordName sword)
    {
        switch (sword)
        {
            case SwordName.EspadaMadera:
                return new Weapon.WeaponData
                {
                    itemID = SwordID(SwordName.EspadaMadera),
                    itemName = Language.GetText(Language.Text.Sword_NameEspadaMadera),
                    description = Language.GetText(Language.Text.Sword_DescEspadaMadera),
                    ability = Language.GetText(Language.Text.Sword_AbilEspadaMadera),
                    power = 1,
                    price = 5,
                    starterState = ItemData.ItemState.Equipped,
                    collectionState = CollectionPrefs.CollectionState.Discovered,
                    range = 6,
                    sprite = Resources.Load<Sprite>("Items/Swords/EspadaMadera"),
                    collectionSprite = Resources.Load<Sprite>("Collection/Swords/EspadaMadera"),
                    clips = Resources.LoadAll<AudioClip>("Sfx/Swords/Normal")
                };
            case SwordName.EspadaHierro:
                return new Weapon.WeaponData
                {
                    itemID = SwordID(SwordName.EspadaHierro),
                    itemName = Language.GetText(Language.Text.Sword_NameEspadaHierro),
                    description = Language.GetText(Language.Text.Sword_DescEspadaHierro),
                    ability = Language.GetText(Language.Text.Sword_AbilEspadaHierro),
                    power = 2,
                    price = 50,
                    starterState = ItemData.ItemState.OnSale,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    range = 7,
                    sprite = Resources.Load<Sprite>("Items/Swords/EspadaHierro"),
                    collectionSprite = Resources.Load<Sprite>("Collection/Swords/EspadaHierro"),
                    clips = Resources.LoadAll<AudioClip>("Sfx/Swords/Normal")
                };
            case SwordName.Aqua:
                return new Weapon.WeaponData
                {
                    itemID = SwordID(SwordName.Aqua),
                    itemName = Language.GetText(Language.Text.Sword_NameAqua),
                    description = Language.GetText(Language.Text.Sword_DescAqua),
                    ability = Language.GetText(Language.Text.Sword_AbilAqua),
                    power = 2,
                    price = 100,
                    starterState = ItemData.ItemState.OnSale,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    range = 8,
                    sprite = Resources.Load<Sprite>("Items/Swords/Aqua"),
                    collectionSprite = Resources.Load<Sprite>("Collection/Swords/Aqua"),
                    clips = Resources.LoadAll<AudioClip>("Sfx/Swords/Normal")
                };
            case SwordName.OscuridadDemoniaca:
                return new Weapon.WeaponData
                {
                    itemID = SwordID(SwordName.OscuridadDemoniaca),
                    itemName = Language.GetText(Language.Text.Sword_NameOscuridadDemoniaca),
                    description = Language.GetText(Language.Text.Sword_DescOscuridadDemoniaca),
                    ability = Language.GetText(Language.Text.Sword_AbilOscuridadDemoniaca),
                    power = 2,
                    price = 120,
                    starterState = ItemData.ItemState.OnSale,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    range = 9,
                    sprite = Resources.Load<Sprite>("Items/Swords/OscuridadDemoniaca"),
                    collectionSprite = Resources.Load<Sprite>("Collection/Swords/OscuridadDemoniaca"),
                    clips = Resources.LoadAll<AudioClip>("Sfx/Swords/Normal")
                };
            case SwordName.EspadaSombras:
                return new Weapon.WeaponData
                {
                    itemID = SwordID(SwordName.EspadaSombras),
                    itemName = Language.GetText(Language.Text.Sword_NameEspadaSombras),
                    description = Language.GetText(Language.Text.Sword_DescEspadaSombras),
                    ability = Language.GetText(Language.Text.Sword_AbilEspadaSombras),
                    power = 3,
                    price = 150,
                    starterState = ItemData.ItemState.OnSale,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    range = 7,
                    sprite = Resources.Load<Sprite>("Items/Swords/EspadaSombras"),
                    collectionSprite = Resources.Load<Sprite>("Collection/Swords/EspadaSombras"),
                    clips = Resources.LoadAll<AudioClip>("Sfx/Swords/Normal")
                };
            case SwordName.EspadonCelestial:
                return new Weapon.WeaponData
                {
                    itemID = SwordID(SwordName.EspadonCelestial),
                    itemName = Language.GetText(Language.Text.Sword_NameEspadonCelestial),
                    description = Language.GetText(Language.Text.Sword_DescEspadonCelestial),
                    ability = Language.GetText(Language.Text.Sword_AbilEspadonCelestial),
                    power = 3,
                    price = 200,
                    starterState = ItemData.ItemState.OnSale,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    range = 10,
                    sprite = Resources.Load<Sprite>("Items/Swords/EspadonCelestial"),
                    collectionSprite = Resources.Load<Sprite>("Collection/Swords/EspadonCelestial"),
                    clips = Resources.LoadAll<AudioClip>("Sfx/Swords/Normal")
                };
            case SwordName.Volcanora:
                return new Weapon.WeaponData
                {
                    itemID = SwordID(SwordName.Volcanora),
                    itemName = Language.GetText(Language.Text.Sword_NameVolcanora),
                    description = Language.GetText(Language.Text.Sword_DescVolcanora),
                    ability = Language.GetText(Language.Text.Sword_AbilVolcanora),
                    power = 4,
                    price = 300,
                    starterState = ItemData.ItemState.OnSale,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    range = 11,
                    sprite = Resources.Load<Sprite>("Items/Swords/Volcanora"),
                    collectionSprite = Resources.Load<Sprite>("Collection/Swords/Volcanora"),
                    clips = Resources.LoadAll<AudioClip>("Sfx/Swords/Normal")
                };
            case SwordName.Hidroblade:
                return new Weapon.WeaponData
                {
                    itemID = SwordID(SwordName.Hidroblade),
                    itemName = Language.GetText(Language.Text.Sword_NameHidroblade),
                    description = Language.GetText(Language.Text.Sword_DescHidroblade),
                    ability = Language.GetText(Language.Text.Sword_AbilHidroblade),
                    power = 2,
                    price = -1,
                    starterState = ItemData.ItemState.Locked,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    range = 8,
                    sprite = Resources.Load<Sprite>("Items/Swords/Hidroblade"),
                    collectionSprite = Resources.Load<Sprite>("Collection/Swords/Hidroblade"),
                    clips = Resources.LoadAll<AudioClip>("Sfx/Swords/Normal")
                };
            case SwordName.Inferno:
                return new Weapon.WeaponData
                {
                    itemID = SwordID(SwordName.Inferno),
                    itemName = Language.GetText(Language.Text.Sword_NameInferno),
                    description = Language.GetText(Language.Text.Sword_DescInferno),
                    ability = Language.GetText(Language.Text.Sword_AbilInferno),
                    power = 4,
                    price = -1,
                    starterState = ItemData.ItemState.Locked,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    range = 10,
                    sprite = Resources.Load<Sprite>("Items/Swords/Inferno"),
                    collectionSprite = Resources.Load<Sprite>("Collection/Swords/Inferno"),
                    clips = Resources.LoadAll<AudioClip>("Sfx/Swords/Normal")
                };
            case SwordName.RebanadoraSlimes:
                return new Weapon.WeaponData
                {
                    itemID = SwordID(SwordName.RebanadoraSlimes),
                    itemName = Language.GetText(Language.Text.Sword_NameRebanadoraSlimes),
                    description = Language.GetText(Language.Text.Sword_DescRebanadoraSlimes),
                    ability = Language.GetText(Language.Text.Sword_AbilRebanadoraSlimes),
                    power = 3,
                    price = -1,
                    starterState = ItemData.ItemState.Locked,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    range = 11,
                    sprite = Resources.Load<Sprite>("Items/Swords/RebanadoraSlimes"),
                    collectionSprite = Resources.Load<Sprite>("Collection/Swords/RebanadoraSlimes"),
                    clips = Resources.LoadAll<AudioClip>("Sfx/Swords/Normal")
                };
            case SwordName.EspadonBosque:
                return new Weapon.WeaponData
                {
                    itemID = SwordID(SwordName.EspadonBosque),
                    itemName = Language.GetText(Language.Text.Sword_NameEspadonBosque),
                    description = Language.GetText(Language.Text.Sword_DescEspadonBosque),
                    ability = Language.GetText(Language.Text.Sword_AbilEspadonBosque),
                    power = 5,
                    price = -1,
                    starterState = ItemData.ItemState.Locked,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    range = 9,
                    sprite = Resources.Load<Sprite>("Items/Swords/EspadonBosque"),
                    collectionSprite = Resources.Load<Sprite>("Collection/Swords/EspadonBosque"),
                    clips = Resources.LoadAll<AudioClip>("Sfx/Swords/Normal")
                };
            case SwordName.EspadaCristal:
                return new Weapon.WeaponData
                {
                    itemID = SwordID(SwordName.EspadaCristal),
                    itemName = Language.GetText(Language.Text.Sword_NameEspadaCristal),
                    description = Language.GetText(Language.Text.Sword_DescEspadaCristal),
                    ability = Language.GetText(Language.Text.Sword_AbilEspadaCristal),
                    power = 5,
                    price = 500,
                    starterState = ItemData.ItemState.OnSale,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    range = 12,
                    sprite = Resources.Load<Sprite>("Items/Swords/EspadaCristal"),
                    collectionSprite = Resources.Load<Sprite>("Collection/Swords/EspadaCristal"),
                    clips = Resources.LoadAll<AudioClip>("Sfx/Swords/Normal")
                };
            case SwordName.EspadaPaladin:
                return new Weapon.WeaponData
                {
                    itemID = SwordID(SwordName.EspadaPaladin),
                    itemName = Language.GetText(Language.Text.Sword_NameEspadaPaladin),
                    description = Language.GetText(Language.Text.Sword_DescEspadaPaladin),
                    ability = Language.GetText(Language.Text.Sword_AbilEspadaPaladin),
                    power = 6,
                    price = 500,
                    starterState = ItemData.ItemState.OnSale,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    range = 11,
                    sprite = Resources.Load<Sprite>("Items/Swords/EspadaPaladin"),
                    collectionSprite = Resources.Load<Sprite>("Collection/Swords/EspadaPaladin"),
                    clips = Resources.LoadAll<AudioClip>("Sfx/Swords/Normal")
                };
            default:
                return null;
        }
    }
}
