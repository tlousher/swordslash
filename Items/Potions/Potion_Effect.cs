using Character;
using UnityEngine;

public class Potion_Effect
{
    protected readonly int shake = Animator.StringToHash("Base Layer.Shake"); 

    public int power;
    public int duration;
    public GameObject prefab;
    public GameObject particleSystem;
    public GameObject potionParent;

    const int Inactive = 2;

    public enum Variation
    {
        Power,
        Duration
    }

    public Potion_Effect(int power, int duration, GameObject prefab)
    {
        this.power = power;
        this.duration = duration;
        this.prefab = prefab ?? throw new System.ArgumentNullException(nameof(prefab));
    }

    public Potion_Effect(int power_duration, GameObject prefab, Variation variation)
    {
        power = variation == Variation.Power ? power_duration : Inactive;
        duration = variation == Variation.Duration ? power_duration : Inactive;
        this.prefab = prefab ?? throw new System.ArgumentNullException(nameof(prefab));
    }

    virtual public bool ActivateEffect()
    {
        particleSystem = Object.Instantiate(prefab, Player.instance.transform);
        Object.Destroy(particleSystem, duration);
        return true;
    }
}
