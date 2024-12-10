using Misc;
using UnityEngine;
using Vault;

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
        
        protected override void OnEnable()
        {
            base.OnEnable();
            DiscoverMonster(Monsters.MonsterName.Fire);
        }

        protected override void AchievementCounterPlus()
        {
            PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementName.FireSlayerI);
        }
    }
}
