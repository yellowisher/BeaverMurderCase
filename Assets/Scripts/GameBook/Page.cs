using BeaverMurderCase.GameBook.Gimmick;
using BeaverMurderCase.GameBook.Pages;
using UnityEngine;

namespace BeaverMurderCase.GameBook
{
    public class Page : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        public ScrollerType ScrollerType;
        public int PageNumber;
        
        public bool IsUnlocked { get; set; }
        
        public CanvasGroup CanvasGroup => _canvasGroup;

        private PageScript _pageScript;

        private void Awake()
        {
            _pageScript = GetComponentInChildren<PageScript>();
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