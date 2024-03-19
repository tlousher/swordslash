using System;
using Character;
using Enemies;
using Gui;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Misc
{
    public class TrainingSystem : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [Header("Dialog")]
        [SerializeField] private GameObject dialogHUD;
        [SerializeField] private GameObject dialogText;
        [SerializeField] private GameObject avatarImage;
        [SerializeField] private GameObject masterImage;
        [SerializeField] private GameObject staminaBar;
        [SerializeField] private GameObject background;
        [SerializeField] private GameObject rangeBar;
        [SerializeField] private TextMeshProUGUI continueText;
        [Header("Enemy")]
        [SerializeField] private GameObject horizontalEnemy;
        [SerializeField] private GameObject verticalEnemy;
        [SerializeField] private GameObject diagonalEnemy;
        [SerializeField] private GameObject shieldEnemy;
        [SerializeField] private GameObject horizontalDemo;
        [SerializeField] private GameObject verticalDemo;
        [SerializeField] private GameObject diagonalDemo;
        [SerializeField] private GameObject jokerDemo;
        
        private int _currentStep;
        private Dialog _dialog;
        private TrainingEnemy _trainingEnemy;
        
        private Animator StaminaAnim => staminaBar.GetComponent<Animator>();
        private Animator RangeAnim => rangeBar.GetComponent<Animator>();
        private int StaminaGrowAnim => Animator.StringToHash("Grow");
        private int ShowAnim => Animator.StringToHash("Show");

        private void Start()
        {
            // Dialog setup
            continueText.text = Language.GetText(Language.Text.MainMenu_TouchStart);
            _dialog = dialogText.GetComponent<Dialog>();
            avatarImage.SetActive(false);
            masterImage.SetActive(true);
            Invoke(nameof(StartDialog), Transition.TransitionTime);
            
            // Enemies inactive
            horizontalEnemy.SetActive(false);
            verticalEnemy.SetActive(false);
            diagonalEnemy.SetActive(false);
            shieldEnemy.SetActive(false);
        }

        private void StartDialog()
        {
            _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster01));
        }

        private void MoveRange(int range)
        {
            Player.instance.sword.data.range = range;
        }

        [ContextMenu("Next Step")]
        public void NextStep()
        {
            if (_dialog.IsShowingText)
            {
                _dialog.SkipText();
                return;
            }
            _currentStep++;
            switch (_currentStep)
            {
                case 1:
                    avatarImage.SetActive(true);
                    masterImage.SetActive(false);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingStudent01));
                    break;
                case 2:
                    avatarImage.SetActive(false);
                    masterImage.SetActive(true);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster02));
                    break;
                case 3:
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster03));
                    break;
                case 4:
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster04));
                    break;
                case 5:
                    masterImage.SetActive(false);
                    dialogHUD.SetActive(false);
                    horizontalEnemy.SetActive(true);
                    _trainingEnemy = horizontalEnemy.GetComponent<TrainingEnemy>();
                    _trainingEnemy.healthPoints = 1;
                    _trainingEnemy.action = NextStep;
                    MoveRange(15);
                    break;
                case 6:
                    horizontalEnemy.SetActive(false);
                    dialogHUD.SetActive(true);
                    avatarImage.SetActive(true);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingStudent02));
                    break;
                case 7:
                    avatarImage.SetActive(false);
                    masterImage.SetActive(true);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster05));
                    break;
                case 8:
                    masterImage.SetActive(false);
                    dialogHUD.SetActive(false);
                    verticalEnemy.SetActive(true);
                    _trainingEnemy = verticalEnemy.GetComponent<TrainingEnemy>();
                    _trainingEnemy.healthPoints = 1;
                    _trainingEnemy.action = NextStep;
                    break;
                case 9:
                    verticalEnemy.SetActive(false);
                    dialogHUD.SetActive(true);
                    masterImage.SetActive(true);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster06));
                    break;
                case 10:
                    masterImage.SetActive(false);
                    dialogHUD.SetActive(false);
                    diagonalEnemy.SetActive(true);
                    _trainingEnemy = diagonalEnemy.GetComponent<TrainingEnemy>();
                    _trainingEnemy.healthPoints = 1;
                    _trainingEnemy.action = NextStep;
                    break;
                case 11:
                    diagonalEnemy.SetActive(false);
                    dialogHUD.SetActive(true);
                    masterImage.SetActive(true);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster07));
                    break;
                case 12:
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster08));
                    break;
                case 13:
                    staminaBar.SetActive(true);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster09));
                    break;
                case 14:
                    StaminaAnim.SetTrigger(StaminaGrowAnim);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster19));
                    break;
                case 15:
                    StaminaAnim.SetTrigger(ShowAnim);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster20));
                    break;
                case 16:
                    staminaBar.SetActive(false);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster10));
                    break;
                case 17:
                    masterImage.SetActive(false);
                    dialogHUD.SetActive(false);
                    horizontalEnemy.SetActive(true);
                    _trainingEnemy = horizontalEnemy.GetComponent<TrainingEnemy>();
                    _trainingEnemy.healthPoints = 2;
                    _trainingEnemy.action = () =>
                    {
                        diagonalEnemy.SetActive(true);
                        _trainingEnemy = diagonalEnemy.GetComponent<TrainingEnemy>();
                        _trainingEnemy.healthPoints = 2;
                        _trainingEnemy.action = () =>
                        {
                            verticalEnemy.SetActive(true);
                            _trainingEnemy = verticalEnemy.GetComponent<TrainingEnemy>();
                            _trainingEnemy.healthPoints = 2;
                            _trainingEnemy.action = NextStep;
                        };
                    };
                    MoveRange(15);
                    break;
                case 18:
                    horizontalEnemy.SetActive(false);
                    diagonalEnemy.SetActive(false);
                    verticalEnemy.SetActive(false);
                    dialogHUD.SetActive(true);
                    masterImage.SetActive(true);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster11));
                    break;
                case 19:
                    background.SetActive(false);
                    rangeBar.SetActive(true);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster12));
                    break;
                case 20:
                    RangeAnim.SetTrigger(ShowAnim);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster13));
                    break;
                case 21:
                    rangeBar.SetActive(false);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster14));
                    break;
                case 22:
                    horizontalDemo.SetActive(true);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster15));
                    break;
                case 23:
                    horizontalDemo.SetActive(false);
                    verticalDemo.SetActive(true);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster16));
                    break;
                case 24:
                    verticalDemo.SetActive(false);
                    diagonalDemo.SetActive(true);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster17));
                    break;
                case 25:
                    diagonalDemo.SetActive(false);
                    jokerDemo.SetActive(true);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster18));
                    break;
                case 26:
                    jokerDemo.SetActive(false);
                    _dialog.ShowDialog(Language.GetTutorialText(Language.TutorialText.TrainingMaster21));
                    break;
                case 27:
                    dialogHUD.SetActive(false);
                    SceneMaster.instance.LevelMap();
                    break;
            }
        }
    }
}
