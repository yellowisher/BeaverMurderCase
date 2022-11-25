using UnityEngine;
using UnityEngine.Events;

namespace BeaverMurderCase.GameBook.Gimmick
{
    public class ScrollObject : MonoBehaviour
    {
        public UnityEvent<float> OnScroll;
    }
}