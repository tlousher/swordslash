using System;
using UnityEngine;

namespace Items
{
    [Serializable]
    public class ItemData
    {
        public string itemID;
        public string itemName;
        public string description;
        public PaymentMethod payment = PaymentMethod.Coins;
        public int price;
        public ItemState starterState;
        public Sprite sprite;

        public ItemState State
        {
            get
            {
                return (ItemState)PlayerPrefs2.GetItemState(itemID, (int)starterState);
            }
        }

        public string GetStateString(bool shopButton = false)
        {
            return StateToString(State, shopButton);
        }

        public enum PaymentMethod
        {
            Coins,
            Gems
        }

        public enum ItemState
        {
            OnSale,
            Aquired,
            Equiped,
            Locked
        }

        public static string StateToString(ItemState state, bool shopButton = false)
        {
            switch (state)
            {
                case ItemState.OnSale:
                    return Language.GetText(Language.Text.Shop_ItemOnSale);
                case ItemState.Aquired:
                    if (shopButton)
                    {
                        return Language.GetText(Language.Text.Shop_ItemAquired);
                    }
                    else
                    {
                        return Language.GetText(Language.Text.Item_Aquired);
                    }
                case ItemState.Equiped:
                    if (shopButton)
                    {
                        return Language.GetText(Language.Text.Shop_ItemEquiped); 
                    }
                    else
                    {
                        return Language.GetText(Language.Text.Item_Equiped);
                    }
                case ItemState.Locked:
                    return Language.GetText(Language.Text.Item_Locked);
                default:
                    return null;
            }
        }
    }
}
