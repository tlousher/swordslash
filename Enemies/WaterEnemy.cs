using Collections;
using Vault;
using static Achievements.Achievements;

namespace Enemies
{
    public class WaterEnemy : Enemy
    {
        protected override void InitializeCollectibles()
        {
            collectibles.Add(Collectibles.GetData(Collectibles.CollectibleName.WaterOrbMini));
            collectibles.Add(Collectibles.GetData(Collectibles.CollectibleName.WaterOrb));
            collectibles.Add(Collectibles.GetData(Collectibles.CollectibleName.WaterOrbBig));
        }
        
        protected override void OnEnable()
        {
            base.OnEnable();
            DiscoverMonster(Monsters.MonsterName.Water);
        }

        protected override void AchievementCounterPlus()
        {
            PlayerPrefs2.IncreaseAchievementProgress(AchievementName.WaterSlayerI);
        }
    }
}
