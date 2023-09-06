using System.Collections.Generic;
using UnityEngine;

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

    public static List<Weapon.Weapon_Data> GetSwordsCollection()
    {
        List<Weapon.Weapon_Data> swordsCollection = new List<Weapon.Weapon_Data>();

        for (int i = 0; i < Swords.Count; i++)
        {
            Weapon.Weapon_Data sword = Swords.GetData((Swords.SwordName)i);
            sword.collectionState = GetCollectionState(sword.itemID, sword.collectionState);
            swordsCollection.Add(sword);
        }

        return swordsCollection;
    }

    public static List<Collectible.Collectible_Data> GetOrbsCollection()
    {
        List<Collectible.Collectible_Data> orbsCollection = new List<Collectible.Collectible_Data>();

        for (int i = 0; i < Collectibles.Count; i++)
        {
            Collectible.Collectible_Data orb = Collectibles.GetData((Collectibles.CollectibleName)i);
            orb.collectionState = GetCollectionState(orb.itemID, orb.collectionState);
            orbsCollection.Add(orb);
        }

        return orbsCollection;
    }

    public static List<Monsters.Monster_Data> GetMonstersCollection()
    {
        List<Monsters.Monster_Data> monstersCollection = new List<Monsters.Monster_Data>();

        for (int i = 0; i < Monsters.Count; i++)
        {
            Monsters.Monster_Data monster = Monsters.GetData((Monsters.MonsterName)i);
            monster.collectionState = GetCollectionState(monster.itemID, monster.collectionState);
            monstersCollection.Add(monster);
        }

        return monstersCollection;
    }
}
