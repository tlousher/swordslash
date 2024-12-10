using System.Collections;
using Collections;
using Gui;
using Items;
using Misc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vault;

public class WindowVictory : Window
{
    [Header("Components")]
    public TextMeshProUGUI coins;
    public TextMeshProUGUI exp;
    public Animator stars;
    public Image starOne;
    public Image starTwo;
    public Image starThree;
    public ExpWheel wheel;
    public GameObject collectiblePrefab;
    [Header("Sprites")]
    public Sprite starOn;
    public Sprite starOff;

    private int starsCount;

    protected override void Start()
    {
        base.Start();
        #region 1.Experience
        //Starts the experience wheel on the experience before adding the gained one
        wheel.UpdateWheel();
        //Adds experience to the player
        PlayerPrefs2.AddExperience(GameManager.instance.score);
        #endregion
        #region 2.Collectibles
        //Saves all the changes on collectibles and coins
        var collectibles = GameManager.instance.collectibles.ToArray();
        foreach (var collectible in collectibles)
        {
            PlayerPrefs2.Coins += collectible.price;
        }
        #endregion
        #region 3.Stars
        //Calculates the stars winned on the level
        starsCount = GameManager.StarsCount;

        //Put the right sprite on the stars
        starOne.sprite = starsCount >= 1 ? starOn : starOff;
        starTwo.sprite = starsCount >= 2 ? starOn : starOff;
        starThree.sprite = starsCount >= 3 ? starOn : starOff;

        if (starsCount >= 3 && PlayerPrefs2.GetLevelStars(SceneMaster.LevelName) < 3)
        {
            switch (SceneMaster.levelData.area)
            {
                case Map.Area.Forest:
                    PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementName.PerfectionistI);
                    break;
                case Map.Area.Mountain:
                    PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementName.PerfectionistII);
                    break;
                case Map.Area.Volcano:
                    PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementName.PerfectionistIII);
                    break;
                case Map.Area.Cavern:
                    PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementName.PerfectionistIV);
                    break;
                case Map.Area.Capital:
                    PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementName.PerfectionistV);
                    break;
                default:
                    break;
            }
        }

        //Saves the stars on the level and the expirience tha player have winned
        PlayerPrefs2.SetLevelStars(SceneMaster.LevelName, starsCount);
        #endregion

        //Starts just animation
        StartCoroutine(ManageAnimations());

        if (GameManager.instance.monstersKilled == 0)
        {
            PlayerPrefs2.IncreaseAchievementProgress(Achievements.Achievements.AchievementName.Pacifist);
        }
    }

    #region Animation
    private IEnumerator ManageAnimations()
    {
        //Start the animations for the text
        yield return StartCoroutine(CoinsAnimation());
        yield return StartCoroutine(ExpAnimation());
        //Start the animations for the Stars
        stars.SetTrigger("Start");
        yield return new WaitForSeconds(1.8f);
        //Start the animation for the wheel
        StartCoroutine(wheel.DotsAnimation());
    }

    private IEnumerator CoinsAnimation()
    {
        int counter = 0;

        while (GameManager.instance.collectibles.Count > 0)
        {
            Collectible.CollectibleData collectible = GameManager.instance.collectibles.Dequeue();
            counter += collectible.price;
            coins.text = $"+{PlayerPrefs2.AddZeros(counter)}";

            //Instatiate the collectible
            //GameObject prefab = Instantiate(collectiblePrefab, coins.gameObject.transform);
            //prefab.GetComponent<Image>().sprite = collectible.sprite;
            //prefab.GetComponent<Collectible>().data = collectible;
            //Destroy(prefab, 0.5f);

            yield return new WaitForSeconds(.05f);
        }
    }

    private IEnumerator ExpAnimation()
    {
        int counter = 0;

        do
        {
            exp.text = $"+{PlayerPrefs2.AddZeros(counter)}";
            counter += 5;
            yield return new WaitForSeconds(.01f);
        } while (counter <= GameManager.instance.score);
    }
    #endregion

    public void NextLevel() => SceneMaster.instance.LoadLevel(Levels.GetData(SceneMaster.levelData.nextLevel).LevelName);
}
