using Character;
using UnityEngine;

public class Effect_Life : Potion_Effect
{
    public Effect_Life(int power, int duration, GameObject prefab) : base(power, duration, prefab) { }

    public Effect_Life(int power_duration, GameObject prefab, Variation variation) : base(power_duration, prefab, variation) { }

    override public bool ActivateEffect()
    {
        if (Player.instance.healthPoints < PlayerPrefs2.PlayerMaxHealth)
        {
            base.ActivateEffect();
            Player.instance.healthPoints = (Player.instance.healthPoints + power < PlayerPrefs2.PlayerMaxHealth) ? Player.instance.healthPoints + power : PlayerPrefs2.PlayerMaxHealth;
            return true;
        }
        else
        {
            potionParent.GetComponent<Animator>().Play(shake);
            return false;
        }
    }
}
