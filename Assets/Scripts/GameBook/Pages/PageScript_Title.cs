using BeaverMurderCase.Dialogue;
using BeaverMurderCase.GameBook.Gimmick;
using UnityEngine;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScript_Title : PageScript
    {
        [SerializeField] private ScrollObject _gameStartMessage;

        private float _minStartPoint;
        private float _accumulated;

        protected override void Initialize()
        {
            _gameStartMessage.OnScroll.AddListener(OnScroll);
            Dialogue.DialogueManager.Instance.StartSpeechSet("title_opening");
        }

        protected override void OnOpened() {
            base.OnOpened();
        }

        private void OnScroll(Vector2 amount)
        {
            _accumulated += amount.x;
            _minStartPoint = Mathf.Min(_minStartPoint, _accumulated);

            if (_accumulated >= _minStartPoint + 1f)
            {
                if (BookManager.Instance.UnlockPage(_page.PageNumber + 1))
                {
                    DialogueManager.Instance.StartSpeechSet("Title_PageUnlocked");
                }
            }
        }
    }
}