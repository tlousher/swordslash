using Gui;
using Items;
using Items.Potions;
using UnityEngine;

namespace Vault
{
    public static class Potions
    {
        public const int Count = 9;
        public const string ItemType = "Potions";

        public enum PotionName
        {
            SmallLife,
            MediumLife,
            BigLife,
            SmallShield,
            MediumShield,
            BigShield,
            Energy,
            Immunity,
            Range
        }

        public static string PotionID(PotionName potionName)
        {
            return $"{ItemType}_{potionName}";
        }

        public static Potion_Effect GetEffect(string potion)
        {
            switch (potion)
            {
                case "Potions_SmallLife":
                    return new Effect_Life(1, Resources.Load<GameObject>("Items/Potions/Effects/VidaPequena"), Potion_Effect.Variation.Power);
                case "Potions_MediumLife":
                    return new Effect_Life(3, Resources.Load<GameObject>("Items/Potions/Effects/VidaMediana"), Potion_Effect.Variation.Power);
                case "Potions_BigLife":
                    return new Effect_Life(PlayerPrefs2.PlayerMaxHealth, Resources.Load<GameObject>("Items/Potions/Effects/VidaGigante"), Potion_Effect.Variation.Power);
                case "Potions_SmallShield":
                    return new Effect_Shield(1, 5, Resources.Load<GameObject>("Items/Potions/Effects/Shield_Magic"));
                case "Potions_MediumShield":
                    return new Effect_Shield(2, 5, Resources.Load<GameObject>("Items/Potions/Effects/Shield_Powerfull"));
                case "Potions_BigShield":
                    return new Effect_Shield(3, 5, Resources.Load<GameObject>("Items/Potions/Effects/Shield_Mistic"));
                case "Potions_Energy":
                    return new Effect_Life(5, Resources.Load<GameObject>("Items/Potions/Effects/StaminaRecharge"), Potion_Effect.Variation.Duration);
                case "Potions_Inmunity":
                    return new Effect_Life(5, Resources.Load<GameObject>("Items/Potions/Effects/InvulnerabilityZone"), Potion_Effect.Variation.Duration);
                case "Potions_Range":
                    return new Effect_Life(15, 5, Resources.Load<GameObject>("Items/Potions/Effects/VisionFlash"));
                default:
                    return null;
            }
        }

