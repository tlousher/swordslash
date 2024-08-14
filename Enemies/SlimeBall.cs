using Character;
using Misc;
using UnityEngine;

namespace Enemies
{
    public class SlimeBall : MonoBehaviour
    {
        [Header("Stats")]
        public float slimeDuration;     
        public float speed;   
        [Header("Components")]
        public GameObject slimeScreen;

        private Vector3 _startPosition;
        private float _timePassed;

        private void Awake()
        {
            _timePassed = 0;
            _startPosition = transform.position;
        }

        private void Update()
        {
            if (!GameManager.instance.IsPlaying) return;
            transform.position = MathParabola.Parabola(_startPosition, Player.instance.transform.position, 2f, _timePassed);
            _timePassed += Time.deltaTime * speed / 10;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.CompareTag("Player")) return;
            //Crea la pantalla de slime
            var newScreen = Instantiate(slimeScreen, GameManager.instance.HUD.transform);
            var slimeScreenComponent = newScreen.GetComponent<SlimeScreen>();
            slimeScreenComponent.Initialize(slimeDuration);

            //Destruye la bala
            Destroy(gameObject);
        }
    }
}
