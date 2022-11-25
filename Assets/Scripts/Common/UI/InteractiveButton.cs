using System;
using BeaverMurderCase.Common;
using Common;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InteractiveButton : MonoBehaviour,
    IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Transform _target;
    [SerializeField] private UnityEvent _onClick;
    [SerializeField] private UnityEvent _onEnter;
    [SerializeField] private UnityEvent _onExit;
    [SerializeField] private float _duration = 0.1f;
    [SerializeField] private float _scaleAdditionOnOver  =  0.15f;
    [SerializeField] private float _scaleAdditionOnPress = -0.15f;

    private bool _isPressing;
    private Transform Target
    {
        get
        {
            if (_target == null) _target = transform;
            return _target;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _onEnter?.Invoke();
        Target.DOBlendableScaleBy(CreateScale(_scaleAdditionOnOver), _duration);
        SoundManager.PlaySfx(ClipType.ButtonHover);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _onExit?.Invoke();
        ReleasePressing();

        Target.DOBlendableScaleBy(CreateScale(-_scaleAdditionOnOver), _duration);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressing = true;
        Target.DOBlendableScaleBy(CreateScale(_scaleAdditionOnPress), _duration);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ReleasePressing();
    }

    private void ReleasePressing()
    {
        if (!_isPressing) return;

        _isPressing = false;
        Target.DOBlendableScaleBy(CreateScale(-_scaleAdditionOnPress), _duration);
    }

    private Vector3 CreateScale(float value)
    {
        return new Vector3(value, value, value);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            _onClick?.Invoke();
        }
    }

    private void OnDestroy()
    {
        Target.DOKill();
    }
}
