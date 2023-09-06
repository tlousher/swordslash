public class WaterEnemy : Enemy
{
    protected override void InitializeCollectibles()
    {
        collectibles.Add(Collectibles.GetData(Collectibles.CollectibleName.WaterOrbMini));
        collectibles.Add(Collectibles.GetData(Collectibles.CollectibleName.WaterOrb));
        collectibles.Add(Collectibles.GetData(Collectibles.CollectibleName.WaterOrbBig));
    }

    protected override void AchievementCounterPlus()
    {
        PlayerPrefs2.IncreaseAchievementProgress(Achievements.AchievementID(Achievements.AchievementName.WaterSlayerI));
    }
}
