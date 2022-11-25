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
        public string Text;
    }
}