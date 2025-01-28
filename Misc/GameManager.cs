using System;
using System.Collections.Generic;
using Character;
using Gui;
using Items;
using Items.Potions;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Vault;

namespace Misc
{
    public class GameManager : MonoBehaviour
    {
        [Header("Stats")]
        public bool gameOver;
        public bool paused;
        public int score;
        public int monstersEscaped;
        public int monstersKilled;
        public float victoryTime;
        [Header("Components")]
        public GameObject life;
        public Image background;
        public Image foreground;
        public TextMeshProUGUI mision;
        public TextMeshProUGUI misionProgress;
        public GameObject HUD;
        public GameObject enemiesGroup;
        public Potion primaryPotion;
        public Potion secondaryPotion;
        [Header("Prefabs")]
        public GameObject defeatWindow;
        public GameObject victoryWindow;
        public GameObject pauseWin;
        public GameObject lifePoint;
        [Header("Audio")]
        public AudioMixerSnapshot unPausedSnapshot;
        public AudioMixerSnapshot pausedSnapshot;
        [Header("Sprites")]
        public Sprite heartFull;
        public Sprite heartEmpty;

        public Queue<Collectible.CollectibleData> collectibles;
        public List<Monsters.MonsterData> newMonsters;
        [HideInInspector]
        public CollectiblesStacks collectiblesStacks;

        public static GameManager instance;

        public bool IsPlaying => !(gameOver || paused);

        public static int StarsCount
        {
            get
            {
                switch (SceneMaster.levelData.playmode)
                {
                    case PlayMode.Horde:
                        return Mathf.FloorToInt(3f / SceneMaster.levelData.mision * instance.monstersKilled);
                    case PlayMode.Time:
                        return Mathf.FloorToInt(3f / SceneMaster.levelData.mision * instance.victoryTime);
                    case PlayMode.Hunt:
                        return Mathf.FloorToInt(3f / PlayerPrefs2.PlayerMaxHealth * Player.instance.healthPoints);
                    default:
                        return -1;
                }
            }
        }

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(instance);
            }
            instance = this;
            gameOver = false;
            collectibles = new Queue<Collectible.CollectibleData>();

            //Carga los puntos de vida segun la vida del jugador
            LoadLifePoints();

            //Creates the spawner set and enviroment for the level
            try
            {
                Instantiate(Resources.Load<GameObject>($"Level/SpawnerSets/SpawnerSet_{SceneMaster.LevelName}"));
                background.sprite = Resources.Load<Sprite>($"Level/Enviroments/Background_{SceneMaster.LevelName}");
                foreground.sprite = Resources.Load<Sprite>($"Level/Enviroments/Enviroment_{SceneMaster.LevelName}");
                

                //Make the changes for the level depending on the playmode
                switch (SceneMaster.levelData.playmode)
                {
                    case PlayMode.Horde:
                        mision.text = Language.GetText(Language.Text.PlayMode_Horde);
                        break;
                    case PlayMode.Hunt:
                        mision.text = Language.GetText(Language.Text.PlayMode_Hunt);
                        break;
                    case PlayMode.Time:
                        mision.text = Language.GetText(Language.Text.PlayMode_Time);
                        break;
                    case PlayMode.Train:
                        mision.text = Language.GetText(Language.Text.PlayMode_Train);
                        break;
                    default:
                        mision.text = Language.GetText(Language.Text.PlayMode_Horde);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.Log("DEVELOPER ACCESS\nNo se cargara spawners, background, foreground ni el modo de juego.\nNo se ha definido el nivel en el SceneMaster.levelData");
                mision.text = "DEBUG";
            }

            //Put the equipped potions
            primaryPotion.data = PlayerPrefs2.GetEquippedPrimaryPotion();
            primaryPotion.UpdateSprite();
            secondaryPotion.data = PlayerPrefs2.GetEquippedSecondaryPotion();
            secondaryPotion.UpdateSprite();
        }

        private void Update()
        {
            if (!IsPlaying) return;
            //Updates the mision progress
            MissionUpdate();
            //Updates the life of the player
            UpdateLife();

            if (SceneMaster.levelData == null) return;
            //Check defeat
            if (Player.instance.healthPoints < 1)
            {
                if (SceneMaster.levelData.playmode == PlayMode.Time && StarsCount >= 1)
                {
                    victoryTime = Time.timeSinceLevelLoad;
                    Victory();
                }
                else
                {
                    Defeated();
                }
            }
            else
            {
                if (SceneMaster.levelData == null) return;
                //Check victory based on the level playmode
                if (VictoryMission() < SceneMaster.levelData.mision) return;
                victoryTime = Time.timeSinceLevelLoad;
                Victory();
            }
        }

        #region Mission
        private int VictoryMission()
        {
            if (SceneMaster.levelData == null) return int.MaxValue;
            switch (SceneMaster.levelData.playmode)
            {
                case PlayMode.Horde:
                    return monstersEscaped + monstersKilled;
                case PlayMode.Time:
                    return Mathf.FloorToInt(Time.timeSinceLevelLoad);
                case PlayMode.Hunt:
                    return monstersKilled;
                case PlayMode.Train:
                default:
                    return int.MaxValue;
            }
        }

        private void MissionUpdate()
        {
            if (SceneMaster.levelData == null)
            {
                misionProgress.text = "--";
                return;
            }
            switch (SceneMaster.levelData.playmode)
            {
                case PlayMode.Horde:
                    misionProgress.text = $"{SceneMaster.levelData.mision - (monstersEscaped + monstersKilled)}";
                    break;
                case PlayMode.Time:
                    misionProgress.text = $"{SceneMaster.levelData.mision - Mathf.FloorToInt(Time.timeSinceLevelLoad)}s";
                    break;
                case PlayMode.Train:
                case PlayMode.Hunt:
                    misionProgress.text = $"{monstersKilled} / {SceneMaster.levelData.mision}";
                    break;
                default:
                    misionProgress.text = $"{SceneMaster.levelData.mision - (monstersEscaped + monstersKilled)}";
                    break;
            }
        } 
        #endregion

        #region Life
        public void UpdateLife()
        {
            for (var i = 0; i < PlayerPrefs2.PlayerMaxHealth; i++)
            {
                life.transform.GetChild(i).GetComponent<Image>().sprite = i + 1 <= Player.instance.healthPoints ? heartFull : heartEmpty;
            }
        }

        private void LoadLifePoints()
        {
            for (var i = 0; i < PlayerPrefs2.PlayerMaxHealth; i++)
            {
                Instantiate(lifePoint, life.transform).GetComponent<RectTransform>().anchoredPosition = new Vector2(100 * i, 0);
            }
        }
        #endregion

        #region Game States
        private void Defeated()
        {
            GameOver(defeatWindow);
        }

        private void GameOver(GameObject gameOverWindow)
        {
            gameOver = true;
            for (var i = 0; i < enemiesGroup.transform.childCount; i++)
            {
                Destroy(enemiesGroup.transform.GetChild(i).gameObject);
            }
            Instantiate(gameOverWindow);
        }

        private void Victory()
        {
            GameOver(victoryWindow);
        }

        public void Pause()
        {
            //paused = true;
            Time.timeScale = 0;
            pausedSnapshot.TransitionTo(0.1f);
            Instantiate(pauseWin);
        }

        public void UnPause()
        {
            //paused = false;
            unPausedSnapshot.TransitionTo(0.3f);
            Time.timeScale = 1;
        }
        #endregion

        public enum PlayMode
        {
            // Sobrevive X monstruos
            Horde,
            // Sobrevive X segundos
            Time,
            // Caza X monstruos
            Hunt,
            Train
        }
    }
}
