using BeaverMurderCase.Common;
using BeaverMurderCase.Dialogue;
using BeaverMurderCase.GameBook.Gimmick;
using DG.Tweening;
using UnityEngine;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScript_HamaCage : PageScript
    {
        [SerializeField] private ScrollObject _valve;
        [SerializeField] private float _goal;
        [SerializeField] private float _maxRotate;
        [SerializeField] private Transform _door;
        [SerializeField] private DOTweenAnimation _mococoAnimation;

        private float _value;
        private bool _isOpen;
        
        protected override void Initialize()
        {
            _valve.OnScroll.AddListener(OnScroll);
        }

        protected override void OnOpened()
        {
            _value = 0;
            _door.rotation = Quaternion.identity;
            _isOpen = false;
            _mococoAnimation.DORewind();
            
            DialogueManager.Instance.StartSpeechSet("Hama_Cage");
        }
        
        public async void OnScroll(Vector2 delta)
        {
            _value += delta.x;
            _value = Mathf.Clamp(_value, 0, _goal);

            float rotate = Mathf.InverseLerp(0, _goal, _value);
            rotate *= _maxRotate;
            
            _door.rotation = Quaternion.Euler(0, rotate, 0);

            if (!_isOpen && _value >= _goal * 0.8f)
            {
                DialogueManager.Instance.StartSpeechSet("Hama_CageOpen", false);
            }
        }

        public async void OnClick_Mococo()
        {
            _mococoAnimation.DOPlay();
            await UniTaskHelper.DelaySeconds(_mococoAnimation.duration);
            DialogueManager.Instance.StartSpeechSet("Hama_MococoClick");
        }
    }
}