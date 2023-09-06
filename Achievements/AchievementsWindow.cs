using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementsWindow : Window
{
    private const int AchievementSeparation = -480;
    public TextMeshProUGUI title;
    public Transform content;
    public GameObject achievementPrefab;

    protected override void Start()
    {
        base.Start();
        title.text = Language.GetText(Language.Text.Achievement_Title);
        List<Achievement.Achievement_Data> achievementsList = Achievements.GetAchievements();

        int counter = 0;
        foreach (Achievement.Achievement_Data achievementData in achievementsList)
        {
            if (PlayerPrefs2.GetAchievementDisplay(achievementData.achievementID, achievementData.defaultDisplay))
            {
                GameObject newAchievement = Instantiate(achievementPrefab, content);
                newAchievement.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, AchievementSeparation * counter);
                newAchievement.GetComponent<Achievement>().data = achievementData;
                counter++; 
            }
        }
    }
}
