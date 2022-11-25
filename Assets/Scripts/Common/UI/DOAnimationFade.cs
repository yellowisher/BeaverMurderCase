using Common;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Graphic))]
public class DOAnimationFade : DOAnimationBase<float, Graphic>
{
    protected override void SetComponentValue(float value) => Component.color = Component.color.SetAlpha(value);
    protected override Tweener GetBaseAnimation(float endValue) => Component.DOFade(endValue, _duration);
}
