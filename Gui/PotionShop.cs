using Items;
using Items.Potions;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Gui
{
    public class PotionShop : MonoBehaviour
    {
        private readonly int exitHash = Animator.StringToHash("Exit");
        [Header("Components")]
        public TextMeshProUGUI title;
        public TextMeshProUGUI description;
        public TextMeshProUGUI quantity;
        public Image product;
        public Image productX3;
        public Image productX5;
        public Image productX10;
        public TextMeshProUGUI priceX3;
        public TextMeshProUGUI priceX5;
        public TextMeshProUGUI priceX10;
        public Image paymentX3;
        public Image paymentX5;
        public Image paymentX10;
        public Image optionX3;
        public Image optionX5;
        public Image optionX10;
        [Header("Sprites")]
        public Sprite coin;
        public Sprite gem;

        [HideInInspector]
        public Potion potion;
        public UnityAction onDestroy;

        private int selectedQuantity;

        private void Start()
        {
            // Put the information for the title
            var data = potion.data;
            title.text = data.itemName;
            description.text = data.description;
            product.sprite = data.sprite;
            quantity.text = data.Quantity.ToString();
            // Change the sprites for the available options
            productX3.sprite = data.shopX3;
            productX5.sprite = data.shopX5;
            productX10.sprite = data.shopX10;
            // Change the prices for the available options
            priceX3.text = data.price.ToString();
            // Se aplica un 10% de descuento
            priceX5.text = Mathf.CeilToInt(data.price * 4.5f / 3).ToString();
            // Se aplica un 20% de descuento
            priceX10.text = Mathf.CeilToInt(data.price * 8 / 3).ToString();
            // Place the sprite for the payment method
            paymentX3.sprite = data.payment == ItemData.PaymentMethod.Coins ? coin : gem;
            paymentX5.sprite = data.payment == ItemData.PaymentMethod.Coins ? coin : gem;
            paymentX10.sprite = data.payment == ItemData.PaymentMethod.Coins ? coin : gem;

            selectedQuantity = 3;
        }

        public void ChangeSelection(int newQuantity)
        {
            selectedQuantity = newQuantity;
            UpdateSelection();
        }

        public void PlayOneShot(AudioClip clip)
        {
            SceneMaster.instance.audioSource.PlayOneShot(clip);
        }

        private void UpdateSelection()
        {
            switch (selectedQuantity)
            {
                case 3:
                    AssignColors(ref optionX3, ref optionX5, ref optionX10);
                    break;
                case 5:
                    AssignColors(ref optionX5, ref optionX3, ref optionX10);
                    break;
                case 10:
                    AssignColors(ref optionX10, ref optionX5, ref optionX3);
                    break;
            }

            return;

            void AssignColors(ref Image selectedOption, ref Image option2, ref Image option3)
            {
                selectedOption.color = new Color(1, 1, 1, .6f);
                option2.color = new Color(.85f, .78f, .82f, .149f);
                option3.color = new Color(.85f, .78f, .82f, .149f);
            }
        }

        public void Buy()
        {
            if (potion.data.payment == ItemData.PaymentMethod.Coins)
            {
                if (PlayerPrefs2.Coins >= SelectedPrice())
                {
                    potion.data.AddPotions(selectedQuantity);
                    quantity.text = potion.data.Quantity.ToString();
                }
                else
                {
                    SceneMaster.instance.ShowMessage(Language.GetText(Language.Text.Shop_MessageError), Language.GetText(Language.Text.Shop_MessageNoMoney), SceneMaster.MessageSFX.Error);
                }
            }
            else
            {
                SceneMaster.instance.ShowConfirmation(Language.GetText(Language.Text.Shop_MessageNotice), Language.GetText(Language.Text.Shop_BuyConfirmation), BuyWithGems, null, SceneMaster.MessageSFX.Notice);
            }

            return;

            int SelectedPrice()
            {
                switch (selectedQuantity)
                {
                    case 3:
                        return int.Parse(priceX3.text);
                    case 5:
                        return int.Parse(priceX5.text);
                    case 10:
                        return int.Parse(priceX10.text);
                    default:
                        return 0;
                }
            }

            void BuyWithGems()
            {
                if (PlayerPrefs2.Gems >= SelectedPrice())
                {
                    potion.data.AddPotions(selectedQuantity);
                    quantity.text = potion.data.Quantity.ToString();
                }
                else
                {
                    SceneMaster.instance.ShowMessage(Language.GetText(Language.Text.Shop_MessageError), Language.GetText(Language.Text.Shop_MessageNoMoney), SceneMaster.MessageSFX.Error);
                }
            }
        }

        public void Close()
        {
            var animator = GetComponent<Animator>();
            animator.SetTrigger(exitHash);
            Destroy(gameObject, 1.1f);
            onDestroy?.Invoke();
        }
    }
}
