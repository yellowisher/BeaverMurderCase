using BeaverMurderCase.Dialogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScript_HippoHouse : PageScript
    {
        protected override async void OnOpened()
        {
            DialogueManager.Instance.StartSpeechSet("HamaHouse_Intro");
        }

        public async void OnClick_Placard()
        {
            DialogueManager.Instance.StartSpeechSet("HamaHouse_PlanCard");
            await DialogueManager.Instance.WaitForSpeechEndAsync();
            BookManager.Instance.UnlockPage(13);
        }

        public async void OnClick_Dumbbel()
        {
            DialogueManager.Instance.StartSpeechSet("HamaHouse_Dumbbel");
            await DialogueManager.Instance.WaitForSpeechEndAsync();
            BookManager.Instance.UnlockPage(12);
        }

        public async void OnClick_SecretDoor()
        {
            DialogueManager.Instance.StartSpeechSet("HamaHouse_Secret");
            await DialogueManager.Instance.WaitForSpeechEndAsync();
            BookManager.Instance.UnlockPage(14);
        }

        public void OnClick_Exit()
        {
            DialogueManager.Instance.StartSpeechSet("HamaHouse_Exit");
        }
    }
}
