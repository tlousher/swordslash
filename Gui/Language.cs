using UnityEngine;

[RequireComponent(typeof(TMPro.TextMeshProUGUI))]
public class Language : MonoBehaviour
{
    public Text text;
    private Languages selectedLanguage;

    private void Awake()
    {
        UpdateText();
    }

    private void Update()
    {
        if (selectedLanguage != PlayerPrefs2.SelectedLanguage)
        {
            UpdateText();
        }
    }

    private void UpdateText()
    {
        selectedLanguage = PlayerPrefs2.SelectedLanguage;
        GetComponent<TMPro.TextMeshProUGUI>().text = GetText(text);
    }

    public enum Languages
    {
        Spanish,
        English
    }

    public enum Text
    {
        #region Menu principal
        MainMenu_TouchStart,
        MainMenu_Play,
        MainMenu_Options,
        MainMenu_Exit,
        #endregion
        #region Opciones
        Options_Lenguage,
        Options_Music,
        Options_SoundFx,
        Options_Credits,
        Options_Developer1,
        Options_Developer2,
        #endregion
        #region Nivel
        Level_Victory,
        Level_Defeat,
        Level_Restart,
        Level_Continue,
        Level_Map,
        Level_Xp,
        Level_Score,
        Level_Pause,
        #endregion
        #region Mapas
        MapName_Forest,
        #endregion
        #region Tienda
        Shop_Title,
        Shop_Level,
        Shop_ItemOnSale,
        Shop_ItemAquired,
        Shop_ItemEquiped,
        Shop_LabelItemName,
        Shop_LabelItemDesc,
        Shop_CategorieSword,
        Shop_CategorieBow,
        Shop_CategorieHammer,
        Shop_CategoriePotion,
        Shop_CategorieHelmet,
        Shop_CategorieUpper,
        Shop_CategorieShirt,
        Shop_CategoriePants,
        Shop_CategorieBoots,
        Shop_CategoriePet,
        Shop_MessageNoMoney,
        Shop_MessageNoGems,
        Shop_MessageNoSword,
        Shop_MessageNoShirt,
        Shop_MessageNoGreave,
        Shop_MessageNoBoots,
        Shop_MessageLockedItem,
        Shop_MessageWarning,
        Shop_MessageError,
        Shop_MessageNotice,
        Shop_BuyConfirmation,
        #endregion
        #region Collection
        Collection_Index,
        Collection_Monsters,
        Collection_Orbs,
        Collection_Weapons,
        Collection_WeaponAbility,
        Collection_MonsterAbility,
        Collection_OrbMonsterBase,
        Collection_UnknownName,
        Collection_UnknownDesc,
        Collection_UnknownExtra,
        #endregion
        #region Estados de objeto
        Item_Aquired,
        Item_Equiped,
        Item_Locked,
        Rarity_Uncommon,
        Rarity_Common,
        Rarity_Rare,
        Rarity_Legendary,
        #endregion
        #region Espadas
        Sword_NameEspadaMadera,
        Sword_NameEspadaHierro,
        Sword_NameAqua,
        Sword_NameOscuridadDemoniaca,
        Sword_NameEspadaSombras,
        Sword_NameEspadonCelestial,
        Sword_NameVolcanora,
        Sword_NameHidroblade,
        Sword_NameInferno,
        Sword_NameRebanadoraSlimes,
        Sword_NameEspadonBosque,
        Sword_NameEspadaCristal,
        Sword_NameEspadaPaladin,
        Sword_DescEspadaMadera,
        Sword_DescEspadaHierro,
        Sword_DescAqua,
        Sword_DescOscuridadDemoniaca,
        Sword_DescEspadaSombras,
        Sword_DescEspadonCelestial,
        Sword_DescVolcanora,
        Sword_DescHidroblade,
        Sword_DescInferno,
        Sword_DescRebanadoraSlimes,
        Sword_DescEspadonBosque,
        Sword_DescEspadaCristal,
        Sword_DescEspadaPaladin,
        Sword_AbilEspadaMadera,
        Sword_AbilEspadaHierro,
        Sword_AbilAqua,
        Sword_AbilOscuridadDemoniaca,
        Sword_AbilEspadaSombras,
        Sword_AbilEspadonCelestial,
        Sword_AbilVolcanora,
        Sword_AbilHidroblade,
        Sword_AbilInferno,
        Sword_AbilRebanadoraSlimes,
        Sword_AbilEspadonBosque,
        Sword_AbilEspadaCristal,
        Sword_AbilEspadaPaladin,
        #endregion
        #region Camisas
        Shirt_NameCampesino,
        Shirt_NameChaleco,
        Shirt_NameCuelloAlto,
        Shirt_NameInicial,
        Shirt_NameJubonCamisa,
        Shirt_NameLeñador,
        Shirt_NameMangasCortas,
        Shirt_NameMercenario,
        Shirt_DescCampesino,
        Shirt_DescChaleco,
        Shirt_DescCuelloAlto,
        Shirt_DescInicial,
        Shirt_DescJubonCamisa,
        Shirt_DescLeñador,
        Shirt_DescMangasCortas,
        Shirt_DescMercenario,
        #endregion
        #region Botas
        Boots_NameInicial,
        Boots_NameSigilo,
        Boots_NameLeñador,
        Boots_NameCarmesi,
        Boots_NameMercenario,
        Boots_NameAcorazado,
        Boots_DescInicial,
        Boots_DescSigilo,
        Boots_DescLeñador,
        Boots_DescCarmesi,
        Boots_DescMercenario,
        Boots_DescAcorazado,
        #endregion
        #region Greaves
        Greave_NameInicial,
        Greave_NameLeñador,
        Greave_NameCarmesi,
        Greave_NameMercenario,
        Greave_NameAcorazado,
        Greave_DescInicial,
        Greave_DescLeñador,
        Greave_DescCarmesi,
        Greave_DescMercenario,
        Greave_DescAcorazado,
        #endregion
        #region Chestplates
        Chestplate_NameLeñador,
        Chestplate_NameHierro,
        Chestplate_NameAqua,
        Chestplate_NameMercenario,
        Chestplate_NameCelestial,
        Chestplate_NameDemoniaco,
        Chestplate_NameSamurai,
        Chestplate_NameVolcanico,
        Chestplate_NameCristal,
        Chestplate_NamePaladin,
        Chestplate_NameHidro,
        Chestplate_NameBosque,
        Chestplate_NameRebanadorSlimes,
        Chestplate_NameInferno,
        Chestplate_DescLeñador,
        Chestplate_DescHierro,
        Chestplate_DescAqua,
        Chestplate_DescMercenario,
        Chestplate_DescCelestial,
        Chestplate_DescDemoniaco,
        Chestplate_DescSamurai,
        Chestplate_DescVolcanico,
        Chestplate_DescCristal,
        Chestplate_DescPaladin,
        Chestplate_DescHidro,
        Chestplate_DescBosque,
        Chestplate_DescRebanadorSlimes,
        Chestplate_DescInferno,
        #endregion
        #region Helmets
        Helmet_NameLeñador,
        Helmet_NameHierro,
        Helmet_NameAqua,
        Helmet_NameMercenario,
        Helmet_NameCelestial,
        Helmet_NameDemoniaco,
        Helmet_NameSamurai,
        Helmet_NameVolcanico,
        Helmet_NameCristal,
        Helmet_NamePaladin,
        Helmet_NameHidro,
        Helmet_NameBosque,
        Helmet_NameRebanadorSlimes,
        Helmet_NameInferno,
        Helmet_DescLeñador,
        Helmet_DescHierro,
        Helmet_DescAqua,
        Helmet_DescMercenario,
        Helmet_DescCelestial,
        Helmet_DescDemoniaco,
        Helmet_DescSamurai,
        Helmet_DescVolcanico,
        Helmet_DescCristal,
        Helmet_DescPaladin,
        Helmet_DescHidro,
        Helmet_DescBosque,
        Helmet_DescRebanadorSlimes,
        Helmet_DescInferno,
        #endregion
        #region Potions
        Potion_NameSmallLife,
        Potion_NameMediumLife,
        Potion_NameBigLife,
        Potion_NameSmallShield,
        Potion_NameMediumShield,
        Potion_NameBigShield,
        Potion_NameEnergy,
        Potion_NameInmunity,
        Potion_NameRange,
        Potion_DescSmallLife,
        Potion_DescMediumLife,
        Potion_DescBigLife,
        Potion_DescSmallShield,
        Potion_DescMediumShield,
        Potion_DescBigShield,
        Potion_DescEnergy,
        Potion_DescInmunity,
        Potion_DescRange,
        #endregion
        #region Collectibles
        Collectible_NameWaterOrbMini,
        Collectible_NameWaterOrb,
        Collectible_NameWaterOrbBig,
        Collectible_DescWaterOrbMini,
        Collectible_DescWaterOrb,
        Collectible_DescWaterOrbBig,
        Collectible_NameWoodOrbMini,
        Collectible_NameWoodOrb,
        Collectible_NameWoodOrbBig,
        Collectible_DescWoodOrbMini,
        Collectible_DescWoodOrb,
        Collectible_DescWoodOrbBig,
        Collectible_NameSlimeOrbMini,
        Collectible_NameSlimeOrb,
        Collectible_NameSlimeOrbBig,
        Collectible_DescSlimeOrbMini,
        Collectible_DescSlimeOrb,
        Collectible_DescSlimeOrbBig,
        Collectible_NameFireOrbMini,
        Collectible_NameFireOrb,
        Collectible_NameFireOrbBig,
        Collectible_DescFireOrbMini,
        Collectible_DescFireOrb,
        Collectible_DescFireOrbBig,
        #endregion
        #region Achievements
        Achievement_Title,
        Achievement_Reward,
        Achievement_Completion,
        Achievement_NameWaterSlayerI,
        Achievement_NameWaterSlayerII,
        Achievement_NameWaterSlayerIII,
        Achievement_NameWoodSlayerI,
        Achievement_NameWoodSlayerII,
        Achievement_NameWoodSlayerIII,
        Achievement_NameSlimeSlayerI,
        Achievement_NameSlimeSlayerII,
        Achievement_NameSlimeSlayerIII,
        Achievement_NameFireSlayerI,
        Achievement_NameFireSlayerII,
        Achievement_NameFireSlayerIII,
        Achievement_NameGatherer,
        Achievement_NamePacifist,
        Achievement_NameGameLover,
        Achievement_NamePerfectionistI,
        Achievement_NamePerfectionistII,
        Achievement_NamePerfectionistIII,
        Achievement_NamePerfectionistIV,
        Achievement_NamePerfectionistV,
        Achievement_NameAdventurerI,
        Achievement_NameAdventurerII,
        Achievement_NameAdventurerIII,
        Achievement_NameAdventurerIV,
        Achievement_NameAdventurerV,
        Achievement_NameAdventurerVI,
        Achievement_NameTimeMasterI,
        Achievement_NameTimeMasterII,
        Achievement_NameTimeMasterIII,
        Achievement_NameTimeMasterIV,
        Achievement_NameTimeMasterV,
        Achievement_NameSwordsmasterI,
        Achievement_NameSwordsmasterII,
        Achievement_NameSwordsmasterIII,
        Achievement_NameBankerI,
        Achievement_NameBankerII,
        Achievement_NameBankerIII,
        Achievement_NameBankerIV,
        Achievement_NameBankerV,
        Achievement_NameCollectionistI,
        Achievement_NameCollectionistII,
        Achievement_NameCollectionistIII,
        Achievement_DescWaterSlayerI,
        Achievement_DescWaterSlayerII,
        Achievement_DescWaterSlayerIII,
        Achievement_DescWoodSlayerI,
        Achievement_DescWoodSlayerII,
        Achievement_DescWoodSlayerIII,
        Achievement_DescSlimeSlayerI,
        Achievement_DescSlimeSlayerII,
        Achievement_DescSlimeSlayerIII,
        Achievement_DescFireSlayerI,
        Achievement_DescFireSlayerII,
        Achievement_DescFireSlayerIII,
        Achievement_DescGatherer,
        Achievement_DescPacifist,
        Achievement_DescGameLover,
        Achievement_DescPerfectionistI,
        Achievement_DescPerfectionistII,
        Achievement_DescPerfectionistIII,
        Achievement_DescPerfectionistIV,
        Achievement_DescPerfectionistV,
        Achievement_DescAdventurerI,
        Achievement_DescAdventurerII,
        Achievement_DescAdventurerIII,
        Achievement_DescAdventurerIV,
        Achievement_DescAdventurerV,
        Achievement_DescAdventurerVI,
        Achievement_DescTimeMasterI,
        Achievement_DescTimeMasterII,
        Achievement_DescTimeMasterIII,
        Achievement_DescTimeMasterIV,
        Achievement_DescTimeMasterV,
        Achievement_DescSwordsmasterI,
        Achievement_DescSwordsmasterII,
        Achievement_DescSwordsmasterIII,
        Achievement_DescBankerI,
        Achievement_DescBankerII,
        Achievement_DescBankerIII,
        Achievement_DescBankerIV,
        Achievement_DescBankerV,
        Achievement_DescCollectionistI,
        Achievement_DescCollectionistII,
        Achievement_DescCollectionistIII,
        #endregion
        #region Monsters
        Monster_NameWater,
        Monster_NameWood,
        Monster_NameFire,
        Monster_NameSlime,
        Monster_DescWater,
        Monster_DescWood,
        Monster_DescFire,
        Monster_DescSlime,
        Monster_AbilWater,
        Monster_AbilWood,
        Monster_AbilFire,
        Monster_AbilSlime,
        #endregion
        #region LevelIntro
        LevelIntro_Title,
        LevelIntro_Defeat,
        LevelIntro_Survive,
        LevelIntro_Monsters,
        LevelIntro_Seconds,
        LevelIntro_Potions,
        LevelIntro_Start,
        LevelIntro_DescLevel_ForestOne,
        LevelIntro_DescLevel_ForestTwo,
        LevelIntro_DescLevel_ForestThree,
        LevelIntro_DescLevel_ForestFour,
        LevelIntro_DescLevel_ForestFive,
        LevelIntro_DescLevel_ForestSix,
        LevelIntro_DescLevel_ForestSeven,
        LevelIntro_DescLevel_ForestEight,
        LevelIntro_DescLevel_ForestNine,
        LevelIntro_DescLevel_ForestTen,
        #endregion
        #region PlayMode
        PlayMode_Horde,
        PlayMode_Time,
        PlayMode_Hunt
        #endregion
    }

