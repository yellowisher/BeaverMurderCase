using BeaverMurderCase.Dialogue;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScript_BearHouse : PageScript
    {
        protected override void OnOpened()
        {
            DialogueManager.Instance.StartSpeechSet("BearHouse");
        }

        public async void OnClick_Pen()
        {
            DialogueManager.Instance.StartSpeechSet("BearHouse_Pen");
            await DialogueManager.Instance.WaitForSpeechEndAsync();
            BookManager.Instance.UnlockPage(17);
        }
        
        public async void OnClick_Knife()
        {
            DialogueManager.Instance.StartSpeechSet("BearHouse_Knife");
            await DialogueManager.Instance.WaitForSpeechEndAsync();
            BookManager.Instance.UnlockPage(15);
        }
        
        public async void OnClick_Refrigerator()
        {
            DialogueManager.Instance.StartSpeechSet("BearHouse_Refrigerator");
            await DialogueManager.Instance.WaitForSpeechEndAsync();
            BookManager.Instance.UnlockPage(16);
        }

        public void OnClick_Exit()
        {
            DialogueManager.Instance.StartSpeechSet("BearHouse_Exit");
        }
    }
}