using Character;
using UnityEngine;

namespace Misc
{
    public class TrainingSystem : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private GameObject dialogHUD;
        [SerializeField] private GameObject dialogText;

        private void MoveRange(int range)
        {
            Player.instance.sword.data.range = range;
        }
    }
}
