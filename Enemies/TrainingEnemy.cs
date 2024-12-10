using System;
using Character;
using Vault;

namespace Enemies
{
    public class TrainingEnemy : Enemy
    {
        internal Action action;
        protected override void AchievementCounterPlus()
        {
            PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementName.TrainingManiac);
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
        
        protected override void OnEnable()
        {
            base.OnEnable();
            DiscoverMonster(Monsters.MonsterName.Training);
        }
        
        internal override void Die()
        {
            Invoke(nameof(ContinueTraining), 1f);
        }

        private void ContinueTraining()
        {
            action?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