    public static string GetText(Text text)
    {
        switch (PlayerPrefs2.SelectedLanguage)
        {
            case Languages.Spanish:
                switch (text)
                {
                    #region Menu principal
                    case Text.MainMenu_TouchStart:
                        return "Toca para continuar";
                    case Text.MainMenu_Play:
                        return "Jugar";
                    case Text.MainMenu_Options:
                        return "Opciones";
                    case Text.MainMenu_Exit:
                        return "Salir";
                    #endregion
                    #region Opciones
                    case Text.Options_Lenguage:
                        return "Idioma";
                    case Text.Options_Music:
                        return "Música";
                    case Text.Options_SoundFx:
                        return "Sonidos";
                    case Text.Options_Credits:
                        return "Creado por:";
                    case Text.Options_Developer1:
                        return "Harold Troya";
                    case Text.Options_Developer2:
                        return "Josué Calle";
                        #endregion
                    #region Nivel
                    case Text.Level_Victory:
                        return "Victoria!";
                    case Text.Level_Defeat:
                        return "Derrota";
                    case Text.Level_Restart:
                        return "Reiniciar";
                    case Text.Level_Continue:
                        return "Continuar";
                    case Text.Level_Map:
                        return "Mapa";
                    case Text.Level_Xp:
                        return "exp";
                    case Text.Level_Score:
                        return "Puntos";
                    case Text.Level_Pause:
                        return "Pausado";
                    #endregion
                    #region Mapas
                    case Text.MapName_Forest:
                        return "Bosque";
                    #endregion
                    #region Tienda
                    case Text.Shop_Title:
                        return "Tienda";
                    case Text.Shop_Level:
                        return "Nvl";
                    case Text.Shop_ItemAquired:
                        return "Equipar";
                    case Text.Shop_ItemEquiped:
                        return "Quitar";
                    case Text.Shop_ItemOnSale:
                        return "Comprar";
                    case Text.Shop_LabelItemName:
                        return "Selecciona un objeto";
                    case Text.Shop_LabelItemDesc:
                        return "Aquí podras ver sus detalles.";
                    case Text.Shop_CategorieSword:
                        return "Espadas";
                    case Text.Shop_CategorieBow:
                        return "Arcos";
                    case Text.Shop_CategorieHammer:
                        return "Martillos";
                    case Text.Shop_CategoriePotion:
                        return "Pociones";
                    case Text.Shop_CategorieHelmet:
                        return "Cascos";
                    case Text.Shop_CategorieUpper:
                        return "Petos";
                    case Text.Shop_CategorieShirt:
                        return "Camisas";
                    case Text.Shop_CategoriePants:
                        return "Grebas";
                    case Text.Shop_CategorieBoots:
                        return "Botas";
                    case Text.Shop_CategoriePet:
                        return "Mascotas";
                    case Text.Shop_MessageNoMoney:
                        return "Necesitas mas monedas para comprar esto.";
                    case Text.Shop_MessageNoGems:
                        return "Necesitas mas gemas para comprar esto.";
                    case Text.Shop_MessageNoSword:
                        return "No creo que sea una buena idea salir sin un arma...";
                    case Text.Shop_MessageNoShirt:
                        return "Hasta el guerrero mas fuerte sabe que no puede luchar sin camisa!";
                    case Text.Shop_MessageNoGreave:
                        return "... No es ilegal ir por ahi sin pantalones, pero mejor dejatelos puestos.";
                    case Text.Shop_MessageNoBoots:
                        return "No se en que estas pensando al querer ir descalzo por el mundo...";
                    case Text.Shop_MessageLockedItem:
                        return "Este objeto esta bloqueado!";
                    case Text.Shop_MessageWarning:
                        return "Advertencia";
                    case Text.Shop_MessageError:
                        return "Ups!";
                    case Text.Shop_MessageNotice:
                        return "Aviso";
                    case Text.Shop_BuyConfirmation:
                        return "¿Estás seguro que deseas comprar esto?";
                        #endregion
                    #region Collection
                    case Text.Collection_Index:
                        return "Indice";
                    case Text.Collection_Monsters:
                        return "Monstruos";
                    case Text.Collection_Orbs:
                        return "Orbes";
                    case Text.Collection_Weapons:
                        return "Armas";
                    case Text.Collection_WeaponAbility:
                        return "Habilidad de espada: ";
                    case Text.Collection_MonsterAbility:
                        return "Ataque especial: ";
                    case Text.Collection_OrbMonsterBase:
                        return "Monsturo base: ";
                    case Text.Collection_UnknownName:
                        return "Desconocido...";
                    case Text.Collection_UnknownDesc:
                        return "Encuentra o compra este objeto para saber mas acerca de el.";
                    case Text.Collection_UnknownExtra:
                        return "Desconocido.";
                    #endregion
                    #region Estados de objetos
                    case Text.Item_Aquired:
                        return "Adquirido";
                    case Text.Item_Equiped:
                        return "Equipado";
                    case Text.Item_Locked:
                        return "Bloqueado";
                    case Text.Rarity_Uncommon:
                        return "Poco común";
                    case Text.Rarity_Common:
                        return "Común";
                    case Text.Rarity_Rare:
                        return "Raro";
                    case Text.Rarity_Legendary:
                        return "Legendario";
                    #endregion
                    #region Espadas
                    case Text.Sword_NameAqua:
                        return "Aqua";
                    case Text.Sword_NameEspadaHierro:
                        return "Espada de Hierro";
                    case Text.Sword_NameEspadaMadera:
                        return "Espada de madera";
                    case Text.Sword_NameEspadaSombras:
                        return "Espada de las sombras";
                    case Text.Sword_NameEspadonBosque:
                        return "Espadón del bosque";
                    case Text.Sword_NameEspadonCelestial:
                        return "Espadón celestial";
                    case Text.Sword_NameHidroblade:
                        return "Hidroespada";
                    case Text.Sword_NameInferno:
                        return "Inferno";
                    case Text.Sword_NameOscuridadDemoniaca:
                        return "Oscuridad demoniaca";
                    case Text.Sword_NameRebanadoraSlimes:
                        return "Rebanadora de slimes";
                    case Text.Sword_NameVolcanora:
                        return "Volcanora";
                    case Text.Sword_NameEspadaCristal:
                        return "Espada de cristal";
                    case Text.Sword_NameEspadaPaladin:
                        return "Espada paladín";
                    case Text.Sword_DescAqua:
                        return "Un corte de esta espada contiene toda la fuerza del  mar.";
                    case Text.Sword_DescEspadaHierro:
                        return "Una espada forjada por tu maestro, muestra de tu entrenamiento y valentía.";
                    case Text.Sword_DescEspadaMadera:
                        return "Con esta espada aprenderás todo lo necesario para ser un caballero del rey.";
                    case Text.Sword_DescEspadaSombras:
                        return "Forjada por los herreros del bosque sombrío con Daknatita.";
                    case Text.Sword_DescEspadonBosque:
                        return "Se consigue al derrotar a 50 troncos.";
                    case Text.Sword_DescEspadonCelestial:
                        return "Imbuido con magia angelical y forjada con una aleación de acero azul y dinatio.";
                    case Text.Sword_DescHidroblade:
                        return "Se consigue al derrotar 50 espíritus de agua.";
                    case Text.Sword_DescInferno:
                        return "Se consigue al derrotar a 100 espíritus de fuego.";
                    case Text.Sword_DescOscuridadDemoniaca:
                        return "Fue la espada del gran demonio Ragnek, hasta que un gran guerrero lo derrotó y guardó su espada como trofeo.";
                    case Text.Sword_DescRebanadoraSlimes:
                        return "Se consigue al derrotar a 75 slimes.";
                    case Text.Sword_DescVolcanora:
                        return "De las entrañas del gran volcán Kranto llena de la energía de la tierra y su calor.";
                    case Text.Sword_DescEspadaCristal:
                        return "Una espada bendecida por las estrellas con su brillo y poder.";
                    case Text.Sword_DescEspadaPaladin:
                        return "Una de las espadas más fuertes que ha empuñado un hombre, para usarla deberás entrenar muy duro.";
                    #endregion
                    #region Camisas
                    case Text.Shirt_NameCampesino:
                        return "Camisa campesino";
                    case Text.Shirt_NameChaleco:
                        return "Chaleco simple";
                    case Text.Shirt_NameCuelloAlto:
                        return "Camisa de cuello alto";
                    case Text.Shirt_NameInicial:
                        return "Camisa de inicio";
                    case Text.Shirt_NameJubonCamisa:
                        return "Jubón y camisa";
                    case Text.Shirt_NameLeñador:
                        return "Camisa de leñador";
                    case Text.Shirt_NameMangasCortas:
                        return "Camisa de mangas cortas";
                    case Text.Shirt_NameMercenario:
                        return "Camisa de mercenario";
                    case Text.Shirt_DescCampesino:
                        return "No es lo mejor para la batalla pero aguantara.";
                    case Text.Shirt_DescChaleco:
                        return "Tal vez no intimides a los monstruos mostrando tus brazos, pero a las chicas les encanta.";
                    case Text.Shirt_DescCuelloAlto:
                        return "Tiene protección especial contra resfriados.";
                    case Text.Shirt_DescInicial:
                        return "Perfecto para empezar una nueva aventura.";
                    case Text.Shirt_DescJubonCamisa:
                        return "Lo último en moda en el siglo XV.";
                    case Text.Shirt_DescLeñador:
                        return "Si le sirve a un leñador estoy seguro de que te servirá para matar uno o dos monstruos.";
                    case Text.Shirt_DescMangasCortas:
                        return "El frío no se compara a los monstruos con los que te enfrentaras.";
                    case Text.Shirt_DescMercenario:
                        return "No existe cuchilla que logre atravezar esta tela.";
                    case Text.Sword_AbilEspadaMadera:
                        return "Ninguna";
                    case Text.Sword_AbilEspadaHierro:
                        return "Ninguna";
                    case Text.Sword_AbilAqua:
                        return "Ninguna";
                    case Text.Sword_AbilOscuridadDemoniaca:
                        return "Ninguna";
                    case Text.Sword_AbilEspadaSombras:
                        return "Ninguna";
                    case Text.Sword_AbilEspadonCelestial:
                        return "Ninguna";
                    case Text.Sword_AbilVolcanora:
                        return "Ninguna";
                    case Text.Sword_AbilHidroblade:
                        return "Ninguna";
                    case Text.Sword_AbilInferno:
                        return "Ninguna";
                    case Text.Sword_AbilRebanadoraSlimes:
                        return "Ninguna";
                    case Text.Sword_AbilEspadonBosque:
                        return "Ninguna";
                    case Text.Sword_AbilEspadaCristal:
                        return "Ninguna";
                    case Text.Sword_AbilEspadaPaladin:
                        return "Ninguna";
                    #endregion
                    #region Botas
                    case Text.Boots_NameInicial:
                        return "Botas de inicio";
                    case Text.Boots_NameSigilo:
                        return "Botas sigilosas";
                    case Text.Boots_NameLeñador:
                        return "Botas de leñador";
                    case Text.Boots_NameCarmesi:
                        return "Botas carmesí";
                    case Text.Boots_NameMercenario:
                        return "Botas de mercenario";
                    case Text.Boots_NameAcorazado:
                        return "Botas acorazadas";
                    case Text.Boots_DescInicial:
                        return "Estas botas son perfectas para iniciar una nueva aventura.";
                    case Text.Boots_DescSigilo:
                        return "Con estas botas no harás ni un solo ruido.";
                    case Text.Boots_DescLeñador:
                        return "Bastante resistentes, y te aseguro que no han sido usadas por ningún leñador.";
                    case Text.Boots_DescCarmesi:
                        return "El cuero de estas botas ha sido imbuido con el poder del mágico rubí de sangre para resistir las más duras caminatas.";
                    case Text.Boots_DescMercenario:
                        return "Se hicieron para mercenarios, pero estoy seguro de que les darás un buen uso.";
                    case Text.Boots_DescAcorazado:
                        return "Reforzadas con un resistente metal, no serán las botas más cómodas pero mantendrán tus pies a salvo.";
                    #endregion
                    #region Greaves
                    case Text.Greave_NameInicial:
                        return "Grebas de inicio";
                    case Text.Greave_NameLeñador:
                        return "Grebas de leñador";
                    case Text.Greave_NameCarmesi:
                        return "Grebas carmesí";
                    case Text.Greave_NameMercenario:
                        return "Grebas de mercenario";
                    case Text.Greave_NameAcorazado:
                        return "Grebas acorazadas";
                    case Text.Greave_DescInicial:
                        return "Estas son las grebas perfectas para iniciar una nueva aventura.";
                    case Text.Greave_DescLeñador:
                        return "No hay hacha capaz de atravezar estas grebas.";
                    case Text.Greave_DescCarmesi:
                        return "Imbuidas con el poder mágico del mágico rubí de sangre.";
                    case Text.Greave_DescMercenario:
                        return "Los mercenarios dicen que ninguna cuchilla las pueden atravezar.";
                    case Text.Greave_DescAcorazado:
                        return "Reforzadas con un metal increíblemente resistente, te protegerán de cualquier daño.";
                    #endregion
                    #region Chestplates
                    case Text.Chestplate_NameLeñador:
                        return "Peto de leñador";
                    case Text.Chestplate_NameHierro:
                        return "Peto de hierro";
                    case Text.Chestplate_NameAqua:
                        return "Peto Aqua";
                    case Text.Chestplate_NameMercenario:
                        return "Peto de Mercenario";
                    case Text.Chestplate_NameCelestial:
                        return "Peto celestial";
                    case Text.Chestplate_NameDemoniaco:
                        return "Peto demoniaco";
                    case Text.Chestplate_NameSamurai:
                        return "Peto de samurai";
                    case Text.Chestplate_NameVolcanico:
                        return "Peto volcanico";
                    case Text.Chestplate_NameCristal:
                        return "Peto de cristal";
                    case Text.Chestplate_NamePaladin:
                        return "Peto paladín";
                    case Text.Chestplate_NameHidro:
                        return "Hidropeto";
                    case Text.Chestplate_NameBosque:
                        return "Peto del bosque";
                    case Text.Chestplate_NameRebanadorSlimes:
                        return "Peto rebanador de slimes";
                    case Text.Chestplate_NameInferno:
                        return "Peto inferno";
                    case Text.Chestplate_DescLeñador:
                        return "Un peto de madera, te otorgara un poco de protección.";
                    case Text.Chestplate_DescHierro:
                        return "Hecho de hierro para ofrecer mayor proteccíon.";
                    case Text.Chestplate_DescAqua:
                        return "Implacable como las olas del mar, te protegerá con todo su poder.";
                    case Text.Chestplate_DescMercenario:
                        return "Si protege a los mercenarios en todas sus fechorías, te será muy útil contra los monstruos.";
                    case Text.Chestplate_DescCelestial:
                        return "Imbuido con magia angelical hecho con una aleación de acero azul y dinario, capaz de resistir los ataques más feroces.";
                    case Text.Chestplate_DescDemoniaco:
                        return "Un peto bastante resistente, está encantado por el gran demonio Ragnek.";
                    case Text.Chestplate_DescSamurai:
                        return "Si alguna vez quisiste ser un samurai, con este peto te sentirás como uno auténtico y valeroso.";
                    case Text.Chestplate_DescVolcanico:
                        return "Otorga la protección del magma desde las profundidades de la tierra.";
                    case Text.Chestplate_DescCristal:
                        return "Un peto hecho de cristal magico reforzado, seguro es incomodo, pero nada jamas lograra hacerte daño.";
                    case Text.Chestplate_DescPaladin:
                        return "Uno de los 10 objetos míticos de este mundo, su resistencia es toda una leyenda.";
                    case Text.Chestplate_DescHidro:
                        return "Pendiente";
                    case Text.Chestplate_DescBosque:
                        return "Pendiente";
                    case Text.Chestplate_DescRebanadorSlimes:
                        return "Pendiente";
                    case Text.Chestplate_DescInferno:
                        return "Pendiente";
                    #endregion
                    #region Helmets
                    case Text.Helmet_NameLeñador:
                        return "Casco de Leñador";
                    case Text.Helmet_NameHierro:
                        return "Casco de hierro";
                    case Text.Helmet_NameAqua:
                        return "Casco Aqua";
                    case Text.Helmet_NameMercenario:
                        return "Casco de mercenario";
                    case Text.Helmet_NameCelestial:
                        return "Casco celestial";
                    case Text.Helmet_NameDemoniaco:
                        return "Casco demoniaco";
                    case Text.Helmet_NameSamurai:
                        return "Casco de samurai";
                    case Text.Helmet_NameVolcanico:
                        return "Casco volcanico";
                    case Text.Helmet_NameCristal:
                        return "Casco de cristal";
                    case Text.Helmet_NamePaladin:
                        return "Casco de paladín";
                    case Text.Helmet_NameHidro:
                        return "Hidrocasco";
                    case Text.Helmet_NameBosque:
                        return "Casco del bosque";
                    case Text.Helmet_NameRebanadorSlimes:
                        return "Casco rebanador de slimes";
                    case Text.Helmet_NameInferno:
                        return "Casco inferno";
                    case Text.Helmet_DescLeñador:
                        return "¿Quién dice que los leñadores no usan casco?";
                    case Text.Helmet_DescHierro:
                        return "Mucho más resistente que el casco de leñador, pero sigue siendo solo una pieza de metal en tu cabeza.";
                    case Text.Helmet_DescAqua:
                        return "Bendecido por las sirenas, este casco tiene rastros mágicos  que le otorgan una gran resistencia.";
                    case Text.Helmet_DescMercenario:
                        return "Con este casco te verás como todo un mercenario, pero seguirás siendo un héroe que recorre el camino del bien.";
                    case Text.Helmet_DescCelestial:
                        return "Bendecido por los ángeles para proteger a su portador contra cualquier mal.";
                    case Text.Helmet_DescDemoniaco:
                        return "El gran demonio Ragnek utilizó este casco y ganó miles de batallas, hay quienes dicen que parte de su poder mágico quedó imbuido en el mismo.";
                    case Text.Helmet_DescSamurai:
                        return "Ha pasado por varias generaciones de samurais, siempre cuidando de su portador, llévalo con honor.";
                    case Text.Helmet_DescVolcanico:
                        return "Creado en las profundidades de la tierra, capaz de soportar temperaturas extremas.";
                    case Text.Helmet_DescCristal:
                        return "Cristal reforzado y bendecido por las hadas de las montañas rocosas para proteger a su portador.";
                    case Text.Helmet_DescPaladin:
                        return "Con este casco obtendrás la protección de los paladines, una habilidad pasiva que te hará mucho más resistente.";
                    case Text.Helmet_DescHidro:
                        return "Pendiente";
                    case Text.Helmet_DescBosque:
                        return "Pendiente";
                    case Text.Helmet_DescRebanadorSlimes:
                        return "Pendiente";
                    case Text.Helmet_DescInferno:
                        return "Pendiente";
                        #endregion
                    #region Potions
                    case Text.Potion_NameSmallLife:
                        return "Vida pequeña";
                    case Text.Potion_NameMediumLife:
                        return "Vida mediana";
                    case Text.Potion_NameBigLife:
                        return "Vida gigante";
                    case Text.Potion_NameSmallShield:
                        return "Escudo magico";
                    case Text.Potion_NameMediumShield:
                        return "Escudo poderoso";
                    case Text.Potion_NameBigShield:
                        return "Escudo mistico";
                    case Text.Potion_NameEnergy:
                        return "Bebida energetica";
                    case Text.Potion_NameInmunity:
                        return "Inmunidad liquida";
                    case Text.Potion_NameRange:
                        return "Vision mejorada";
                    case Text.Potion_DescSmallLife:
                        return "Regenera un corazon de manera inmediata.";
                    case Text.Potion_DescMediumLife:
                        return "Regerenera tres corazones de manera inmediata.";
                    case Text.Potion_DescBigLife:
                        return "Regenera todos tus corazones de manera inmediata.";
                    case Text.Potion_DescSmallShield:
                        return "Te proteje de un ataque durante 5 segundos.";
                    case Text.Potion_DescMediumShield:
                        return "Te protege de dos ataque durante 5 segundos.";
                    case Text.Potion_DescBigShield:
                        return "Te protege de tres ataques durante 5 segundos.";
                    case Text.Potion_DescEnergy:
                        return "Te otorga energia ilimitada durante 5 segundos.";
                    case Text.Potion_DescInmunity:
                        return "Te vuelve invulnerable durante 5 segundos.";
                    case Text.Potion_DescRange:
                        return "Te otorga rango maximo durante 5 segundos.";
                    #endregion
                    #region Collectibles
                    case Text.Collectible_NameWaterOrbMini:
                        return "Pequeño orbe espiritual de agua";
                    case Text.Collectible_NameWaterOrb:
                        return "Orbe espiritual de agua";
                    case Text.Collectible_NameWaterOrbBig:
                        return "Gran orbe espiritual de agua";
                    case Text.Collectible_DescWaterOrbMini:
                        return "Contiene un poco de la esencia de un espíritu de agua.";
                    case Text.Collectible_DescWaterOrb:
                        return "Contiene la esencia de un espíritu de agua.";
                    case Text.Collectible_DescWaterOrbBig:
                        return "Contiene la esencia de un espíritu de agua y toda su magia.";
                    case Text.Collectible_NameWoodOrbMini:
                        return "Pequeño orbe espiritual de madera";
                    case Text.Collectible_NameWoodOrb:
                        return "Orbe espiritual de madera";
                    case Text.Collectible_NameWoodOrbBig:
                        return "Gran orbe espiritual de madera";
                    case Text.Collectible_DescWoodOrbMini:
                        return "Contiene un poco de la esencia de un tronco.";
                    case Text.Collectible_DescWoodOrb:
                        return "Contiene la esencia de un tronco.";
                    case Text.Collectible_DescWoodOrbBig:
                        return "Contiene la esencia de un tronco y toda su magia.";
                    #endregion
                    #region Achievements
                    case Text.Achievement_Title:
                        return "Logros";
                    case Text.Achievement_Reward:
                        return "Recompensa";
                    case Text.Achievement_Completion:
                        return "Completado";
                    case Text.Achievement_NameWaterSlayerI:
                        return "Guerrero acuático I";
                    case Text.Achievement_NameWaterSlayerII:
                        return "Guerrero acuático II";
                    case Text.Achievement_NameWaterSlayerIII:
                        return "Guerrero acuático III";
                    case Text.Achievement_NameWoodSlayerI:
                        return "Leñador I";
                    case Text.Achievement_NameWoodSlayerII:
                        return "Leñador II";
                    case Text.Achievement_NameWoodSlayerIII:
                        return "Leñador III";
                    case Text.Achievement_NameSlimeSlayerI:
                        return "Guerrero del pantano I";
                    case Text.Achievement_NameSlimeSlayerII:
                        return "Guerrero del pantano II";
                    case Text.Achievement_NameSlimeSlayerIII:
                        return "Guerrero del pantano III";
                    case Text.Achievement_NameFireSlayerI:
                        return "A prueba de fuego I";
                    case Text.Achievement_NameFireSlayerII:
                        return "A prueba de fuego II";
                    case Text.Achievement_NameFireSlayerIII:
                        return "A prueba de fuego III";
                    case Text.Achievement_NameGatherer:
                        return "Recolector";
                    case Text.Achievement_NamePacifist:
                        return "Pacifista";
                    case Text.Achievement_NameGameLover:
                        return "Amante del juego";
                    case Text.Achievement_NamePerfectionistI:
                        return "Perfeccionista I";
                    case Text.Achievement_NamePerfectionistII:
                        return "Perfeccionista II";
                    case Text.Achievement_NamePerfectionistIII:
                        return "Perfeccionista III";
                    case Text.Achievement_NamePerfectionistIV:
                        return "Perfeccionista IV";
                    case Text.Achievement_NamePerfectionistV:
                        return "Perfeccionista V";
                    case Text.Achievement_NameAdventurerI:
                        return "Aventurero I";
                    case Text.Achievement_NameAdventurerII:
                        return "Aventurero II";
                    case Text.Achievement_NameAdventurerIII:
                        return "Aventurero III";
                    case Text.Achievement_NameAdventurerIV:
                        return "Aventurero IV";
                    case Text.Achievement_NameAdventurerV:
                        return "Aventurero V";
                    case Text.Achievement_NameAdventurerVI:
                        return "Aventurero VI";
                    case Text.Achievement_NameTimeMasterI:
                        return "Amo del tiempo I";
                    case Text.Achievement_NameTimeMasterII:
                        return "Amo del tiempo II";
                    case Text.Achievement_NameTimeMasterIII:
                        return "Amo del tiempo III";
                    case Text.Achievement_NameTimeMasterIV:
                        return "Amo del tiempo IV";
                    case Text.Achievement_NameTimeMasterV:
                        return "Amo del tiempo V";
                    case Text.Achievement_NameSwordsmasterI:
                        return "Maestro Espadachín I";
                    case Text.Achievement_NameSwordsmasterII:
                        return "Maestro Espadachín II";
                    case Text.Achievement_NameSwordsmasterIII:
                        return "Maestro Espadachín III";
                    case Text.Achievement_NameBankerI:
                        return "Banquero I";
                    case Text.Achievement_NameBankerII:
                        return "Banquero II";
                    case Text.Achievement_NameBankerIII:
                        return "Banquero III";
                    case Text.Achievement_NameBankerIV:
                        return "Banquero IV";
                    case Text.Achievement_NameBankerV:
                        return "Banquero V";
                    case Text.Achievement_NameCollectionistI:
                        return "Coleccionista I";
                    case Text.Achievement_NameCollectionistII:
                        return "Coleccionista II";
                    case Text.Achievement_NameCollectionistIII:
                        return "Coleccionista III";
                    case Text.Achievement_DescWaterSlayerI:
                        return "Elimina 25 espíritus de agua.";
                    case Text.Achievement_DescWaterSlayerII:
                        return "Elimina 50 espíritus de agua.";
                    case Text.Achievement_DescWaterSlayerIII:
                        return "Elimina 100 espíritus de agua.";
                    case Text.Achievement_DescWoodSlayerI:
                        return "Elimina 25 espíritus de madera.";
                    case Text.Achievement_DescWoodSlayerII:
                        return "Elimina 50 espíritus de madera.";
                    case Text.Achievement_DescWoodSlayerIII:
                        return "Elimina 100 espíritus de madera.";
                    case Text.Achievement_DescSlimeSlayerI:
                        return "Elimina 25 espíritus de pantano.";
                    case Text.Achievement_DescSlimeSlayerII:
                        return "Elimina 50 espíritus de pantano.";
                    case Text.Achievement_DescSlimeSlayerIII:
                        return "Elimina 100 espíritus de pantano.";
                    case Text.Achievement_DescFireSlayerI:
                        return "Elimina 25 espíritus de fuego.";
                    case Text.Achievement_DescFireSlayerII:
                        return "Elimina 50 espíritus de fuego.";
                    case Text.Achievement_DescFireSlayerIII:
                        return "Elimina 100 espíritus de fuego.";
                    case Text.Achievement_DescGatherer:
                        return "Encuentra todos los orbes del juego.";
                    case Text.Achievement_DescPacifist:
                        return "Termina un nivel sin matar a ningún monstruo.";
                    case Text.Achievement_DescGameLover:
                        return "Termina todos los logros.";
                    case Text.Achievement_DescPerfectionistI:
                        return "Consigue 3 estrellas en todos los niveles del primer mapa.";
                    case Text.Achievement_DescPerfectionistII:
                        return "Consigue 3 estrellas en todos los niveles del segundo mapa.";
                    case Text.Achievement_DescPerfectionistIII:
                        return "Consigue 3 estrellas en todos los niveles del tercer mapa.";
                    case Text.Achievement_DescPerfectionistIV:
                        return "Consigue 3 estrellas en todos los niveles del cuarto mapa.";
                    case Text.Achievement_DescPerfectionistV:
                        return "Consigue 3 estrellas en todos los niveles del quinto mapa.";
                    case Text.Achievement_DescAdventurerI:
                        return "Completa el tutorial.";
                    case Text.Achievement_DescAdventurerII:
                        return "Completa el primer mapa.";
                    case Text.Achievement_DescAdventurerIII:
                        return "Completa el segundo mapa.";
                    case Text.Achievement_DescAdventurerIV:
                        return "Completa el tercero mapa.";
                    case Text.Achievement_DescAdventurerV:
                        return "Completa el cuarto mapa.";
                    case Text.Achievement_DescAdventurerVI:
                        return "Completa el quinto mapa.";
                    case Text.Achievement_DescTimeMasterI:
                        return "Juega un total de 1 hora.";
                    case Text.Achievement_DescTimeMasterII:
                        return "Juega un total de 3 horas.";
                    case Text.Achievement_DescTimeMasterIII:
                        return "Juega un total de 5 horas.";
                    case Text.Achievement_DescTimeMasterIV:
                        return "Juega un total de 10 horas.";
                    case Text.Achievement_DescTimeMasterV:
                        return "Juega un total de 50 horas.";
                    case Text.Achievement_DescSwordsmasterI:
                        return "Realiza un combo de dos monstruos.";
                    case Text.Achievement_DescSwordsmasterII:
                        return "Realiza un combo de tres monstruos.";
                    case Text.Achievement_DescSwordsmasterIII:
                        return "Realiza un combo de cinco monstruos.";
                    case Text.Achievement_DescBankerI:
                        return "Ten 100 monedas en tu inventario.";
                    case Text.Achievement_DescBankerII:
                        return "Ten 500 monedas en tu inventario.";
                    case Text.Achievement_DescBankerIII:
                        return "Ten 1000 monedas en tu inventario.";
                    case Text.Achievement_DescBankerIV:
                        return "Ten 5000 monedas en tu inventario.";
                    case Text.Achievement_DescBankerV:
                        return "Ten 10000 monedas en tu inventario.";
                    case Text.Achievement_DescCollectionistI:
                        return "Compra un objeto en la tienda.";
                    case Text.Achievement_DescCollectionistII:
                        return "Compra 25 objetos en la tienda.";
                    case Text.Achievement_DescCollectionistIII:
                        return "Compra 50 objetos en la tienda.";
                    #endregion
                    #region Monsters
                    case Text.Monster_NameWater:
                        return "Espiritu de agua";
                    case Text.Monster_NameWood:
                        return "Espiritu de madera";
                    case Text.Monster_NameFire:
                        return "Espiritu de fuego";
                    case Text.Monster_NameSlime:
                        return "Espiritu de slime";
                    case Text.Monster_DescWater:
                        return "Un espiritu nacido por el resentimiento de los rios de Odsbury.";
                    case Text.Monster_DescWood:
                        return "Cuando el bosque fue inundado de maldad estos malignos espiritus de madera nacieron.";
                    case Text.Monster_DescFire:
                        return "Espiritus violentos y salvajes llenos de energia.";
                    case Text.Monster_DescSlime:
                        return "Puede ser tentador tocar a estas criaturas, pero son bastante venenosas.";
                    case Text.Monster_AbilWater:
                        return "Ninguna.";
                    case Text.Monster_AbilWood:
                        return "Resiste mas de un golpe y puede ser cortado en cualquier dirección.";
                    case Text.Monster_AbilFire:
                        return "Quemadura - Te incendia y hace daño extra cada cierto tiempo.";
                    case Text.Monster_AbilSlime:
                        return "Dispara una bola de slime que dificulta tu vision por cierto tiempo.";
                    #endregion
                    #region LevelIntro
                    case Text.LevelIntro_Title:
                        return "Nivel";
                    case Text.LevelIntro_Defeat:
                        return "Derrota";
                    case Text.LevelIntro_Survive:
                        return "Sobrevive";
                    case Text.LevelIntro_Monsters:
                        return "monstruos";
                    case Text.LevelIntro_Seconds:
                        return "segundos";
                    case Text.LevelIntro_Potions:
                        return "Pociones";
                    case Text.LevelIntro_Start:
                        return "Empezar";
                    case Text.LevelIntro_DescLevel_ForestOne:
                        return "Sobrevive al ataque sorpresa y trata de no recibir daño.";
                    case Text.LevelIntro_DescLevel_ForestTwo:
                        return "Consigue muestras de monstruos para averiguar su naturaleza.";
                    case Text.LevelIntro_DescLevel_ForestThree:
                        return "Protege la aldea mientras se contruyen las defensas.";
                    case Text.LevelIntro_DescLevel_ForestFour:
                        return "Descripción pendiente...";
                    case Text.LevelIntro_DescLevel_ForestFive:
                        return "Descripción pendiente...";
                    case Text.LevelIntro_DescLevel_ForestSix:
                        return "Descripción pendiente...";
                    case Text.LevelIntro_DescLevel_ForestSeven:
                        return "Descripción pendiente...";
                    case Text.LevelIntro_DescLevel_ForestEight:
                        return "Descripción pendiente...";
                    case Text.LevelIntro_DescLevel_ForestNine:
                        return "Descripción pendiente...";
                    case Text.LevelIntro_DescLevel_ForestTen:
                        return "Descripción pendiente...";
                    #endregion
                    #region PlayMode
                    case Text.PlayMode_Horde:
                        return "Monstruos:";
                    case Text.PlayMode_Time:
                        return "Tiempo:";
                    case Text.PlayMode_Hunt:
                        return "Caceria:";
                    #endregion
                    default:
                        return null;
                }
            case Languages.English:
                switch (text)
                {
                    #region Menu principal
                    case Text.MainMenu_TouchStart:
                        return "Touch to continue";
                    case Text.MainMenu_Play:
                        return "Play";
                    case Text.MainMenu_Options:
                        return "Options";
                    case Text.MainMenu_Exit:
                        return "Exit";
                    #endregion
                    #region Opciones
                    case Text.Options_Lenguage:
                        return "Lenguage";
                    case Text.Options_Music:
                        return "Music";
                    case Text.Options_SoundFx:
                        return "Sounds";
                    case Text.Options_Credits:
                        return "Created by:";
                    case Text.Options_Developer1:
                        return "Harold Troya";
                    case Text.Options_Developer2:
                        return "Josué Calle";
                    #endregion
                    #region Nivel
                    case Text.Level_Victory:
                        return "Victory!";
                    case Text.Level_Defeat:
                        return "Defeat";
                    case Text.Level_Restart:
                        return "Restart";
                    case Text.Level_Continue:
                        return "Continue";
                    case Text.Level_Map:
                        return "Map";
                    case Text.Level_Xp:
                        return "xp";
                    case Text.Level_Score:
                        return "Score";
                    case Text.Level_Pause:
                        return "Paused";
                    #endregion
                    #region Mapas
                    case Text.MapName_Forest:
                        return "Forest";
                    #endregion
                    #region Tienda
                    case Text.Shop_Title:
                        return "Shop";
                    case Text.Shop_Level:
                        return "Lv";
                    case Text.Shop_ItemAquired:
                        return "Equip";
                    case Text.Shop_ItemEquiped:
                        return "Unequip";
                    case Text.Shop_ItemOnSale:
                        return "Buy";
                    case Text.Shop_LabelItemName:
                        return "Select an item";
                    case Text.Shop_LabelItemDesc:
                        return "Here you would see it's details.";
                    case Text.Shop_CategorieSword:
                        return "Swords";
                    case Text.Shop_CategorieBow:
                        return "Bows";
                    case Text.Shop_CategorieHammer:
                        return "Hammers";
                    case Text.Shop_CategoriePotion:
                        return "Potions";
                    case Text.Shop_CategorieHelmet:
                        return "Helmets";
                    case Text.Shop_CategorieUpper:
                        return "Breastplates";
                    case Text.Shop_CategorieShirt:
                        return "Shirts";
                    case Text.Shop_CategoriePants:
                        return "Greaves";
                    case Text.Shop_CategorieBoots:
                        return "Boots";
                    case Text.Shop_CategoriePet:
                        return "Pets";
                    case Text.Shop_MessageNoMoney:
                        return "You need more coins to buy this.";
                    case Text.Shop_MessageNoGems:
                        return "You need more gems to buy this.";
                    case Text.Shop_MessageNoSword:
                        return "I don't think it's a good idea to go without a weapon...";
                    case Text.Shop_MessageNoShirt:
                        return "Even the strongest hero knows he needs to wear a shirt into a battle!";
                    case Text.Shop_MessageNoGreave:
                        return "... There is no law against going out with no pants, but it would be the best to just leave them on.";
                    case Text.Shop_MessageNoBoots:
                        return "I don't know what you're thinking wanting to go barefoot around the world...";
                    case Text.Shop_MessageLockedItem:
                        return "This item is locked!";
                    case Text.Shop_MessageWarning:
                        return "Warning";
                    case Text.Shop_MessageError:
                        return "Oops!";
                    case Text.Shop_MessageNotice:
                        return "Notice";
                    case Text.Shop_BuyConfirmation:
                        return "Are you sure you want to buy this?";
                    #endregion
                    #region Collection
                    case Text.Collection_Index:
                        return "Index";
                    case Text.Collection_Monsters:
                        return "Monsters";
                    case Text.Collection_Orbs:
                        return "Orbs";
                    case Text.Collection_Weapons:
                        return "Weapons";
                    case Text.Collection_WeaponAbility:
                        return "Sword ability: ";
                    case Text.Collection_MonsterAbility:
                        return "Special attack: ";
                    case Text.Collection_OrbMonsterBase:
                        return "Base monster: ";
                    case Text.Collection_UnknownName:
                        return "Unknown...";
                    case Text.Collection_UnknownDesc:
                        return "Find or buy this object to know more about it.";
                    case Text.Collection_UnknownExtra:
                        return "Unknown.";
                    #endregion
                    #region Estados de objetos
                    case Text.Item_Aquired:
                        return "Aquired";
                    case Text.Item_Equiped:
                        return "Equiped";
                    case Text.Item_Locked:
                        return "Locked";
                    case Text.Rarity_Uncommon:
                        return "Uncommon";
                    case Text.Rarity_Common:
                        return "Common";
                    case Text.Rarity_Rare:
                        return "Rare";
                    case Text.Rarity_Legendary:
                        return "Legendary";
                    #endregion
                    #region Espadas
                    case Text.Sword_NameAqua:
                        return "Aqua";
                    case Text.Sword_NameEspadaHierro:
                        return "Iron sword";
                    case Text.Sword_NameEspadaMadera:
                        return "Wooden sword";
                    case Text.Sword_NameEspadaSombras:
                        return "Sword of the shadows";
                    case Text.Sword_NameEspadonBosque:
                        return "Forest greatsword";
                    case Text.Sword_NameEspadonCelestial:
                        return "Celestial greatsword";
                    case Text.Sword_NameHidroblade:
                        return "Hidroblade";
                    case Text.Sword_NameInferno:
                        return "Inferno";
                    case Text.Sword_NameOscuridadDemoniaca:
                        return "Black demon";
                    case Text.Sword_NameRebanadoraSlimes:
                        return "Slimeslayer";
                    case Text.Sword_NameVolcanora:
                        return "Volcanora";
                    case Text.Sword_NameEspadaCristal:
                        return "Cristal sword";
                    case Text.Sword_NameEspadaPaladin:
                        return "Paladin's sword";
                    case Text.Sword_DescAqua:
                        return "A single slash from this sword contains all the power of the ocean.";
                    case Text.Sword_DescEspadaHierro:
                        return "This sword was forged by your master, it shows all your training and bravery.";
                    case Text.Sword_DescEspadaMadera:
                        return "With this sword, you will learn everything you need to become a king's knight.";
                    case Text.Sword_DescEspadaSombras:
                        return "Forged by the blacksmiths in the dark forest with Daknatite.";
                    case Text.Sword_DescEspadonBosque:
                        return "Available when you defeat 50 wooden monsters.";
                    case Text.Sword_DescEspadonCelestial:
                        return "Imbued with celestial magic, forged with an alloy of Blue Steel and Dinatium.";
                    case Text.Sword_DescHidroblade:
                        return "Available when you defeat 50 water spirits.";
                    case Text.Sword_DescInferno:
                        return "Available when you defeat 100 fire spirits.";
                    case Text.Sword_DescOscuridadDemoniaca:
                        return "It was long ago the sword of the great demon Ragnek, until one day a great warrior defeated him and save this sword as his precious reward.";
                    case Text.Sword_DescRebanadoraSlimes:
                        return "Available when you defeat 75 slimes.";
                    case Text.Sword_DescVolcanora:
                        return "From the depths of the great volcano Kranto filled with the energy from the earth's magma.";
                    case Text.Sword_DescEspadaCristal:
                        return "A sword blessed by the stars with their light and power.";
                    case Text.Sword_DescEspadaPaladin:
                        return "One of the strongest swords a man has ever wielded, to use it you will have to train very hard.";
                    case Text.Sword_AbilEspadaMadera:
                        return "No ability";
                    case Text.Sword_AbilEspadaHierro:
                        return "No ability";
                    case Text.Sword_AbilAqua:
                        return "No ability";
                    case Text.Sword_AbilOscuridadDemoniaca:
                        return "No ability";
                    case Text.Sword_AbilEspadaSombras:
                        return "No ability";
                    case Text.Sword_AbilEspadonCelestial:
                        return "No ability";
                    case Text.Sword_AbilVolcanora:
                        return "No ability";
                    case Text.Sword_AbilHidroblade:
                        return "No ability";
                    case Text.Sword_AbilInferno:
                        return "No ability";
                    case Text.Sword_AbilRebanadoraSlimes:
                        return "No ability";
                    case Text.Sword_AbilEspadonBosque:
                        return "No ability";
                    case Text.Sword_AbilEspadaCristal:
                        return "No ability";
                    case Text.Sword_AbilEspadaPaladin:
                        return "No ability";
                    #endregion
                    #region Camisas
                    case Text.Shirt_NameCampesino:
                        return "Peasant's shirt";
                    case Text.Shirt_NameChaleco:
                        return "Simple vest";
                    case Text.Shirt_NameCuelloAlto:
                        return "Turtle's neck shirt";
                    case Text.Shirt_NameInicial:
                        return "Beginner's shirt";
                    case Text.Shirt_NameJubonCamisa:
                        return "Doublet & shirt";
                    case Text.Shirt_NameLeñador:
                        return "Lumberjack's shirt";
                    case Text.Shirt_NameMangasCortas:
                        return "Short sleeve shirt";
                    case Text.Shirt_NameMercenario:
                        return "Merceary's shirt";
                    case Text.Shirt_DescCampesino:
                        return "Not the best option on the market but it will do the trick.";
                    case Text.Shirt_DescChaleco:
                        return "You might not intimidate the monsters with this, but the girls will love it.";
                    case Text.Shirt_DescCuelloAlto:
                        return "It has special protection against the cold.";
                    case Text.Shirt_DescInicial:
                        return "Perfect for starting a new adventure.";
                    case Text.Shirt_DescJubonCamisa:
                        return "The top fashion of the XV century.";
                    case Text.Shirt_DescLeñador:
                        return "If it works for a lumberjack it will for sure help you killing one or two monsters.";
                    case Text.Shirt_DescMangasCortas:
                        return "The cold breeze you will feel is nothing compared to the monsters you will encounter.";
                    case Text.Shirt_DescMercenario:
                        return "There's no manmade knife that can pierce this fabric.";
                    #endregion
                    #region Botas
                    case Text.Boots_NameInicial:
                        return "Beginner's boots";
                    case Text.Boots_NameSigilo:
                        return "Stealth Boots";
                    case Text.Boots_NameLeñador:
                        return "Lumberjack boots";
                    case Text.Boots_NameCarmesi:
                        return "Carmesi boots";
                    case Text.Boots_NameMercenario:
                        return "Mercenary boots";
                    case Text.Boots_NameAcorazado:
                        return "Reinforced boots";
                    case Text.Boots_DescInicial:
                        return "These boots are perfect for starting a new adventure.";
                    case Text.Boots_DescSigilo:
                        return "With these boots, you won’t make any sound.";
                    case Text.Boots_DescLeñador:
                        return "Pretty resistant, and I assure you they have not been worn by any lumberjack.";
                    case Text.Boots_DescCarmesi:
                        return "The leather of these boots has been infused with the power of the magical blood ruby to withstand the toughest of walks.";
                    case Text.Boots_DescMercenario:
                        return "They were made for mercenaries, but I'm sure you'll put them to good use.";
                    case Text.Boots_DescAcorazado:
                        return "Reinforced with a resistant metal, they will not be the most comfortable boots but they will keep your feet safe.";
                    #endregion
                    #region Greaves
                    case Text.Greave_NameInicial:
                        return "Beginner's greaves";
                    case Text.Greave_NameLeñador:
                        return "Lumberjack greaves";
                    case Text.Greave_NameCarmesi:
                        return "Carmesi greaves";
                    case Text.Greave_NameMercenario:
                        return "Mercenary greaves";
                    case Text.Greave_NameAcorazado:
                        return "Reinforced greaves";
                    case Text.Greave_DescInicial:
                        return "These are the perfect greaves to start a new adventure.";
                    case Text.Greave_DescLeñador:
                        return "There is no ax capable of piercing these greaves.";
                    case Text.Greave_DescCarmesi:
                        return "Imbued with the power of the magical blood ruby.";
                    case Text.Greave_DescMercenario:
                        return "Mercenaries say that no blade can pierce them.";
                    case Text.Greave_DescAcorazado:
                        return "Reinforced with an incredibly resistant metal, they will protect you from any damage.";
                    #endregion
                    #region Chestplates
                    case Text.Chestplate_NameLeñador:
                        return "Lumberjack's chestplate";
                    case Text.Chestplate_NameHierro:
                        return "Iron chestplate";
                    case Text.Chestplate_NameAqua:
                        return "Aqua chestplate";
                    case Text.Chestplate_NameMercenario:
                        return "Mercenary chestplate";
                    case Text.Chestplate_NameCelestial:
                        return "Celestial chestplate";
                    case Text.Chestplate_NameDemoniaco:
                        return "Demoniac chestplate";
                    case Text.Chestplate_NameSamurai:
                        return "Samurai chestplate";
                    case Text.Chestplate_NameVolcanico:
                        return "Volcanic chestplate";
                    case Text.Chestplate_NameCristal:
                        return "Cristal chestplate";
                    case Text.Chestplate_NamePaladin:
                        return "Paladin's chestplate";
                    case Text.Chestplate_NameHidro:
                        return "Hidrochestplate";
                    case Text.Chestplate_NameBosque:
                        return "Chestplate of the forest";
                    case Text.Chestplate_NameRebanadorSlimes:
                        return "Slimeslayer's chestplate";
                    case Text.Chestplate_NameInferno:
                        return "Inferno chestplate";
                    case Text.Chestplate_DescLeñador:
                        return "A wooden chestplate will give you a little protection.";
                    case Text.Chestplate_DescHierro:
                        return "Made of iron to offer better protection.";
                    case Text.Chestplate_DescAqua:
                        return "Relentless as the waves of the sea, it will protect you with all its might.";
                    case Text.Chestplate_DescMercenario:
                        return "If it can protect the mercenaries in all their misdeeds, it will be very useful against monsters.";
                    case Text.Chestplate_DescCelestial:
                        return "Imbued with angelic magic made with a blue steel and dinatium alloy, capable of withstanding the most ferocious attacks.";
                    case Text.Chestplate_DescDemoniaco:
                        return "A rather endurable chestplate, he is enchanted by the great demon Ragnek.";
                    case Text.Chestplate_DescSamurai:
                        return "If you ever wanted to become a samurai, with this chestplate you will feel like an authentic and courageous one.";
                    case Text.Chestplate_DescVolcanico:
                        return "Forged with the magma extracted from the depths of the earth and imbued with its great protection.";
                    case Text.Chestplate_DescCristal:
                        return "A chestplate made of magic reinforced glass. Sure is uncomfortable, but nothing will ever hurt you.";
                    case Text.Chestplate_DescPaladin:
                        return "One of the 10 mythical objects in this world, its resistance is a legend.";
                    case Text.Chestplate_DescHidro:
                        return "InProgress";
                    case Text.Chestplate_DescBosque:
                        return "InProgress";
                    case Text.Chestplate_DescRebanadorSlimes:
                        return "InProgress";
                    case Text.Chestplate_DescInferno:
                        return "InProgress";
                    #endregion
                    #region Helmets
                    case Text.Helmet_NameLeñador:
                        return "Lumberjack's helmet";
                    case Text.Helmet_NameHierro:
                        return "Iron helmet";
                    case Text.Helmet_NameAqua:
                        return "Aqua helmet";
                    case Text.Helmet_NameMercenario:
                        return "Mercenary helmet";
                    case Text.Helmet_NameCelestial:
                        return "Celestial helmet";
                    case Text.Helmet_NameDemoniaco:
                        return "Demoniac helmet";
                    case Text.Helmet_NameSamurai:
                        return "Samurai helmet";
                    case Text.Helmet_NameVolcanico:
                        return "Volcanic helmet";
                    case Text.Helmet_NameCristal:
                        return "Cristal helmet";
                    case Text.Helmet_NamePaladin:
                        return "Paladin's helmet";
                    case Text.Helmet_NameHidro:
                        return "Hidrohelmet";
                    case Text.Helmet_NameBosque:
                        return "Helmet of the forest";
                    case Text.Helmet_NameRebanadorSlimes:
                        return "Slimeslayer's helmet";
                    case Text.Helmet_NameInferno:
                        return "Inferno helmet";
                    case Text.Helmet_DescLeñador:
                        return "Who says lumberjacks don't wear helmets?";
                    case Text.Helmet_DescHierro:
                        return "Much stronger than the lumberjack helmet, but still just a piece of metal on your head.";
                    case Text.Helmet_DescAqua:
                        return "Blessed by mermaids, this helmet has magical traces that give it great resistance.";
                    case Text.Helmet_DescMercenario:
                        return "With this helmet, you will look like a mercenary, but you will remain as a hero who walks the path of rightness.";
                    case Text.Helmet_DescCelestial:
                        return "Blessed by angels to protect its bearer against any evil.";
                    case Text.Helmet_DescDemoniaco:
                        return "The great demon Ragnek used this helmet and won thousands of battles, some say that part of his magical power was imbued in it.";
                    case Text.Helmet_DescSamurai:
                        return "It has passed through several generations of samurais, always taking care of its wearer. Wear it with honor.";
                    case Text.Helmet_DescVolcanico:
                        return "Created in the depths of the earth, able to withstand extreme temperatures.";
                    case Text.Helmet_DescCristal:
                        return "Strengthened glass blessed by the Rocky Mountain Fairies to protect its wearer.";
                    case Text.Helmet_DescPaladin:
                        return "With this helmet, you will get the protection of the paladins, a passive ability that will make you much more resistant.";
                    case Text.Helmet_DescHidro:
                        return "InProgress";
                    case Text.Helmet_DescBosque:
                        return "InProgress";
                    case Text.Helmet_DescRebanadorSlimes:
                        return "InProgress";
                    case Text.Helmet_DescInferno:
                        return "InProgress";
                    #endregion
                    #region Potions
                    case Text.Potion_NameSmallLife:
                        return "Small life";
                    case Text.Potion_NameMediumLife:
                        return "Medium life";
                    case Text.Potion_NameBigLife:
                        return "Giant life";
                    case Text.Potion_NameSmallShield:
                        return "Magic shield";
                    case Text.Potion_NameMediumShield:
                        return "Powerfull shield";
                    case Text.Potion_NameBigShield:
                        return "Mistic shield";
                    case Text.Potion_NameEnergy:
                        return "Energy drink";
                    case Text.Potion_NameInmunity:
                        return "Liquid inmunity";
                    case Text.Potion_NameRange:
                        return "Enhaced vision";
                    case Text.Potion_DescSmallLife:
                        return "Regenerates one life point instantly.";
                    case Text.Potion_DescMediumLife:
                        return "Regenerates three life points instantly.";
                    case Text.Potion_DescBigLife:
                        return "Regenerates your full life instantly.";
                    case Text.Potion_DescSmallShield:
                        return "Protects you from one hit for 5 seconds";
                    case Text.Potion_DescMediumShield:
                        return "Protects you from two hits form 5 seconds.";
                    case Text.Potion_DescBigShield:
                        return "Protects you from three hits for 5 seconds";
                    case Text.Potion_DescEnergy:
                        return "Gives you unlimited energy for 5 seconds.";
                    case Text.Potion_DescInmunity:
                        return "Makes you invulnerable for 5 seconds.";
                    case Text.Potion_DescRange:
                        return "Gives you full range for 5 seconds.";
                    #endregion
                    #region Collectibles
                    case Text.Collectible_NameWaterOrbMini:
                        return "Small spiritual water orb";
                    case Text.Collectible_NameWaterOrb:
                        return "Spiritual water orb";
                    case Text.Collectible_NameWaterOrbBig:
                        return "Great spiritual water orb";
                    case Text.Collectible_DescWaterOrbMini:
                        return "Contains a bit of the essence of a water spirit.";
                    case Text.Collectible_DescWaterOrb:
                        return "Contains the essence of a water spirit.";
                    case Text.Collectible_DescWaterOrbBig:
                        return "Contains the essence of a water spirit and it's magic power.";
                    case Text.Collectible_NameWoodOrbMini:
                        return "Small spiritual wood orb";
                    case Text.Collectible_NameWoodOrb:
                        return "Spiritual wood orb";
                    case Text.Collectible_NameWoodOrbBig:
                        return "Great spiritual wood orb";
                    case Text.Collectible_DescWoodOrbMini:
                        return "Contains a bit of the essence of a dark log.";
                    case Text.Collectible_DescWoodOrb:
                        return "Contains the essence of a dark log.";
                    case Text.Collectible_DescWoodOrbBig:
                        return "Contains the essence of a dark log and it's magic power.";
                    #endregion
                    #region Achievements
                    case Text.Achievement_Title:
                        return "Achievements";
                    case Text.Achievement_Reward:
                        return "Reward";
                    case Text.Achievement_Completion:
                        return "Completed";
                    case Text.Achievement_NameWaterSlayerI:
                        return "Water slayer I";
                    case Text.Achievement_NameWaterSlayerII:
                        return "Water slayer II";
                    case Text.Achievement_NameWaterSlayerIII:
                        return "Water slayer III";
                    case Text.Achievement_NameWoodSlayerI:
                        return "Lumberjack I";
                    case Text.Achievement_NameWoodSlayerII:
                        return "Lumberjack II";
                    case Text.Achievement_NameWoodSlayerIII:
                        return "Lumberjack III";
                    case Text.Achievement_NameSlimeSlayerI:
                        return "Swampman I";
                    case Text.Achievement_NameSlimeSlayerII:
                        return "Swampman II";
                    case Text.Achievement_NameSlimeSlayerIII:
                        return "Swampman III";
                    case Text.Achievement_NameFireSlayerI:
                        return "Piromaniac I";
                    case Text.Achievement_NameFireSlayerII:
                        return "Piromaniac II";
                    case Text.Achievement_NameFireSlayerIII:
                        return "Piromaniac III";
                    case Text.Achievement_NameGatherer:
                        return "Gatherer";
                    case Text.Achievement_NamePacifist:
                        return "Pacifist";
                    case Text.Achievement_NameGameLover:
                        return "Game lover";
                    case Text.Achievement_NamePerfectionistI:
                        return "Prefectionist I";
                    case Text.Achievement_NamePerfectionistII:
                        return "Prefectionist II";
                    case Text.Achievement_NamePerfectionistIII:
                        return "Prefectionist III";
                    case Text.Achievement_NamePerfectionistIV:
                        return "Prefectionist IV";
                    case Text.Achievement_NamePerfectionistV:
                        return "Prefectionist V";
                    case Text.Achievement_NameAdventurerI:
                        return "Adventurer I";
                    case Text.Achievement_NameAdventurerII:
                        return "Adventurer II";
                    case Text.Achievement_NameAdventurerIII:
                        return "Adventurer III";
                    case Text.Achievement_NameAdventurerIV:
                        return "Adventurer IV";
                    case Text.Achievement_NameAdventurerV:
                        return "Adventurer V";
                    case Text.Achievement_NameAdventurerVI:
                        return "Adventurer VI";
                    case Text.Achievement_NameTimeMasterI:
                        return "Time master I";
                    case Text.Achievement_NameTimeMasterII:
                        return "Time master II";
                    case Text.Achievement_NameTimeMasterIII:
                        return "Time master III";
                    case Text.Achievement_NameTimeMasterIV:
                        return "Time master IV";
                    case Text.Achievement_NameTimeMasterV:
                        return "Time master V";
                    case Text.Achievement_NameSwordsmasterI:
                        return "Swordmaster I";
                    case Text.Achievement_NameSwordsmasterII:
                        return "Swordmaster II";
                    case Text.Achievement_NameSwordsmasterIII:
                        return "Swordmaster III";
                    case Text.Achievement_NameBankerI:
                        return "Banker I";
                    case Text.Achievement_NameBankerII:
                        return "Banker II";
                    case Text.Achievement_NameBankerIII:
                        return "Banker III";
                    case Text.Achievement_NameBankerIV:
                        return "Banker IV";
                    case Text.Achievement_NameBankerV:
                        return "Banker V";
                    case Text.Achievement_NameCollectionistI:
                        return "Collectionist I";
                    case Text.Achievement_NameCollectionistII:
                        return "Collectionist II";
                    case Text.Achievement_NameCollectionistIII:
                        return "Collectionist III";
                    case Text.Achievement_DescWaterSlayerI:
                        return "Defeat 25 water spirits.";
                    case Text.Achievement_DescWaterSlayerII:
                        return "Defeat 50 water spirits.";
                    case Text.Achievement_DescWaterSlayerIII:
                        return "Defeat 100 water spirits.";
                    case Text.Achievement_DescWoodSlayerI:
                        return "Defeat 25 wood spirits.";
                    case Text.Achievement_DescWoodSlayerII:
                        return "Defeat 50 wood spirits.";
                    case Text.Achievement_DescWoodSlayerIII:
                        return "Defeat 100 wood spirits.";
                    case Text.Achievement_DescSlimeSlayerI:
                        return "Defeat 25 swamp spirits.";
                    case Text.Achievement_DescSlimeSlayerII:
                        return "Defeat 50 swamp spirits.";
                    case Text.Achievement_DescSlimeSlayerIII:
                        return "Defeat 100 swamp spirits.";
                    case Text.Achievement_DescFireSlayerI:
                        return "Defeat 25 fire spirits.";
                    case Text.Achievement_DescFireSlayerII:
                        return "Defeat 50 fire spirits.";
                    case Text.Achievement_DescFireSlayerIII:
                        return "Defeat 100 fire spirits.";
                    case Text.Achievement_DescGatherer:
                        return "Gather all the orbs in the game.";
                    case Text.Achievement_DescPacifist:
                        return "Finish a level without killing any monster.";
                    case Text.Achievement_DescGameLover:
                        return "Complete all the achievements.";
                    case Text.Achievement_DescPerfectionistI:
                        return "Get 3 stars on all the levels in the first map.";
                    case Text.Achievement_DescPerfectionistII:
                        return "Get 3 stars on all the levels in the second map.";
                    case Text.Achievement_DescPerfectionistIII:
                        return "Get 3 stars on all the levels in the third map.";
                    case Text.Achievement_DescPerfectionistIV:
                        return "Get 3 stars on all the levels in the fourth map.";
                    case Text.Achievement_DescPerfectionistV:
                        return "Get 3 stars on all the levels in the fifth map.";
                    case Text.Achievement_DescAdventurerI:
                        return "Complete the tutorial.";
                    case Text.Achievement_DescAdventurerII:
                        return "Complete the first map.";
                    case Text.Achievement_DescAdventurerIII:
                        return "Complete the second map.";
                    case Text.Achievement_DescAdventurerIV:
                        return "Complete the third map.";
                    case Text.Achievement_DescAdventurerV:
                        return "Complete the fourth map.";
                    case Text.Achievement_DescAdventurerVI:
                        return "Complete the fifth map.";
                    case Text.Achievement_DescTimeMasterI:
                        return "Play a total of 1 hour.";
                    case Text.Achievement_DescTimeMasterII:
                        return "Play a total of 3 hours.";
                    case Text.Achievement_DescTimeMasterIII:
                        return "Play a total of 5 hours.";
                    case Text.Achievement_DescTimeMasterIV:
                        return "Play a total of 10 hours.";
                    case Text.Achievement_DescTimeMasterV:
                        return "Play a total of 50 hours.";
                    case Text.Achievement_DescSwordsmasterI:
                        return "Achieve a combo slash of two monsters.";
                    case Text.Achievement_DescSwordsmasterII:
                        return "Achieve a combo slash of three monsters.";
                    case Text.Achievement_DescSwordsmasterIII:
                        return "Achieve a combo slash of five monsters.";
                    case Text.Achievement_DescBankerI:
                        return "Have 100 coins in your inventory.";
                    case Text.Achievement_DescBankerII:
                        return "Have 500 coins in your inventory.";
                    case Text.Achievement_DescBankerIII:
                        return "Have 1000 coins in your inventory.";
                    case Text.Achievement_DescBankerIV:
                        return "Have 5000 coins in your inventory.";
                    case Text.Achievement_DescBankerV:
                        return "Have 10000 coins in your inventory.";
                    case Text.Achievement_DescCollectionistI:
                        return "Buy an object in the store.";
                    case Text.Achievement_DescCollectionistII:
                        return "Buy 25 objects in the store.";
                    case Text.Achievement_DescCollectionistIII:
                        return "Buy 50 objects in the store.";
                    #endregion
                    #region Monsters
                    case Text.Monster_NameWater:
                        return "Water spirit";
                    case Text.Monster_NameWood:
                        return "Wood spirit";
                    case Text.Monster_NameFire:
                        return "Fire spirit";
                    case Text.Monster_NameSlime:
                        return "Slime spirit";
                    case Text.Monster_DescWater:
                        return "Born from the resentment of the rivers from Oddsbury.";
                    case Text.Monster_DescWood:
                        return "When the forest was plaged with the diabolic energy, this monsters where born.";
                    case Text.Monster_DescFire:
                        return "Violent and wild spirits, full of energy.";
                    case Text.Monster_DescSlime:
                        return "It may be tempting to touch this creatures, but they are poisonous so watch your step.";
                    case Text.Monster_AbilWater:
                        return "None.";
                    case Text.Monster_AbilWood:
                        return "Resists more than one slash but can be damaged in any direction.";
                    case Text.Monster_AbilFire:
                        return "Ignite - It fires you up and make damage every certain time.";
                    case Text.Monster_AbilSlime:
                        return "Shoots a slime bullet that blinds you for a short amount of time.";
                    #endregion
                    #region LevelIntro
                    case Text.LevelIntro_Title:
                        return "Level";
                    case Text.LevelIntro_Defeat:
                        return "Defeat";
                    case Text.LevelIntro_Survive:
                        return "Survive";
                    case Text.LevelIntro_Monsters:
                        return "monsters";
                    case Text.LevelIntro_Seconds:
                        return "seconds";
                    case Text.LevelIntro_Potions:
                        return "Potions";
                    case Text.LevelIntro_Start:
                        return "Start";
                    case Text.LevelIntro_DescLevel_ForestOne:
                        return "Survive the surprise attack and try to not get any damage.";
                    case Text.LevelIntro_DescLevel_ForestTwo:
                        return "Get some monster samples to gather more info about them.";
                    case Text.LevelIntro_DescLevel_ForestThree:
                        return "Protect the village while they build up the defenses.";
                    case Text.LevelIntro_DescLevel_ForestFour:
                        return "Description on process...";
                    case Text.LevelIntro_DescLevel_ForestFive:
                        return "Description on process...";
                    case Text.LevelIntro_DescLevel_ForestSix:
                        return "Description on process...";
                    case Text.LevelIntro_DescLevel_ForestSeven:
                        return "Description on process...";
                    case Text.LevelIntro_DescLevel_ForestEight:
                        return "Description on process...";
                    case Text.LevelIntro_DescLevel_ForestNine:
                        return "Description on process...";
                    case Text.LevelIntro_DescLevel_ForestTen:
                        return "Description on process...";
                    #endregion
                    #region PlayMode
                    case Text.PlayMode_Horde:
                        return "Monsters:";
                    case Text.PlayMode_Time:
                        return "Time:";
                    case Text.PlayMode_Hunt:
                        return "Hunt:";
                    #endregion
                    default:
                        return null;
                }
            default:
                return null;
        }
    }
}
