using Gui;
using Items;
using Items.Potions;
using UnityEngine;
using Vault;

public static class PlayerPrefs2
{
    public const float DificultyCurve = 30;
    public const int MusicMin = -35;
    public const int SoundMin = -35;

    #region Global
    public static Language.Languages SelectedLanguage
    {
        get => (Language.Languages)PlayerPrefs.GetInt("Lenguage", 0);
        set => PlayerPrefs.SetInt("Lenguage", (int)value);
    }

    public static int Coins
    {
        get => PlayerPrefs.GetInt("Coins", 0);
        set
        {
            PlayerPrefs.SetInt("Coins", value);
            SetAchievementProgress(Achievements.Achievements.AchievementID(Achievements.Achievements.AchievementName.BankerI), Coins);
        }
    }

    public static int Gems
    {
        get => PlayerPrefs.GetInt("Gems", 0);
        set => PlayerPrefs.SetInt("Gems", value);
    }

    public static int GetPotionQuantity(string potionId)
    {
        return PlayerPrefs.GetInt($"{potionId}_Quantity", 0);
    }

    public static void SetPotionQuantity(string potionId, int value)
    {
        PlayerPrefs.SetInt($"{potionId}_Quantity", value);
    }

    public static int LevelStart
    {
        get => PlayerPrefs.GetInt("LevelStart", 0);
        set => PlayerPrefs.SetInt("LevelStart", value);
    }

    public static int LevelEnd
    {
        get => PlayerPrefs.GetInt("LevelEnd", 100);
        set => PlayerPrefs.SetInt("LevelEnd", value);
    }

    public static int AddExperience(int exp)
    {
        int cont = 0;
        PlayerExperience += exp;
        while (PlayerExperience >= LevelEnd)
        {
            NextLevel();
            cont++;
        }
        return cont;
    }

    public static string AddZeros(int number, int zeros = 4)
    {
        string str = number.ToString();
        while (str.Length < zeros)
        {
            str = $"0{str}";
        }

        return str;
    }

    public static void NextLevel()
    {
        int temp = LevelEnd;
        LevelEnd += Mathf.CeilToInt((LevelEnd - LevelStart) * (1 + DificultyCurve / 100));
        LevelStart = temp;
        PlayerLevel++;
        UpgradePlayer();
    }

    private static void UpgradePlayer()
    {
        switch (PlayerLevel)
        {
            case 3:
                PlayerMaxStamina++;
                break;
            case 5:
                PlayerMaxStamina++;
                PlayerMaxHealth++;
                break;
            case 10:
                PlayerMaxStamina++;
                PlayerMaxHealth++;
                break;
            default:
                break;
        }
    }

    public static float Music
    {
        get => PlayerPrefs.GetFloat("Music", -35);

        set
        {
            PlayerPrefs.SetFloat("Music", ControlledVolume(value, MusicMin));
        }
    }

    public static float Sound
    {
        get => PlayerPrefs.GetFloat("Sound", -5);

        set
        {
            PlayerPrefs.SetFloat("Sound", ControlledVolume(value, SoundMin));
        }
    }

    public static float ControlledVolume(float volume, int minimum)
    {
        if (volume <= minimum)
        {
            volume = -80;
        }

        return volume;
    }

    // Maneja el tiempo en jugado en segundos
    public static int GetTimePlayed()
    {
        return PlayerPrefs.GetInt("TimePlayed", 0);
    }

    // Maneja el tiempo en jugado en segundos
    public static void SetTimePlayed(int value)
    {
        PlayerPrefs.SetInt("TimePlayed", GetTimePlayed() + value);
        SetAchievementProgress(Achievements.Achievements.AchievementID(Achievements.Achievements.AchievementName.TimeMasterI), GetTimePlayed() / 3600);
    }
    #endregion

    #region Player
    public static int PlayerLevel
    {
        get => PlayerPrefs.GetInt("PlayerLevel", 0);
        set => PlayerPrefs.SetInt("PlayerLevel", value);
    }

