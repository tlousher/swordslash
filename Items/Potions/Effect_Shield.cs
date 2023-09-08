using System.Collections;
using Character;
using Misc;
using UnityEngine;

public class Effect_Shield : Potion_Effect
{
    public Effect_Shield(int power, int duration, GameObject prefab) : base(power, duration, prefab) { }

    public Effect_Shield(int power_duration, GameObject prefab, Variation variation) : base(power_duration, prefab, variation) { }

    override public bool ActivateEffect()
    {
        if (!Player.instance.shield)
        {
            base.ActivateEffect();
            GameManager.instance.StartCoroutine(ShieldTimer());
            return true;
        }
        else
        {
            potionParent.GetComponent<Animator>().Play(shake);
            return false;
        }
    }

    public IEnumerator ShieldTimer()
    {
        Player.instance.shield = particleSystem;
        Player.instance.shieldPoints = power;
        Player.instance.shield.SetActive(true);
        yield return new WaitForSeconds(duration);
        Player.instance.shieldPoints = 0;
        Player.instance.shield = null;
    }
}
