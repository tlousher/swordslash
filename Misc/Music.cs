using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public static Music instance;
    public AudioMixer master;

    private void Awake()
    {
        if (instance != null)
        {
            if (instance.GetComponent<AudioSource>().clip.Equals(GetComponent<AudioSource>().clip))
            {
                //Mantain the same music
                Destroy(gameObject);
                //Start amplyfing the music for this scene
                instance.StartCoroutine(MusicLowpassEnd());
                return;
            }
            else
            {
                //Change the music
                Destroy(instance.gameObject);
                instance = this;
                //Start amplyfing the music for this scene
                StartCoroutine(MusicLowpassEnd());
            }
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        master.SetFloat("MusicVol", PlayerPrefs2.Music);
        master.SetFloat("SoundFxVol", PlayerPrefs2.Sound);
    }

    //This takes about 1 second
    private IEnumerator MusicLowpassEnd()
    {
        float time = 0;

        while (time < 1)
        {
            float lerp = Mathf.Lerp(10, 22000, time);
            instance.master.SetFloat("MusicLowpass", lerp);
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime / 3;
        }
    }

    public void ChangeVolume(Slider slider)
    {
        GetComponent<AudioSource>().volume = slider.value;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
