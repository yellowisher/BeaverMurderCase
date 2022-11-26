using BeaverMurderCase.Dialogue;
using BeaverMurderCase.GameBook.Gimmick;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using Cysharp.Threading.Tasks;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScript_HouseOptions : PageScript
    {
        protected override void Initialize()
        {
            transform.Find("beaver_office")
                .GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(async _ =>
                {
                    DialogueManager.Instance
                        .StartSpeechSet("BeaverOffice");
                });

            transform.Find("otter_house")
                .GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(async _ =>
                {
                    DialogueManager.Instance
                        .StartSpeechSet("OtterHouse");
                    BookManager.Instance.UnlockPage(5);
                });

            transform.Find("hippo_house")
                .GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(async _ =>
                {
                    DialogueManager.Instance
                        .StartSpeechSet("HippoHouse");
                    BookManager.Instance.UnlockPage(6);
                });

            transform.Find("bear_house")
                .GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(async _ =>
                {
                    DialogueManager.Instance
                        .StartSpeechSet("BearHouse");
                    BookManager.Instance.UnlockPage(7);
                });
        }

        protected override void OnOpened()
        {

        }
    }
}