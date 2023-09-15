using System.Collections.Generic;
using Items;
using UnityEngine;
using Vault;

namespace Collections
{
    public static class CollectionPrefs
    {
        public enum CollectionState
        {
            Discovered,
            Missing
        }
    
        #region State
        public static int GetCollectionState(string itemID, int defaultState)
        {
            return PlayerPrefs.GetInt(itemID, defaultState);
        }

        public static void SetCollectionState(string itemID, int newState)
        {
            PlayerPrefs.SetInt(itemID, newState);
        }

        public static CollectionState GetCollectionState(string itemID)
        {
            return (CollectionState)PlayerPrefs.GetInt(itemID, (int)CollectionState.Missing);
        }

        public static CollectionState GetCollectionState(string itemID, CollectionState defaultState)
        {
            return (CollectionState)PlayerPrefs.GetInt(itemID, (int)defaultState);
        }

        public static void SetCollectionState(string itemID, CollectionState newState)
        {
            PlayerPrefs.SetInt(itemID, (int)newState);
        }
        #endregion

        public static List<Weapon.WeaponData> GetSwordsCollection()
        {
            List<Weapon.WeaponData> swordsCollection = new List<Weapon.WeaponData>();

            for (int i = 0; i < Swords.Count; i++)
            {
                Weapon.WeaponData sword = Swords.GetData((Swords.SwordName)i);
                sword.collectionState = GetCollectionState(sword.itemID, sword.collectionState);
                swordsCollection.Add(sword);
            }

            return swordsCollection;
        }

        public static List<Collectible.CollectibleData> GetOrbsCollection()
        {
            List<Collectible.CollectibleData> orbsCollection = new List<Collectible.CollectibleData>();

            for (int i = 0; i < Collectibles.Count; i++)
            {
                Collectible.CollectibleData orb = Collectibles.GetData((Collectibles.CollectibleName)i);
                orb.collectionState = GetCollectionState(orb.itemID, orb.collectionState);
                orbsCollection.Add(orb);
            }

            return orbsCollection;
        }

        public static List<Monsters.MonsterData> GetMonstersCollection()
        {
            List<Monsters.MonsterData> monstersCollection = new List<Monsters.MonsterData>();

            for (int i = 0; i < Monsters.Count; i++)
            {
                Monsters.MonsterData monster = Monsters.GetData((Monsters.MonsterName)i);
                monster.collectionState = GetCollectionState(monster.itemID, monster.collectionState);
                monstersCollection.Add(monster);
            }

            return monstersCollection;
        }
    }
}
