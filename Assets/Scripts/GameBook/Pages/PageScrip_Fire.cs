using System;
using BeaverMurderCase.Dialogue;
using BeaverMurderCase.GameBook.Gimmick;
using UnityEngine;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScrip_Fire : PageScript
    {
        [SerializeField] private ScrollObject _fire;
        [SerializeField] private float _goal;

        private float _accumulated;
        
        protected override void Initialize()
        {
            _fire.OnScroll.AddListener(OnScroll);    
        }

        public void OnScroll(Vector2 amount)
        {
            _accumulated += Mathf.Abs(amount.x);
            if (_accumulated > _goal)
            {
                if (BookManager.Instance.UnlockPage(_page.PageNumber + 1))
                {
                    DialogueManager.Instance.StartSpeechSet("Fire_WellDone");
                }
            }
        }
    }
}