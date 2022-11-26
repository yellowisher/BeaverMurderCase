using System;
using System.Collections.Generic;
using UnityEngine;

namespace BeaverMurderCase.Common
{
    public enum BgmType
    {
        Bgm,
    }
    
    public enum ClipType
    {
        ButtonHover,
        Typing,
        Die,
        Thunder,
        MoveScene,
        Pop,
    }
    
    public class SoundData : ScriptableSingleton<SoundData>
    {
        
        [Serializable]
        public class BgmPair
        {
            public BgmType Type;
            public AudioClip Clip;
        }
        
        [Serializable]
        public class ClipPair
        {
            public ClipType Type;
            public AudioClip Clip;
        }
        
        [SerializeField] private List<BgmPair> _bgmPairs;
        [SerializeField] private List<ClipPair> _clipPairs;

        public AudioClip GetBgmClip(BgmType type) => _bgmPairs.Find(pair => pair.Type == type)?.Clip;
        public AudioClip GetSfxClip(ClipType type) => _clipPairs.Find(pair => pair.Type == type)?.Clip;
    }
}
