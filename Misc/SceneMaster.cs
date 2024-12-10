using System;
using System.Collections;
using Gui;
using Items.Potions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Vault;

namespace Misc
{
    public class SceneMaster : MonoBehaviour
    {
        private const float TimeBetweenScenes = 0.8f;
        private readonly int exitHash = Animator.StringToHash("Exit");

        [Header("Prefabs")]
        public GameObject optionsPrefab;
        public GameObject popupMessagePrefab;
        public GameObject popupConfirmationPrefab;
        public GameObject potionShopPrefab;
        public GameObject collectionsPrefab;
        public GameObject achievementsPrefab;
        public GameObject transitionCanvas;
        public GameObject achievementPopUpPrefab;
        [Header("SFX")]
        public AudioSource audioSource;
        public AudioClip error;
        public AudioClip notice;
        public AudioClip warning;
        public AudioClip achievementSfx;

        public static Levels.Level_Data levelData;
        public static SceneMaster instance;

        public enum MessageSfx
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

        public static string LevelName => $"{levelData.area}_{levelData.number}";

        public void Options()
        {
            Instantiate(optionsPrefab).GetComponent<Window>().audioSource = GetComponent<AudioSource>();
        }

        public void OpenPotionShop(Potion potion, Transform parent, UnityAction onDestroy = null)
        {
            var potionShop = Instantiate(potionShopPrefab, parent).GetComponent<PotionShop>();
            potionShop.potion = potion;
            potionShop.onDestroy = onDestroy;
        }

        public void OpenCollections(GameObject callerCanvas)
        {
            var diary = Instantiate(collectionsPrefab).GetComponent<Window>();
            diary.mainCanvas = callerCanvas;
        }
        public void OpenAchievements(GameObject callerCanvas)
        {
            var achievements = Instantiate(achievementsPrefab).GetComponent<Window>();
            achievements.mainCanvas = callerCanvas;
        }
        public void ShowAchievementPopUp(Achievement.Achievement_Data data)
        {
            var achievement = Instantiate(achievementPopUpPrefab);
            achievement.GetComponent<Achievement>().data = data;
            achievement.GetComponent<Window>().mainCanvas = FindObjectOfType<Canvas>().gameObject;
            PlayClip(MessageSfx.Other, achievementSfx);
        }

        public void ShowMessage(string title, string msg, MessageSfx messageSfx, AudioClip clip = null)
        {
            Instantiate(popupMessagePrefab).GetComponent<PopupMessage>().Initialize(title, msg, GetComponent<AudioSource>());
            PlayClip(messageSfx, clip);
        }
    
        public void ShowConfirmation(string title, string message, UnityEngine.Events.UnityAction yesEvent, UnityEngine.Events.UnityAction noEvent, MessageSfx messageSFX, AudioClip clip = null)
        {
            Instantiate(popupConfirmationPrefab).GetComponent<PopupConfirmation>().Initialize(title, message, yesEvent, noEvent, GetComponent<AudioSource>());
            PlayClip(messageSFX, clip);
        }

        private void PlayClip(MessageSfx messageSfx, AudioClip clip)
        {
            switch (messageSfx)
            {
                case MessageSfx.Error:
                    GetComponent<AudioSource>().PlayOneShot(error);
                    break;
                case MessageSfx.Notice:
                    GetComponent<AudioSource>().PlayOneShot(notice);
                    break;
                case MessageSfx.Warning:
                    GetComponent<AudioSource>().PlayOneShot(warning);
                    break;
                case MessageSfx.Other:
                    if (clip)
                    {
                        GetComponent<AudioSource>().PlayOneShot(clip);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(messageSfx), messageSfx, null);
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
            levelData = Levels.GetData(levelName);
            LoadScene(levelData.area.ToString());
        }

        public void LevelMap()
        {
            if (PlayerPrefs2.ShowTutorial)
            {
                PlayerPrefs2.ShowTutorial = false;
                LevelTraining();
                return;
            }
            LoadScene("LevelMap");
        }

        public void LevelTraining()
        {
            LoadScene("Training");
        }

        public void RestartScene()
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private static void PrepareLoading()
        {
            Time.timeScale = 1;
        }

        private void LoadScene(string sceneName)
        {
            PrepareLoading();
            StartCoroutine(StartTransition(sceneName));
        }

        private void LoadScene(int sceneIndex)
        {
            PrepareLoading();
            StartCoroutine(StartTransition(sceneIndex));
        }

        private IEnumerator StartTransition(string sceneName)
        {
            yield return BeforeTransitioning();
            yield return new WaitForSeconds(TimeBetweenScenes);

            SceneManager.LoadScene(sceneName);
        }

        private IEnumerator StartTransition(int sceneIndex)
        {
            yield return BeforeTransitioning();
            yield return new WaitForSeconds(TimeBetweenScenes);

            SceneManager.LoadScene(sceneIndex);
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
        private static IEnumerator MusicLowpassStart()
        {
            float time = 0;

            while (time < 1)
            {
                var lerp = Mathf.Lerp(18000, 10, time);
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
}
