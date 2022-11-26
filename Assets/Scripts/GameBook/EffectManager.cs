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
        [Button] public void Test()
        {
            Color c = new Color(1.0f, 1.0f, 1.0f);
            ScreenFlash(c, 1.0f);
        }
        
        public async UniTask ScreenFlashReset() {
            await ScreenArea.DOColor(default, 0);
        }
        public async UniTask ScreenFlash(Color color, float delay, bool asyncTrue = true) {
            
            if (asyncTrue) {
                Debug.Log("hello");
                await ScreenArea.DOColor(color, delay).SetEase(Ease.Linear);
            }
            else {
                ScreenArea.DOColor(color, delay).SetEase(Ease.Linear);
            }
        }
    }
}
