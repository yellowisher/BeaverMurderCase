using UnityEngine;
using UnityEngine.Events;

namespace BeaverMurderCase.GameBook.Gimmick
{
    public class ScrollObject : MonoBehaviour
    {
        public UnityEvent<float> OnScroll;

        public void Scroll(float amount)
        {
            OnScroll?.Invoke(amount);
            //Debug.Log($"{gameObject.name} scroll: {amount}");
        }
    }
}