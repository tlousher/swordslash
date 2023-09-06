using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputModifier : MonoBehaviour
{
    private const int ClickMargin = 3;
    [Header("Stats")]
    public Canvas mainCanvas;
    [Header("Events")]
    public UnityEvent OnPointerDown;
    public UnityEvent OnPointerUp;
    public UnityEvent OnPointerClick;
    public UnityEvent OnPointerDrag;

    public static Vector2 beginPosition;

    private bool clicking;
    private bool touchIn;
    private GraphicRaycaster raycaster;
    private PointerEventData pointerEventData;

    void Start()
    {
        if (mainCanvas)
        {
            raycaster = mainCanvas.GetComponent<GraphicRaycaster>(); 
        }
    }

    private void Update()
    {
        #region Touch input controll
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (IsPointerOnMe(touch.position))
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        beginPosition = touch.position;
                        touchIn = IsPointerOnMe(touch.position);
                        if (touchIn)
                        {
                            clicking = true;
                            if (OnPointerDown != null)
                            {
                                OnPointerDown.Invoke();
                            }
                        }
                        break;
                    case TouchPhase.Moved:
                        if (touchIn && !CheckProximity(beginPosition, touch.position, ClickMargin))
                        {
                            clicking = false;
                            if (OnPointerDrag != null)
                            {
                                OnPointerDrag.Invoke();
                            }
                        }
                        break;
                    case TouchPhase.Ended:
                        if (touchIn)
                        {
                            if (clicking && CheckProximity(beginPosition, touch.position, ClickMargin))
                            {
                                if (OnPointerClick != null)
                                {
                                    OnPointerClick.Invoke();
                                }
                            }
                            if (OnPointerUp != null)
                            {
                                OnPointerUp.Invoke();
                            }
                        }
                        break;
                    default:
                        break;
                } 
            }
        } 
        #endregion
    }

    private bool IsPointerOnMe(Vector3 inputPosition)
    {
        pointerEventData = new PointerEventData(EventSystem.current)
        {
            //Set the Pointer Event Position to that of the mouse position
            position = inputPosition
        };

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        raycaster.Raycast(pointerEventData, results);

        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.Equals(gameObject))
            {
                return true;
            }
        }

        return false;
    }

    private static bool CheckProximity(Vector2 start, Vector2 end, float margin) => (end.x > start.x - margin && end.x < start.x + margin && end.y > start.y - margin && end.y < start.y + margin);
}
