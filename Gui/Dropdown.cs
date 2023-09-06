using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Dropdown : MonoBehaviour
{
    private const int ItemDiference = -87;

    [Header("Components")]
    public TextMeshProUGUI mainText;
    public GameObject display;
    public Transform content;
    public GameObject item;
    public GameObject arrowUp;
    public GameObject arrowDown;
    [Header("Values")]
    public List<string> options;
    [Header("Events")]
    public UnityEvent onValueChange;
    public UnityEvent onAwake;

    [HideInInspector]
    public int value;

    private Stack<GameObject> items;

    private void Awake()
    {
        items = new Stack<GameObject>();
        value = 0;
        onAwake.Invoke();
    }

    public void Open()
    {
        display.SetActive(true);

        for (int i = options.Count - 1; i >= 0; i--)
        {
            items.Push(Instantiate(item, content));
            GameObject newItem = items.Peek();
            RectTransform itemRect = newItem.GetComponent<RectTransform>();
            newItem.SetActive(true);
            itemRect.anchoredPosition = new Vector2(itemRect.anchoredPosition.x, ItemDiference * i - 8);
            newItem.GetComponentInChildren<TextMeshProUGUI>().text = options[i];
            if (value == i)
            {
                newItem.transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        arrowDown.SetActive(false);
        arrowUp.SetActive(true);
    }

    public void Close()
    {
        display.SetActive(false);

        foreach (GameObject itm in items)
        {
            Destroy(itm);
        }
        items = new Stack<GameObject>();

        arrowUp.SetActive(false);
        arrowDown.SetActive(true);
    }

    public void Select(GameObject selected)
    {
        GameObject[] itemArray = items.ToArray();

        for (int i = 0; i < itemArray.Length; i++)
        {
            if (itemArray[i].Equals(selected))
            {
                value = i;
                break;
            }
        }
        mainText.text = itemArray[value].GetComponentInChildren<TextMeshProUGUI>().text;
        onValueChange.Invoke();
        Close();
    }
}
