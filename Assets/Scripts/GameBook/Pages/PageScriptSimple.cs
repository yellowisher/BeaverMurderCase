using BeaverMurderCase.Dialogue;
using Cysharp.Threading.Tasks;
using System;
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

        protected override void OnOpened()
        {
            DialogueManager.Instance.StartSpeechSet(_targetSpeech);
            _afterSpeech?.Invoke();
        }
    }
}