using UnityEngine;
using UnityEngine.Events;

namespace BeaverMurderCase.GameBook.Gimmick
{
    public class ScrollObject : MonoBehaviour
    {
        public UnityEvent<Vector2> OnScroll;

        public void Scroll(Vector2 amount)
        {
            OnScroll?.Invoke(amount);
            Debug.Log($"{gameObject.name} scroll: {amount}");
        }
    }
}