using BeaverMurderCase.Common;
using BeaverMurderCase.Dialogue;

namespace BeaverMurderCase.GameBook.Pages
{
    public class Ending_Bear : PageScript
    {
        protected override void OnOpened()
        {
            DialogueManager.Instance.StartSpeechSet("Ending_Bear");
            SoundManager.PlaySfx(ClipType.Thunder);
        }
    }
}