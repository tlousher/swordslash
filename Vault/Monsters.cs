using Gui;
using Items;
using UnityEngine;

namespace Vault
{
    public class Monsters : MonoBehaviour
    {
        public const int Count = 5;
        private const string ItemType = "Monster";

        public enum MonsterName
        {
            Water,
            Wood,
            Fire,
            Slime,
            Training
        }

        public static MonsterData GetData(MonsterName monster)
        {
            switch (monster)
            {
                case MonsterName.Water:
                    return new MonsterData
                    {
                        itemID = $"{ItemType}_{MonsterName.Water}",
                        itemName = Language.GetText(Language.Text.Monster_NameWater),
                        description = Language.GetText(Language.Text.Monster_DescWater),
                        ability = Language.GetText(Language.Text.Monster_AbilWater),
                        collectionState = CollectionPrefs.CollectionState.Missing,
                        sprite = Resources.Load<Sprite>("Collection/Monsters/WaterMonster")
                    };
                case MonsterName.Wood:
                    return new MonsterData
                    {
                        itemID = $"{ItemType}_{MonsterName.Wood}",
                        itemName = Language.GetText(Language.Text.Monster_NameWood),
                        description = Language.GetText(Language.Text.Monster_DescWood),
                        ability = Language.GetText(Language.Text.Monster_AbilWood),
                        collectionState = CollectionPrefs.CollectionState.Missing,
                        sprite = Resources.Load<Sprite>("Collection/Monsters/WoodMonster")
                    };
                case MonsterName.Fire:
                    return new MonsterData
                    {
                        itemID = $"{ItemType}_{MonsterName.Fire}",
                        itemName = Language.GetText(Language.Text.Monster_NameFire),
                        description = Language.GetText(Language.Text.Monster_DescFire),
                        ability = Language.GetText(Language.Text.Monster_AbilFire),
                        collectionState = CollectionPrefs.CollectionState.Missing,
                        sprite = Resources.Load<Sprite>("Collection/Monsters/FireMonster")
                    };
                case MonsterName.Slime:
                    return new MonsterData
                    {
                        itemID = $"{ItemType}_{MonsterName.Slime}",
                        itemName = Language.GetText(Language.Text.Monster_NameSlime),
                        description = Language.GetText(Language.Text.Monster_DescSlime),
                        ability = Language.GetText(Language.Text.Monster_AbilSlime),
                        collectionState = CollectionPrefs.CollectionState.Missing,
                        sprite = Resources.Load<Sprite>("Collection/Monsters/SlimeMonster")
                    };
                case MonsterName.Training:
                    var itemID = $"{ItemType}_{MonsterName.Training}";
                    return new MonsterData
                    {
                        itemID = itemID,
                        itemName = Language.GetText(Language.Text.Monster_NameTrainingDummy),
                        description = Language.GetText(Language.Text.Monster_DescTrainingDummy),
                        ability = Language.GetText(Language.Text.Monster_AbilTrainingDummy),
                        collectionState = CollectionPrefs.GetCollectionState(itemID, CollectionPrefs.CollectionState.Missing),
                        sprite = Resources.Load<Sprite>("Collection/Monsters/SlimeMonster")
                    };
                default:
                    return null;
            }
        }

        [System.Serializable]
        public class MonsterData : ItemData
        {
            public CollectionPrefs.CollectionState collectionState;
            public string ability;
        }
    }
}
