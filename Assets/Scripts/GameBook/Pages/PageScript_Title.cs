using BeaverMurderCase.Dialogue;
using BeaverMurderCase.GameBook.Gimmick;
using BeaverMurderCase.GameBook;
using UnityEngine;
using BeaverMurderCase.Common;
using Cysharp.Threading.Tasks;


namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScript_Title : PageScript
    {
        [SerializeField] private ScrollObject _gameStartMessage;

        private float _minStartPoint;
        private float _accumulated;

        protected override async void Initialize()
        {
            _gameStartMessage.OnScroll.AddListener(OnScroll);

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
            await UniTaskHelper.DelaySeconds(0.1f);

            await EffectManager.Instance.ScreenFlash(new Color(0, 0, 0, 0), 0.1f);
            Dialogue.DialogueManager.Instance.StartSpeechSet("title_opening 4");
            await UniTask.WaitUntil(() => GameManager.Instance.IsScrollerMode);
            
            // 당장 내 나에게
            await UniTask.WaitUntil(() => !Dialogue.DialogueManager.Instance.IsSpeeching);
            Debug.Log("Input Ok");

            await UniTaskHelper.DelaySeconds(1.0f);

            Dialogue.DialogueManager.Instance.StartSpeechSet("title_opening 5");
            await UniTask.WaitUntil(() => GameManager.Instance.IsScrollerMode);


            // 흔들리는 이펙트
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