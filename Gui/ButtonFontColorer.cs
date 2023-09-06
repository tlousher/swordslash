using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gui
{
    public class ButtonFontColorer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Header("Colors")]
        public Color normalColor = Color.white;
        public Color pressedColor = new Color(0.9686275f, 0.8705883f, 0.6313726f);
        public Color disabledColor = new Color(0.7607844f, 0.7294118f, 0.6705883f);

        private bool interactionChange;
        private Button button;
        private TextMeshProUGUI text;

        private void Start()
        {
            button = GetComponent<Button>();
            text = GetComponentInChildren<TextMeshProUGUI>();
            interactionChange = !button.IsInteractable();
        }

        private void FixedUpdate()
        {
            if (!interactionChange && !button.IsInteractable())
            {
                interactionChange = true;
                text.color = disabledColor;
            }
            else if(interactionChange && button.IsInteractable())
            {
                interactionChange = false;
                text.color = normalColor;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (text && button.IsInteractable() && eventData.pointerEnter.Equals(gameObject))
            {
                text.color = pressedColor;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (text && button.IsInteractable())
            {
                text.color = normalColor;
            }
        }
    }
}
