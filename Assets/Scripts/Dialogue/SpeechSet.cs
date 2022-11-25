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
        [Range(0, 1)] public int Talker;
        public Sprite Portrait;
        [TextArea(3, 10)] public string Line;
    }
}