    public static int PlayerExperience
    {
        get => PlayerPrefs.GetInt("PlayerExperience", 0);
        set => PlayerPrefs.SetInt("PlayerExperience", value);
    }

    public static int PlayerMaxHealth
    {
        get => PlayerPrefs.GetInt("PlayerMaxHealth", 3);
        set => PlayerPrefs.SetInt("PlayerMaxHealth", value);
    }

    public static int PlayerMaxStamina
    {
        get => PlayerPrefs.GetInt("PlayerMaxStamina", 1);
        set => PlayerPrefs.SetInt("PlayerMaxStamina", value);
    }

    public static int PlayerStaminaRegen
    {
        get => PlayerPrefs.GetInt("PlayerStaminaRegen", 1);
        set => PlayerPrefs.SetInt("PlayerStaminaRegen", value);
    }
    #endregion

    #region Level
    public static int GetLevelStars(string levelName)
    {
        return PlayerPrefs.GetInt($"{levelName}_Stars", 0);
    }

    public static void SetLevelStars(string levelName, int stars)
    {
        PlayerPrefs.SetInt($"{levelName}_Stars", stars);
    }
    #endregion

    #region Achievements
    public static bool GetAchievementDisplay(string achievementID, bool defaultDisplay)
    {
        return PlayerPrefs.GetInt($"AchievementDisplay_{achievementID}", defaultDisplay ? 1 : 0) == 1 ? true : false;
    }

    public static void SetAchievementDisplay(string achievementID, bool newDisplay)
    {
        PlayerPrefs.SetInt($"AchievementDisplay_{achievementID}", newDisplay ? 1 : 0);
    }

    public static bool IsAchievementComplete(string achievementID)
    {
        return PlayerPrefs.GetInt($"AchievementCompletion_{achievementID}", 0) == 1 ? true : false;
    }

    public static void AchievementComplete(string achievementID)
    {
        PlayerPrefs.SetInt($"AchievementCompletion_{achievementID}", 1);
    }

    public static int GetAchievementProgress(string achievementID)
    {
        return PlayerPrefs.GetInt($"AchivementProgress_{achievementID}", 0);
    }

    public static void SetAchievementProgress(string achievementID, int value)
    {
        PlayerPrefs.SetInt($"AchivementProgress_{achievementID}", value);
    }

    public static void IncreaseAchievementProgress(string achievementID, int value = 1)
    {
        PlayerPrefs.SetInt($"AchivementProgress_{achievementID}", GetAchievementProgress(achievementID) + value);
    }
    #endregion

    #region Items
    #region General Items
    public static int GetItemState(string itemID, int defaultState)
    {
        return PlayerPrefs.GetInt(itemID, defaultState); ;
    }

    public static ItemData.ItemState GetItemState(string itemID, ItemData.ItemState defaultState)
    {
        return (ItemData.ItemState)PlayerPrefs.GetInt(itemID, (int)defaultState); ;
    }

    public static void SetItemState(string itemID, int newState)
    {
        PlayerPrefs.SetInt(itemID, newState);
    }

    public static void SetItemState(string itemID, ItemData.ItemState newState)
    {
        PlayerPrefs.SetInt(itemID, (int)newState);
    }
    #endregion

    #region Swords
    public static void SetEquipedSword(Weapon.WeaponData sword)
    {
        if (sword == null)
        {
            PlayerPrefs.SetString("EquipedSwordData", null);
        }
        else
        {
            PlayerPrefs.SetString("EquipedSwordData", JsonUtility.ToJson(sword));
        }
    }

    public static Weapon.WeaponData GetEquipedSword()
    {
        return JsonUtility.FromJson<Weapon.WeaponData>(PlayerPrefs.GetString("EquipedSwordData", JsonUtility.ToJson(Swords.GetData(Swords.SwordName.EspadaMadera))));
    }
    #endregion

