using BeaverMurderCase.Common;
using BeaverMurderCase.Dialogue;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScript_Office : PageScript
    {
        protected override void OnOpened()
        {
            DialogueManager.Instance.StartSpeechSet("Office");
        }

        public async void OnClick_Lens()
        {
            DialogueManager.Instance.StartSpeechSet("Office_Lens");
            await DialogueManager.Instance.WaitForSpeechEndAsync();
            BookManager.Instance.UnlockPage(8);
        }

        public async void OnClick_Spray()
        {
            DialogueManager.Instance.StartSpeechSet("Office_Spray");
            await DialogueManager.Instance.WaitForSpeechEndAsync();
            BookManager.Instance.UnlockPage(4);
        }

        public async void OnClick_Door()
        {
            DialogueManager.Instance.StartSpeechSet("Office_Door");
            await DialogueManager.Instance.WaitForSpeechEndAsync();
            BookManager.Instance.UnlockPage(3);
        }
    }
}