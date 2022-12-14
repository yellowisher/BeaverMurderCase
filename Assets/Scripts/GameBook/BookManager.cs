using System.Collections.Generic;
using BeaverMurderCase.Common;
using BeaverMurderCase.Dialogue;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace BeaverMurderCase.GameBook
{
    public class BookManager : SingletonMonoBehaviour<BookManager>
    {
        [SerializeField] private Transform _pageHolder;
        [SerializeField] private Transform _pageButtonHolder;
        [SerializeField] private float _fadeDuration = 0.3f;
        [SerializeField] private float _fadeDelay = 0.1f;

        private bool _isTransitioning;

        public Dictionary<int, Page> Pages { get; } = new();
        public List<PageButton> PageButtons { get; } = new();

        public int CurrentPageNumber { get; private set; } = -1;
        public Page CurrentPage => Pages[CurrentPageNumber];

#if UNITY_EDITOR
        [Button]
        public void ArrangeButton()
        {
            var buttons = _pageButtonHolder.GetComponentsInChildren<PageButton>(true);
            for (int i = 0; i < buttons.Length; i++)
            {
                var button = buttons[i];
                button.EditorInitialize(i);
                UnityEditor.EditorUtility.SetDirty(button);
            }
        }
#endif

        protected override void Awake()
        {
            base.Awake();

            var pages = _pageHolder.GetComponentsInChildren<Page>(true);
            foreach (var page in pages)
            {
                Pages.Add(page.PageNumber, page);
                page.gameObject.SetActive(false);
            }

            var buttons = _pageButtonHolder.GetComponentsInChildren<PageButton>(true);
            PageButtons.AddRange(buttons);
            foreach (var button in PageButtons)
            {
                button.Initialize();
            }
            
            UnlockPage(0);
            OpenPage(0);
        }

        public bool IsUnlocked(int pageNumber)
        {
            return Pages[pageNumber].IsUnlocked;
        }
        
        public bool UnlockPage(int page)
        {
            if (Pages[page].IsUnlocked) return false;
            
            GameManager.Instance.SetScrollerState(false);
            Pages[page].IsUnlocked = true;
            PageButtons[page].OnPageUnlocked();

            return true;
        }

        public void UnlockPageSimple(int page) {
            if (Pages[page].IsUnlocked) return;

            GameManager.Instance.SetScrollerState(false);
            Pages[page].IsUnlocked = true;
            PageButtons[page].OnPageUnlocked();
            return;
        }

        public async void OpenPage(int page)
        {
            if (_isTransitioning) return;
            if (page == CurrentPageNumber) return;
            if (DialogueManager.Instance.IsSpeeching) return;

            _isTransitioning = true;
            if (CurrentPageNumber != -1)
            {
                PageButtons[CurrentPageNumber].SetCurrentPage(false);
            }
            
            PageButtons[page].SetCurrentPage(true);
            GameManager.Instance.SetScrollerState(false);
            SoundManager.PlaySfx(ClipType.MoveScene);

            if (CurrentPageNumber != -1)
            {
                CloseCurrentPage();
                DialogueManager.Instance.ClearSpeech();
                await UniTaskHelper.DelaySeconds(_fadeDelay);
            }

            CurrentPageNumber = page;

            var pageToOpen = Pages[CurrentPageNumber];
            pageToOpen.Open();
            pageToOpen.CanvasGroup.alpha = 0;
            await pageToOpen.CanvasGroup.DOFade(1f, _fadeDuration).SetEase(Ease.InQuad);
            
            _isTransitioning = false;


            async void CloseCurrentPage()
            {
                var pageToClose = Pages[CurrentPageNumber];
                await pageToClose.CanvasGroup.DOFade(0, _fadeDuration).SetEase(Ease.OutQuad);
                pageToClose.Close();
            }
        }
    }
}