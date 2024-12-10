using System.Collections.Generic;
using Gui;
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
        var achievementsList = Achievements.Achievements.GetAchievements();

        var counter = 0;
        foreach (var achievementData in achievementsList)
        {
            if (!PlayerPrefs2.GetAchievementDisplay(achievementData.achievementID, achievementData.defaultDisplay))
                continue;
            
            var newAchievement = Instantiate(achievementPrefab, content);
            newAchievement.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, AchievementSeparation * counter);
            newAchievement.GetComponent<Achievement>().data = achievementData;
            counter++;
        }
    }
}
