using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DOAnimationLocalMove : DOAnimationBase<Vector3, Transform>
{
    private Vector3? _origin;
    private Vector3 Origin
    {
        get
        {
            if (_origin == null) _origin = transform.localPosition;
            return _origin.Value;
        }
    }


    protected override void SetComponentValue(Vector3 value) => Component.localPosition = Origin + value;
    protected override Tweener GetBaseAnimation(Vector3 endValue) => Component.DOLocalMove(Origin + endValue, _duration);
}
