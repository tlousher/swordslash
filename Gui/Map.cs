using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Gui
{
    public class Map : MonoBehaviour
    {
        private readonly int openHash = Animator.StringToHash("Open");

        [Header("Components")]
        public Image mapImage;
        public GameObject levelIntro;
        [Tooltip("Este componente contiene los niveles del mapa en orden secuencial del numero inferior al superior.")]
        public Transform levelsParent;
        public GameObject[] starsPrefabs;
        [Header("Stats")]
        public Area area;
        
        private Animator animator;
        private AudioSource audioSource;
        private bool fromTransition;
        private string GetArea => area.ToString();

        public enum Area
        {
            Forest,
            Mountain,
            Volcano,
            Cavern,
            Capital
        }
        
        private void Awake()
        {
            fromTransition = true;
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            LoadStars();
        }
        
        private void OnEnable()
        {
            var delay = 0.1f;
            if (fromTransition)
            {
                delay = 2.2f;
                fromTransition = false;
            }
            StartCoroutine(OpenMap(delay));
        }

        private void OnDisable()
        {
            animator.SetBool(openHash, false);
        }

        private void LoadStars()
        {
            for (var i = 0; i < levelsParent.childCount; i++)
            {
                Instantiate(starsPrefabs[PlayerPrefs2.GetLevelStars(LevelName(i + 1))], levelsParent.GetChild(i));
            }
        }

        private IEnumerator OpenMap(float delay = 0)
        {
            yield return new WaitForSeconds(delay);
            animator.SetBool(openHash, true);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        public void LoadLevel(int level)
        {
            var data = Levels.GetData(LevelName(level));
            var intro = Instantiate(this.levelIntro, transform).GetComponent<LevelIntro>();
            intro.data = data;
            intro.audioSource = GetComponent<AudioSource>();
        }

        private string LevelName(int level)
        {
            return $"{GetArea}_{level}";
        }
    }
}
