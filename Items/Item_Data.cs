using System;
using Gui;
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

        public ItemState State => (ItemState)PlayerPrefs2.GetItemState(itemID, (int)starterState);

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
            Acquired,
            Equipped,
            Locked
        }

        public static string StateToString(ItemState state, bool shopButton = false)
        {
            switch (state)
            {
                case ItemState.OnSale:
                    return Language.GetText(Language.Text.Shop_ItemOnSale);
                case ItemState.Acquired:
                    return Language.GetText(shopButton ? Language.Text.Shop_ItemAquired : Language.Text.Item_Aquired);
                case ItemState.Equipped:
                    return Language.GetText(shopButton ? Language.Text.Shop_ItemEquiped : Language.Text.Item_Equiped);
                case ItemState.Locked:
                    return Language.GetText(Language.Text.Item_Locked);
                default:
                    return null;
            }
        }
    }
}
