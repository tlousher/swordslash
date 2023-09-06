using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gui
{
    public class MapBoard : MonoBehaviour
    {
        [Header("Components")]
        public TextMeshProUGUI mapTitle;
        public Button arrowRight;
        public Button arrowLeft;
        public GameObject[] maps;

        private int page;
        private GameObject mapDisplayed;
        private static MapBoard _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(_instance);
            }
            _instance = this;
        }

        private void Start()
        {
            page = 0;
            ChangeMap();
            arrowLeft.interactable = false;
            arrowRight.interactable = maps.Length > 1;
        }

        public void NextPage()
        {
            page++;
            NextMap();
            CheckArrowsInteraction(1);
        }

        public void PreviousPage()
        {
            page--;
            PreviousMap();
            CheckArrowsInteraction(-1);
        }

        private void CheckArrowsInteraction(int offset)
        {
            arrowLeft.interactable = page + offset > 0;
            arrowRight.interactable = (page + offset < maps.Length - 1 && maps.Length > 1);
        }

        private void PreviousMap()
        {
            ChangeMap();
        }

        private void ChangeMap()
        {
            Destroy(mapDisplayed);
            mapDisplayed = Instantiate(maps[page], transform);
            mapTitle.text = MapNameToString((MapNames)page);
        }

        private void NextMap()
        {
            ChangeMap();
        }

        public enum MapNames
        {
            Forest
        }

        public static string MapNameToString(MapNames map)
        {
            switch (map)
            {
                case MapNames.Forest:
                    return Language.GetText(Language.Text.MapName_Forest);
                default:
                    return null;
            }
        }
    }
}
