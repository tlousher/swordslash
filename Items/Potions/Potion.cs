using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Items.Potions
{
    public class Potion : MonoBehaviour
    {
        private readonly int useHash = Animator.StringToHash("Use");
        private readonly int shakeHash = Animator.StringToHash("Shake");
        
        [Header("Components")]
        public TextMeshProUGUI quantity;
        [Header("Additional information")]
        public PotionData data;
        
        private Animator animator;
        private Image image;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            image = GetComponent<Image>();
        }

        public void UpdateSprite()
        {
            if (!image) image = GetComponent<Image>();
            try
            {
                image.sprite = data.sprite;
            }
            catch (MissingReferenceException missRef)
            {
                image.sprite = Resources.Load<Sprite>($"Items/Potions/{data.sprite.name}");
            }
        }

        private void Start()
        {
            UpdateQuantity();
        }

        public void ActivateEffect(AudioClip clip)
        {
            if (data.Quantity <= 1)
            {
                // No hay pociones
                animator.SetTrigger(shakeHash);
                return;
            }
            data.effect.potionParent = gameObject;
            if (!data.GetEffect.ActivateEffect()) return;
            
            // Se activa el efecto
            animator.SetTrigger(useHash);
            PlayOneShot(clip);
            data.Quantity--;
            UpdateQuantity();
        }

        public void PlayOneShot(AudioClip clip)
        {
            SceneMaster.instance.audioSource.PlayOneShot(clip);
        }

        protected void UpdateQuantity()
        {
            if (quantity != null)
            {
                quantity.text = data.Quantity.ToString(); 
            }
        }

        [System.Serializable]
        public class PotionData : ItemData
        {
            public int cooldown = 1;
            public Sprite shopX3;
            public Sprite shopX5;
            public Sprite shopX10;
            public Potion_Effect effect;
            public Potion_Effect GetEffect => effect ?? (effect = global::Vault.Potions.GetEffect(itemID));

            public int Quantity
            {
                get => PlayerPrefs2.GetPotionQuantity(itemID);
                set => PlayerPrefs2.SetPotionQuantity(itemID, value);
            }

            public void AddPotions(int value)
            {
                PlayerPrefs2.SetPotionQuantity(itemID, PlayerPrefs2.GetPotionQuantity(itemID) + value);
            }

            public void ReducePotions(int value = 1)
            {
                PlayerPrefs2.SetPotionQuantity(itemID, PlayerPrefs2.GetPotionQuantity(itemID) - value);
            }
        }
    }
}
