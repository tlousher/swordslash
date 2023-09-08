using System;
using Character;
using Misc;
using UnityEngine;
using UnityEngine.UI;

namespace Gui
{
    public class StarsBar : MonoBehaviour
    {
        private const double Tolerance = 0.0001;
        [Header("Components")]
        public Image fillImage;
        public Image[] starImage;
        [Header("Sprites")]
        public Sprite starOn;
        public Sprite starOff;

        private float progress;
        private int mission;

        private void Start()
        {
            //Initialize the bar fill amount to 0
            fillImage.fillAmount = 0;

            //Sets to off all the stars
            foreach (var star in starImage)
            {
                star.sprite = starOff;
            }

            //Sets the mision for this level
            mission = SceneMaster.levelData != null ? SceneMaster.levelData.mision : 1000;
        }

        private float newProgress;
        private void Update()
        {
            if (SceneMaster.levelData == null) return;
            //Checks the progress the player has made so far
            switch (SceneMaster.levelData.playmode)
            {
                case GameManager.PlayMode.Horde:
                    newProgress = 3f / mission * GameManager.instance.monstersKilled;
                    break;
                case GameManager.PlayMode.Time:
                    newProgress = 3f / SceneMaster.levelData.mision * GameManager.instance.victoryTime;
                    break;
                case GameManager.PlayMode.Train:
                case GameManager.PlayMode.Hunt:
                    newProgress = 3f / PlayerPrefs2.PlayerMaxHealth * Player.instance.healthPoints;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            //Check if ther is new progress
            if (Math.Abs(progress - newProgress) < Tolerance) return;
            //Sets the new progress
            progress = newProgress;

            //Adjust the stars to show that progress
            for (var i = 0; i < Mathf.FloorToInt(progress); i++)
            {
                if (starImage[i].sprite.Equals(starOff))
                {
                    starImage[i].sprite = starOn;
                }
            }

            //Adjust the bar to show that progress
            fillImage.fillAmount = progress / 3;
        }
    }
}
