using BeaverMurderCase.GameBook;
using System.Collections;
using System.Collections.Generic;
using BeaverMurderCase.Common;
using BeaverMurderCase.Dialogue;

using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using DG.Tweening;
using Cysharp.Threading.Tasks;


namespace BeaverMurderCase.GameBook
{
    public class EffectManager : SingletonMonoBehaviour<EffectManager>
    {
        [SerializeField] private Image ScreenArea;
        [SerializeField] private DOTweenAnimation _shakeAnimation;
        
        [Button] public void Test()
        {
            Color c = new Color(1.0f, 1.0f, 1.0f);
            ScreenFlash(c, 1.0f);
        }
        
        public async UniTask ScreenFlashReset() {
            await ScreenArea.DOColor(default, 0);
        }
        public async UniTask ScreenFlash(Color color, float delay, bool asyncTrue = true, Ease interpType=Ease.Linear) {
            
            if (asyncTrue) {
                await ScreenArea.DOColor(color, delay).SetEase(interpType);
            }
            else {
                ScreenArea.DOColor(color, delay).SetEase(interpType);
            }
        }

        public async UniTask ShakeScreen()
        {
            _shakeAnimation.DORestart();
            await UniTaskHelper.DelaySeconds(_shakeAnimation.duration);
        }

        [Button]
        public void TestShakeScreen()
        {
            ShakeScreen().Forget();
        }

        [Button]
        public async void ShakeAndDie() {
            ShakeScreen().Forget();
            await ScreenFlash(Color.red, 0.3f, true, Ease.InCubic);
            await ScreenFlash(new Color(0,0,0,0), 2f, true, Ease.Linear);
        }
    }
}
