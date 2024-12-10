using System.Collections.Generic;
using Gui;
using UnityEngine;

namespace Achievements
{
    public class Achievements : MonoBehaviour
    {
        public const int Count = 43;
        private const string ItemType = "Achievement";
        public const string CoinsReward = "Coins";
        public const string GemsReward = "Gems";

        public enum AchievementName
        {
            Final,
            WaterSlayerI,
            WaterSlayerII,
            WaterSlayerIII,
            WoodSlayerI,
            WoodSlayerII,
            WoodSlayerIII,
            SlimeSlayerI,
            SlimeSlayerII,
            SlimeSlayerIII,
            FireSlayerI,
            FireSlayerII,
            FireSlayerIII,
            TrainingManiac,
            Gatherer,
            Pacifist,
            GameLover,
            PerfectionistI,
            PerfectionistII,
            PerfectionistIII,
            PerfectionistIV,
            PerfectionistV,
            AdventurerI,
            AdventurerII,
            AdventurerIII,
            AdventurerIV,
            AdventurerV,
            AdventurerVI,
            TimeMasterI,
            TimeMasterII,
            TimeMasterIII,
            TimeMasterIV,
            TimeMasterV,
            SwordsmasterI,
            SwordsmasterII,
            SwordsmasterIII,
            BankerI,
            BankerII,
            BankerIII,
            BankerIV,
            BankerV,
            CollectionistI,
            CollectionistII,
            CollectionistIII,
        }

        public static string AchievementID(AchievementName achievementName)
        {
            return $"{ItemType}_{achievementName}";
        }

        public static List<Achievement.Achievement_Data> GetAchievements()
        {
            var achievementsList = new List<Achievement.Achievement_Data>();
            for (var i = 1; i < Count; i++)
            {
                achievementsList.Add(GetData((AchievementName)i));
            }
            return achievementsList;
        }

