using BeaverMurderCase.Dialogue;
using BeaverMurderCase.GameBook.Gimmick;
using UnityEngine;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScript_0_Title : PageScript
    {
        [SerializeField] private ScrollObject _gameStartMessage;

        private float _minStartPoint;
        private float _accumulated;

        protected override void Initialize()
        {
            _gameStartMessage.OnScroll.AddListener(OnScroll);
        }

        private void OnScroll(float amount)
        {
            _accumulated += amount;
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