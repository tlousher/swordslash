using Items;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public const int Count = 6;
    public const string ItemType = "Collectible";

    public enum CollectibleName
    {
        WaterOrbMini,
        WaterOrb,
        WaterOrbBig,
        WoodOrbMini,
        WoodOrb,
        WoodOrbBig
    }

    public static Collectible.Collectible_Data GetData(CollectibleName collectible)
    {
        switch (collectible)
        {
            case CollectibleName.WaterOrbMini:
                return new Collectible.Collectible_Data
                {
                    itemID = $"{ItemType}_{CollectibleName.WaterOrbMini}",
                    itemName = Language.GetText(Language.Text.Collectible_NameWaterOrbMini),
                    description = Language.GetText(Language.Text.Collectible_DescWaterOrbMini),
                    monsterBase = Language.GetText(Language.Text.Monster_NameWater),
                    price = 5,
                    rarity = Collectible.Collectible_Data.Rarity.Common,
                    starterState = ItemData.ItemState.Locked,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    collectionSprite = Resources.Load<Sprite>("Collection/Orbs/WaterOrbMini"),
                    sprite = Resources.Load<Sprite>("Items/Collectibles/WaterOrbMini"),
                    trailMaterial = Resources.Load<Material>("Items/Collectibles/Trails/Water")
                };
            case CollectibleName.WaterOrb:
                return new Collectible.Collectible_Data
                {
                    itemID = $"{ItemType}_{CollectibleName.WaterOrb}",
                    itemName = Language.GetText(Language.Text.Collectible_NameWaterOrb),
                    description = Language.GetText(Language.Text.Collectible_DescWaterOrb),
                    monsterBase = Language.GetText(Language.Text.Monster_NameWater),
                    price = 25,
                    rarity = Collectible.Collectible_Data.Rarity.Uncommon,
                    starterState = ItemData.ItemState.Locked,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    collectionSprite = Resources.Load<Sprite>("Collection/Orbs/WaterOrb"),
                    sprite = Resources.Load<Sprite>("Items/Collectibles/WaterOrb"),
                    trailMaterial = Resources.Load<Material>("Items/Collectibles/Trails/Water")
                };
            case CollectibleName.WaterOrbBig:
                return new Collectible.Collectible_Data
                {
                    itemID = $"{ItemType}_{CollectibleName.WaterOrbBig}",
                    itemName = Language.GetText(Language.Text.Collectible_NameWaterOrbBig),
                    description = Language.GetText(Language.Text.Collectible_DescWaterOrbBig),
                    monsterBase = Language.GetText(Language.Text.Monster_NameWater),
                    price = 50,
                    rarity = Collectible.Collectible_Data.Rarity.Rare,
                    starterState = ItemData.ItemState.Locked,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    collectionSprite = Resources.Load<Sprite>("Collection/Orbs/WaterOrbBig"),
                    sprite = Resources.Load<Sprite>("Items/Collectibles/WaterOrbBig"),
                    trailMaterial = Resources.Load<Material>("Items/Collectibles/Trails/Water")
                };
            case CollectibleName.WoodOrbMini:
                return new Collectible.Collectible_Data
                {
                    itemID = $"{ItemType}_{CollectibleName.WoodOrbMini}",
                    itemName = Language.GetText(Language.Text.Collectible_NameWoodOrbMini),
                    description = Language.GetText(Language.Text.Collectible_DescWoodOrbMini),
                    monsterBase = Language.GetText(Language.Text.Monster_NameWood),
                    price = 7,
                    rarity = Collectible.Collectible_Data.Rarity.Common,
                    starterState = ItemData.ItemState.Locked,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    collectionSprite = Resources.Load<Sprite>("Collection/Orbs/WoodOrbMini"),
                    sprite = Resources.Load<Sprite>("Items/Collectibles/WoodOrbMini"),
                    trailMaterial = Resources.Load<Material>("Items/Collectibles/Trails/Wood")
                };
            case CollectibleName.WoodOrb:
                return new Collectible.Collectible_Data
                {
                    itemID = $"{ItemType}_{CollectibleName.WoodOrb}",
                    itemName = Language.GetText(Language.Text.Collectible_NameWoodOrb),
                    description = Language.GetText(Language.Text.Collectible_DescWoodOrb),
                    monsterBase = Language.GetText(Language.Text.Monster_NameWood),
                    price = 30,
                    rarity = Collectible.Collectible_Data.Rarity.Uncommon,
                    starterState = ItemData.ItemState.Locked,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    collectionSprite = Resources.Load<Sprite>("Collection/Orbs/WoodOrb"),
                    sprite = Resources.Load<Sprite>("Items/Collectibles/WoodOrb"),
                    trailMaterial = Resources.Load<Material>("Items/Collectibles/Trails/Wood")
                };
            case CollectibleName.WoodOrbBig:
                return new Collectible.Collectible_Data
                {
                    itemID = $"{ItemType}_{CollectibleName.WoodOrbBig}",
                    itemName = Language.GetText(Language.Text.Collectible_NameWoodOrbBig),
                    description = Language.GetText(Language.Text.Collectible_DescWoodOrbBig),
                    monsterBase = Language.GetText(Language.Text.Monster_NameWood),
                    price = 60,
                    rarity = Collectible.Collectible_Data.Rarity.Rare,
                    starterState = ItemData.ItemState.Locked,
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    collectionSprite = Resources.Load<Sprite>("Collection/Orbs/WoodOrbBig"),
                    sprite = Resources.Load<Sprite>("Items/Collectibles/WoodOrbBig"),
                    trailMaterial = Resources.Load<Material>("Items/Collectibles/Trails/Wood")
                };
            default:
                return null;
        }
    }
}
