using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    public int healthPoints;
    public int shieldPoints;
    public float stamina;
    [Header("Items")]
    public Weapon sword;
    public Armor shirt;
    public Armor helmet;
    public SpriteRenderer helmet2;
    public Armor greaves;
    public Armor chestplate;
    public Armor boots;
    [Header("Prefabs")]
    public GameObject damageScreen;
    [HideInInspector]
    public GameObject shield;

    public static Player instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;

        // Sets all the equipement to the correct one
        #region Equipment
        sword.data = PlayerPrefs2.GetEquipedSword();
        sword.GetComponent<SpriteRenderer>().sprite = sword.data.sprite;
        ComboManager.instance.swordImage.sprite = sword.data.sprite;

        shirt.data = PlayerPrefs2.GetEquipedShirt();
        shirt.GetComponent<SpriteRenderer>().sprite = shirt.data.spriteBack;

        greaves.data = PlayerPrefs2.GetEquipedGreave();
        greaves.GetComponent<SpriteRenderer>().sprite = greaves.data.spriteBack;

        boots.data = PlayerPrefs2.GetEquipedBoots();
        boots.GetComponent<SpriteRenderer>().sprite = boots.data.spriteBack;

        Armor.Armor_Data tempArmor = PlayerPrefs2.GetEquipedHelmet();
        if (tempArmor != null)
        {
            helmet.data = tempArmor;
            helmet.GetComponent<SpriteRenderer>().sprite = helmet.data.spriteBack;
            if (helmet.data.sprite2Back != null)
            {
                helmet2.sprite = helmet.data.sprite2Back;
            }
        }
        else
        {
            SpriteRenderer spriteRenderer = helmet.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = null;
            helmet.GetComponent<SpriteRenderer>().color = Color.clear;
            helmet2.sprite = null;
            helmet2.color = Color.clear;
        }

        tempArmor = PlayerPrefs2.GetEquipedChestplate();
        if (tempArmor != null)
        {
            chestplate.data = tempArmor;
            chestplate.GetComponent<SpriteRenderer>().sprite = chestplate.data.spriteBack;
        }
        else
        {
            SpriteRenderer spriteRenderer = chestplate.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = null;
            chestplate.GetComponent<SpriteRenderer>().color = Color.clear;
        }
        #endregion

        // Sets the stamina and health to the maximum
        stamina = PlayerPrefs2.PlayerMaxStamina;
        healthPoints = PlayerPrefs2.PlayerMaxHealth;
        // Resets the shield
        shieldPoints = 0;
        shield = null;
        expandedVision = false;
    }

    private void Start()
    {
        StartCoroutine(StaminaRegeneration());
    }

    //Regenerates the stamina x points per second depending on PlayerPrefs2.PlayerStaminaRegen
    private IEnumerator StaminaRegeneration()
    {
        if (stamina < PlayerPrefs2.PlayerMaxStamina)
        {
            stamina = Mathf.Clamp(stamina + Time.deltaTime * PlayerPrefs2.PlayerStaminaRegen, 0, PlayerPrefs2.PlayerMaxStamina);
            yield return new WaitForEndOfFrame();
        }
        else
        {
            yield return new WaitUntil(() => stamina < PlayerPrefs2.PlayerMaxStamina);
        }

        StartCoroutine(StaminaRegeneration());
    }

    public void SwordAbility()
    {
        // Triggers the sword special ability
        // This ability if kills enemys it can't kill with slash method so it doesn't trigger another combo

        //Turn off the button and restart the combo bar
        ComboManager.instance.Reset();
    }

    public void Damage(int enemyPower)
    {
        if (shieldPoints < 1 || !shield)
        {
            healthPoints -= enemyPower;
            GameManager.instance.UpdateLife();
            GameObject newScreen = Instantiate(damageScreen, GameManager.instance.HUD.transform);
            Destroy(newScreen, newScreen.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
        }
        else
        {
            shieldPoints--;
            if (shield.transform.childCount > shieldPoints)
            {
                Destroy(shield.transform.GetChild(0).gameObject);
            }
            if (shieldPoints < 1)
            {
                shield.SetActive(false);
            }
        }
    }

    #region Vision potion
    [HideInInspector]
    public bool expandedVision;

    public int ExpandVision(int maxRange)
    {
        expandedVision = true;
        // Saves the original range value
        int originalRange = sword.data.range;
        // Changes the range to it's maximum value
        sword.data.range = maxRange;

        return originalRange;
    }

    public void ResetVision(int originalRange)
    {
        expandedVision = false;
        // Changes the range to it's original value
        sword.data.range = originalRange;
    }
    #endregion
}
