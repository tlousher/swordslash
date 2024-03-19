using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Character
{
    public class Stamina : MonoBehaviour
    {
        private const float StaminaPointThreshold = 0.9f;
        
        [Header("Components")]
        public GameObject staminaPrefab;

        [Header("Sprites")]
        public Color chargedColor = Color.white;
        public Color dischargedColor = Color.clear;
        public Sprite[] staminaBar;
        public Sprite[] staminaPoint;

        private int staminaLevel;
        private Transform staminaPointsParent;
        private readonly List<Image> staminaPoints = new List<Image>();

        private void Start()
        {
            //Changes the stamina bar image to the stamina level of the player
            GetComponent<Image>().sprite = staminaBar[PlayerPrefs2.PlayerMaxStamina - 1];
            var staminaFrame = transform.GetChild(0);
            //Creates stamina points for this level, based on the maximum capacity of the player at the start of this level
            for (var i = 0; i < PlayerPrefs2.PlayerMaxStamina; i++)
            {
                //Instantiate the stamina point
                var newPoint = Instantiate(staminaPrefab, staminaFrame);

                //Moves the stamina point to it's required position
                newPoint.GetComponent<RectTransform>().anchoredPosition = new Vector2(98 * i, 0);
                
                var pointImage = newPoint.GetComponent<Image>();
                //Changes the image to it's corresponding one depending on it's number
                pointImage.sprite = staminaPoint[i];
                pointImage.color = chargedColor;
                //Fills the image to it's fullest
                pointImage.fillAmount = 1;
                
                //Adds the stamina point to the list
                staminaPoints.Add(pointImage);
            }

            //Assign the stamina points group transform
            staminaPointsParent = staminaFrame;
        }

        private void Update()
        {

            //If the stamina level is bellow the maximum level then we have to constantly update the points fill amount accordinlgy
            if (!(Player.instance.stamina < PlayerPrefs2.PlayerMaxStamina) &&
                !(staminaPoints[staminaPointsParent.childCount - 1].fillAmount < 1)) return;
            var playerStaminaToInt = Mathf.FloorToInt(Player.instance.stamina);
            var staminaResidue = Player.instance.stamina - playerStaminaToInt;

            //If there is a change on the stamina points then we adjust all the points
            if (staminaLevel != playerStaminaToInt)
            {
                //First we equal the stamina level from the bar to the one of the player
                staminaLevel = playerStaminaToInt;

                //Now we assign a full point to every point bellow the player stamina
                for (var i = 0; i < transform.childCount; i++)
                {
                    //We set the point full if the point is below the stamina
                    staminaPoints[i].fillAmount = i <= playerStaminaToInt ? 1 :
                        //If not then empty stamina
                        0;
                    staminaPoints[i].color = i <= playerStaminaToInt ? chargedColor : dischargedColor;
                }
            }

            if (playerStaminaToInt >= staminaPointsParent.childCount) return;

            //Adjust the next stamina point to the residue value of the player's stamina
            staminaPoints[playerStaminaToInt].fillAmount = staminaResidue > StaminaPointThreshold ? 1 : staminaResidue;
            staminaPoints[playerStaminaToInt].color = staminaPoints[playerStaminaToInt].fillAmount > StaminaPointThreshold ? chargedColor : dischargedColor;
        }
    }
}
