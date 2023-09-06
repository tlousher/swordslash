using System.Collections;
using Misc;
using UnityEngine;

public class Effect_Totem : Potion_Effect
{
    public Effect_Totem(int power, int duration, GameObject prefab) : base(power, duration, prefab) { }

    public Effect_Totem(int power_duration, GameObject prefab, Variation variation) : base(power_duration, prefab, variation) { }

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
        Player.instance.shieldPoints = 10000;
        Player.instance.shield.SetActive(true);
        yield return new WaitForSeconds(duration);
        Player.instance.shieldPoints = 0;
        Player.instance.shield = null;
    }
}