        public static Potion.PotionData GetData(PotionName potion)
        {
            switch (potion)
            {
                case PotionName.SmallLife:
                    return new Potion.PotionData
                    {
                        itemID = PotionID(PotionName.SmallLife),
                        itemName = Language.GetText(Language.Text.Potion_NameSmallLife),
                        description = Language.GetText(Language.Text.Potion_DescSmallLife),
                        price = 30,
                        starterState = ItemData.ItemState.Equipped,
                        cooldown = 1,
                        sprite = Resources.Load<Sprite>("Items/Potions/VidaPequena"),
                        shopX3 = Resources.Load<Sprite>("Items/Potions/GrupoVidaPequena"),
                        shopX5 = Resources.Load<Sprite>("Items/Potions/CajaVidaPequena"),
                        shopX10 = Resources.Load<Sprite>("Items/Potions/CofreVidaPequena")
                    };
                case PotionName.MediumLife:
                    return new Potion.PotionData
                    {
                        itemID = PotionID(PotionName.MediumLife),
                        itemName = Language.GetText(Language.Text.Potion_NameMediumLife),
                        description = Language.GetText(Language.Text.Potion_DescMediumLife),
                        price = 80,
                        starterState = ItemData.ItemState.Equipped,
                        cooldown = 1,
                        sprite = Resources.Load<Sprite>("Items/Potions/VidaMediana"),
                        shopX3 = Resources.Load<Sprite>("Items/Potions/GrupoVidaMediana"),
                        shopX5 = Resources.Load<Sprite>("Items/Potions/CajaVidaMediana"),
                        shopX10 = Resources.Load<Sprite>("Items/Potions/CofreVidaMediana")
                    };
                case PotionName.BigLife:
                    return new Potion.PotionData
                    {
                        itemID = PotionID(PotionName.BigLife),
                        itemName = Language.GetText(Language.Text.Potion_NameBigLife),
                        description = Language.GetText(Language.Text.Potion_DescBigLife),
                        price = 150,
                        starterState = ItemData.ItemState.Equipped,
                        cooldown = 1,
                        sprite = Resources.Load<Sprite>("Items/Potions/VidaGigante"),
                        shopX3 = Resources.Load<Sprite>("Items/Potions/GrupoVidaGigante"),
                        shopX5 = Resources.Load<Sprite>("Items/Potions/CajaVidaGigante"),
                        shopX10 = Resources.Load<Sprite>("Items/Potions/CofreVidaGigante")
                    };
                case PotionName.SmallShield:
                    return new Potion.PotionData
                    {
                        itemID = PotionID(PotionName.SmallShield),
                        itemName = Language.GetText(Language.Text.Potion_NameSmallShield),
                        description = Language.GetText(Language.Text.Potion_DescSmallShield),
                        price = 30,
                        starterState = ItemData.ItemState.Equipped,
                        cooldown = 1,
                        sprite = Resources.Load<Sprite>("Items/Potions/EscudoMagico"),
                        shopX3 = Resources.Load<Sprite>("Items/Potions/GrupoEscudoMagico"),
                        shopX5 = Resources.Load<Sprite>("Items/Potions/CajaEscudoMagico"),
                        shopX10 = Resources.Load<Sprite>("Items/Potions/CofreEscudoMagico")
                    };
                case PotionName.MediumShield:
                    return new Potion.PotionData
                    {
                        itemID = PotionID(PotionName.MediumShield),
                        itemName = Language.GetText(Language.Text.Potion_NameMediumShield),
                        description = Language.GetText(Language.Text.Potion_DescMediumShield),
                        price = 50,
                        starterState = ItemData.ItemState.Equipped,
                        cooldown = 1,
                        sprite = Resources.Load<Sprite>("Items/Potions/EscudoPoderoso"),
                        shopX3 = Resources.Load<Sprite>("Items/Potions/GrupoEscudoPoderoso"),
                        shopX5 = Resources.Load<Sprite>("Items/Potions/CajaEscudoPoderoso"),
                        shopX10 = Resources.Load<Sprite>("Items/Potions/CofreEscudoPoderoso")
                    };
                case PotionName.BigShield:
                    return new Potion.PotionData
                    {
                        itemID = PotionID(PotionName.BigShield),
                        itemName = Language.GetText(Language.Text.Potion_NameBigShield),
                        description = Language.GetText(Language.Text.Potion_DescBigShield),
                        price = 80,
                        starterState = ItemData.ItemState.Equipped,
                        cooldown = 1,
                        sprite = Resources.Load<Sprite>("Items/Potions/EscudoMistico"),
                        shopX3 = Resources.Load<Sprite>("Items/Potions/GrupoEscudoMistico"),
                        shopX5 = Resources.Load<Sprite>("Items/Potions/CajaEscudoMistico"),
                        shopX10 = Resources.Load<Sprite>("Items/Potions/CofreEscudoMistico")
                    };
                case PotionName.Energy:
                    return new Potion.PotionData
                    {
                        itemID = PotionID(PotionName.Energy),
                        itemName = Language.GetText(Language.Text.Potion_NameEnergy),
                        description = Language.GetText(Language.Text.Potion_DescEnergy),
                        price = 2,
                        payment = ItemData.PaymentMethod.Gems,
                        starterState = ItemData.ItemState.Equipped,
                        cooldown = 1,
                        sprite = Resources.Load<Sprite>("Items/Potions/EnergiaLiquida"),
                        shopX3 = Resources.Load<Sprite>("Items/Potions/GrupoEnergiaLiquida"),
                        shopX5 = Resources.Load<Sprite>("Items/Potions/CajaEnergiaLiquida"),
                        shopX10 = Resources.Load<Sprite>("Items/Potions/CofreEnergiaLiquida")
                    };
                case PotionName.Immunity:
                    return new Potion.PotionData
                    {
                        itemID = PotionID(PotionName.Immunity),
                        itemName = Language.GetText(Language.Text.Potion_NameInmunity),
                        description = Language.GetText(Language.Text.Potion_DescInmunity),
                        price = 150,
                        starterState = ItemData.ItemState.Equipped,
                        cooldown = 1,
                        sprite = Resources.Load<Sprite>("Items/Potions/TotemInmunidad"),
                        shopX3 = Resources.Load<Sprite>("Items/Potions/GrupoTotemInmunidad"),
                        shopX5 = Resources.Load<Sprite>("Items/Potions/CajaTotemInmunidad"),
                        shopX10 = Resources.Load<Sprite>("Items/Potions/CofreTotemInmunidad")
                    };
                case PotionName.Range:
                    return new Potion.PotionData
                    {
                        itemID = PotionID(PotionName.Range),
                        itemName = Language.GetText(Language.Text.Potion_NameRange),
                        description = Language.GetText(Language.Text.Potion_DescRange),
                        price = 150,
                        starterState = ItemData.ItemState.Equipped,
                        cooldown = 1,
                        sprite = Resources.Load<Sprite>("Items/Potions/VisonMejorada"),
                        shopX3 = Resources.Load<Sprite>("Items/Potions/GrupoVisonMejorada"),
                        shopX5 = Resources.Load<Sprite>("Items/Potions/CajaVisonMejorada"),
                        shopX10 = Resources.Load<Sprite>("Items/Potions/CofreVisonMejorada")
                    };
                default:
                    return null;
            }
        }
    }
}
