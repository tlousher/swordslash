using Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    [Header("Components")]
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI rewardQuantity;
    public Image icon;
    public Image rewardIcon;
    public Button button;
    public Image progressBar;
    public TextMeshProUGUI numericProgress;
    public GameObject completion;
    [Header("Advanced information")]
    public Achievement_Data data;

    private const int MaxFill = 720;

    private void Start()
    {
        title.text = data.title;
        description.text = data.description;
        rewardQuantity.text = $"x{data.rewardQuantity}";
        icon.sprite = data.icon;
        rewardIcon.sprite = data.rewardIcon;
        progressBar.fillAmount = Mathf.Clamp(1 / data.goal * data.Progress, 0, 1);
        numericProgress.text = $"{data.Progress}/{data.goal}";
        if (data.IsComplete)
        {
            button.interactable = false;
            completion.SetActive(true);
        }
        else
        {
            button.interactable = true;
            completion.SetActive(false);
        }
    }

    public void CollectAchivement()
    {
        //Si hay otra mision, oculto la completada y muestro la que sigue
        if (!data.nextAchievementID.Equals(Achievements.AchievementID(Achievements.AchievementName.Final)))
        {
            PlayerPrefs2.SetAchievementDisplay(data.achievementID, false);
            PlayerPrefs2.SetAchievementDisplay(data.nextAchievementID, true);
        }

        data.Complete();
    }

    [System.Serializable]
    public class Achievement_Data
    {
        public string achievementID;
        public string achievementProgressID;
        public string title;
        public string description;
        public int rewardQuantity;
        public string rewardItemID;
        public bool defaultDisplay;
        public string nextAchievementID;
        public Sprite icon;
        public Sprite rewardIcon;
        public int goal;

        public bool IsComplete
        {
            get
            {
                return PlayerPrefs2.IsAchievementComplete(achievementID);
            }
        }
        
        public int Progress
        {
            get
            {
                return PlayerPrefs2.GetAchievementProgress(achievementProgressID);
            }
        }

        public void Complete()
        {
            PlayerPrefs2.IncreaseAchievementProgress(Achievements.AchievementID(Achievements.AchievementName.GameLover));
            PlayerPrefs2.AchievementComplete(achievementID);
            if (rewardItemID.Equals(Achievements.CoinsReward))
            {
                PlayerPrefs2.Coins += rewardQuantity;
                SceneMaster.instance.ShowMessage("Logro completado", $"Felicitaciones por completar \"{title}\", has ganado {rewardQuantity} monedas.", SceneMaster.MessageSFX.Notice);
            }
            else if (rewardItemID.Equals(Achievements.GemsReward))
            {
                PlayerPrefs2.Gems += rewardQuantity;
                SceneMaster.instance.ShowMessage("Logro completado", $"Felicitaciones por completar \"{title}\", has ganado {rewardQuantity} gemas.", SceneMaster.MessageSFX.Notice);
            }
            else
            {
                PlayerPrefs2.SetItemState(rewardItemID, ItemData.ItemState.Aquired);
                SceneMaster.instance.ShowMessage("Logro completado", $"Felicitaciones por completar \"{title}\", puedes encontrar tu nuevo equipo en la tienda.", SceneMaster.MessageSFX.Notice);
            }
        }
    }
}
