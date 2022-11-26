using BeaverMurderCase.Common;
using BeaverMurderCase.GameBook.Gimmick;
using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BeaverMurderCase.GameBook
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] private Scroller _scroller;
        [SerializeField] private RectMask2D _scrollerMask;
        [SerializeField] private CanvasGroup _canvasGroup;
        
        public Canvas RootCanvas;
        
        public bool IsScrollerMode { get; private set; }

        private bool _blockPageInput;

        public bool BlockPageInput
        {
            get => _blockPageInput;
            set
            {
                _blockPageInput = value;
                _canvasGroup.interactable = !_blockPageInput;
            }
        }

        private void Start()
        {
            _scroller.SetActive(false);
            TAnimBuilder.InitializeGlobalDatabase();
            _scrollerMask.enabled = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ToggleScroller();
            }

            if (Input.GetKeyDown(KeyCode.F12))
            {
                SceneManager.LoadScene(0);
            }
        }

        public void ToggleScroller()
        {
            SetScrollerState(!IsScrollerMode);
        }

        public void SetScrollerState(bool isScrollerMode)
        {
            _scroller.SetActive(isScrollerMode);
            IsScrollerMode = isScrollerMode;
        }
    }
}