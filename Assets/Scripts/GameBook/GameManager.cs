using BeaverMurderCase.Common;
using BeaverMurderCase.GameBook.Gimmick;
using UnityEngine;

namespace BeaverMurderCase.GameBook
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] private Scroller _scroller;
        
        public bool IsScrollerMode { get; private set; }

        private void Start()
        {
            _scroller.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ToggleScroller();
            }
        }

        public void ToggleScroller()
        {
            bool scrollerMode = !IsScrollerMode;
            _scroller.SetActive(scrollerMode);
            
            IsScrollerMode = scrollerMode;
        }
    }
}