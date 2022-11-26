using BeaverMurderCase.Dialogue;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScript_HaedalCoffee : PageScript
    {
        [SerializeField] private GameObject _positionEffect;
        [SerializeField] private float _radius;
        [SerializeField] private float _delay;
        [SerializeField] private Transform _effectParent;

        private float _nextEffectTime;
        
        protected override void OnOpened()
        {
            DialogueManager.Instance.StartSpeechSet("HaedalHouseCoffee");
            _nextEffectTime = Time.time + 5f;
        }

        private void Update()
        {
            if (Time.time > _nextEffectTime)
            {
                _nextEffectTime += _delay;
                CreateEffect();
            }
        }

        public void OnClick_Coffee()
        {
            CreateEffect();
        }

        public void CreateEffect()
        {
            var effect = Instantiate(_positionEffect, _effectParent);
            (effect.transform as RectTransform).anchoredPosition += Random.insideUnitCircle * _radius;
            effect.SetActive(true);
        }
    }
}