using BeaverMurderCase.GameBook;
using System.Collections;
using System.Collections.Generic;
using BeaverMurderCase.Common;
using BeaverMurderCase.Dialogue;

using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using Unity.VisualScripting;
using Cysharp.Threading.Tasks;

namespace BeaverMurderCase.GameBook
{
    public class EffectManager : SingletonMonoBehaviour<EffectManager>
    {
        [SerializeField] private Image ScreenArea;
        [Button] public void Test()
        {
            Flash();
        }

        public async void Flash() {
            ScreenArea.gameObject.SetActive(true);
            await UniTaskHelper.DelaySeconds(0.5f);
            ScreenArea.gameObject.SetActive(false);
        }


    }
}
