using BeaverMurderCase.Dialogue;
using BeaverMurderCase.GameBook.Gimmick;
using UnityEngine;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScript_0 : PageScript
    {
        [SerializeField] private Transform _door;
        [SerializeField] private ScrollObject _valve;
        
        private float _doorOpenValue;

        protected override void Initialize()
        {
            _valve.OnScroll.AddListener(OnValveScroll);
        }

        public void OnValveScroll(float amount)
        {
            _doorOpenValue += amount;
            _door.transform.position += new Vector3(0, amount * 0.05f, 0);

            if (Mathf.Abs(_doorOpenValue) > 10)
            {
                if (BookManager.Instance.UnlockPage(1))
                {
                    DialogueManager.Instance.StartSpeechSet("0_OpenDoor");
                }
            }
        }
    }
}