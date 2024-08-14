using System.Threading;
using System.Threading.Tasks;
using Misc;
using UnityEngine;

namespace Enemies
{
    public class SlimeScreen : MonoBehaviour
    {
        [SerializeField] private AnimationClip slimeScreenAnimation;

        private Animator _animator;
        private float _screenDuration;
        private static readonly int Fall = Animator.StringToHash("Fall");
        private CancellationTokenSource _cancellationTokenSource;
        private bool _isShaking;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (!GameManager.instance.IsPlaying || _isShaking) return;

            // Check if the phone is shaking
            if (!(Input.acceleration.sqrMagnitude > 1.5f)) return;
            _isShaking = true;
            _cancellationTokenSource?.Cancel();
            Debug.Log("Shake detected");
            ScreenFall();
        }

        internal void Initialize(float duration)
        {
            _screenDuration = duration;
            _isShaking = false;
            _cancellationTokenSource = new CancellationTokenSource();
            AutomaticFall(_cancellationTokenSource.Token);
        }

        private async void AutomaticFall(CancellationToken token)
        {
            try
            {
                var waitTime =(int)((slimeScreenAnimation.length - _screenDuration) * 1000);
                Debug.Log($"Waiting {waitTime} ms");
                await Task.Delay(waitTime, token);
                if (!token.IsCancellationRequested)
                {
                    ScreenFall();
                }
            }
            catch (TaskCanceledException)
            {
                // Task was canceled, do nothing
            }
        }

        private void ScreenFall()
        {
            _animator.SetTrigger(Fall);
            Destroy(gameObject, slimeScreenAnimation.length);
        }
    }
}