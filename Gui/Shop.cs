using System.Collections;
using Gui;
using Items;
using Misc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    #region Variables
    [Header("General")]
    public TextMeshProUGUI coins;
    public TextMeshProUGUI gems;
    [Header("Canvas")]
    public TextMeshProUGUI canvasTitle;
    public TextMeshProUGUI canvasDescription;
    public TextMeshProUGUI canvasPower;
    public TextMeshProUGUI canvasRange;
    public TextMeshProUGUI canvasResistance;
    public Button canvasButton;
    public Image canvasSwordImage;
    public Image canvasShirtImage;
    public Image canvasBootsImage;
    public Image canvasGreaveImage;
    public Image canvasChestplateImage;
    public Image canvasHelmetImage;
    public Image canvasHelmet2Image;
    [Header("Stand")]
    public TextMeshProUGUI categorieLabel;
    public GameObject standContent;
    public GameObject framePrefab;
    [Header("Audio")]
    public AudioClip purchaseClip;
    public AudioClip equipClip;
    public AudioClip removeClip;
    public AudioClip lockedClip;
    public AudioClip errorClip;

    public static Shop instance;

    private ItemData.ItemState itemState;
    private GameObject selectedItem;
    private Categorie categorie;
    private int frames;
    private const Categorie LastCategorie = Categorie.Mascotas;

    public string CategorieString
    {
        get
        {
            return CategorieToString(categorie);
        }
    }
    #endregion

    #region Context menu
    [ContextMenu("Ganar 50 monedas")]
    public void AddCoins()
    {
        PlayerPrefs2.Coins += 50;
        UpdateCoinsText();
    }

    [ContextMenu("Ganar 10 gemas")]
    public void AddGems()
    {
        PlayerPrefs2.Gems += 10;
        UpdateGemsText();
    }

    [ContextMenu("Delete prefs")]
    public void DeletePrefs()
    {
        //Delete all of the PlayerPrefs settings by pressing this Button
        PlayerPrefs.DeleteAll();
        UpdateCoinsText();
        UpdateFrames();
        FindObjectOfType<ExpWheel>().UpdateWheel();
        Debug.Log("PlayerPrefs deleted");
    }

    [ContextMenu("Unlock Weapons")]
    public void UnlockWeapons()
    {
        PlayerPrefs2.SetItemState(Swords.GetData(Swords.SwordName.RebanadoraSlimes).itemID, ItemData.ItemState.Acquired);
        PlayerPrefs2.SetItemState(Swords.GetData(Swords.SwordName.Hidroblade).itemID, ItemData.ItemState.Acquired);
        PlayerPrefs2.SetItemState(Swords.GetData(Swords.SwordName.Inferno).itemID, ItemData.ItemState.Acquired);
        PlayerPrefs2.SetItemState(Swords.GetData(Swords.SwordName.EspadonBosque).itemID, ItemData.ItemState.Acquired);

        PlayerPrefs2.SetItemState(Helmets.GetData(Helmets.HelmetName.RebanadorSlimes).itemID, ItemData.ItemState.Acquired);
        PlayerPrefs2.SetItemState(Helmets.GetData(Helmets.HelmetName.Hidro).itemID, ItemData.ItemState.Acquired);
        PlayerPrefs2.SetItemState(Helmets.GetData(Helmets.HelmetName.Inferno).itemID, ItemData.ItemState.Acquired);
        PlayerPrefs2.SetItemState(Helmets.GetData(Helmets.HelmetName.Bosque).itemID, ItemData.ItemState.Acquired);

        PlayerPrefs2.SetItemState(Chestplates.GetData(Chestplates.ChestplateName.RebanadorSlimes).itemID, ItemData.ItemState.Acquired);
        PlayerPrefs2.SetItemState(Chestplates.GetData(Chestplates.ChestplateName.Hidro).itemID, ItemData.ItemState.Acquired);
        PlayerPrefs2.SetItemState(Chestplates.GetData(Chestplates.ChestplateName.Inferno).itemID, ItemData.ItemState.Acquired);
        PlayerPrefs2.SetItemState(Chestplates.GetData(Chestplates.ChestplateName.Bosque).itemID, ItemData.ItemState.Acquired);

        UpdateFrames();
        Debug.Log("Objetos de mision desbloqueadas!");
    }
    #endregion

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
    }

    private void Start()
    {
        categorie = 0;
        UpdateCategorie();
        UpdateCoinsText();
        UpdateGemsText();
        FindObjectOfType<ExpWheel>().UpdateWheel();
    }

    private void UpdateCoinsText()
    {
        coins.text = PlayerPrefs2.Coins.ToString();
    }

    private void UpdateGemsText()
    {
        gems.text = PlayerPrefs2.Gems.ToString();
    }

    #region Categories & Frames
    public void NextCategorie()
    {
        do
        {
            if (categorie < LastCategorie)
            {
                categorie++;
            }
            else
            {
                categorie = 0;
            }
        } while (categorie == Categorie.Martillos || categorie == Categorie.Mascotas || categorie == Categorie.Arcos);
        UpdateCategorie();
    }

    public void PreviousCategorie()
    {
        do
        {
            if (categorie > 0)
            {
                categorie--;
            }
            else
            {
                categorie = LastCategorie;
            }
        } while (categorie == Categorie.Martillos || categorie == Categorie.Mascotas || categorie == Categorie.Arcos);
        UpdateCategorie();
    }

    private void UpdateCategorie()
    {
        Deselect();
        categorieLabel.text = CategorieString;
        standContent.transform.parent.GetComponent<Drager>().ResetContent();
        CreateFrames();
    }

    private void CreateFrames()
    {
        switch (categorie)
        {
            case Categorie.Espadas:
                InstantiateFrames(Swords.Count);
                break;
            case Categorie.Arcos:
                InstantiateFrames(-1);
                break;
            case Categorie.Martillos:
                InstantiateFrames(-1);
                break;
            case Categorie.Cascos:
                InstantiateFrames(Helmets.Count);
                break;
            case Categorie.Petos:
                InstantiateFrames(Chestplates.Count);
                break;
            case Categorie.Camisas:
                InstantiateFrames(Shirts.Count);
                break;
            case Categorie.Grebas:
                InstantiateFrames(Greaves.Count);
                break;
            case Categorie.Botas:
                InstantiateFrames(Boots.Count);
                break;
            case Categorie.Mascotas:
                InstantiateFrames(-1);
                break;
            default:
                break;
        }
    }

    private void InstantiateFrames(int count)
    {
        ShopFrame.selectedFrame = null;
        frames = count;

        for (int i = 0; i <= count; i++)
        {
            GameObject frame = Instantiate(framePrefab, standContent.transform);
            frame.GetComponent<ShopFrame>().Initialize(categorie, i);
            frame.GetComponent<InputModifier>().mainCanvas = GetComponent<Canvas>();
        }
    }

    private void UpdateFrames()
    {
        for (int i = 0; i < standContent.transform.childCount; i++)
        {
            standContent.transform.GetChild(i).GetComponent<ShopFrame>().UpdateFrame();
        }
    }
    #endregion

    #region Selection
    public void SelectItem(GameObject item)
    {
        selectedItem = item;
        switch (categorie)
        {
            case Categorie.Espadas:
                SelectWeapon(selectedItem.GetComponentInChildren<Weapon>(), ref canvasSwordImage);
                break;
            case Categorie.Arcos:
                //SelectSword(selectedItem.GetComponentInChildren<SecondaryWeapon>());
                break;
            case Categorie.Martillos:
                //SelectSword(selectedItem.GetComponentInChildren<SecondaryWeapon>());
                break;
            case Categorie.Cascos:
                SelectArmor(selectedItem.GetComponentInChildren<Armor>(), ref canvasHelmetImage, ref canvasHelmet2Image);
                break;
            case Categorie.Petos:
                SelectArmor(selectedItem.GetComponentInChildren<Armor>(), ref canvasChestplateImage);
                break;
            case Categorie.Camisas:
                SelectArmor(selectedItem.GetComponentInChildren<Armor>(), ref canvasShirtImage);
                break;
            case Categorie.Grebas:
                SelectArmor(selectedItem.GetComponentInChildren<Armor>(), ref canvasGreaveImage);
                break;
            case Categorie.Botas:
                SelectArmor(selectedItem.GetComponentInChildren<Armor>(), ref canvasBootsImage);
                break;
            case Categorie.Mascotas:
                //SelectSword(selectedItem.GetComponentInChildren<Pet>());
                break;
            default:
                break;
        }
    }

    public void Deselect()
    {
        //Title & Description
        canvasTitle.text = Language.GetText(Language.Text.Shop_LabelItemName);
        canvasDescription.text = Language.GetText(Language.Text.Shop_LabelItemDesc);

        //Stats
        canvasRange.transform.parent.gameObject.SetActive(false);
        canvasRange.text = "";
        canvasPower.transform.parent.gameObject.SetActive(false);
        canvasPower.text = "";
        canvasResistance.transform.parent.gameObject.SetActive(false);
        canvasResistance.text = "";

        //Button
        canvasButton.GetComponentInChildren<TextMeshProUGUI>().text = Language.GetText(Language.Text.Shop_ItemOnSale);
        canvasButton.interactable = false;

        //Images
        canvasSwordImage.sprite = PlayerPrefs2.GetEquipedSword().sprite;
        canvasShirtImage.sprite = PlayerPrefs2.GetEquipedShirt().sprite;
        canvasGreaveImage.sprite = PlayerPrefs2.GetEquipedGreave().sprite;
        canvasBootsImage.sprite = PlayerPrefs2.GetEquipedBoots().sprite;
        Armor.Armor_Data tempArmor = PlayerPrefs2.GetEquipedChestplate();
        if (tempArmor == null)
        {
            canvasChestplateImage.sprite = null;
            canvasChestplateImage.color = Color.clear;
        }
        else
        {
            canvasChestplateImage.sprite = tempArmor.sprite;
            canvasChestplateImage.color = Color.white;
        }
        tempArmor = PlayerPrefs2.GetEquipedHelmet();
        if (tempArmor == null)
        {
            canvasHelmetImage.sprite = null;
            canvasHelmetImage.color = Color.clear;
            canvasHelmet2Image.sprite = null;
            canvasHelmet2Image.color = Color.clear;
        }
        else
        {
            canvasHelmetImage.sprite = tempArmor.sprite;
            canvasHelmetImage.color = Color.white;
            if (tempArmor.sprite2 != null)
            {
                canvasHelmet2Image.sprite = tempArmor.sprite2;
                canvasHelmet2Image.color = Color.white;
            }
            else
            {
                canvasHelmet2Image.sprite = null;
                canvasHelmet2Image.color = Color.clear;
            }
        }
    }

    public void SelectWeapon(Weapon weapon, ref Image weaponImage)
    {
        Weapon.Weapon_Data weaponData = weapon.data;

        //Title & Description
        canvasTitle.text = weaponData.itemName;
        canvasDescription.text = weaponData.description;

        //Power & Range
        canvasRange.transform.parent.gameObject.SetActive(true);
        canvasRange.text = weaponData.range.ToString();
        canvasPower.transform.parent.gameObject.SetActive(true);
        canvasPower.text = weaponData.power.ToString();

        //Button
        canvasButton.GetComponentInChildren<TextMeshProUGUI>().text = weaponData.GetStateString(true);
        canvasButton.interactable = weaponData.State != ItemData.ItemState.Locked;

        //Image
        weaponImage.sprite = weaponData.sprite;

        //ItemState
        itemState = weaponData.State;
    }

    public void SelectArmor(Armor armor, ref Image armorImage)
    {
        Armor.Armor_Data armorData = armor.data;

        //Title & Description
        canvasTitle.text = armorData.itemName;
        canvasDescription.text = armorData.description;

        //Power & Range
        canvasResistance.transform.parent.gameObject.SetActive(true);
        canvasResistance.text = armorData.resistance.ToString();

        //Button
        canvasButton.GetComponentInChildren<TextMeshProUGUI>().text = armorData.GetStateString(true);
        canvasButton.interactable = armorData.State != ItemData.ItemState.Locked;

        //Image
        armorImage.sprite = armorData.sprite;
        armorImage.color = Color.white;

        //ItemState
        itemState = armorData.State;
    }

    public void SelectArmor(Armor armor, ref Image armorImage, ref Image armorImage2)
    {
        SelectArmor(armor, ref armorImage);

        if (armor.data.sprite2 != null)
        {
            armorImage2.sprite = armor.data.sprite2;
            armorImage2.color = Color.white;
        }
        else
        {
            armorImage2.sprite = null;
            armorImage2.color = Color.clear;
        }
    }
    #endregion

    #region Canvas button press
    //Cuando equipo un objeto este deberia automaticamente buscar el objeto equipado y desequiparlo.
    public void CanvasButtonPress()
    {
        switch (categorie)
        {
            case Categorie.Espadas:
                CanvasButton_Sword();
                break;
            case Categorie.Arcos:

                break;
            case Categorie.Martillos:

                break;
            case Categorie.Cascos:
                CanvasButton_Helmet();
                break;
            case Categorie.Camisas:
                CanvasButton_Shirt();
                break;
            case Categorie.Petos:
                CanvasButton_Chestplate();
                break;
            case Categorie.Grebas:
                CanvasButton_Greave();
                break;
            case Categorie.Botas:
                CanvasButton_Boots();
                break;
            case Categorie.Mascotas:

                break;
            default:
                break;
        }
    }

    private void CanvasButton_Sword()
    {
        switch (itemState)
        {
            case ItemData.ItemState.OnSale:
                Weapon.Weapon_Data weapon = ShopFrame.selectedFrame.item.GetComponent<Weapon>().data;
                //Buys the item
                BuyItem(weapon);
                //Sets the item to be discovered
                CollectionPrefs.SetCollectionState(weapon.itemID, CollectionPrefs.CollectionState.Discovered);
                break;
            case ItemData.ItemState.Acquired:
                EquipWeapon(ShopFrame.selectedFrame.item.GetComponent<Weapon>().data, PlayerPrefs2.GetEquipedSword());
                EquipedSuccess(equipClip);
                break;
            case ItemData.ItemState.Equipped:
                if (PlayerPrefs2.GetItemState(Swords.GetData(Swords.SwordName.EspadaMadera).itemID, ItemData.ItemState.Equipped) != ItemData.ItemState.Equipped)
                {
                    EquipWeapon(Swords.GetData(Swords.SwordName.EspadaMadera), PlayerPrefs2.GetEquipedSword());
                    EquipedSuccess(removeClip);
                }
                else
                {
                    SceneMaster.instance.ShowMessage(Language.GetText(Language.Text.Shop_MessageWarning), Language.GetText(Language.Text.Shop_MessageNoSword), SceneMaster.MessageSfx.Error);
                }
                break;
            case ItemData.ItemState.Locked:
                SceneMaster.instance.ShowMessage(Language.GetText(Language.Text.Shop_MessageError), Language.GetText(Language.Text.Shop_MessageLockedItem), SceneMaster.MessageSfx.Other, lockedClip);
                break;
        }
    }

    private void CanvasButton_Shirt()
    {
        switch (itemState)
        {
            case ItemData.ItemState.OnSale:
                BuyItem(ShopFrame.selectedFrame.item.GetComponent<Armor>().data);
                break;
            case ItemData.ItemState.Acquired:
                EquipArmor(ShopFrame.selectedFrame.item.GetComponent<Armor>().data, PlayerPrefs2.GetEquipedShirt());
                EquipedSuccess(equipClip);
                break;
            case ItemData.ItemState.Equipped:
                if (PlayerPrefs2.GetItemState(Shirts.GetData(Shirts.ShirtName.Inicial).itemID, ItemData.ItemState.Equipped) != ItemData.ItemState.Equipped)
                {
                    EquipArmor(Shirts.GetData(Shirts.ShirtName.Inicial), PlayerPrefs2.GetEquipedShirt());
                    EquipedSuccess(removeClip);
                }
                else
                {
                    SceneMaster.instance.ShowMessage(Language.GetText(Language.Text.Shop_MessageWarning), Language.GetText(Language.Text.Shop_MessageNoShirt), SceneMaster.MessageSfx.Error);
                }
                break;
            case ItemData.ItemState.Locked:
                SceneMaster.instance.ShowMessage(Language.GetText(Language.Text.Shop_MessageError), Language.GetText(Language.Text.Shop_MessageLockedItem), SceneMaster.MessageSfx.Other, lockedClip);
                break;
        }
    }

    private void CanvasButton_Helmet()
    {
        switch (itemState)
        {
            case ItemData.ItemState.OnSale:
                BuyItem(ShopFrame.selectedFrame.item.GetComponent<Armor>().data);
                break;
            case ItemData.ItemState.Acquired:
                EquipArmor(ShopFrame.selectedFrame.item.GetComponent<Armor>().data, PlayerPrefs2.GetEquipedHelmet());
                EquipedSuccess(equipClip);
                break;
            case ItemData.ItemState.Equipped:
                EquipArmor(null, PlayerPrefs2.GetEquipedHelmet());
                EquipedSuccess(removeClip);
                break;
            case ItemData.ItemState.Locked:
                SceneMaster.instance.ShowMessage(Language.GetText(Language.Text.Shop_MessageError), Language.GetText(Language.Text.Shop_MessageLockedItem), SceneMaster.MessageSfx.Other, lockedClip);
                break;
        }
    }

    private void CanvasButton_Greave()
    {
        switch (itemState)
        {
            case ItemData.ItemState.OnSale:
                BuyItem(ShopFrame.selectedFrame.item.GetComponent<Armor>().data);
                break;
            case ItemData.ItemState.Acquired:
                EquipArmor(ShopFrame.selectedFrame.item.GetComponent<Armor>().data, PlayerPrefs2.GetEquipedGreave());
                EquipedSuccess(equipClip);
                break;
            case ItemData.ItemState.Equipped:
                if (PlayerPrefs2.GetItemState(Greaves.GetData(Greaves.GreaveName.Inicial).itemID, ItemData.ItemState.Equipped) != ItemData.ItemState.Equipped)
                {
                    EquipArmor(Greaves.GetData(Greaves.GreaveName.Inicial), PlayerPrefs2.GetEquipedGreave());
                    EquipedSuccess(removeClip);
                }
                else
                {
                    SceneMaster.instance.ShowMessage(Language.GetText(Language.Text.Shop_MessageWarning), Language.GetText(Language.Text.Shop_MessageNoGreave), SceneMaster.MessageSfx.Error);
                }
                break;
            case ItemData.ItemState.Locked:
                SceneMaster.instance.ShowMessage(Language.GetText(Language.Text.Shop_MessageError), Language.GetText(Language.Text.Shop_MessageLockedItem), SceneMaster.MessageSfx.Other, lockedClip);
                break;
        }
    }

    private void CanvasButton_Chestplate()
    {
        switch (itemState)
        {
            case ItemData.ItemState.OnSale:
                BuyItem(ShopFrame.selectedFrame.item.GetComponent<Armor>().data);
                break;
            case ItemData.ItemState.Acquired:
                EquipArmor(ShopFrame.selectedFrame.item.GetComponent<Armor>().data, PlayerPrefs2.GetEquipedChestplate());
                EquipedSuccess(equipClip);
                break;
            case ItemData.ItemState.Equipped:
                EquipArmor(null, PlayerPrefs2.GetEquipedChestplate());
                EquipedSuccess(removeClip);
                break;
            case ItemData.ItemState.Locked:
                SceneMaster.instance.ShowMessage(Language.GetText(Language.Text.Shop_MessageError), Language.GetText(Language.Text.Shop_MessageLockedItem), SceneMaster.MessageSfx.Other, lockedClip);
                break;
        }
    }

    private void CanvasButton_Boots()
    {
        switch (itemState)
        {
            case ItemData.ItemState.OnSale:
                BuyItem(ShopFrame.selectedFrame.item.GetComponent<Armor>().data);
                break;
            case ItemData.ItemState.Acquired:
                EquipArmor(ShopFrame.selectedFrame.item.GetComponent<Armor>().data, PlayerPrefs2.GetEquipedBoots());
                EquipedSuccess(equipClip);
                break;
            case ItemData.ItemState.Equipped:
                if (PlayerPrefs2.GetItemState(Boots.GetData(Boots.BootsName.Inicial).itemID, ItemData.ItemState.Equipped) != ItemData.ItemState.Equipped)
                {
                    EquipArmor(Boots.GetData(Boots.BootsName.Inicial), PlayerPrefs2.GetEquipedBoots());
                    EquipedSuccess(removeClip);
                }
                else
                {
                    SceneMaster.instance.ShowMessage(Language.GetText(Language.Text.Shop_MessageWarning), Language.GetText(Language.Text.Shop_MessageNoBoots), SceneMaster.MessageSfx.Error);
                }
                break;
            case ItemData.ItemState.Locked:
                SceneMaster.instance.ShowMessage(Language.GetText(Language.Text.Shop_MessageError), Language.GetText(Language.Text.Shop_MessageLockedItem), SceneMaster.MessageSfx.Other, lockedClip);
                break;
        }
    }

    private void BuyItem(ItemData itemData)
    {
        int price = int.Parse(ShopFrame.selectedFrame.price.text);
        if (price <= PlayerPrefs2.Coins)
        {
            PlayerPrefs2.Coins -= price;
            UpdateCoinsText();
            PlayerPrefs2.SetItemState(itemData.itemID, ItemData.ItemState.Acquired);
            ShopFrame.selectedFrame.UpdateFrame();
            SelectItem(selectedItem);
            GetComponent<AudioSource>().PlayOneShot(purchaseClip);
            PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementID(Achievements.Achievements.AchievementName.CollectionistI));
        }
        else
        {
            SceneMaster.instance.ShowMessage(Language.GetText(Language.Text.Shop_MessageError), Language.GetText(Language.Text.Shop_MessageNoMoney), SceneMaster.MessageSfx.Error);
        }
    }

    private void EquipWeapon(Weapon.Weapon_Data newWeapon, Weapon.Weapon_Data oldWeapon)
    {
        switch (categorie)
        {
            case Categorie.Espadas:
                PlayerPrefs2.SetEquipedSword(newWeapon);
                break;
        }
        SwitchEquipedItem(newWeapon, oldWeapon);
    }

    private void EquipArmor(Armor.Armor_Data newArmor, Armor.Armor_Data oldArmor)
    {
        switch (categorie)
        {
            case Categorie.Camisas:
                PlayerPrefs2.SetEquipedShirt(newArmor);
                break;
            case Categorie.Botas:
                PlayerPrefs2.SetEquipedBoots(newArmor);
                break;
            case Categorie.Cascos:
                PlayerPrefs2.SetEquipedHelmet(newArmor);
                break;
            case Categorie.Grebas:
                PlayerPrefs2.SetEquipedGreave(newArmor);
                break;
            case Categorie.Petos:
                PlayerPrefs2.SetEquipedChestplate(newArmor);
                break;
        }
        SwitchEquipedItem(newArmor, oldArmor);
    }

    private static void SwitchEquipedItem(ItemData newWeapon, ItemData oldWeapon)
    {
        if (oldWeapon != null)
        {
            PlayerPrefs2.SetItemState(oldWeapon.itemID, ItemData.ItemState.Acquired);
        }
        if (newWeapon != null)
        {
            PlayerPrefs2.SetItemState(newWeapon.itemID, ItemData.ItemState.Equipped);
        }
    }

    private void EquipedSuccess(AudioClip clip)
    {
        UpdateFrames();
        SelectItem(selectedItem);
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
    #endregion

    public enum Categorie
    {
        Espadas,
        Cascos,
        Camisas,
        Petos,
        Grebas,
        Botas,
        Arcos,
        Martillos,
        Mascotas
    }

    public static string CategorieToString(Categorie cat)
    {
        switch (cat)
        {
            case Categorie.Espadas:
                return Language.GetText(Language.Text.Shop_CategorieSword);
            case Categorie.Arcos:
                return Language.GetText(Language.Text.Shop_CategorieBow);
            case Categorie.Martillos:
                return Language.GetText(Language.Text.Shop_CategorieHammer);
            case Categorie.Cascos:
                return Language.GetText(Language.Text.Shop_CategorieHelmet);
            case Categorie.Petos:
                return Language.GetText(Language.Text.Shop_CategorieUpper);
            case Categorie.Camisas:
                return Language.GetText(Language.Text.Shop_CategorieShirt);
            case Categorie.Grebas:
                return Language.GetText(Language.Text.Shop_CategoriePants);
            case Categorie.Botas:
                return Language.GetText(Language.Text.Shop_CategorieBoots);
            case Categorie.Mascotas:
                return Language.GetText(Language.Text.Shop_CategoriePet);
            default:
                return null;
        }
    }
}
