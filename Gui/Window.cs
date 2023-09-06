using UnityEngine;
using UnityEngine.Events;

public class Window : MonoBehaviour
{
    [HideInInspector]
    public AudioSource audioSource;
    [HideInInspector]
    public GameObject mainCanvas;
    [HideInInspector]
    public UnityAction onDestroy;

    protected virtual void Start()
    {
        Canvas myCanvas = GetComponent<Canvas>();
        if (myCanvas && myCanvas.worldCamera == null)
        {
            myCanvas.worldCamera = Camera.main;
        }
        if (mainCanvas)
        {
            mainCanvas.SetActive(false);
        }
    }

    public void MainMenu()
    {
        SceneMaster.instance.MainMenu();
    }

    public void LevelMap()
    {
        SceneMaster.instance.LevelMap();
    }

    virtual public void Close()
    {
        if (mainCanvas)
        {
            mainCanvas.SetActive(true);
        }
        if (onDestroy != null)
        {
            onDestroy.Invoke();
        }
        Destroy(gameObject);
    }

    public void PlayOneShot(AudioClip clip)
    {
        if (audioSource)
        {
            audioSource.PlayOneShot(clip); 
        }
    }
}
