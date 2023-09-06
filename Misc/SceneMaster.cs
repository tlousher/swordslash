using System.Collections;
using Gui;
using Items.Potions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    private const float TimeBeetwenScenes = 2f;
    readonly int exitHash = Animator.StringToHash("Exit");

    [Header("Prefabs")]
    public GameObject optionsPrefab;
    public GameObject popupMessagePrefab;
    public GameObject popupConfirmationPrefab;
    public GameObject potionShopPrefab;
    public GameObject collectionsPrefab;
    public GameObject achievementsPrefab;
    public GameObject transitionCanvas;
    [Header("SFX")]
    public AudioSource audioSource;
    public AudioClip error;
    public AudioClip notice;
    public AudioClip warning;

    public static Levels.Level_Data level_Data;
    public static SceneMaster instance;

    public enum MessageSFX
    {
        Error,
        Notice,
        Warning,
        Other
    }

    private void Awake()
    {
        if (instance)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
    }

    public static string LevelName
    {
        get
        {
            return $"{level_Data.area}_{level_Data.number}";
        }
    }

    public void Options()
    {
        Instantiate(optionsPrefab).GetComponent<Window>().audioSource = GetComponent<AudioSource>();
    }

    public void OpenPotionShop(Potion potion, Transform parent, UnityAction onDestroy = null)
    {
        PotionShop potionShop = Instantiate(potionShopPrefab, parent).GetComponent<PotionShop>();
        potionShop.potion = potion;
        potionShop.onDestroy = onDestroy;
    }

    public void OpenCollections(GameObject callerCanvas)
    {
        Window diary = Instantiate(collectionsPrefab).GetComponent<Window>();
        diary.mainCanvas = callerCanvas;
    }
    public void OpenAchievements(GameObject callerCanvas)
    {
        Window achievements = Instantiate(achievementsPrefab).GetComponent<Window>();
        achievements.mainCanvas = callerCanvas;
    }

    public void ShowMessage(string title, string msg, MessageSFX messageSFX, AudioClip clip = null)
    {
        Instantiate(popupMessagePrefab).GetComponent<PopupMessage>().Initialize(title, msg, GetComponent<AudioSource>());
        PlayClip(messageSFX, clip);
    }
    
    public void ShowConfirmation(string title, string message, UnityEngine.Events.UnityAction yesEvent, UnityEngine.Events.UnityAction noEvent, MessageSFX messageSFX, AudioClip clip = null)
    {
        Instantiate(popupConfirmationPrefab).GetComponent<PopupConfirmation>().Initialize(title, message, yesEvent, noEvent, GetComponent<AudioSource>());
        PlayClip(messageSFX, clip);
    }

    private void PlayClip(MessageSFX messageSFX, AudioClip clip)
    {
        switch (messageSFX)
        {
            case MessageSFX.Error:
                GetComponent<AudioSource>().PlayOneShot(error);
                break;
            case MessageSFX.Notice:
                GetComponent<AudioSource>().PlayOneShot(notice);
                break;
            case MessageSFX.Warning:
                GetComponent<AudioSource>().PlayOneShot(warning);
                break;
            case MessageSFX.Other:
                if (clip)
                {
                    GetComponent<AudioSource>().PlayOneShot(clip);
                }
                break;
        }
    }

    public void MainMenu()
    {
        LoadScene("MainMenu");
    }

    public void OpenShop()
    {
        LoadScene("Shop");
    }

    public void LoadLevel(string levelName)
    {
        level_Data = Levels.GetData(levelName);
        LoadScene(level_Data.area.ToString());
    }

    public void LevelMap()
    {
        LoadScene("LevelMap");
    }

    public void RestartScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void PrepareLoading()
    {
        Time.timeScale = 1;
    }

    private void LoadScene(string SceneName)
    {
        PrepareLoading();
        StartCoroutine(StartTransition(SceneName));
    }

    private void LoadScene(int SceneIndex)
    {
        PrepareLoading();
        StartCoroutine(StartTransition(SceneIndex));
    }

    private IEnumerator StartTransition(string SceneName)
    {
        yield return BeforeTransitioning();
        yield return new WaitForSeconds(TimeBeetwenScenes);

        SceneManager.LoadScene(SceneName);
    }

    private IEnumerator StartTransition(int SceneIndex)
    {
        yield return BeforeTransitioning();
        yield return new WaitForSeconds(TimeBeetwenScenes);

        SceneManager.LoadScene(SceneIndex);
    }

    public IEnumerator GlobalChrono()
    {
        while (instance == this)
        {
            yield return new WaitForSeconds(60f);
            PlayerPrefs2.SetTimePlayed(PlayerPrefs2.GetTimePlayed() + 60);
        }
    }

    private Coroutine BeforeTransitioning()
    {
        transitionCanvas.GetComponent<Animator>().SetTrigger(exitHash);

        //Start reducing the music for the next scene
        return StartCoroutine(MusicLowpassStart());
    }

    //This takes about 1 second
    private IEnumerator MusicLowpassStart()
    {
        float time = 0;

        while (time < 1)
        {
            float lerp = Mathf.Lerp(18000, 10, time);
            Music.instance.master.SetFloat("MusicLowpass", lerp);
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime / 3;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
