using System;
using System.Collections;
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

        protected override void Awake()
        {
            base.Awake();
            
            _textAnimator.SetText(string.Empty, true);
            _textAnimatorPlayer.onTextShowed.AddListener(() => _allTextShowed = true);
            _textAnimatorPlayer.onCharacterVisible.AddListener(OnCharacterVisible);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                _didInput = true;
            }
        }

        private void OnCharacterVisible(char ch)
        {
            SoundManager.PlaySfx(ClipType.Typing);
        }

        public void PlaySpeechSet(SpeechSet speechSet)
        {
            StopCoroutine(nameof(PlaySpeechSetCo));
            StartCoroutine(nameof(PlaySpeechSetCo), speechSet);
        }

        private IEnumerator PlaySpeechSetCo(SpeechSet speechSet)
        {
            foreach (var speech in speechSet.Speeches)
            {
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

                _didInput = false;
                yield return new WaitUntil(() => _didInput);
            }
        }
        
        [SerializeField] private SpeechSet _testSpeechSet;

        [Button]
        public void StartTestSpeech()
        {
            PlaySpeechSet(_testSpeechSet);
        }
    }
}