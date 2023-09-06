using Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopFrame : MonoBehaviour
{
    [Header("Components")]
    public GameObject item;
    public TextMeshProUGUI price;
    public TextMeshProUGUI state;
    public Image frame;
    public Image block;
    public Sprite[] sprites;
    
    private ItemData itemData;

    internal static ShopFrame selectedFrame;

    private ItemData GetItemData(Shop.Categorie itemCategorie, int count)
    {
        switch (itemCategorie)
        {
            case Shop.Categorie.Espadas:
                Weapon sword = item.GetComponent<Weapon>();
                if (sword == null)
                {
                    sword = item.AddComponent<Weapon>();
                }
                sword.data = Swords.GetData((Swords.SwordName)count);
                return sword.data;
            case Shop.Categorie.Arcos:
                //SelectSword(selectedItem.GetComponentInChildren<SecondaryWeapon>());
                break;
            case Shop.Categorie.Martillos:
                //SelectSword(selectedItem.GetComponentInChildren<SecondaryWeapon>());
                break;
            case Shop.Categorie.Cascos:
                Armor helmet = item.GetComponent<Armor>();
                if (helmet == null)
                {
                    helmet = item.AddComponent<Armor>();
                }
                helmet.data = Helmets.GetData((Helmets.HelmetName)count);
                return helmet.data;
            case Shop.Categorie.Petos:
                Armor chestplate = item.GetComponent<Armor>();
                if (chestplate == null)
                {
                    chestplate = item.AddComponent<Armor>();
                }
                chestplate.data = Chestplates.GetData((Chestplates.ChestplateName)count);
                return chestplate.data;
            case Shop.Categorie.Camisas:
                Armor shirt = item.GetComponent<Armor>();
                if (shirt == null)
                {
                    shirt = item.AddComponent<Armor>();
                }
                shirt.data = Shirts.GetData((Shirts.ShirtName)count);
                return shirt.data;
            case Shop.Categorie.Grebas:
                Armor greaves = item.GetComponent<Armor>();
                if (greaves == null)
                {
                    greaves = item.AddComponent<Armor>();
                }
                greaves.data = Greaves.GetData((Greaves.GreaveName)count);
                return greaves.data;
            case Shop.Categorie.Botas:
                Armor boots = item.GetComponent<Armor>();
                if (boots == null)
                {
                    boots = item.AddComponent<Armor>();
                }
                boots.data = Boots.GetData((Boots.BootsName)count);
                return boots.data;
            case Shop.Categorie.Mascotas:
                //SelectSword(selectedItem.GetComponentInChildren<Pet>());
                break;
        }
        return null;
    }

    public void Select()
    {
        ShopFrame lastSelectedFrame = selectedFrame;
        selectedFrame = this;
        Shop.instance.SelectItem(item);

        if (lastSelectedFrame != null)
        {
            lastSelectedFrame.UpdateFrame(); 
        }
        UpdateFrame();
    }

    internal void Initialize(Shop.Categorie itemCategorie, int count)
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector3(440 * count, 0);
        itemData = GetItemData(itemCategorie, count);

        item.GetComponent<Image>().sprite = itemData.sprite;

        if (itemData.price < 0 || itemData.State != ItemData.ItemState.OnSale)
        {
            price.text = "--";
            price.gameObject.SetActive(false);
        }
        else
        {
            price.text = $"{itemData.price}";
        }
        UpdateFrame();
    }

    public void UpdateFrame()
    {
        ItemData.ItemState itemState = itemData.State;
        switch (itemState)
        {
            case ItemData.ItemState.OnSale:
                ChangeImage(3, 0);
                state.text = "";
                break;
            case ItemData.ItemState.Aquired:
                ChangeImage(4, 1);
                state.text = ItemData.StateToString(itemState);
                break;
            case ItemData.ItemState.Equiped:
                ChangeImage(4, 1);
                state.text = ItemData.StateToString(itemState);
                break;
            case ItemData.ItemState.Locked:
                ChangeImage(4, 2);
                state.text = ItemData.StateToString(itemState);
                break;
        }
    }

    private void ChangeImage(int selectedPos, int unselectedPos)
    {
        if (selectedFrame != null && selectedFrame.Equals(this))
        {
            frame.sprite = sprites[selectedPos];
            block.sprite = sprites[selectedPos];
        }
        else
        {
            frame.sprite = sprites[unselectedPos];
            block.sprite = sprites[unselectedPos];
        }
    }
}