        public static Achievement.Achievement_Data GetData(AchievementName achievement)
        {
            switch (achievement)
            {
                #region Water slayer
                case AchievementName.WaterSlayerI:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.WaterSlayerI),
                        achievementProgressID = AchievementID(AchievementName.WaterSlayerI),
                        title = Language.GetText(Language.Text.Achievement_NameWaterSlayerI),
                        description = Language.GetText(Language.Text.Achievement_DescWaterSlayerI),
                        defaultDisplay = true,
                        rewardQuantity = 1,
                        goal = 25,
                        rewardItemID = Helmets.HelmetID(Helmets.HelmetName.Hidro),
                        nextAchievementID = AchievementID(AchievementName.WaterSlayerII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_WaterSkull"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_WaterHelmet")
                    };
                case AchievementName.WaterSlayerII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.WaterSlayerII),
                        achievementProgressID = AchievementID(AchievementName.WaterSlayerI),
                        title = Language.GetText(Language.Text.Achievement_NameWaterSlayerII),
                        description = Language.GetText(Language.Text.Achievement_DescWaterSlayerII),
                        defaultDisplay = false,
                        rewardQuantity = 1,
                        goal = 50,
                        rewardItemID = Chestplates.ChestplateID(Chestplates.ChestplateName.Hidro),
                        nextAchievementID = AchievementID(AchievementName.WaterSlayerIII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_WaterSkull"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_WaterChestplate")
                    };
                case AchievementName.WaterSlayerIII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.WaterSlayerIII),
                        achievementProgressID = AchievementID(AchievementName.WaterSlayerI),
                        title = Language.GetText(Language.Text.Achievement_NameWaterSlayerIII),
                        description = Language.GetText(Language.Text.Achievement_DescWaterSlayerIII),
                        defaultDisplay = false,
                        rewardQuantity = 1,
                        goal = 100,
                        rewardItemID = Swords.SwordID(Swords.SwordName.Hidroblade),
                        nextAchievementID = AchievementID(AchievementName.Final),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_WaterSkull"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_WaterSword")
                    };
                #endregion
                #region Wood slayer
                case AchievementName.WoodSlayerI:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.WoodSlayerI),
                        achievementProgressID = AchievementID(AchievementName.WoodSlayerI),
                        title = Language.GetText(Language.Text.Achievement_NameWoodSlayerI),
                        description = Language.GetText(Language.Text.Achievement_DescWoodSlayerI),
                        defaultDisplay = true,
                        rewardQuantity = 1,
                        goal = 25,
                        rewardItemID = Helmets.HelmetID(Helmets.HelmetName.Bosque),
                        nextAchievementID = AchievementID(AchievementName.WoodSlayerII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_WoodSkull"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_WoodHelmet")
                    };
                case AchievementName.WoodSlayerII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.WoodSlayerII),
                        achievementProgressID = AchievementID(AchievementName.WoodSlayerI),
                        title = Language.GetText(Language.Text.Achievement_NameWoodSlayerII),
                        description = Language.GetText(Language.Text.Achievement_DescWoodSlayerII),
                        defaultDisplay = false,
                        rewardQuantity = 1,
                        goal = 50,
                        rewardItemID = Chestplates.ChestplateID(Chestplates.ChestplateName.Bosque),
                        nextAchievementID = AchievementID(AchievementName.WoodSlayerIII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_WoodSkull"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_WoodChestplate")
                    };
                case AchievementName.WoodSlayerIII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.WoodSlayerIII),
                        achievementProgressID = AchievementID(AchievementName.WoodSlayerI),
                        title = Language.GetText(Language.Text.Achievement_NameWoodSlayerIII),
                        description = Language.GetText(Language.Text.Achievement_DescWoodSlayerIII),
                        defaultDisplay = false,
                        rewardQuantity = 1,
                        goal = 100,
                        rewardItemID = Swords.SwordID(Swords.SwordName.EspadonBosque),
                        nextAchievementID = AchievementID(AchievementName.Final),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_WoodSkull"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_WoodSword")
                    };
                #endregion
                #region Slime slayer
                case AchievementName.SlimeSlayerI:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.SlimeSlayerI),
                        achievementProgressID = AchievementID(AchievementName.SlimeSlayerI),
                        title = Language.GetText(Language.Text.Achievement_NameSlimeSlayerI),
                        description = Language.GetText(Language.Text.Achievement_DescSlimeSlayerI),
                        defaultDisplay = true,
                        rewardQuantity = 1,
                        goal = 25,
                        rewardItemID = Helmets.HelmetID(Helmets.HelmetName.RebanadorSlimes),
                        nextAchievementID = AchievementID(AchievementName.SlimeSlayerII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_SlimeSkull"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SlimeHelmet")
                    };
                case AchievementName.SlimeSlayerII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.SlimeSlayerII),
                        achievementProgressID = AchievementID(AchievementName.SlimeSlayerI),
                        title = Language.GetText(Language.Text.Achievement_NameSlimeSlayerII),
                        description = Language.GetText(Language.Text.Achievement_DescSlimeSlayerII),
                        defaultDisplay = false,
                        rewardQuantity = 1,
                        goal = 50,
                        rewardItemID = Chestplates.ChestplateID(Chestplates.ChestplateName.RebanadorSlimes),
                        nextAchievementID = AchievementID(AchievementName.SlimeSlayerIII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_SlimeSkull"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SlimeChestplate")
                    };
                case AchievementName.SlimeSlayerIII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.SlimeSlayerIII),
                        achievementProgressID = AchievementID(AchievementName.SlimeSlayerI),
                        title = Language.GetText(Language.Text.Achievement_NameSlimeSlayerIII),
                        description = Language.GetText(Language.Text.Achievement_DescSlimeSlayerIII),
                        defaultDisplay = false,
                        rewardQuantity = 1,
                        goal = 100,
                        rewardItemID = Swords.SwordID(Swords.SwordName.RebanadoraSlimes),
                        nextAchievementID = AchievementID(AchievementName.Final),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_SlimeSkull"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SlimeSword")
                    };
                #endregion
                #region FireSlayer
                case AchievementName.FireSlayerI:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.FireSlayerI),
                        achievementProgressID = AchievementID(AchievementName.FireSlayerI),
                        title = Language.GetText(Language.Text.Achievement_NameFireSlayerI),
                        description = Language.GetText(Language.Text.Achievement_DescFireSlayerI),
                        defaultDisplay = true,
                        rewardQuantity = 1,
                        goal = 25,
                        rewardItemID = Helmets.HelmetID(Helmets.HelmetName.Inferno),
                        nextAchievementID = AchievementID(AchievementName.FireSlayerII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_FireSkull"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_FireHelmet")
                    };
                case AchievementName.FireSlayerII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.FireSlayerII),
                        achievementProgressID = AchievementID(AchievementName.FireSlayerI),
                        title = Language.GetText(Language.Text.Achievement_NameFireSlayerII),
                        description = Language.GetText(Language.Text.Achievement_DescFireSlayerII),
                        defaultDisplay = false,
                        rewardQuantity = 1,
                        goal = 50,
                        rewardItemID = Chestplates.ChestplateID(Chestplates.ChestplateName.Inferno),
                        nextAchievementID = AchievementID(AchievementName.FireSlayerIII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_FireSkull"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_FireChestplate")
                    };
                case AchievementName.FireSlayerIII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.FireSlayerIII),
                        achievementProgressID = AchievementID(AchievementName.FireSlayerI),
                        title = Language.GetText(Language.Text.Achievement_NameFireSlayerIII),
                        description = Language.GetText(Language.Text.Achievement_DescFireSlayerIII),
                        defaultDisplay = false,
                        rewardQuantity = 1,
                        goal = 100,
                        rewardItemID = Swords.SwordID(Swords.SwordName.Inferno),
                        nextAchievementID = AchievementID(AchievementName.Final),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_FireSkull"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_FireSword")
                    };
                #endregion
                case AchievementName.TrainingManiac:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.TrainingManiac),
                        achievementProgressID = AchievementID(AchievementName.TrainingManiac),
                        title = Language.GetText(Language.Text.Achievement_NameTrainingManiac),
                        description = Language.GetText(Language.Text.Achievement_DescTrainingManiac),
                        defaultDisplay = true,
                        rewardQuantity = 1,
                        goal = 50,
                        rewardItemID = Swords.SwordID(Swords.SwordName.EspadaPaladin),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Sword"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_PaladinSword")
                    };
                case AchievementName.Gatherer:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.Gatherer),
                        achievementProgressID = AchievementID(AchievementName.Gatherer),
                        title = Language.GetText(Language.Text.Achievement_NameGatherer),
                        description = Language.GetText(Language.Text.Achievement_DescGatherer),
                        defaultDisplay = true,
                        rewardQuantity = 25,
                        goal = Collectibles.Count,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.Final),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Orb"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_MediumGems")
                    };
                case AchievementName.Pacifist:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.Pacifist),
                        achievementProgressID = AchievementID(AchievementName.Pacifist),
                        title = Language.GetText(Language.Text.Achievement_NamePacifist),
                        description = Language.GetText(Language.Text.Achievement_DescPacifist),
                        defaultDisplay = true,
                        rewardQuantity = 10,
                        goal = 1,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.Final),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Peace"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    };
                case AchievementName.GameLover:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.GameLover),
                        achievementProgressID = AchievementID(AchievementName.GameLover),
                        title = Language.GetText(Language.Text.Achievement_NameGameLover),
                        description = Language.GetText(Language.Text.Achievement_DescGameLover),
                        defaultDisplay = true,
                        rewardQuantity = 50,
                        goal = Count,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.Final),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_GameLogo"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_MediumGems")
                    };
                #region Perfectionist
                case AchievementName.PerfectionistI:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.PerfectionistI),
                        achievementProgressID = AchievementID(AchievementName.PerfectionistI),
                        title = Language.GetText(Language.Text.Achievement_NamePerfectionistI),
                        description = Language.GetText(Language.Text.Achievement_DescPerfectionistI),
                        defaultDisplay = true,
                        rewardQuantity = 10,
                        goal = 10,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.PerfectionistII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Stars"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    };
                case AchievementName.PerfectionistII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.PerfectionistII),
                        achievementProgressID = AchievementID(AchievementName.PerfectionistII),
                        title = Language.GetText(Language.Text.Achievement_NamePerfectionistII),
                        description = Language.GetText(Language.Text.Achievement_DescPerfectionistII),
                        defaultDisplay = false,
                        rewardQuantity = 10,
                        goal = 10,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.PerfectionistIII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Stars"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    };
                case AchievementName.PerfectionistIII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.PerfectionistIII),
                        achievementProgressID = AchievementID(AchievementName.PerfectionistIII),
                        title = Language.GetText(Language.Text.Achievement_NamePerfectionistIII),
                        description = Language.GetText(Language.Text.Achievement_DescPerfectionistIII),
                        defaultDisplay = false,
                        rewardQuantity = 10,
                        goal = 10,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.PerfectionistIV),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Stars"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    };
                case AchievementName.PerfectionistIV:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.PerfectionistIV),
                        achievementProgressID = AchievementID(AchievementName.PerfectionistIV),
                        title = Language.GetText(Language.Text.Achievement_NamePerfectionistIV),
                        description = Language.GetText(Language.Text.Achievement_DescPerfectionistIV),
                        defaultDisplay = false,
                        rewardQuantity = 10,
                        goal = 10,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.PerfectionistV),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Stars"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    };
                case AchievementName.PerfectionistV:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.PerfectionistV),
                        achievementProgressID = AchievementID(AchievementName.PerfectionistV),
                        title = Language.GetText(Language.Text.Achievement_NamePerfectionistV),
                        description = Language.GetText(Language.Text.Achievement_DescPerfectionistV),
                        defaultDisplay = false,
                        rewardQuantity = 10,
                        goal = 10,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.Final),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Stars"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    };
                #endregion
                #region Adventurer
                case AchievementName.AdventurerI:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.AdventurerI),
                        achievementProgressID = AchievementID(AchievementName.AdventurerI),
                        title = Language.GetText(Language.Text.Achievement_NameAdventurerI),
                        description = Language.GetText(Language.Text.Achievement_DescAdventurerI),
                        defaultDisplay = true,
                        rewardQuantity = 10,
                        goal = 1,
                        rewardItemID = CoinsReward,
                        nextAchievementID = AchievementID(AchievementName.AdventurerII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Sword"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallCoins")
                    };
                case AchievementName.AdventurerII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.AdventurerII),
                        achievementProgressID = AchievementID(AchievementName.AdventurerI),
                        title = Language.GetText(Language.Text.Achievement_NameAdventurerII),
                        description = Language.GetText(Language.Text.Achievement_DescAdventurerII),
                        defaultDisplay = false,
                        rewardQuantity = 50,
                        goal = 10,
                        rewardItemID = CoinsReward,
                        nextAchievementID = AchievementID(AchievementName.AdventurerIII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Sword"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallCoins")
                    };
                case AchievementName.AdventurerIII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.AdventurerIII),
                        achievementProgressID = AchievementID(AchievementName.AdventurerI),
                        title = Language.GetText(Language.Text.Achievement_NameAdventurerIII),
                        description = Language.GetText(Language.Text.Achievement_DescAdventurerIII),
                        defaultDisplay = false,
                        rewardQuantity = 100,
                        goal = 10,
                        rewardItemID = CoinsReward,
                        nextAchievementID = AchievementID(AchievementName.AdventurerIV),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Sword"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallCoins")
                    };
                case AchievementName.AdventurerIV:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.AdventurerIV),
                        achievementProgressID = AchievementID(AchievementName.AdventurerI),
                        title = Language.GetText(Language.Text.Achievement_NameAdventurerIV),
                        description = Language.GetText(Language.Text.Achievement_DescAdventurerIV),
                        defaultDisplay = false,
                        rewardQuantity = 150,
                        goal = 10,
                        rewardItemID = CoinsReward,
                        nextAchievementID = AchievementID(AchievementName.AdventurerV),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Sword"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallCoins")
                    };
                case AchievementName.AdventurerV:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.AdventurerV),
                        achievementProgressID = AchievementID(AchievementName.AdventurerI),
                        title = Language.GetText(Language.Text.Achievement_NameAdventurerV),
                        description = Language.GetText(Language.Text.Achievement_DescAdventurerV),
                        defaultDisplay = false,
                        rewardQuantity = 200,
                        goal = 10,
                        rewardItemID = CoinsReward,
                        nextAchievementID = AchievementID(AchievementName.AdventurerVI),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Sword"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallCoins")
                    };
                case AchievementName.AdventurerVI:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.AdventurerVI),
                        achievementProgressID = AchievementID(AchievementName.AdventurerI),
                        title = Language.GetText(Language.Text.Achievement_NameAdventurerVI),
                        description = Language.GetText(Language.Text.Achievement_DescAdventurerVI),
                        defaultDisplay = false,
                        rewardQuantity = 250,
                        goal = 10,
                        rewardItemID = CoinsReward,
                        nextAchievementID = AchievementID(AchievementName.Final),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Sword"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallCoins")
                    };
                #endregion
                #region TimeMaster
                case AchievementName.TimeMasterI:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.TimeMasterI),
                        achievementProgressID = AchievementID(AchievementName.TimeMasterI),
                        title = Language.GetText(Language.Text.Achievement_NameTimeMasterI),
                        description = Language.GetText(Language.Text.Achievement_DescTimeMasterI),
                        defaultDisplay = true,
                        rewardQuantity = 10,
                        goal = 1,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.TimeMasterII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Time"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    };
                case AchievementName.TimeMasterII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.TimeMasterII),
                        achievementProgressID = AchievementID(AchievementName.TimeMasterI),
                        title = Language.GetText(Language.Text.Achievement_NameTimeMasterII),
                        description = Language.GetText(Language.Text.Achievement_DescTimeMasterII),
                        defaultDisplay = false,
                        rewardQuantity = 30,
                        goal = 3,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.TimeMasterIII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Time"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    };
                case AchievementName.TimeMasterIII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.TimeMasterIII),
                        achievementProgressID = AchievementID(AchievementName.TimeMasterI),
                        title = Language.GetText(Language.Text.Achievement_NameTimeMasterIII),
                        description = Language.GetText(Language.Text.Achievement_DescTimeMasterIII),
                        defaultDisplay = false,
                        rewardQuantity = 50,
                        goal = 5,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.TimeMasterIV),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Time"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    };
                case AchievementName.TimeMasterIV:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.TimeMasterIV),
                        achievementProgressID = AchievementID(AchievementName.TimeMasterI),
                        title = Language.GetText(Language.Text.Achievement_NameTimeMasterIV),
                        description = Language.GetText(Language.Text.Achievement_DescTimeMasterIV),
                        defaultDisplay = false,
                        rewardQuantity = 100,
                        goal = 10,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.TimeMasterV),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Time"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_MediumGems")
                    };
                case AchievementName.TimeMasterV:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.TimeMasterV),
                        achievementProgressID = AchievementID(AchievementName.TimeMasterI),
                        title = Language.GetText(Language.Text.Achievement_NameTimeMasterV),
                        description = Language.GetText(Language.Text.Achievement_DescTimeMasterV),
                        defaultDisplay = false,
                        rewardQuantity = 500,
                        goal = 50,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.Final),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Time"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_MediumGems")
                    };
                #endregion
                #region Swordmaster
                case AchievementName.SwordsmasterI:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.SwordsmasterI),
                        achievementProgressID = AchievementID(AchievementName.SwordsmasterI),
                        title = Language.GetText(Language.Text.Achievement_NameSwordsmasterI),
                        description = Language.GetText(Language.Text.Achievement_DescSwordsmasterI),
                        defaultDisplay = true,
                        rewardQuantity = 5,
                        goal = 2,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.SwordsmasterI),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Sword"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    };
                case AchievementName.SwordsmasterII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.SwordsmasterI),
                        achievementProgressID = AchievementID(AchievementName.SwordsmasterI),
                        title = Language.GetText(Language.Text.Achievement_NameSwordsmasterI),
                        description = Language.GetText(Language.Text.Achievement_DescSwordsmasterI),
                        defaultDisplay = false,
                        rewardQuantity = 10,
                        goal = 3,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.SwordsmasterIII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Sword"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    };
                case AchievementName.SwordsmasterIII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.SwordsmasterIII),
                        achievementProgressID = AchievementID(AchievementName.SwordsmasterI),
                        title = Language.GetText(Language.Text.Achievement_NameSwordsmasterIII),
                        description = Language.GetText(Language.Text.Achievement_DescSwordsmasterIII),
                        defaultDisplay = false,
                        rewardQuantity = 25,
                        goal = 5,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.Final),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Sword"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    };
                #endregion
                #region Banker
                case AchievementName.BankerI:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.BankerI),
                        achievementProgressID = AchievementID(AchievementName.BankerI),
                        title = Language.GetText(Language.Text.Achievement_NameBankerI),
                        description = Language.GetText(Language.Text.Achievement_DescBankerI),
                        defaultDisplay = true,
                        rewardQuantity = 5 ,
                        goal = 100,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.BankerII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Coin"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    };
                case AchievementName.BankerII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.BankerII),
                        achievementProgressID = AchievementID(AchievementName.BankerI),
                        title = Language.GetText(Language.Text.Achievement_NameBankerII),
                        description = Language.GetText(Language.Text.Achievement_DescBankerII),
                        defaultDisplay = false,
                        rewardQuantity = 10,
                        goal = 500,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.BankerIII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Coin"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    };
                case AchievementName.BankerIII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.BankerIII),
                        achievementProgressID = AchievementID(AchievementName.BankerI),
                        title = Language.GetText(Language.Text.Achievement_NameBankerIII),
                        description = Language.GetText(Language.Text.Achievement_DescBankerIII),
                        defaultDisplay = false,
                        rewardQuantity = 25,
                        goal = 1000,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.BankerIV),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Coin"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    };
                case AchievementName.BankerIV:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.BankerIV),
                        achievementProgressID = AchievementID(AchievementName.BankerI),
                        title = Language.GetText(Language.Text.Achievement_NameBankerIV),
                        description = Language.GetText(Language.Text.Achievement_DescBankerIV),
                        defaultDisplay = false,
                        rewardQuantity = 50,
                        goal = 5000,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.BankerV),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Coin"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_MediumGems")
                    };
                case AchievementName.BankerV:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.BankerV),
                        achievementProgressID = AchievementID(AchievementName.BankerI),
                        title = Language.GetText(Language.Text.Achievement_NameBankerV),
                        description = Language.GetText(Language.Text.Achievement_DescBankerV),
                        defaultDisplay = false,
                        rewardQuantity = 100,
                        goal = 10000,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.Final),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Coin"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_MediumGems")
                    };
                #endregion
                #region Collectionist
                case AchievementName.CollectionistI:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.CollectionistI),
                        achievementProgressID = AchievementID(AchievementName.CollectionistI),
                        title = Language.GetText(Language.Text.Achievement_NameCollectionistI),
                        description = Language.GetText(Language.Text.Achievement_DescCollectionistI),
                        defaultDisplay = true,
                        rewardQuantity = 5,
                        goal = 1,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.CollectionistII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Collectionist"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    };
                case AchievementName.CollectionistII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.CollectionistII),
                        achievementProgressID = AchievementID(AchievementName.CollectionistI),
                        title = Language.GetText(Language.Text.Achievement_NameCollectionistII),
                        description = Language.GetText(Language.Text.Achievement_DescCollectionistII),
                        defaultDisplay = false,
                        rewardQuantity = 25,
                        goal = 10,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.CollectionistIII),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Collectionist"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    };
                case AchievementName.CollectionistIII:
                    return new Achievement.Achievement_Data
                    {
                        achievementID = AchievementID(AchievementName.CollectionistIII),
                        achievementProgressID = AchievementID(AchievementName.CollectionistI),
                        title = Language.GetText(Language.Text.Achievement_NameCollectionistIII),
                        description = Language.GetText(Language.Text.Achievement_DescCollectionistIII),
                        defaultDisplay = false,
                        rewardQuantity = 50,
                        goal = 25,
                        rewardItemID = GemsReward,
                        nextAchievementID = AchievementID(AchievementName.Final),
                        icon = Resources.Load<Sprite>("Achievements/AchievementIcon_Collectionist"),
                        rewardIcon = Resources.Load<Sprite>("Achievements/AchievementIcon_SmallGems")
                    }; 
                #endregion
                default:
                    return null;
            }
        }
    }
}
