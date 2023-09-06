using Items.Potions;
using Misc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vault;

namespace Gui
{
    public class LevelIntro : MonoBehaviour
    {
        [Header("Components")]
        public TextMeshProUGUI title;
        public TextMeshProUGUI mision;
        public TextMeshProUGUI description;
        public TextMeshProUGUI potions;
        public TextMeshProUGUI start;
        public Potion primaryPotion;
        public Potion secondaryPotion;
        public TextMeshProUGUI primaryPotionQuantity;
        public TextMeshProUGUI secondaryPotionQuantity;
        public Image starOne;
        public Image starTwo;
        public Image starThree;
        [HideInInspector]
        public AudioSource audioSource;
        [Header("Sprites")]
        public Sprite starOn;
        public Sprite starOff;
        [Header("Prefabs")]
        public GameObject potionSelector;

        public Levels.Level_Data data;

        private void Start()
        {
            //Put all the right texts 
            title.text = $"{Language.GetText(Language.Text.LevelIntro_Title)} {data.number}";
            mision.text = $"{data.Objective}: <color=#F4D844>{data.mision} {data.MisionDesc}";
            description.text = data.description;
            potions.text = Language.GetText(Language.Text.LevelIntro_Potions);
            start.text = Language.GetText(Language.Text.LevelIntro_Start);

            //Put the right sprite on the stars
            var starsCount = PlayerPrefs2.GetLevelStars(data.LevelName);
            starOne.sprite = starsCount >= 1 ? starOn : starOff;
            starTwo.sprite = starsCount >= 2 ? starOn : starOff;
            starThree.sprite = starsCount >= 3 ? starOn : starOff;

            //Update equiped potions
            UpdatePotion();

            //Changes the event for the android escape button
            var escape = FindObjectOfType<AndroidEscape>();
            if (escape)
            {
                escape.SetNewEvent(CloseLevelIntro);
            }
        }

        private void UpdatePotion()
        {
            //Update equiped potions
            primaryPotion.data = PlayerPrefs2.GetEquippedPrimaryPotion();
            secondaryPotion.data = PlayerPrefs2.GetEquippedSecondaryPotion();
            //Update the potion sprites
            primaryPotion.UpdateSprite();
            secondaryPotion.UpdateSprite();
            //Update the potion quantity
            primaryPotionQuantity.text = primaryPotion.data.Quantity.ToString();
            secondaryPotionQuantity.text = secondaryPotion.data.Quantity.ToString();
        }

        public void StartLevel()
        {
            SceneMaster.instance.LoadLevel(data.LevelName);
        }

        public void OpenPotionSelector(int slot = 1)
        {
            PotionSelector selector = Instantiate(potionSelector).GetComponent<PotionSelector>();
            selector.selectedSlot = slot;
            selector.mainCanvas = transform.parent.parent.parent.gameObject;
            selector.onDestroy = UpdatePotion;
        }

        public void OpenPotionShop(Potion potion)
        {
            SceneMaster.instance.OpenPotionShop(potion, transform.parent.parent, UpdatePotion);
        }

        public void PlayOneShot(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }

        public void CloseLevelIntro()
        {
            Destroy(gameObject);
        }
    }
}
