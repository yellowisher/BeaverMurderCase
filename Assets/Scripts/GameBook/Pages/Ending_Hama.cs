using BeaverMurderCase.Common;
using BeaverMurderCase.Dialogue;

namespace BeaverMurderCase.GameBook.Pages
{
    public class Ending_Hama : PageScript
    {
        protected override void OnOpened()
        {
            DialogueManager.Instance.StartSpeechSet("Ending_Hama");
            SoundManager.PlaySfx(ClipType.Thunder);
        }
    }
}