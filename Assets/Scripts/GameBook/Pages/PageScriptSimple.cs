using BeaverMurderCase.Dialogue;
using UnityEngine;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScriptSimple : PageScript
    {
        [SerializeField] private SpeechSet _targetSpeech;

        protected override void OnOpened()
        {
            DialogueManager.Instance.StartSpeechSet(_targetSpeech);
        }
    }
}