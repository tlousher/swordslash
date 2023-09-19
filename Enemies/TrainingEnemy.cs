using Character;

namespace Enemies
{
    public class TrainingEnemy : Enemy
    {
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
    }
}
