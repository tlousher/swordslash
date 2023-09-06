using Items;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    public const int Count = 4;
    public const string ItemType = "Monster";

    public enum MonsterName
    {
        Water,
        Wood,
        Fire,
        Slime
    }

    public static Monster_Data GetData(MonsterName monster)
    {
        switch (monster)
        {
            case MonsterName.Water:
                return new Monster_Data
                {
                    itemID = $"{ItemType}_{MonsterName.Water}",
                    itemName = Language.GetText(Language.Text.Monster_NameWater),
                    description = Language.GetText(Language.Text.Monster_DescWater),
                    ability = Language.GetText(Language.Text.Monster_AbilWater),
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    sprite = Resources.Load<Sprite>("Collection/Monsters/WaterMonster")
                };
            case MonsterName.Wood:
                return new Monster_Data
                {
                    itemID = $"{ItemType}_{MonsterName.Wood}",
                    itemName = Language.GetText(Language.Text.Monster_NameWood),
                    description = Language.GetText(Language.Text.Monster_DescWood),
                    ability = Language.GetText(Language.Text.Monster_AbilWood),
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    sprite = Resources.Load<Sprite>("Collection/Monsters/WoodMonster")
                };
            case MonsterName.Fire:
                return new Monster_Data
                {
                    itemID = $"{ItemType}_{MonsterName.Fire}",
                    itemName = Language.GetText(Language.Text.Monster_NameFire),
                    description = Language.GetText(Language.Text.Monster_DescFire),
                    ability = Language.GetText(Language.Text.Monster_AbilFire),
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    sprite = Resources.Load<Sprite>("Collection/Monsters/FireMonster")
                };
            case MonsterName.Slime:
                return new Monster_Data
                {
                    itemID = $"{ItemType}_{MonsterName.Slime}",
                    itemName = Language.GetText(Language.Text.Monster_NameSlime),
                    description = Language.GetText(Language.Text.Monster_DescSlime),
                    ability = Language.GetText(Language.Text.Monster_AbilSlime),
                    collectionState = CollectionPrefs.CollectionState.Missing,
                    sprite = Resources.Load<Sprite>("Collection/Monsters/SlimeMonster")
                };
            default:
                return null;
        }
    }

    [System.Serializable]
    public class Monster_Data : ItemData
    {
        public CollectionPrefs.CollectionState collectionState;
        public string ability;
    }
}
