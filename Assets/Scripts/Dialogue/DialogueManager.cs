using System.Collections;
using System.Collections.Generic;
using BeaverMurderCase.Common;
using Febucci.UI;
using NaughtyAttributes;
using UnityEngine;

namespace BeaverMurderCase.Dialogue
{
    public class DialogueManager : SingletonMonoBehaviour<DialogueManager>
    {
        [SerializeField] private TextAnimator _textAnimator;
        [SerializeField] private TextAnimatorPlayer _textAnimatorPlayer;

        private bool _didInput;
        private bool _allTextShowed;
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
            StopCoroutine(nameof(StartSpeechSetCo));
            StartCoroutine(nameof(StartSpeechSetCo), speechSet);
        }

        private IEnumerator StartSpeechSetCo(SpeechSet speechSet)
        {
            IsSpeeching = true;
            for (int i = 0; i < speechSet.Speeches.Count; i++)
            {
                var speech = speechSet.Speeches[i];
                _textAnimator.SetText(speech.Line, true);
                _textAnimatorPlayer.StartShowingText();
                _allTextShowed = false;

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
                    _didInput = false;
                    yield return new WaitUntil(() => _didInput);       
                }
            }

            IsSpeeching = false;
            Debug.Log("speech done");
        }

        public void ClearSpeech()
        {
            StopCoroutine(nameof(StartSpeechSetCo));
            _textAnimator.SetText(string.Empty, true);
        }
        
        [SerializeField] private SpeechSet _testSpeechSet;

        [Button]
        public void StartTestSpeech()
        {
            StartSpeechSet(_testSpeechSet);
        }
    }
}