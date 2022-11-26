using BeaverMurderCase.Common;
using BeaverMurderCase.Dialogue;

namespace BeaverMurderCase.GameBook.Pages
{
    public class Ending_Haedal : PageScript
    {
        protected override void OnOpened()
        {
            DialogueManager.Instance.StartSpeechSet("Ending_Haedal");
            SoundManager.PlaySfx(ClipType.Thunder);
        }
    }
}