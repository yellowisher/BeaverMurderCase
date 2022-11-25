using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class DOAnimationGroup : DOAnimation
{
    [SerializeField] private DOAnimation[] _animations;

    private DOAnimation[] Animations
    {
        get
        {
            if (_animations == null)
            {
                var animations = GetComponentsInChildren<DOAnimation>().ToList();
                animations.Remove(this);
                _animations = animations.ToArray();
            }
            return _animations;
        }
    }

    public override UniTask Play(PlayType playType)
    {
        var tasks = new List<UniTask>(Animations.Length);
        foreach (var animation in Animations)
        {
            tasks.Add(animation.Play(playType));
        }

        return UniTask.WhenAll(tasks);
    }

    public override void ResetToStart()
    {
        foreach (var animation in Animations)
        {
            animation.ResetToStart();
        }
    }
}
