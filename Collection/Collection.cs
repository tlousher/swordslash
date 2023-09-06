using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Collection : Window
{
    [Header("Componenets")]
    public GameObject titleMonsters;
    public GameObject titleOrbs;
    public GameObject titleWeapons;
    public GameObject tabMonsters;
    public GameObject tabOrbs;
    public GameObject tabWeapons;
    public GameObject index;
    public GameObject book;
    [Header("Items Control")]
    public Transform itemsParent;
    public GameObject prefabMonsters;
    public GameObject prefabOrbs;
    public GameObject prefabWeapons;
    public Material discovered;
    public Material unknown;
    [Header("Colors")]
    public Color monstersColor;
    public Color orbsColor;
    public Color weaponsColor;
    public Color indexColor;

    private int tabPage1;
    private int tabPage2;
    private Categorie page;
    const int Gap = 15;

    protected override void Start()
    {
        base.Start();
        titleMonsters.GetComponent<TextMeshProUGUI>().text = Language.GetText(Language.Text.Collection_Monsters);
        titleOrbs.GetComponent<TextMeshProUGUI>().text = Language.GetText(Language.Text.Collection_Orbs);
        titleWeapons.GetComponent<TextMeshProUGUI>().text = Language.GetText(Language.Text.Collection_Weapons);
    }

    public void SetPage(int newPage)
    {
        page = (Categorie)newPage;

        switch (page)
        {
            case Categorie.Monsters:
                ManageTabs(tabMonsters, tabOrbs, tabWeapons);
                ManageTitles(titleMonsters, titleOrbs, titleWeapons);
                InstantiateMonsters();
                break;
            case Categorie.Orbs:
                ManageTabs(tabOrbs, tabMonsters, tabWeapons);
                ManageTitles(titleOrbs, titleMonsters, titleWeapons);
                InstantiateCollectibles();
                break;
            case Categorie.Weapons:
                ManageTabs(tabWeapons, tabMonsters, tabOrbs);
                ManageTitles(titleWeapons, titleMonsters, titleOrbs);
                InstantiateWeapons();
                break;
            default:
                break;
        }
    }

    #region Instantiation
    public void InstantiateWeapons()
    {
        List<Weapon.Weapon_Data> weapons = CollectionPrefs.GetSwordsCollection();
        int counter = 0;
        foreach (Weapon.Weapon_Data weapon in weapons)
        {
            //Instantiates the zone
            ItemZone zone = Instantiate(prefabWeapons, itemsParent).GetComponent<ItemZone>();
            //Changes the zone data
            zone.image.sprite = weapon.collectionSprite;
            zone.image.material = weapon.collectionState == CollectionPrefs.CollectionState.Missing ? unknown : discovered;
            zone.title.text = weapon.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownName) : weapon.itemName;
            zone.description.text = weapon.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownDesc) : weapon.description;
            zone.aditional.text = Language.GetText(Language.Text.Collection_WeaponAbility) + (weapon.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownExtra) : weapon.ability);
            RectTransform rectTransform = zone.gameObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, (rectTransform.sizeDelta.y + Gap) * -counter);
            //Adds the counter
            counter++;
        }
    }

    public void InstantiateCollectibles()
    {
        List<Collectible.Collectible_Data> orbs = CollectionPrefs.GetOrbsCollection();
        int counter = 0;
        foreach (Collectible.Collectible_Data orb in orbs)
        {
            //Instantiates the zone
            ItemZone zone = Instantiate(prefabOrbs, itemsParent).GetComponent<ItemZone>();
            //Changes the zone data
            zone.image.sprite = orb.collectionSprite;
            zone.image.material = orb.collectionState == CollectionPrefs.CollectionState.Missing ? unknown : discovered;
            zone.title.text = orb.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownName) : orb.itemName;
            zone.description.text = orb.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownDesc) : orb.description;
            zone.aditional.text = Language.GetText(Language.Text.Collection_OrbMonsterBase) + (orb.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownExtra) : orb.monsterBase);
            RectTransform rectTransform = zone.gameObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, (rectTransform.sizeDelta.y + Gap) * -counter);
            //Adds the counter
            counter++;
        }
    }

    public void InstantiateMonsters()
    {
        List<Monsters.Monster_Data> monsters = CollectionPrefs.GetMonstersCollection();
        int counter = 0;
        foreach (Monsters.Monster_Data monster in monsters)
        {
            //Instantiates the zone
            ItemZone zone = Instantiate(prefabMonsters, itemsParent).GetComponent<ItemZone>();
            //Changes the zone data
            zone.image.sprite = monster.sprite;
            zone.image.material = monster.collectionState == CollectionPrefs.CollectionState.Missing ? unknown : discovered;
            zone.title.text = monster.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownName) : monster.itemName;
            zone.description.text = monster.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownDesc) : monster.description;
            zone.aditional.text = Language.GetText(Language.Text.Collection_MonsterAbility) + (monster.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownExtra) : monster.ability);
            RectTransform rectTransform = zone.gameObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, (rectTransform.sizeDelta.y + Gap) * -counter);
            //Adds the counter
            counter++;
        }
    } 
    #endregion

    private void ManageTitles(GameObject activeTitle, GameObject inactiveTitle1, GameObject inactiveTitle2)
    {
        //Activates and deactivates the tabs
        activeTitle.SetActive(true);
        inactiveTitle1.SetActive(false);
        inactiveTitle2.SetActive(false);
    }

    private void ManageTabs(GameObject selectedTab, GameObject unselectedTab1, GameObject unselectedTab2)
    {
        //Put the correct color on every tab
        selectedTab.GetComponent<Image>().color = indexColor;
        unselectedTab1.GetComponent<Image>().color = unselectedTab1.Equals(tabMonsters) ? monstersColor : orbsColor;
        unselectedTab2.GetComponent<Image>().color = unselectedTab2.Equals(tabWeapons) ? weaponsColor : orbsColor;

        //Moves the tabs to the correct posiotion
        selectedTab.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        unselectedTab1.GetComponent<RectTransform>().anchoredPosition = new Vector2(205, 5);
        unselectedTab2.GetComponent<RectTransform>().anchoredPosition = new Vector2(410, 10);

        //Put the correct text on every tab
        selectedTab.GetComponentInChildren<TextMeshProUGUI>().text = Language.GetText(Language.Text.Collection_Index);
        unselectedTab1.GetComponentInChildren<TextMeshProUGUI>().text = unselectedTab1.Equals(tabMonsters) ? Language.GetText(Language.Text.Collection_Monsters) : Language.GetText(Language.Text.Collection_Orbs);
        unselectedTab2.GetComponentInChildren<TextMeshProUGUI>().text = unselectedTab2.Equals(tabWeapons) ? Language.GetText(Language.Text.Collection_Weapons) : Language.GetText(Language.Text.Collection_Orbs);

        //Change the events for the tabs
        UnityEvent selectedTabEvent = selectedTab.GetComponent<Button>().onClick;
        //UnityEventTools.RemovePersistentListener(selectedTabEvent, 1);
        //UnityEventTools.AddPersistentListener(selectedTabEvent, OpenIndex);
        selectedTabEvent.RemoveAllListeners();
        selectedTabEvent.AddListener(OpenIndex);

        Button.ButtonClickedEvent unselectedTabEvent1 = unselectedTab1.GetComponent<Button>().onClick;
        //UnityEventTools.RemovePersistentListener(unselectedTabEvent1, 1);
        //UnityEventTools.AddIntPersistentListener(unselectedTabEvent1, SetPage, unselectedTab1.Equals(tabMonsters) ? 0 : 1);
        unselectedTabEvent1.RemoveAllListeners();
        tabPage1 = unselectedTab1.Equals(tabMonsters) ? 0 : 1;
        unselectedTabEvent1.AddListener(SelectTab1);


        Button.ButtonClickedEvent unselectedTabEvent2 = unselectedTab2.GetComponent<Button>().onClick;
        //UnityEventTools.RemovePersistentListener(unselectedTabEvent2, 1);
        //UnityEventTools.AddIntPersistentListener(unselectedTabEvent2, SetPage, unselectedTab2.Equals(tabWeapons) ? 2 : 1);
        unselectedTabEvent2.RemoveAllListeners();
        tabPage2 = unselectedTab2.Equals(tabWeapons) ? 2 : 1;
        unselectedTabEvent2.AddListener(SelectTab2);

        //Resets the position and the content of the items
        itemsParent.transform.parent.GetComponent<Drager>().ResetContent();

    }

    private void SelectTab1()
    {
        SetPage(tabPage1);
    }

    private void SelectTab2()
    {
        SetPage(tabPage2);
    }

    public void OpenIndex()
    {
        index.SetActive(true);
        book.SetActive(false);
    }

    public enum Categorie
    {
        Monsters,
        Orbs,
        Weapons
    }
}
