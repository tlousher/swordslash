using System.Collections;
using UnityEngine;

public class Effect_Vision : Potion_Effect
{
    public Effect_Vision(int power, int duration, GameObject prefab) : base(power, duration, prefab) { }

    public Effect_Vision(int power_duration, GameObject prefab, Variation variation) : base(power_duration, prefab, variation) { }

    override public bool ActivateEffect()
    {
        if (!Player.instance.expandedVision)
        {
            base.ActivateEffect();
            GameManager.instance.StartCoroutine(VisionTimer());
            return true;
        }
        else
        {
            potionParent.GetComponent<Animator>().Play(shake);
            return false;
        }
    }

    public IEnumerator VisionTimer()
    {
        int originalRange = Player.instance.ExpandVision(power);
        yield return new WaitForSeconds(duration);
        Player.instance.ResetVision(originalRange);
    }
}
