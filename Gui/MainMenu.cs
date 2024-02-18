using Gui;
using UnityEngine;
using UnityEngine.Playables;

public class MainMenu : MonoBehaviour
{
    readonly int noTextHash = Animator.StringToHash("MainMenu_NoText");
    public bool started;
    private PlayableDirector director;
    private static bool firstOpen = false;

    private void Awake()
    {
        started = false;
        director = GetComponent<PlayableDirector>();
        if (!firstOpen)
        {
            FindObjectOfType<Transition>().GetComponent<Animator>().Play("Idle");
        }
        firstOpen = true;
    }

    private void Update()
    {
        if ((Input.touchCount > 0 || Input.GetMouseButtonDown(0)) && !started)
        {
            started = true;
            director.Play();
            GetComponent<Animator>().Play(noTextHash);
        }
    }
}
