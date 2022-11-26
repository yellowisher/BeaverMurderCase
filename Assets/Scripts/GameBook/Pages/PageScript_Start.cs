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
        [SerializeField] private bool _event_finish;

        private float _minStartPoint;
        private float _accumulated;

        protected override async void Initialize()
        {
            _gameStartMessage.OnScroll.AddListener(OnScroll);
        }


        protected override void OnOpened() {
            base.OnOpened();
            Dialogue.DialogueManager.Instance.StartSpeechSet("start_dialog 1");
            _accumulated = 0;
            _event_finish = false;
        }

        private async void OnScroll(Vector2 amount)
        {
            _accumulated += Mathf.Abs(0.02f);

            if (_accumulated > _goal && !_event_finish) {
                _event_finish = true;
                await EffectManager.Instance.ScreenFlash(Color.black, 1.0f, true, DG.Tweening.Ease.OutQuad);

                GameManager.Instance.SetScrollerState(false);
                await UniTaskHelper.DelaySeconds(0.5f);

                _gameStartMessage.gameObject.SetActive(false);
                GameObject player_bar = gameObject.transform.Find("DeadBeaver").gameObject;
                player_bar.SetActive(true);
                await UniTaskHelper.DelaySeconds(1.5f);
                await EffectManager.Instance.ScreenFlash(new Color(0, 0, 0, 0.2f), 2.5f);

                Dialogue.DialogueManager.Instance.StartSpeechSet("start_dialog 2");
                await UniTask.WaitUntil(() => !Dialogue.DialogueManager.Instance.IsSpeeching);

                BookManager.Instance.UnlockPage(2);
            }
        }
    }
}