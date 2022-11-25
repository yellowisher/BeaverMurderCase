using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class DOAnimationGroupFade : DOAnimationBase<float, CanvasGroup>
{
    protected override void SetComponentValue(float value) => Component.alpha = Component.alpha = value;
    protected override Tweener GetBaseAnimation(float endValue) => Component.DOFade(endValue, _duration);
}
