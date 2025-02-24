﻿using Vault;

namespace Enemies
{
    public class WoodEnemy : Enemy
    {
        protected override void InitializeCollectibles()
        {
            collectibles.Add(Collectibles.GetData(Collectibles.CollectibleName.WoodOrbMini));
            collectibles.Add(Collectibles.GetData(Collectibles.CollectibleName.WoodOrb));
            collectibles.Add(Collectibles.GetData(Collectibles.CollectibleName.WoodOrbBig));
        }
        
        protected override void OnEnable()
        {
            base.OnEnable();
            DiscoverMonster(Monsters.MonsterName.Wood);
        }

        protected override void AchievementCounterPlus()
        {
            PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementName.WoodSlayerI);
        }
    }
}
