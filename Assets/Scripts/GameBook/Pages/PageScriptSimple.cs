using BeaverMurderCase.Dialogue;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScriptSimple : PageScript
    {
        [SerializeField] private SpeechSet _targetSpeech;
        [SerializeField] private UnityEvent _afterSpeech;


        protected void OnDisable() {
            EffectManager.Instance.ScreenFlashReset().Forget();
        }

        protected override async void OnOpened()
        {
            DialogueManager.Instance.StartSpeechSet(_targetSpeech);
            await DialogueManager.Instance.WaitForSpeechEndAsync();
            _afterSpeech?.Invoke();
        }
    }
}