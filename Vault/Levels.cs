using Gui;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public const int Count = 10;

    public enum LevelName
    {
        Level_ForestOne,
        Level_ForestTwo,
        Level_ForestThree,
        Level_ForestFour,
        Level_ForestFive,
        Level_ForestSix,
        Level_ForestSeven,
        Level_ForestEight,
        Level_ForestNine,
        Level_ForestTen,
        Map
    }

    public static Level_Data GetData(string level)
    {
        switch (level)
        {
            case "Forest_1":
                return GetData(LevelName.Level_ForestOne);
            case "Forest_2":
                return GetData(LevelName.Level_ForestTwo);
            case "Forest_3":
                return GetData(LevelName.Level_ForestThree);
            case "Forest_4":
                return GetData(LevelName.Level_ForestFour);
            case "Forest_5":
                return GetData(LevelName.Level_ForestFive);
            case "Forest_6":
                return GetData(LevelName.Level_ForestSix);
            case "Forest_7":
                return GetData(LevelName.Level_ForestSeven);
            case "Forest_8":
                return GetData(LevelName.Level_ForestEight);
            case "Forest_9":
                return GetData(LevelName.Level_ForestNine);
            case "Forest_10":
                return GetData(LevelName.Level_ForestTen);
            default:
                return GetData(LevelName.Level_ForestOne);
        }
    }

    public static Level_Data GetData(LevelName level)
    {
        switch (level)
        {
            case LevelName.Level_ForestOne:
                return new Level_Data
                {
                    playmode = GameManager.PlayMode.Horde,
                    mision = 15,
                    description = Language.GetText(Language.Text.LevelIntro_DescLevel_ForestOne),
                    number = 1,
                    area = Map.Area.Forest,
                    nextLevel = LevelName.Level_ForestTwo
                };
            case LevelName.Level_ForestTwo:
                return new Level_Data
                {
                    playmode = GameManager.PlayMode.Hunt,
                    mision = 15,
                    description = Language.GetText(Language.Text.LevelIntro_DescLevel_ForestTwo),
                    number = 2,
                    area = Map.Area.Forest,
                    nextLevel = LevelName.Level_ForestThree
                };
            case LevelName.Level_ForestThree:
                return new Level_Data
                {
                    playmode = GameManager.PlayMode.Time,
                    mision = 30,
                    description = Language.GetText(Language.Text.LevelIntro_DescLevel_ForestThree),
                    number = 3,
                    area = Map.Area.Forest,
                    nextLevel = LevelName.Level_ForestFour
                };
            case LevelName.Level_ForestFour:
                return new Level_Data
                {
                    playmode = GameManager.PlayMode.Horde,
                    mision = 20,
                    description = Language.GetText(Language.Text.LevelIntro_DescLevel_ForestFour),
                    number = 4,
                    area = Map.Area.Forest,
                    nextLevel = LevelName.Level_ForestFive
                };
            case LevelName.Level_ForestFive:
                return new Level_Data
                {
                    playmode = GameManager.PlayMode.Horde,
                    mision = 25,
                    description = Language.GetText(Language.Text.LevelIntro_DescLevel_ForestFive),
                    number = 5,
                    area = Map.Area.Forest,
                    nextLevel = LevelName.Level_ForestSix
                };
            case LevelName.Level_ForestSix:
                return new Level_Data
                {
                    playmode = GameManager.PlayMode.Time,
                    mision = 30,
                    description = Language.GetText(Language.Text.LevelIntro_DescLevel_ForestSix),
                    number = 6,
                    area = Map.Area.Forest,
                    nextLevel = LevelName.Level_ForestSeven
                };
            case LevelName.Level_ForestSeven:
                return new Level_Data
                {
                    playmode = GameManager.PlayMode.Time,
                    mision = 40,
                    description = Language.GetText(Language.Text.LevelIntro_DescLevel_ForestSeven),
                    number = 7,
                    area = Map.Area.Forest,
                    nextLevel = LevelName.Level_ForestEight
                };
            case LevelName.Level_ForestEight:
                return new Level_Data
                {
                    playmode = GameManager.PlayMode.Hunt,
                    mision = 25,
                    description = Language.GetText(Language.Text.LevelIntro_DescLevel_ForestEight),
                    number = 8,
                    area = Map.Area.Forest,
                    nextLevel = LevelName.Level_ForestNine
                };
            case LevelName.Level_ForestNine:
                return new Level_Data
                {
                    playmode = GameManager.PlayMode.Hunt,
                    mision = 15,
                    description = Language.GetText(Language.Text.LevelIntro_DescLevel_ForestNine),
                    number = 9,
                    area = Map.Area.Forest,
                    nextLevel = LevelName.Level_ForestTen
                };
            case LevelName.Level_ForestTen:
                return new Level_Data
                {
                    playmode = GameManager.PlayMode.Horde,
                    mision = 30,
                    description = Language.GetText(Language.Text.LevelIntro_DescLevel_ForestTen),
                    number = 10,
                    area = Map.Area.Forest,
                    nextLevel = LevelName.Map
                };
            default:
                return null;
        }
    }
    
    public class Level_Data
    {
        public GameManager.PlayMode playmode;
        public int mision;
        public int number;
        public Map.Area area;
        public LevelName nextLevel;
        public string description;

        public string LevelName
        {
            get
            {
                return $"{area}_{number}";
            }
        }

        public string Objective
        {
            get
            {
                switch (playmode)
                {
                    case GameManager.PlayMode.Horde:
                        return Language.GetText(Language.Text.LevelIntro_Survive);
                    case GameManager.PlayMode.Time:
                        return Language.GetText(Language.Text.LevelIntro_Survive);
                    case GameManager.PlayMode.Hunt:
                        return Language.GetText(Language.Text.LevelIntro_Defeat);
                    default:
                        return null;
                }
            }
        }

        public string MisionDesc
        {
            get
            {
                switch (playmode)
                {
                    case GameManager.PlayMode.Horde:
                        return Language.GetText(Language.Text.LevelIntro_Monsters);
                    case GameManager.PlayMode.Time:
                        return Language.GetText(Language.Text.LevelIntro_Seconds);
                    case GameManager.PlayMode.Hunt:
                        return Language.GetText(Language.Text.LevelIntro_Monsters);
                    default:
                        return null;
                }
            }
        }
    }
}
