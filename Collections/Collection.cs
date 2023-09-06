using System;
using System.Collections.Generic;
using Gui;
using Items;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Vault;

namespace Collections
{
    public class Collection : Window
    {
        [Header("Components")]
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
        private Categories page;
        private const int Gap = 15;

        protected override void Start()
        {
            base.Start();
            titleMonsters.GetComponent<TextMeshProUGUI>().text = Language.GetText(Language.Text.Collection_Monsters);
            titleOrbs.GetComponent<TextMeshProUGUI>().text = Language.GetText(Language.Text.Collection_Orbs);
            titleWeapons.GetComponent<TextMeshProUGUI>().text = Language.GetText(Language.Text.Collection_Weapons);
        }

        private void SetPage(int newPage)
        {
            page = (Categories)newPage;

            switch (page)
            {
                case Categories.Monsters:
                    ManageTabs(tabMonsters, tabOrbs, tabWeapons);
                    ManageTitles(titleMonsters, titleOrbs, titleWeapons);
                    InstantiateMonsters();
                    break;
                case Categories.Orbs:
                    ManageTabs(tabOrbs, tabMonsters, tabWeapons);
                    ManageTitles(titleOrbs, titleMonsters, titleWeapons);
                    InstantiateCollectibles();
                    break;
                case Categories.Weapons:
                    ManageTabs(tabWeapons, tabMonsters, tabOrbs);
                    ManageTitles(titleWeapons, titleMonsters, titleOrbs);
                    InstantiateWeapons();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #region Instantiation

        private void InstantiateWeapons()
        {
            var weapons = CollectionPrefs.GetSwordsCollection();
            var counter = 0;
            foreach (var weapon in weapons)
            {
                //Instantiates the zone
                var zone = Instantiate(prefabWeapons, itemsParent).GetComponent<ItemZone>();
                //Changes the zone data
                zone.image.sprite = weapon.collectionSprite;
                zone.image.material = weapon.collectionState == CollectionPrefs.CollectionState.Missing ? unknown : discovered;
                zone.title.text = weapon.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownName) : weapon.itemName;
                zone.description.text = weapon.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownDesc) : weapon.description;
                zone.aditional.text = Language.GetText(Language.Text.Collection_WeaponAbility) + (weapon.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownExtra) : weapon.ability);
                var rectTransform = zone.gameObject.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(0, (rectTransform.sizeDelta.y + Gap) * -counter);
                //Adds the counter
                counter++;
            }
        }

        private void InstantiateCollectibles()
        {
            var orbs = CollectionPrefs.GetOrbsCollection();
            var counter = 0;
            foreach (var orb in orbs)
            {
                //Instantiates the zone
                var zone = Instantiate(prefabOrbs, itemsParent).GetComponent<ItemZone>();
                //Changes the zone data
                zone.image.sprite = orb.collectionSprite;
                zone.image.material = orb.collectionState == CollectionPrefs.CollectionState.Missing ? unknown : discovered;
                zone.title.text = orb.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownName) : orb.itemName;
                zone.description.text = orb.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownDesc) : orb.description;
                zone.aditional.text = Language.GetText(Language.Text.Collection_OrbMonsterBase) + (orb.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownExtra) : orb.monsterBase);
                var rectTransform = zone.gameObject.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(0, (rectTransform.sizeDelta.y + Gap) * -counter);
                //Adds the counter
                counter++;
            }
        }

        private void InstantiateMonsters()
        {
            var monsters = CollectionPrefs.GetMonstersCollection();
            var counter = 0;
            foreach (var monster in monsters)
            {
                //Instantiates the zone
                var zone = Instantiate(prefabMonsters, itemsParent).GetComponent<ItemZone>();
                //Changes the zone data
                zone.image.sprite = monster.sprite;
                zone.image.material = monster.collectionState == CollectionPrefs.CollectionState.Missing ? unknown : discovered;
                zone.title.text = monster.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownName) : monster.itemName;
                zone.description.text = monster.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownDesc) : monster.description;
                zone.aditional.text = Language.GetText(Language.Text.Collection_MonsterAbility) + (monster.collectionState == CollectionPrefs.CollectionState.Missing ? Language.GetText(Language.Text.Collection_UnknownExtra) : monster.ability);
                var rectTransform = zone.gameObject.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(0, (rectTransform.sizeDelta.y + Gap) * -counter);
                //Adds the counter
                counter++;
            }
        } 
        #endregion

        private static void ManageTitles(GameObject activeTitle, GameObject inactiveTitle1, GameObject inactiveTitle2)
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

            //Moves the tabs to the correct position
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

            var unselectedTabEvent1 = unselectedTab1.GetComponent<Button>().onClick;
            //UnityEventTools.RemovePersistentListener(unselectedTabEvent1, 1);
            //UnityEventTools.AddIntPersistentListener(unselectedTabEvent1, SetPage, unselectedTab1.Equals(tabMonsters) ? 0 : 1);
            unselectedTabEvent1.RemoveAllListeners();
            tabPage1 = unselectedTab1.Equals(tabMonsters) ? 0 : 1;
            unselectedTabEvent1.AddListener(SelectTab1);


            var unselectedTabEvent2 = unselectedTab2.GetComponent<Button>().onClick;
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

        private void OpenIndex()
        {
            index.SetActive(true);
            book.SetActive(false);
        }

        private enum Categories
        {
            Monsters,
            Orbs,
            Weapons
        }
    }
}
