using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class DOAnimation : MonoBehaviour
{
    public enum PlayType
    {
        Play,
        PlayReverse
    }

    public UniTask Play() => Play(PlayType.Play);
    public UniTask PlayReverse() => Play(PlayType.PlayReverse);
    public abstract void ResetToStart();

    public abstract UniTask Play(PlayType playType);
}
