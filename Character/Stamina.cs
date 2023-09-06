using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [Header("Components")]
    public GameObject staminaPrefab;
    [Header("Sprites")]
    public Sprite[] staminaBar;
    public Sprite[] staminaPoint;

    private int staminaLevel;
    private Transform staminaPoints;

    void Start()
    {
        //Changes the stamina bar image to the stamina level of the player
        GetComponent<Image>().sprite = staminaBar[PlayerPrefs2.PlayerMaxStamina - 1];
        //Creates stamina points for this level, based on the maximum capacity of the player at the start of this level
        for (int i = 0; i < PlayerPrefs2.PlayerMaxStamina; i++)
        {
            //Instantiate the stamina point
            GameObject newPoint = Instantiate(staminaPrefab, transform.GetChild(0));

            //Moves the stamina point to it's required position
            newPoint.GetComponent<RectTransform>().anchoredPosition = new Vector2(98 * i, 0);
            //Changes the image to it's coresponding one depending on it's number
            newPoint.GetComponent<Image>().sprite = staminaPoint[i];
            //Fills the image to it's fullets
            newPoint.GetComponent<Image>().fillAmount = 1;
        }

        //Assign the stamina points group transform
        staminaPoints = transform.GetChild(0);
    }

    void Update()
    {

        //If the stamine level is bellow the maximum level then we have to constantly update the points fill amount accordinlgy
        if (Player.instance.stamina < PlayerPrefs2.PlayerMaxStamina || staminaPoints.GetChild(staminaPoints.childCount - 1).GetComponent<Image>().fillAmount < 1)
        {
            int playerStaminaToInt = Mathf.FloorToInt(Player.instance.stamina);
            float staminaResidue = Player.instance.stamina - playerStaminaToInt;

            //If there is a change on the stamina points then we adjust all the points
            if (staminaLevel != playerStaminaToInt)
            {
                //First we equal the stamina level from the bar to the one of the player
                staminaLevel = playerStaminaToInt;

                //Now we assign a full point to every point bellow the player stamina
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (i <= playerStaminaToInt)
                    {
                        //We set the point full if the point is below the stamina
                        staminaPoints.GetChild(i).GetComponent<Image>().fillAmount = 1;
                    }
                    else
                    {
                        //If not then empty stamina
                        staminaPoints.GetChild(i).GetComponent<Image>().fillAmount = 0;
                    }
                }
            }

            if (playerStaminaToInt < staminaPoints.childCount)
            {
                //Adjust the next stamina point to the residue value of the player's stamina
                staminaPoints.GetChild(playerStaminaToInt).GetComponent<Image>().fillAmount = staminaResidue; 
            }
        }
    }
}
