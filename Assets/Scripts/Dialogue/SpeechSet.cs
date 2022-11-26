using System;
using System.Collections.Generic;
using UnityEngine;

namespace BeaverMurderCase.Dialogue
{
    [CreateAssetMenu]
    public class SpeechSet : ScriptableObject
    {
        public List<Speech> Speeches;
    }

    [Serializable]
    public class Speech
    {
        public const int TalkerLeft = 0;
        public const int NoTalker = 1;
        public const int TalkerRight = 2;
        
        [Range(0, 2)] public int Talker = NoTalker;
        public Sprite Portrait;
        [TextArea(3, 10)] public string Line;
    }
}