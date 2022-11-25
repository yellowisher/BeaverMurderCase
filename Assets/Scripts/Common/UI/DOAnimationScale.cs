using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DOAnimationScale : DOAnimationBase<float, Transform>
{
    protected override void SetComponentValue(float value) => Component.localScale = new Vector3(value, value, value);
    protected override Tweener GetBaseAnimation(float endValue) => Component.DOScale(endValue, _duration);
}
