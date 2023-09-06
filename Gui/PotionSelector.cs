using Items.Potions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionSelector : Window
{
    readonly int exitLeftHash = Animator.StringToHash("Base Layer.ExitLeft");
    readonly int exitRightHash = Animator.StringToHash("Base Layer.ExitRight");
    readonly int enterLeftHash = Animator.StringToHash("Base Layer.EnterLeft");
    readonly int enterRightHash = Animator.StringToHash("Base Layer.EnterRight");
    [Header("Components")]
    public TextMeshProUGUI title;
    public Potion primaryPotion;
    public Potion secondaryPotion;
    public Image selectedSlot1;
    public Image selectedSlot2;
    [Header("Prefabs")]
    public GameObject[] stands;
    [Header("Sprite")]
    public Sprite selectedSprite;
    public Sprite deselectedSprite;

    [HideInInspector]
    public int selectedSlot;

    private int page;
    private GameObject stand;

    protected override void Start()
    {
        //Updates the main info
        title.text = Language.GetText(Language.Text.LevelIntro_Potions);
        UpdateSelectedSlot();
        page = 0;
        CreateStand();
        //Update equiped potions
        primaryPotion.data = PlayerPrefs2.GetEquippedPrimaryPotion();
        secondaryPotion.data = PlayerPrefs2.GetEquippedSecondaryPotion();
        //Update the potion sprites
        primaryPotion.UpdateSprite();
        secondaryPotion.UpdateSprite();
    }

    public void NextPage()
    {
        if (page >= stands.Length)
        {
            page = 0;
        }
        else
        {
            page++;
        }

        stand.GetComponent<Animator>().SetTrigger(exitLeftHash);
        Destroy(stand, 1.5f);
        CreateStand();
        stand.GetComponent<Animator>().SetBool(enterRightHash, true);
    }

    public void PreviousPage()
    {
        if (page <= 0)
        {
            page = stands.Length;
        }
        else
        {
            page--;
        }

        stand.GetComponent<Animator>().SetTrigger(exitRightHash);
        Destroy(stand, 1.5f);
        CreateStand();
        stand.GetComponent<Animator>().SetBool(exitLeftHash, true);
    }

    private void CreateStand()
    {
        stand = Instantiate(stands[page], transform);
        stand.GetComponent<PotionStand>().selector = this;
    }

    private void UpdateSelectedSlot()
    {
        if (selectedSlot == 1)
        {
            selectedSlot1.sprite = selectedSprite;
            selectedSlot2.sprite = deselectedSprite;
        }
        else
        {
            selectedSlot1.sprite = deselectedSprite;
            selectedSlot2.sprite = selectedSprite;
        }
    }

    public void SwitchSelection(int newSelection)
    {
        if (selectedSlot != newSelection)
        {
            selectedSlot = selectedSlot == 1 ? 2 : 1;
            UpdateSelectedSlot();
        }
    }

    public void SendPotion(Potion potion)
    {
        if (selectedSlot == 1)
        {
            primaryPotion.data = potion.data;
            PlayerPrefs2.SetEquippedPrimaryPotion(potion.data);
            primaryPotion.UpdateSprite();
        }
        else
        {
            secondaryPotion.data = potion.data;
            PlayerPrefs2.SetEquippedSecondaryPotion(potion.data);
            secondaryPotion.UpdateSprite();
        }
    }

    public void OpenPotionShop(Potion potion)
    {
        SceneMaster.instance.OpenPotionShop(potion, transform);
    }
}
