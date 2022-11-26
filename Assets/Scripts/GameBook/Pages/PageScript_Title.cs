using BeaverMurderCase.Dialogue;
using BeaverMurderCase.GameBook.Gimmick;
using BeaverMurderCase.GameBook;
using UnityEngine;
using BeaverMurderCase.Common;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScript_Title : PageScript
    {
        [SerializeField] private ScrollObject _gameStartMessage;
<<<<<<< HEAD
        [SerializeField] private float _goal;
=======
        [SerializeField] private bool _skip;
>>>>>>> 8f57058713a563ca72042919585a23be88931612

        private float _minStartPoint;
        private float _accumulated;
        private bool firstVisit = true;
        private bool goalFinish = false;

        protected override async void Initialize()
        {
            if (Application.isEditor && _skip)
            {
                return;
            }
                
            _gameStartMessage.OnScroll.AddListener(OnScroll);

            if (firstVisit) {
                firstVisit = false;
                await UniTaskHelper.DelaySeconds(0.5f);

                Dialogue.DialogueManager.Instance.StartSpeechSet("title_opening 1");
                await UniTask.WaitUntil(() => !Dialogue.DialogueManager.Instance.IsSpeeching);

                await EffectManager.Instance.ScreenFlash(Color.white, 0.1f);
                await UniTaskHelper.DelaySeconds(0.5f);
                await EffectManager.Instance.ScreenFlash(new Color(0, 0, 0, 0), 2f);

                await UniTaskHelper.DelaySeconds(1.0f);

                await EffectManager.Instance.ScreenFlash(Color.white, 0.1f);
                await UniTaskHelper.DelaySeconds(1.0f);

                // DeadBeaver on
                GameObject dead_beaver = gameObject.transform.Find("DeadBeaver").gameObject;
                dead_beaver.SetActive(true);
                await EffectManager.Instance.ScreenFlash(new Color(1.0f, 0, 0, 0.2f), 3f);

                Dialogue.DialogueManager.Instance.StartSpeechSet("title_opening 2");
                await UniTask.WaitUntil(() => !Dialogue.DialogueManager.Instance.IsSpeeching);

                await UniTaskHelper.DelaySeconds(1.0f);
                Dialogue.DialogueManager.Instance.StartSpeechSet("title_opening 3");
                await UniTask.WaitUntil(() => !Dialogue.DialogueManager.Instance.IsSpeeching);

                await UniTaskHelper.DelaySeconds(0.5f);

                // Falsh Sound
                await EffectManager.Instance.ScreenFlash(Color.white, 0.1f);
                dead_beaver.SetActive(false);
                GameObject player = gameObject.transform.Find("player").gameObject;
                player.SetActive(true);
                await UniTaskHelper.DelaySeconds(0.3f);

                await EffectManager.Instance.ScreenFlash(new Color(0, 0, 0, 0), 0.1f);
                Dialogue.DialogueManager.Instance.StartSpeechSet("title_opening 4");
                await UniTask.WaitUntil(() => GameManager.Instance.IsScrollerMode);

                // Input interaction
                await UniTask.WaitUntil(() => !Dialogue.DialogueManager.Instance.IsSpeeching);
                Debug.Log("Input Ok");
            }
        }


        protected override void OnOpened() {
            base.OnOpened();
        }

        private async void OnScroll(Vector2 amount)
        {
            _accumulated += Mathf.Abs(0.02f);

            if (_accumulated > _goal && !goalFinish) {
                goalFinish = true;
                await EffectManager.Instance.ScreenFlash(Color.white, 2.0f, true, DG.Tweening.Ease.OutQuad);
                GameManager.Instance.SetScrollerState(false);
                await UniTaskHelper.DelaySeconds(0.5f);

                GameObject player_bar = gameObject.transform.Find("player_bar").gameObject;
                player_bar.SetActive(true);
                await UniTaskHelper.DelaySeconds(0.5f);
                await EffectManager.Instance.ScreenFlash(new Color(0, 0, 0, 0), 1.5f);


                Dialogue.DialogueManager.Instance.StartSpeechSet("title_opening 6");

                BookManager.Instance.UnlockPage(1);
            }
        }
    }
}