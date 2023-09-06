using Items.Potions;

public class Potion_Defined : Potion
{
    public Potions.PotionName potion;

    private void Start()
    {
        data = Potions.GetData(potion);
    }

    private void Update()
    {
        UpdateQuantity();
    }
}
