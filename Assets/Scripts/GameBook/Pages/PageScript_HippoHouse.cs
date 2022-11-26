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
            DialogueManager.Instance.StartSpeechSet("HaedalHouse_Intro");
            await DialogueManager.Instance.WaitForSpeechEndAsync();
            BookManager.Instance.UnlockPage(12);
            BookManager.Instance.UnlockPage(13);
            BookManager.Instance.UnlockPage(14);
            BookManager.Instance.UnlockPage(19);
        }

        public void OnClick_Placard()
        {
            DialogueManager.Instance.StartSpeechSet("HaedalHouse_Coffee");
        }

        public void OnClick_Dumbbel()
        {
            DialogueManager.Instance.StartSpeechSet("HaedalHouse_Drink");
        }

        public void OnClick_SecretDoor()
        {
            DialogueManager.Instance.StartSpeechSet("HaedalHouse_Lamp");
        }

        public void OnClick_Door()
        {

        }
    }
}
