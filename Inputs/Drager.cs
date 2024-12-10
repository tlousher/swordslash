using System.Collections;
using UnityEngine;

public class Drager : InputModifier
{
    [Header("Stats")]
    public int gap;
    public bool vertical = false;
    [SerializeField] private float speed;
    [Header("Components")]
    public GameObject content;

    private bool inertia;
    private float dragSpeed;
    private float dragMovement;
    private RectTransform contentRect;

    private float ChildSize => vertical ? content.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y : content.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;

    private float MaxPosition => (ChildSize + gap) * (vertical ? content.transform.childCount - 1 : -content.transform.childCount + 1) + (vertical ? -content.GetComponent<RectTransform>().sizeDelta.y : content.GetComponent<RectTransform>().sizeDelta.x);

    private int MinPosition => vertical ? -20 : 20;

    private void Awake()
    {
        contentRect = content.GetComponent<RectTransform>();
        OnPointerDown.AddListener(DragStart);
        OnPointerUp.AddListener(DragInertia);
        OnPointerDrag.AddListener(DragContent);
    }

    public void DragStart()
    {
        //Stops any inertia motion left
        inertia = false;
    }

    public void DragContent()
    {
        var delta = Input.GetTouch(0).deltaPosition;
        dragMovement = vertical ? delta.y : delta.x;

        //float newPosition = initialPosition.x + dragMovement;
        var newPosition = (vertical ? contentRect.anchoredPosition.y : contentRect.anchoredPosition.x) + (vertical ? delta.y : delta.x) * speed;
        if (CheckBounds(newPosition))
        {
            //Applys that movement to the content position
            contentRect.anchoredPosition = new Vector2(vertical ? contentRect.anchoredPosition.x : newPosition, vertical ? newPosition : contentRect.anchoredPosition.y);
            //Ativates the inertia
            inertia = true;
        }

        //Saves the last movement speed
        dragSpeed = delta.magnitude * Input.GetTouch(0).deltaTime;
    }

    public void DragInertia()
    {
        StartCoroutine(ResidualDrag());
    }

    private IEnumerator ResidualDrag()
    {
        float endPosition = (vertical ? contentRect.anchoredPosition.y : contentRect.anchoredPosition.x) + dragMovement * 5;
        float time = 0;
        float timeLerper = 0;

        float lerp = Mathf.Lerp(vertical ? contentRect.anchoredPosition.y : contentRect.anchoredPosition.x, endPosition, time);
        while (inertia && CheckBounds(lerp) && time < 1)
        {
            contentRect.anchoredPosition = new Vector2(vertical ? contentRect.anchoredPosition.x : lerp, vertical ? lerp : contentRect.anchoredPosition.y);
            time += Time.deltaTime * Mathf.Lerp(Mathf.Clamp(dragSpeed, 0, 3) * 3, 1, timeLerper);
            timeLerper += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            lerp = Mathf.Lerp((vertical ? contentRect.anchoredPosition.y : contentRect.anchoredPosition.x), endPosition, time);
        }
        inertia = false;
    }

    private bool CheckBounds(float position)
    {
        //Move the content to the corresponding bound
        if (position < (vertical ? MinPosition : MaxPosition))
        {
            contentRect.anchoredPosition = new Vector2(vertical ? contentRect.anchoredPosition.x : MaxPosition, vertical ? MinPosition : contentRect.anchoredPosition.y);
            return false;
        }
        else if (position > (vertical ? MaxPosition : MinPosition))
        {
            contentRect.anchoredPosition = new Vector2(vertical ? contentRect.anchoredPosition.x : MinPosition, vertical ? MaxPosition : contentRect.anchoredPosition.y);
            return false;
        }

        return true;
    }

    public void ResetContent()
    {
        //Moves the content to a zero position
        contentRect.anchoredPosition = Vector2.zero;
        //Destroy every child of content
        for (int i = 0; i < contentRect.childCount; i++)
        {
            Destroy(contentRect.GetChild(i).gameObject);
        }
    }
}
