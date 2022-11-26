using BeaverMurderCase.Common;
using BeaverMurderCase.Dialogue;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine.UI;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScript_HaedalHouse : PageScript
    {
        protected override async void OnOpened()
        {
            DialogueManager.Instance.StartSpeechSet("HaedalHouse_Intro");
            await DialogueManager.Instance.WaitForSpeechEndAsync();
            BookManager.Instance.UnlockPage(9);
            BookManager.Instance.UnlockPage(10);
            BookManager.Instance.UnlockPage(11);
        }

        public void OnClick_Coffee()
        {
            DialogueManager.Instance.StartSpeechSet("HaedalHouse_Coffee");
        }
        
        public void OnClick_Drink()
        {
            DialogueManager.Instance.StartSpeechSet("HaedalHouse_Drink");
        }

        public void OnClick_Lamp()
        {
            DialogueManager.Instance.StartSpeechSet("HaedalHouse_Lamp");
        }
    }
}