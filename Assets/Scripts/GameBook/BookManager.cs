using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace BeaverMurderCase.GameBook
{
    public class BookManager : MonoBehaviour
    {
        [SerializeField] private Transform _pageHolder;
        [SerializeField] private Transform _pageButtonHolder;

        public List<Page> Pages { get; } = new();
        public List<PageButton> PageButtons { get; } = new();

        public int CurrentPage { get; private set; } = -1;

        [Button]
        public void ArrangeButton()
        {
            var buttons = _pageButtonHolder.GetComponentsInChildren<PageButton>(true);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].EditorInitialize(i);
            }
        } 
        
        private void Awake()
        {
            var pages = _pageHolder.GetComponentsInChildren<Page>(true);
            Pages.AddRange(pages);
            foreach (var page in Pages)
            {
                page.gameObject.SetActive(false);
            }
            
            var buttons = _pageButtonHolder.GetComponentsInChildren<PageButton>(true);
            PageButtons.AddRange(buttons);
            foreach (var button in PageButtons)
            {
                button.Initialize();
            }
            
            OpenPage(0);
        }

        public void OpenPage(int page)
        {
            if (page == CurrentPage) return;

            if (page != -1)
            {
                Pages[CurrentPage].Close();
            }

            CurrentPage = page;
            Pages[CurrentPage].Open();
        }
    }
}