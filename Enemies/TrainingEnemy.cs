using System;
using Character;

namespace Enemies
{
    public class TrainingEnemy : Enemy
    {
        internal Action action;
        protected override void AchievementCounterPlus()
        {
            PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementID(Achievements.Achievements.AchievementName.TrainingManiac));
        }

        protected override void Update()
        {
            if (transform.position.y < Player.instance.sword.RangePositionY)
            {
                inRange = true;
                ShowAura();
            }
            else
            {
                inRange = false;
                HideAura();
            }
        }
        
        internal override void Die()
        {
            action?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
