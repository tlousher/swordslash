using Items.Potions;
using UnityEngine;

public class PotionStand : MonoBehaviour
{
    public PotionSelector selector;

    public void SendPotion(Potion potion)
    {
        selector.SendPotion(potion);
    }
}
