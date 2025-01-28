using System;
using System.Collections.Generic;
using System.Linq;
using Character;
using Misc;
using UnityEngine;
using UnityEngine.Serialization;

namespace Inputs
{
    public class Slasher : MonoBehaviour
    {
        public const float DirectionThreshold = 0.35f;
        
        [Header("Stats")]
        public float trailPositionZ = 1;
        public float minimumSlashDistance = 100;
        public float minimumDeltaDistance = 100;
        [SerializeField] private float swordSpeed = 1;
        public bool createSlash;
        [Header("Components")]
        public GameObject enemies;
        [SerializeField] private Transform sword;
        [SerializeField] private ParticleSystem tiredParticle;
        [Header("Prefabs")]
        public GameObject slashTrail;
        public GameObject slashParticle;
        public GameObject whatParticle;
        public GameObject notSlashParticle;

        private Vector2 _touchStartPosition;
        private Vector2 _touchEndedPosition;
        private List<Vector2> _touchPositions = new();
        private GameObject _myTrail;
        private Camera _mainCamera;
        private bool _isSlashing;

        public static event Action<Vector2> OnSlash = delegate { };

        public enum SlashDirections
        {
            Right,
            UpRight,
            Up,
            UpLeft,
            Left,
            DownLeft,
            Down,
            DownRight,
            Bad,
            Joker
        }

        public static int SlashDirectionToAngle(SlashDirections direction) =>
            (int) direction * 45;

        private void Start()
        {
            _mainCamera = Camera.main;
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
                    _touchStartPosition = touch.position;
                    _isSlashing = false;

                    // Just continue to create the trail if the createSlash is false
                    if (createSlash) break;
                    
                    // If there is a Trail we destroy it and create a new one
                    if (_myTrail)
                    {
                        Destroy(_myTrail);
                    }

                    _myTrail = Instantiate(slashTrail,
                        _mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,
                            trailPositionZ)), Quaternion.identity, transform.parent);
                    break;
                }
                case TouchPhase.Moved:
                {
                    // If the finger has moved long enough then we start slashing
                    var distance = Vector2.Distance(_touchStartPosition, touch.position);
                    if (!_isSlashing && distance > minimumSlashDistance)
                    {
                        _isSlashing = true;
                    }

                    // Debug.Log($"Touch moved delta position: {touch.deltaPosition}");
                    sword.Rotate(Vector3.forward, -touch.deltaPosition.x * swordSpeed);
                    sword.Rotate(Vector3.right, touch.deltaPosition.y * swordSpeed);
                    
                    // If the finger has moved too little then we reset the start position
                    if (touch.deltaPosition.magnitude < minimumDeltaDistance)
                    {
                        _touchStartPosition = touch.position;
                        _touchPositions.Clear();
                    }
                    else
                    {
                        _touchPositions.Add(touch.deltaPosition);
                    }

                    if (!createSlash)
                    {
                        // We start moving the trail
                        _myTrail.transform.position =
                            _mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,
                                trailPositionZ));
                    }
                    break;
                }
                case TouchPhase.Ended:
                {
                    if (!createSlash)
                    {
                        // We start moving the trail
                        _myTrail.transform.position =
                            _mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,
                                trailPositionZ));
                    }
                    // Logs the position when the touch ends
                    _touchEndedPosition = touch.position;

                    // Calculates distance of touch
                    if (!_isSlashing)
                    {
                        Debug.Log("Distance was not long enough");
                        return;
                    }

                    // Creates a slash depending on the direction needed if the player has enough stamina
                    if (Player.instance.stamina >= 1)
                    {
                        // Calculates the vector formed from the last start and this finish phase
                        var meanDirection = GetMeanDirection();
                        var direction = VectorToSlashDirections(meanDirection);
                        
                        // Calls the sender method
                        SendSlash(meanDirection);

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
                    else
                    {
                        // If the player has no stamina we play the tired particle
                        if (tiredParticle.isPlaying)
                        {
                            tiredParticle.Stop();
                        }
                        tiredParticle.Play();
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

        private Vector2 GetMeanDirection()
        {
            var mean = _touchPositions.Aggregate(Vector2.zero, (current, touchPosition) => current + touchPosition);
            return mean.normalized;
        }

        internal static SlashDirections VectorToSlashDirections(Vector2 normalizedDir)
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
        internal static bool IsUpSlash(Vector2 direction)
        {
            return direction.x is < DirectionThreshold and > -DirectionThreshold && direction.y > DirectionThreshold;
        }

        internal static bool IsDownSlash(Vector2 direction)
        {
            return direction.x is < DirectionThreshold and > -DirectionThreshold && direction.y < -DirectionThreshold;
        }

        internal static bool IsLeftSlash(Vector2 direction)
        {
            return direction.y is < DirectionThreshold and > -DirectionThreshold && direction.x < -DirectionThreshold;
        }

        internal static bool IsRightSlash(Vector2 direction)
        {
            return direction.y is < DirectionThreshold and > -DirectionThreshold && direction.x > DirectionThreshold;
        }

        internal static bool IsUpLeftSlash(Vector2 direction)
        {
            return direction is { x: < -DirectionThreshold, y: > DirectionThreshold };
        }

        internal static bool IsUpRightSlash(Vector2 direction)
        {
            return direction is { x: > DirectionThreshold, y: > DirectionThreshold };
        }

        internal static bool IsDownLeftSlash(Vector2 direction)
        {
            return direction is { x: < -DirectionThreshold, y: < -DirectionThreshold };
        }

        internal static bool IsDownRightSlash(Vector2 direction)
        {
            return direction is { x: > DirectionThreshold, y: < -DirectionThreshold };
        }
        #endregion

        private void CreateSlash(Quaternion quaternion, GameObject slashPrefab = null)
        {
            var slash = Instantiate(slashPrefab ? slashPrefab : slashParticle, Vector3.zero, quaternion, GameManager.instance.HUD.transform);
            slash.transform.localPosition = Vector3.zero;
            Destroy(slash, slash.GetComponent<ParticleSystem>().main.duration);
        }

        private static void SendSlash(Vector2 direction)
        {
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
