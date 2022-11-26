using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BeaverMurderCase.Dialogue
{
    [CreateAssetMenu]
    public class SpeechSet : ScriptableObject
    {
        public List<Speech> Speeches;
    }

    public enum SpeechEventType
    {
        None,
        Die,
    }
    
    [Serializable]
    public class Speech
    {
        public float EventDelay;
        public SpeechEventType EventType;
        
        public const int TalkerLeft = 0;
        public const int NoTalker = 1;
        public const int TalkerRight = 2;
        
        [Range(0, 2)] public int Talker = NoTalker;
        public Sprite Portrait;
        [TextArea(5, 10)] public string Line;
    }
}