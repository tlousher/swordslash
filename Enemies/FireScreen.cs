using Character;
using Misc;
using UnityEngine;

public class FireScreen : MonoBehaviour
{
    public int fireDamage;

    private float timer;
    private int counter;

    private const float TimerReset = 2;

    private void Awake()
    {
        timer = TimerReset;
        counter = 0;
    }

    private void Update()
    {
        if (GameManager.instance.IsPlaying)
        {
            if (timer > fireDamage)
            {
                Player.instance.Damage(1);
                timer = TimerReset;
                counter++;
                if (counter >= fireDamage)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }
}
