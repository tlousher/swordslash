using UnityEngine;
using Vault;

namespace Enemies
{
    public class SlimeEnemy : Enemy
    {
        [Header("Special ability")]
        public GameObject slimeBall;
        [Tooltip("After the animation starts it will wait this time to intantiate the projectile.")]
        public float animationOffset;

        private readonly int shootHash = Animator.StringToHash("Base Layer.Shoot");

        protected override void Shoot()
        {
            GetComponent<Animator>().SetTrigger(shootHash);
            Invoke(nameof(InstantiateSlimeBall), animationOffset);
        }

        private void InstantiateSlimeBall()
        {
            var myTransform = transform;
            var ballPosition = myTransform.position + Vector3.up * 1.3f;
            Instantiate(slimeBall, ballPosition, myTransform.rotation, myTransform.parent);
        }
        
        protected override void OnEnable()
        {
            base.OnEnable();
            DiscoverMonster(Monsters.MonsterName.Slime);
        }

        protected override void AchievementCounterPlus()
        {
            PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementName.SlimeSlayerI);
        }
    }
}
