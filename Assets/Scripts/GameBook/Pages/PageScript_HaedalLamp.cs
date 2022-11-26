using BeaverMurderCase.Dialogue;
using BeaverMurderCase.GameBook.Gimmick;
using UnityEngine;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScript_HaedalLamp : PageScript
    {
        [SerializeField] private float _goal;
        [SerializeField] private ScrollObject _fire;

        private float _accumulate;
        private bool _didKill;

        protected override void Initialize()
        {
            _fire.OnScroll.AddListener(OnScroll);
        }

        protected override void OnOpened()
        {
            _accumulate = 0;
            _didKill = false;
            DialogueManager.Instance.StartSpeechSet("HaedalHouseLamp");
        }

        public void OnScroll(Vector2 amount)
        {
            _accumulate += Mathf.Abs(amount.x);
            if (!_didKill && _accumulate > _goal)
            {
                DialogueManager.Instance.StartSpeechSet("HaedalHouseLamp_Die");
            }
        }
    }
}