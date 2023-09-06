using Misc;
using UnityEngine;

namespace Enemies
{
    public class FireEnemy : Enemy
    {
        [Header("Special ability")]
        public int totalFireDamage;
        public GameObject fireScreen;

        protected override void ExplodeSpecial()
        {
            var newScreen = Instantiate(fireScreen, GameManager.instance.HUD.transform);
            newScreen.GetComponent<FireScreen>().fireDamage = totalFireDamage;
        }

        protected override void AchievementCounterPlus()
        {
            PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementID(Achievements.Achievements.AchievementName.FireSlayerI));
        }
    }
}
