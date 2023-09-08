using Character;
using UnityEngine;

public class Effect_Stamina : Potion_Effect
{
    public Effect_Stamina(int power, int duration, GameObject prefab) : base(power, duration, prefab) { }

    public Effect_Stamina(int power_duration, GameObject prefab, Variation variation) : base(power_duration, prefab, variation) { }

    override public bool ActivateEffect()
    {
        if (Player.instance.stamina < PlayerPrefs2.PlayerMaxStamina)
        {
            base.ActivateEffect();
            Player.instance.stamina = PlayerPrefs2.PlayerMaxStamina;
            return true;
        }
        else
        {
            potionParent.GetComponent<Animator>().Play(shake);
            return false;
        }
    }
}
