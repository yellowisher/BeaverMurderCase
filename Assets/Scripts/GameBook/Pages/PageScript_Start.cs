using BeaverMurderCase.Dialogue;
using BeaverMurderCase.GameBook.Gimmick;
using BeaverMurderCase.GameBook;
using UnityEngine;
using BeaverMurderCase.Common;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScript_Start : PageScript
    {
        [SerializeField] private ScrollObject _gameStartMessage;
        [SerializeField] private float _goal;

        private float _minStartPoint;
        private float _accumulated;


        protected override async void Initialize()
        {
            _gameStartMessage.OnScroll.AddListener(OnScroll);
        }


        protected override void OnOpened() {
            base.OnOpened();
            Dialogue.DialogueManager.Instance.StartSpeechSet("start_dialog 1");
        }

        private async void OnScroll(Vector2 amount)
        {
            _accumulated += Mathf.Abs(0.02f);

            if (_accumulated > _goal) {
                Dialogue.DialogueManager.Instance.StartSpeechSet("start_dialog 1");
                // 
            }
        }
    }
}