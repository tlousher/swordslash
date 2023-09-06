using UnityEngine;
using UnityEngine.Events;

public class AndroidEscape : MonoBehaviour
{
    public UnityEvent OnEscape;
    private bool isAndroid;

    void Start()
    {
        isAndroid = Application.platform == RuntimePlatform.Android;
        if (!isAndroid)
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isAndroid)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnEscape.Invoke();
            }
        }
    }

    public void SetNewEvent(UnityAction newEvent)
    {
        OnEscape.SetPersistentListenerState(0, UnityEventCallState.Off);
        OnEscape.AddListener(newEvent);
        OnEscape.AddListener(ResetOnEscape);
    }

    public void ResetOnEscape()
    {
        OnEscape.RemoveAllListeners();
        OnEscape.SetPersistentListenerState(0, UnityEventCallState.EditorAndRuntime);
    }
}
