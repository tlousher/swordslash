namespace Enemies
{
    public class TrainingEnemy : Enemy
    {
        protected override void AchievementCounterPlus()
        {
            PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementID(Achievements.Achievements.AchievementName.TrainingManiac));
        }
    }
}
