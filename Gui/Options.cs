using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    [Header("Components")]
    public Dropdown dropdown;
    public Slider musicSlider;
    public Slider soundSlider;
    public AudioMixer audioMaster;

    private void Start()
    {
        musicSlider.value = PlayerPrefs2.Music;
        soundSlider.value = PlayerPrefs2.Sound;
        audioMaster.SetFloat("MusicVol", PlayerPrefs2.Music);
        audioMaster.SetFloat("SoundFxVol", PlayerPrefs2.Sound);

        //Makes the escape button to close this window
        AndroidEscape escape = FindObjectOfType<AndroidEscape>();
        if (escape)
        {
            escape.SetNewEvent(GetComponent<Window>().Close);
        }
    }

    public void ChangeLenguage()
    {
        PlayerPrefs2.SelectedLanguage = (Language.Languages)dropdown.value;
    }

    public void SetAwakeSelection()
    {
        dropdown.value = (int)PlayerPrefs2.SelectedLanguage;
        dropdown.mainText.text = $"{(Language.Languages)dropdown.value}";
}

    public void ChangeMusicVolume(float musicLvl)
    {
        PlayerPrefs2.Music = PlayerPrefs2.ControlledVolume(musicLvl, PlayerPrefs2.MusicMin);
        audioMaster.SetFloat("MusicVol", PlayerPrefs2.Music);
    }

    public void ChangeSoundVolume(float sfxLvl)
    {
        PlayerPrefs2.Sound = PlayerPrefs2.ControlledVolume(sfxLvl, PlayerPrefs2.SoundMin);
        audioMaster.SetFloat("SoundFxVol", PlayerPrefs2.Sound);
    }
}