    #region Shirts
    public static void SetEquipedShirt(Armor.Armor_Data armor)
    {
        if (armor == null)
        {
            PlayerPrefs.SetString("EquipedShirtData", null);
        }
        else
        {
            PlayerPrefs.SetString("EquipedShirtData", JsonUtility.ToJson(armor));
        }
    }

    public static Armor.Armor_Data GetEquipedShirt()
    {
        return JsonUtility.FromJson<Armor.Armor_Data>(PlayerPrefs.GetString("EquipedShirtData", JsonUtility.ToJson(Shirts.GetData(Shirts.ShirtName.Inicial))));
    }
    #endregion

    #region Helmet
    public static void SetEquipedHelmet(Armor.Armor_Data armor)
    {
        if (armor == null)
        {
            PlayerPrefs.SetString("EquipedHelmetData", null);
        }
        else
        {
            PlayerPrefs.SetString("EquipedHelmetData", JsonUtility.ToJson(armor));
        }
    }

    public static Armor.Armor_Data GetEquipedHelmet()
    {
        return JsonUtility.FromJson<Armor.Armor_Data>(PlayerPrefs.GetString("EquipedHelmetData", null));
    }
    #endregion

    #region Greave
    public static void SetEquipedGreave(Armor.Armor_Data armor)
    {
        if (armor == null)
        {
            PlayerPrefs.SetString("EquipedGreaveData", null);
        }
        else
        {
            PlayerPrefs.SetString("EquipedGreaveData", JsonUtility.ToJson(armor));
        }
    }

    public static Armor.Armor_Data GetEquipedGreave()
    {
        return JsonUtility.FromJson<Armor.Armor_Data>(PlayerPrefs.GetString("EquipedGreaveData", JsonUtility.ToJson(Greaves.GetData(Greaves.GreaveName.Inicial))));
    }
    #endregion

    #region Chestplate
    public static void SetEquipedChestplate(Armor.Armor_Data armor)
    {
        if (armor == null)
        {
            PlayerPrefs.SetString("EquipedChestplateData", null);
        }
        else
        {
            PlayerPrefs.SetString("EquipedChestplateData", JsonUtility.ToJson(armor));
        }
    }

    public static Armor.Armor_Data GetEquipedChestplate()
    {
        return JsonUtility.FromJson<Armor.Armor_Data>(PlayerPrefs.GetString("EquipedChestplateData", null));
    }
    #endregion

    #region Boots
    public static void SetEquipedBoots(Armor.Armor_Data armor)
    {
        if (armor == null)
        {
            PlayerPrefs.SetString("EquipedBootsData", null);
        }
        else
        {
            PlayerPrefs.SetString("EquipedBootsData", JsonUtility.ToJson(armor));
        }
    }

    public static Armor.Armor_Data GetEquipedBoots()
    {
        return JsonUtility.FromJson<Armor.Armor_Data>(PlayerPrefs.GetString("EquipedBootsData", JsonUtility.ToJson(Boots.GetData(Boots.BootsName.Inicial))));
    }
    #endregion

    #region Potions
    public static void SetEquippedPrimaryPotion(Potion.PotionData potion)
    {
        PlayerPrefs.SetString("EquippedPrimaryPotionData", potion == null ? null : JsonUtility.ToJson(potion));
    }

    public static Potion.PotionData GetEquippedPrimaryPotion()
    {
        return JsonUtility.FromJson<Potion.PotionData>(PlayerPrefs.GetString("EquippedPrimaryPotionData", JsonUtility.ToJson(Potions.GetData(Potions.PotionName.SmallLife))));
    }

    public static void SetEquippedSecondaryPotion(Potion.PotionData potion)
    {
        PlayerPrefs.SetString("EquippedSecondaryPotionData", potion == null ? null : JsonUtility.ToJson(potion));
    }

    public static Potion.PotionData GetEquippedSecondaryPotion()
    {
        return JsonUtility.FromJson<Potion.PotionData>(PlayerPrefs.GetString("EquippedSecondaryPotionData", JsonUtility.ToJson(Potions.GetData(Potions.PotionName.SmallShield))));
    }
    #endregion
    #endregion
}
