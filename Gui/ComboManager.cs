using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    [Header("Components")]
    public Image fillBar;
    public Image fillCircle;
    public Image swordImage;
    public Button swordButton;
    [Header("Stats")]
    public int maxCombo = 10;
    public bool onCombo;
    [Range(.1f, 2)]
    public float timerStart = 2;

    public static ComboManager instance;

    private int counter;
    private float timer;
    private int achievedCombo;
    private int comboPower;

    public float FillPercent
    {
        get
        {
            return 1 / (float)maxCombo;
        }
    }

    private void Awake()
    {
        //Makes sure there is only one instance of the combo manager
        if (instance)
        {
            Destroy(instance.gameObject);
        }

        instance = this;
    }

    private void Start()
    {
        Reset();

        //Initialize the highest achieved combo
        achievedCombo = PlayerPrefs2.GetAchievementProgress(Achievements.AchievementID(Achievements.AchievementName.SwordsmasterI));
    }

    public void Reset()
    {
        //Restarts the combo bar
        fillBar.fillAmount = 0;
        comboPower = 0;

        //Resets the combo ability button
        swordImage.color = Color.gray;
        swordButton.interactable = false;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            fillCircle.fillAmount = Mathf.Clamp(1f / timerStart * timer, 0, 1);
        }
        else
        {
            ComboEnds();
        }
    }

    private void ComboEnds()
    {
        // Just runs this code if there is a combo going on
        if (onCombo)
        {
            // If I had a combo
            if (counter > 1)
            {
                // Add the counter to the players power
                comboPower += counter;
                // Updates the fill amount of the bar
                fillBar.fillAmount += counter * FillPercent;
            }

            // If this combo is bigger than the biggest combo
            if (counter > achievedCombo)
            {
                // Sets the new highest combo achieved
                PlayerPrefs2.SetAchievementProgress(Achievements.AchievementID(Achievements.AchievementName.SwordsmasterI), counter);
            }

            //Restarts the combo counter
            counter = 0;
            //Finishes the combo
            onCombo = false;

            // If I've completed the bar
            if (counter > maxCombo)
            {
                //Activates the button
                swordImage.color = Color.white;
                swordButton.interactable = true;
            }
        }
    }

    public void AddCombo()
    {
        counter++;
        onCombo = true;
        timer = timerStart;
    }
}
