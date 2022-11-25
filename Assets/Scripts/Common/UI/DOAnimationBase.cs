using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public abstract class DOAnimationBase<V, C> : DOAnimation where C : Component
{
    [SerializeField] protected float _duration = 0.2f;
    [SerializeField] private Ease _ease = Ease.Linear;
    [SerializeField] private bool _initBeforeFirstPlay = false;

    [SerializeField] protected V _startValue;
    [SerializeField] protected V _endValue;

    private bool _isFirstPlay = true;

    private C _component;
    protected C Component
    {
        get
        {
            if (_component == null) _component = GetComponent<C>();
            return _component;
        }
    }

    public override async UniTask Play(PlayType playType)
    {
        V startValue = _startValue;
        V endValue   = _endValue;

        if (playType == PlayType.PlayReverse)
        {
            startValue = _endValue;
            endValue   = _startValue;
        }

        if (_isFirstPlay)
        {
            _isFirstPlay = false;
            if (_initBeforeFirstPlay)
            {
                SetComponentValue(startValue);
            }
        }

        await GetBaseAnimation(endValue).SetEase(GetEase(playType));
    }

    public override void ResetToStart()
    {
        SetComponentValue(_startValue);
    }

    protected abstract void SetComponentValue(V value);
    protected abstract Tweener GetBaseAnimation(V endValue);

    private Ease GetEase(PlayType playType)
    {
        if (playType == PlayType.Play) return _ease;

        // Some hardcoded ease reversing function
        switch (_ease)
        {
            case Ease.InSine: return Ease.OutSine;
            case Ease.OutSine: return Ease.InSine;

            case Ease.InQuad: return Ease.OutQuad;
            case Ease.OutQuad: return Ease.InQuad;

            case Ease.InCubic: return Ease.OutCubic;
            case Ease.OutCubic: return Ease.InCubic;

            case Ease.InQuart: return Ease.OutQuart;
            case Ease.OutQuart: return Ease.InQuart;

            case Ease.InQuint: return Ease.OutQuint;
            case Ease.OutQuint: return Ease.InQuint;

            case Ease.InExpo: return Ease.OutExpo;
            case Ease.OutExpo: return Ease.InExpo;

            case Ease.InCirc: return Ease.OutCirc;
            case Ease.OutCirc: return Ease.InCirc;

            case Ease.InElastic: return Ease.OutElastic;
            case Ease.OutElastic: return Ease.InElastic;

            case Ease.InBack: return Ease.OutBack;
            case Ease.OutBack: return Ease.InBack;

            case Ease.InBounce: return Ease.OutBounce;
            case Ease.OutBounce: return Ease.InBounce;

            case Ease.InFlash: return Ease.OutFlash;
            case Ease.OutFlash: return Ease.InFlash;
            default: return _ease;
        }
    }
}
