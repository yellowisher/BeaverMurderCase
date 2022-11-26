using System;
using BeaverMurderCase.Dialogue;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScript_HaedalLamp : PageScript
    {
        protected override void OnOpened()
        {
            DialogueManager.Instance.StartSpeechSet("HaedalHouseLamp");
        }

        private void Update()
        {
        }
    }
}