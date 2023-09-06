using System.Collections.Generic;
using Misc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectiblesStacks : MonoBehaviour
{
    [Header("Stats")]
    public float secondsToCollect = 3.1f;
    [Header("Prefabs")]
    public GameObject orbStack;

    private Dictionary<Sprite, int> stacksCounter;
    private Dictionary<Sprite, Transform> stacksObject;
    private Queue<Sprite> orbsDropped;

    void Start()
    {
        GameManager.instance.collectiblesStacks = this;
        stacksCounter = new Dictionary<Sprite, int>();
        stacksObject = new Dictionary<Sprite, Transform>();
        orbsDropped = new Queue<Sprite>();
    }

    public void CollectibleDrop(Sprite orbSprite)
    {
        orbsDropped.Enqueue(orbSprite);
        Invoke("AddCollectibleToStack", secondsToCollect);
    }

    public void AddCollectibleToStack()
    {
        Sprite orbSprite = orbsDropped.Dequeue();
        Transform newStack = null;

        //Check if this key does exists
        if (stacksObject.ContainsKey(orbSprite))
        {
            //Asigns the stack into the variable
            newStack = stacksObject[orbSprite];
            //Adds the orb counter
            stacksCounter[orbSprite]++;
        }
        else
        {
            //Creates the new Stack
            newStack = Instantiate(orbStack, transform).transform;

            //Adds the orb to the stack
            stacksObject.Add(orbSprite, newStack);
            //Adds the orb to the counter
            stacksCounter.Add(orbSprite, 0);

            //Changes the sprite to matchs the stack
            newStack.GetChild(0).GetComponent<Image>().sprite = orbSprite;

            //Moves the stack to it's position
            RectTransform stackRectTransform = newStack.GetComponent<RectTransform>();
            stackRectTransform.anchoredPosition = new Vector2((stackRectTransform.anchoredPosition.x + stackRectTransform.sizeDelta.x + 10) * (transform.childCount - 1), stackRectTransform.anchoredPosition.y);
        }

        //Update the number in the stack
        newStack.GetComponentInChildren<TextMeshProUGUI>().text = $"x{stacksCounter[orbSprite] + 1}";
    }
}
