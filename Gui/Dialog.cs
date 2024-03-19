using System;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gui
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Dialog : MonoBehaviour
    {
        [Tooltip("Delay between each letter in milliseconds")]
        [SerializeField] private int delayPerLetter;
        
        private string _text;
        private TextMeshProUGUI _textMeshPro;
        private Task _showTextTask;
        private CancellationTokenSource _cancellationToken;
        
        internal bool IsShowingText => _showTextTask != null && !_showTextTask.IsCompleted;

        private void Start()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();
            _textMeshPro.text = "";
        }
        
        internal async void ShowDialog(string text, Action callback = null)
        {
            _showTextTask = ShowText(text);
            await _showTextTask;
            callback?.Invoke();
        }

        private async Task ShowText(string text)
        {
            _cancellationToken = new CancellationTokenSource();
            _text = text;
            _textMeshPro.text = "";
            try
            {
                var isRichText = false;
                foreach (var letter in _text)
                {
                    _textMeshPro.text += letter;
                    isRichText = letter switch
                    {
                        '<' => true,
                        '>' => false,
                        _ => isRichText
                    };
                    if (isRichText) continue;
                    await Task.Delay(delayPerLetter, _cancellationToken.Token);
                    if (_cancellationToken.IsCancellationRequested) return;
                }
            }
            catch (TaskCanceledException) { }
        }
        
        internal void SkipText()
        {
            if (_showTextTask == null || _showTextTask.IsCompleted) return;
            _cancellationToken?.Cancel();
            _textMeshPro.text = _text;
        }
    }
}
