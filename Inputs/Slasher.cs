using System;
using Character;
using Misc;
using UnityEngine;

namespace Inputs
{
    public class Slasher : MonoBehaviour
    {
        [Header("Stats")]
        public float trailPositionZ = 1;
        public float minimumSlashDistance = 100;
        public bool createSlash;
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
        private Camera mainCamera;
        private bool isSlashing;

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
        
        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (!GameManager.instance.IsPlaying) return;
            //Attack
            if (Input.touchCount > 0)
            {
                AnalyzeTouch();
            }
        }

        private void AnalyzeTouch()
        {
            var touch = Input.GetTouch(0);

            #region Touch Began

            switch (touch.phase)
            {
                case TouchPhase.Began:
                {
                    // Logs the position when the touch began
                    touchStartPosition = touch.position;
                    isSlashing = false;

                    // If there is a Trail we destroy it and create a new one
                    if (myTrail)
                    {
                        Destroy(myTrail);
                    }

                    myTrail = Instantiate(slashTrail,
                        mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,
                            trailPositionZ)), Quaternion.identity, transform.parent);
                    break;
                }
                case TouchPhase.Moved:
                {
                    // If the finger has moved long enough then we change the slashes start
                    if (Vector2.Distance(touchStartPosition, touch.position) > minimumSlashDistance)
                    {
                        touchStartPosition = touch.position;
                        isSlashing = true;
                    }
                    
                    // We start moving the trail
                    myTrail.transform.position =
                        mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,
                            trailPositionZ));
                    break;
                }
                case TouchPhase.Ended:
                {
                    // We start moving the trail
                    myTrail.transform.position =
                        mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,
                            trailPositionZ));
                    // Logs the position when the touch ends
                    touchEndedPosition = touch.position;

                    // Calculates distance of touch
                    if (!isSlashing)
                    {
                        Debug.Log("Distance was not long enough");
                        return;
                    }

                    // Creates a slash depending on the direction needed
                    if (Player.instance.stamina >= 1)
                    {
                        // Calculates the vector formed from the last start and this finish phase
                        var direction = VectorToSlashDirections((touchEndedPosition - touchStartPosition).normalized);

                        if (direction == SlashDirections.Bad)
                        {
                            Debug.Log($"Bad slash {(touchEndedPosition - touchStartPosition).normalized}");
                        }
                        
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
                                case SlashDirections.Joker:
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            } 
                        }
                    }
                    #endregion

                    break;
                }
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Canceled:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static SlashDirections VectorToSlashDirections(Vector2 normalizedDir)
        {
            if (IsDownSlash(normalizedDir))
                return SlashDirections.Down;

            if (IsUpSlash(normalizedDir))
                return SlashDirections.Up;

            if (IsRightSlash(normalizedDir))
                return SlashDirections.Right;

            if (IsLeftSlash(normalizedDir))
                return SlashDirections.Left;

            if (IsDownRightSlash(normalizedDir))
                return SlashDirections.DownRight;

            if (IsDownLeftSlash(normalizedDir))
                return SlashDirections.DownLeft;

            if (IsUpRightSlash(normalizedDir))
                return SlashDirections.UpRight;

            return IsUpLeftSlash(normalizedDir) ? SlashDirections.UpLeft : SlashDirections.Bad;
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
            var slash = Instantiate(slashPrefab ? slashPrefab : slashParticle, Vector3.zero, quaternion, GameManager.instance.HUD.transform);
            slash.transform.localPosition = Vector3.zero;
            Destroy(slash, slash.GetComponent<ParticleSystem>().main.duration);
        }

        private static void SendSlash(SlashDirections direction)
        {
            if (direction == SlashDirections.Bad) return;
            // Plays the audio of the slash
            Player.instance.sword.GetComponent<AudioSource>().PlayOneShot(Player.instance.sword.GetAudioClip);
            // Reduce the stamina
            Player.instance.stamina--;
            // Send the slash direction to all delegates
            OnSlash(direction);
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
                case SlashDirections.Bad:
                case SlashDirections.Joker:
                default:
                    return false;
            }
        }
    }
}
