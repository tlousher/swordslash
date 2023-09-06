using System.Collections;
using Misc;
using UnityEngine;

public class FireEnemy : Enemy
{
    [Header("Special ability")]
    public int totalFireDamage;
    public GameObject fireScreen;

    public override void ExplodeSpecial()
    {
        GameObject newScreen = Instantiate(fireScreen, GameManager.instance.HUD.transform);
        newScreen.GetComponent<FireScreen>().fireDamage = totalFireDamage;
    }

    protected override void AchievementCounterPlus()
    {
        PlayerPrefs2.IncreaseAchievementProgress(Achievements.AchievementID(Achievements.AchievementName.FireSlayerI));
    }
}
