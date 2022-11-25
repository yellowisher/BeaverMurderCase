using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DOAnimationColor : DOAnimationBase<Color, Graphic>
{
    protected override void SetComponentValue(Color value) => Component.color = value;
    protected override Tweener GetBaseAnimation(Color endValue) => Component.DOColor(endValue, _duration);
}
