using BeaverMurderCase.GameBook.Gimmick;
using BeaverMurderCase.GameBook.Pages;
using UnityEngine;

namespace BeaverMurderCase.GameBook
{
    public class Page : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        public ScrollerType ScrollerType; 
        
        public bool IsUnlocked { get; set; }
        public int PageNumber { get; private set; }
        
        public CanvasGroup CanvasGroup => _canvasGroup;

        private PageScript _pageScript;

        private void Awake()
        {
            _pageScript = GetComponentInChildren<PageScript>();
        }

        public void Initialize(int pageNumber)
        {
            PageNumber = pageNumber;
        }

        public void Open()
        {
            gameObject.SetActive(true);
            if (_pageScript != null)
            {
                _pageScript.OnOpen(this);
            }
        }

        public void Close()
        {
            if (_pageScript != null)
            {
                _pageScript.OnClose(this);
            }

            gameObject.SetActive(false);
        }
    }
}