using Misc;
using UnityEngine;

public class SlimeBall : MonoBehaviour
{
    [Header("Stats")]
    public float slimeDuration;     
    public float speed;   
    [Header("Components")]
    public GameObject slimeScreen;

    private Vector3 startPosition;
    private float timePassed;

    private void Awake()
    {
        timePassed = 0;
        startPosition = transform.position;
    }

    void Update()
    {
        if (GameManager.instance.IsPlaying)
        {
            transform.position = MathParabola.Parabola(startPosition, Player.instance.transform.position, 2f, timePassed);
            timePassed += Time.deltaTime * speed / 10; 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            //Crea la pantalla de slime
            GameObject newScreen = Instantiate(slimeScreen, GameManager.instance.HUD.transform);
            Destroy(newScreen, slimeDuration);

            //Destruye la bala
            Destroy(gameObject);
        }
    }
}
