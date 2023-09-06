using System;
using UnityEngine;

public class Slasher : MonoBehaviour
{
    [Header("Stats")]
    public float trailPositionZ = 1;
    public float minimumSlashDistance = 100;
    public bool createSlash;
    public Gradient trailColorEnd;
    [Header("Components")]
    public GameObject enemies;
    [Header("Prefabs")]
    public GameObject slashTrail;
    public GameObject slashParticle;
    public GameObject whatParticle;
    public GameObject notSlashParticle;

    private Vector2 touchStartPosition;
    private Vector2 touchEndedPosition;
    private GameObject myTrail;

    public static event Action<SlashDirections> OnSlash = delegate { };

    public enum SlashDirections
    {
        Down,
        Up,
        Right,
        Left,
        DownRight,
        DownLeft,
        UpRight,
        UpLeft,
        Bad,
        Joker
    }

    void Update()
    {
        if (GameManager.instance.IsPlaying)
        {
            //Attack
            if (Input.touchCount > 0)
            {
                AnalizeTouch();
            }
        }
    }

    private void AnalizeTouch()
    {
        Touch touch = Input.GetTouch(0);

        #region Touch Began
        if (touch.phase == TouchPhase.Began)
        {
            // Logs the position when the touch began
            touchStartPosition = touch.position;

            // If there is a Trail we destroy it and create a new one
            if (myTrail)
            {
                Destroy(myTrail);
            }
            myTrail = Instantiate(slashTrail, Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, trailPositionZ)), Quaternion.identity, transform.parent);
        }
        #endregion
        #region Touch Moved
        else if (touch.phase == TouchPhase.Moved)
        {
            // If the finger has moved long enough then we change the slashes start
            if (Vector2.Distance(touchStartPosition, touchEndedPosition) > minimumSlashDistance)
            {
                touchStartPosition = touch.position;
            }

            // We start moving the trail
            myTrail.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, trailPositionZ));
        }
        #endregion
        #region Touch Ended
        else if (touch.phase == TouchPhase.Ended)
        {
            // We start moving the trail
            myTrail.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, trailPositionZ));
            // Logs the position when the touch ends
            touchEndedPosition = touch.position;

            // Calculates the vector formed from the last start and this finish phase
            SlashDirections direction = VectorToSlashDirections((touchEndedPosition - touchStartPosition).normalized);

            // Creates a slash depending on the direction needed
            if (Player.instance.stamina >= 1)
            {
                // Changes the color of the trail
                myTrail.GetComponent<TrailRenderer>().colorGradient = trailColorEnd;
                // Calls the sender method
                SendSlash(direction);

                // Creates a full HUD slash
                if (createSlash)
                {
                    switch (direction)
                    {
                        case SlashDirections.Down:
                            CreateSlash(Quaternion.Euler(25, 0, 0));
                            break;
                        case SlashDirections.Up:
                            CreateSlash(Quaternion.Euler(25, 0, 180));
                            break;
                        case SlashDirections.Right:
                            CreateSlash(Quaternion.Euler(25, 0, 90));
                            break;
                        case SlashDirections.Left:
                            CreateSlash(Quaternion.Euler(25, 0, -90));
                            break;
                        case SlashDirections.DownRight:
                            CreateSlash(Quaternion.Euler(25, 0, 45));
                            break;
                        case SlashDirections.DownLeft:
                            CreateSlash(Quaternion.Euler(25, 0, -45));
                            break;
                        case SlashDirections.UpRight:
                            CreateSlash(Quaternion.Euler(25, 0, 135));
                            break;
                        case SlashDirections.UpLeft:
                            CreateSlash(Quaternion.Euler(25, 0, -135));
                            break;
                        case SlashDirections.Bad:
                            CreateSlash(Quaternion.Euler(25, 0, 0), slashPrefab: whatParticle);
                            break;
                    } 
                }
            }
            #endregion
        }
    }

    private static SlashDirections VectorToSlashDirections(Vector2 normalizedDir)
    {
        if (IsDownSlash(normalizedDir))
        {
            return SlashDirections.Down;
        }
        else if (IsUpSlash(normalizedDir))
        {
            return SlashDirections.Up;
        }
        else if (IsRightSlash(normalizedDir))
        {
            return SlashDirections.Right;
        }
        else if (IsLeftSlash(normalizedDir))
        {
            return SlashDirections.Left;
        }
        else if (IsDownRightSlash(normalizedDir))
        {
            return SlashDirections.DownRight;
        }
        else if (IsDownLeftSlash(normalizedDir))
        {
            return SlashDirections.DownLeft;
        }
        else if (IsUpRightSlash(normalizedDir))
        {
            return SlashDirections.UpRight;
        }
        else if (IsUpLeftSlash(normalizedDir))
        {
            return SlashDirections.UpLeft;
        }
        else
        {
            return SlashDirections.Bad;
        }
    }

    #region Check Slashes
    private static bool IsUpSlash(Vector2 direction)
    {
        return direction.x < 0.3 && direction.x > -0.3 && direction.y > 0.3;
    }

    private static bool IsDownSlash(Vector2 direction)
    {
        return direction.x < 0.3 && direction.x > -0.3 && direction.y < -0.3;
    }

    private static bool IsLeftSlash(Vector2 direction)
    {
        return direction.y < 0.3 && direction.y > -0.3 && direction.x < -0.3;
    }

    private static bool IsRightSlash(Vector2 direction)
    {
        return direction.y < 0.3 && direction.y > -0.3 && direction.x > 0.3;
    }

    private static bool IsUpLeftSlash(Vector2 direction)
    {
        return direction.x < -0.3 && direction.y > 0.3;
    }

    private static bool IsUpRightSlash(Vector2 direction)
    {
        return direction.x > 0.3 && direction.y > 0.3;
    }

    private static bool IsDownLeftSlash(Vector2 direction)
    {
        return direction.x < -0.3 && direction.y < -0.3;
    }

    private static bool IsDownRightSlash(Vector2 direction)
    {
        return direction.x > 0.3 && direction.y < -0.3;
    }
    #endregion

    private void CreateSlash(Quaternion quaternion, GameObject slashPrefab = null)
    {
        GameObject slash = Instantiate(slashPrefab ?? slashParticle, Vector3.zero, quaternion, GameManager.instance.HUD.transform);
        slash.transform.localPosition = Vector3.zero;
        Destroy(slash, slash.GetComponent<ParticleSystem>().main.duration);
    }

    private void SendSlash(SlashDirections direction)
    {
        if (direction != SlashDirections.Bad)
        {
            // Plays the audio of the slash
            Player.instance.sword.GetComponent<AudioSource>().PlayOneShot(Player.instance.sword.GetAudioClip);
            // Reduce the stamina
            Player.instance.stamina--;
            // Send the slash direction to all delegates
            OnSlash(direction);
        }
    }

    private static bool SameDir(Vector2 sample, SlashDirections target)
    {
        switch (target)
        {
            case SlashDirections.Down:
                return IsDownSlash(sample);
            case SlashDirections.Up:
                return IsUpSlash(sample);
            case SlashDirections.Right:
                return IsRightSlash(sample);
            case SlashDirections.Left:
                return IsLeftSlash(sample);
            case SlashDirections.DownRight:
                return IsDownRightSlash(sample);
            case SlashDirections.DownLeft:
                return IsDownLeftSlash(sample);
            case SlashDirections.UpRight:
                return IsUpRightSlash(sample);
            case SlashDirections.UpLeft:
                return IsUpLeftSlash(sample);
            default:
                return false;
        }
    }
}
