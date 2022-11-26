using System.Collections;
using System.Collections.Generic;
using BeaverMurderCase.Common;
using BeaverMurderCase.GameBook;
using Cysharp.Threading.Tasks;
using Febucci.UI;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace BeaverMurderCase.Dialogue
{
    public class DialogueManager : SingletonMonoBehaviour<DialogueManager>
    {
        [SerializeField] private TextAnimator _textAnimator;
        [SerializeField] private TextAnimatorPlayer _textAnimatorPlayer;
        [SerializeField] private Image _leftPortrait;
        [SerializeField] private Image _rightPortrait;
        [SerializeField] private GameObject _goNextCursor;

        private bool _didInput;
        public bool _allTextShowed;
        private readonly Dictionary<string, SpeechSet> _speechSets = new();
        
        public bool IsSpeeching { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            
            _textAnimator.SetText(string.Empty, true);
            _textAnimatorPlayer.onTextShowed.AddListener(() => _allTextShowed = true);
            _textAnimatorPlayer.onCharacterVisible.AddListener(OnCharacterVisible);

            var speeches = Resources.LoadAll<SpeechSet>("Speech");
            foreach (var speech in speeches)
            {
                _speechSets.Add(speech.name, speech);
            }
            
            ClearSpeech();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                _didInput = true;
            }
        }

        public void OnClick_Panel()
        {
            _didInput = true;
        }

        private void OnCharacterVisible(char ch)
        {
            SoundManager.PlaySfx(ClipType.Typing);
        }

        public void StartSpeechSet(string speechName)
        {
            if (!_speechSets.TryGetValue(speechName, out var speech))
            {
                Debug.LogError($"Cannot find speech name: {speechName}");
                return;
            }
           
            StartSpeechSet(speech);
        }

        public void StartSpeechSet(SpeechSet speechSet)
        {
            ClearSpeech();
            GameManager.Instance.SetScrollerState(false);
            StartCoroutine(nameof(StartSpeechSetCo), speechSet);
        }

        private IEnumerator StartSpeechSetCo(SpeechSet speechSet)
        {
            IsSpeeching = true;
            GameManager.Instance.BlockPageInput = true;
            for (int i = 0; i < speechSet.Speeches.Count; i++)
            {
                var speech = speechSet.Speeches[i];

                DisablePortrait(_leftPortrait);
                DisablePortrait(_rightPortrait);
                if (speech.Talker == Speech.TalkerLeft)
                {
                    SetPortrait(_leftPortrait, speech.Portrait);
                }
                else if (speech.Talker == Speech.TalkerRight)
                {
                    SetPortrait(_rightPortrait, speech.Portrait);
                }
                
                _textAnimator.SetText(speech.Line, true);
                _textAnimatorPlayer.StartShowingText();
                _allTextShowed = false;
                _goNextCursor.SetActive(false);

                _didInput = false;
                while (!_allTextShowed)
                {
                    if (_didInput)
                    {
                        _textAnimatorPlayer.SkipTypewriter();
                    }

                    yield return null;
                }

                if (i != speechSet.Speeches.Count - 1)
                {
                    _goNextCursor.SetActive(true);
                    _didInput = false;
                    yield return new WaitUntil(() => _didInput);       
                }
            }

            GameManager.Instance.BlockPageInput = false;
            IsSpeeching = false;
            Debug.Log($"Speech {speechSet.name} done");
        }

        public void ClearSpeech()
        {
            StopCoroutine(nameof(StartSpeechSetCo));
            _textAnimator.SetText(string.Empty, true);
            _goNextCursor.SetActive(false);

            DisablePortrait(_leftPortrait);
            DisablePortrait(_rightPortrait);
        }

        private void SetPortrait(Image image, Sprite sprite)
        {
            image.gameObject.SetActive(true);
            image.sprite = sprite;
        }

        private void DisablePortrait(Image image)
        {
            image.sprite = null;
            image.gameObject.SetActive(false);
        }

        public UniTask WaitForSpeechEndAsync()
        {
            return UniTask.WaitUntil(() => !IsSpeeching);
        }
        
        [SerializeField] private SpeechSet _testSpeechSet;

        [Button]
        public void StartTestSpeech()
        {
            StartSpeechSet(_testSpeechSet);
        }
    }
}