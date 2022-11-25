using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BeaverMurderCase.GameBook
{
    public class Page : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        
        public bool IsUnlocked { get; set; }
        public CanvasGroup CanvasGroup => _canvasGroup;
        
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}