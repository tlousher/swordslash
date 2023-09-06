using UnityEngine;

public class SlimeEnemy : Enemy
{
    [Header("Special ability")]
    public GameObject slimeBall;
    [Tooltip("After the animation starts it will wait this time to intantiate the projectile.")]
    public float animationOffset;

    readonly int shootHash = Animator.StringToHash("Base Layer.Shoot");

    public override void Shoot()
    {
        GetComponent<Animator>().SetTrigger(shootHash);
        Invoke("InstantiateSlimeBall", animationOffset);
    }

    private void InstantiateSlimeBall()
    {
        Vector3 ballPosition = transform.position + Vector3.up * 1.3f;
        Instantiate(slimeBall, ballPosition, transform.rotation, transform.parent);
    }

    protected override void AchievementCounterPlus()
    {
        PlayerPrefs2.IncreaseAchievementProgress(Achievements.AchievementID(Achievements.AchievementName.SlimeSlayerI));
    }
}
