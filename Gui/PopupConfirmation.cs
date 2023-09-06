using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PopupConfirmation : Window
{
    [Header("Components")]
    public TextMeshProUGUI title;
    public TextMeshProUGUI body;
    public GameObject yes;
    public GameObject no;
    public GameObject signature;

    private UnityAction yesEvent;
    private UnityAction noEvent;
    private bool yesOption;

    public void Initialize(string title, string message, UnityAction yesEvent, UnityAction noEvent, AudioSource audioSource = null)
    {
        this.audioSource = audioSource;
        this.title.text = title;
        this.yesEvent = yesEvent;
        this.noEvent = noEvent;
        body.text = message;
    }

    public void CallEvent(bool yesOption)
    {
        this.yesOption = yesOption;
        yes.SetActive(false);
        no.SetActive(false);
        signature.SetActive(true);
        Invoke("EventInvoker", 1.1f);
        Destroy(gameObject, 1.2f);
    }

    private void EventInvoker()
    {
        if (yesOption)
        {
            if (yesEvent != null)
            {
                yesEvent.Invoke();
            }
        }
        else
        {
            if (noEvent != null)
            {
                noEvent.Invoke();
            }
        }
    }
}
