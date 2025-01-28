using UnityEngine;
using UnityEngine.UI;

namespace Gui
{
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
        internal static int Combo => instance.counter; 

        // This counter is the Combo
        private int counter;
        private float timer;
        private int achievedCombo;
        private int comboPower;

        private float FillPercent => 1 / (float)maxCombo;

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
            achievedCombo = PlayerPrefs2.GetAchievementProgress(Achievements.Achievements.AchievementID(Achievements.Achievements.AchievementName.SwordsmasterI));
        }

        public void Reset()
        {
            //Restarts the combo bar
            fillBar.fillAmount = 0;
            comboPower = 0;

            //Resets the combo ability button
            fillCircle.fillAmount = 0;
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
            if (!onCombo) return;

            // If this combo is bigger than the biggest combo
            if (counter > achievedCombo)
            {
                // Sets the new highest combo achieved
                PlayerPrefs2.SetAchievementProgress(Achievements.Achievements.AchievementID(Achievements.Achievements.AchievementName.SwordsmasterI), counter);
                // Updates the highest combo achieved
                achievedCombo = counter;
            }

            //Restarts the combo counter
            counter = 0;
            //Finishes the combo
            onCombo = false;
        }

        private void CounterControl()
        {
            // If I had a combo
            if (counter <= 1 || comboPower >= maxCombo) return;
            // Add the counter to the players power
            comboPower += counter;
            // Updates the fill amount of the bar
            fillBar.fillAmount += comboPower * FillPercent;

            // If I've completed the bar
            if (comboPower < maxCombo) return;
            //Activates the button
            swordImage.color = Color.white;
            swordButton.interactable = true;
        }

        public void AddCombo()
        {
            counter++;
            onCombo = true;
            timer = timerStart;
            CounterControl();
        }
    }
}
