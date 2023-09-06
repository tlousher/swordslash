using TMPro;
using UnityEngine;

public class PopupMessage : Window
{
    [Header("Components")]
    public TextMeshProUGUI title;
    public TextMeshProUGUI body;

    public void Initialize(string title, string message, AudioSource audioSource = null)
    {
        this.audioSource = audioSource;
        this.title.text = title;
        body.text = message;
    }
}
