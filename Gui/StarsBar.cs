using UnityEngine;
using UnityEngine.UI;

public class StarsBar : MonoBehaviour
{
    [Header("Components")]
    public Image fillImage;
    public Image[] starImage;
    [Header("Sprites")]
    public Sprite starOn;
    public Sprite starOff;

    private float progress;
    private int mision;

    private void Start()
    {
        //Initialize the bar fill amount to 0
        fillImage.fillAmount = 0;

        //Sets to off all the stars
        for (int i = 0; i < starImage.Length; i++)
        {
            starImage[i].sprite = starOff;
        }

        //Sets the mision for this level
        mision = SceneMaster.level_Data.mision;
    }

    private float newProgress;
    private void Update()
    {
        //Checks the progress the player has made so far
        switch (SceneMaster.level_Data.playmode)
        {
            case GameManager.PlayMode.Horde:
                newProgress = 3f / mision * GameManager.instance.monstersKilled;
                break;
            case GameManager.PlayMode.Time:
                newProgress = 3f / SceneMaster.level_Data.mision * GameManager.instance.victoryTime;
                break;
            case GameManager.PlayMode.Hunt:
                newProgress = 3f / PlayerPrefs2.PlayerMaxHealth * Player.instance.healthPoints;
                break;
        }

        //Check if ther is new progress
        if (progress != newProgress)
        {
            //Sets the new progress
            progress = newProgress;

            //Adjust the stars to show that progress
            for (int i = 0; i < Mathf.FloorToInt(progress); i++)
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
