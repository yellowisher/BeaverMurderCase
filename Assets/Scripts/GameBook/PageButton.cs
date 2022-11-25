using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BeaverMurderCase.GameBook
{
    public class PageButton : MonoBehaviour
    {
        [SerializeField] private int _page;
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _pageText;
        [SerializeField] private Color _lockedPageColor;
        [SerializeField] private Color _defaultPageColor;
        [SerializeField] private Color _currentPageColor;
        [SerializeField] private Color _newPageColor;

        public bool IsNeverVisit { get; private set; }

#if UNITY_EDITOR
        public void EditorInitialize(int index)
        {
            _pageText.text = $"{index}p";
            _page = index;
            UnityEditor.EditorUtility.SetDirty(_pageText);
        }
#endif

        public void Initialize()
        {
            _pageText.color = _lockedPageColor;
        }

        public void OnPageUnlocked()
        {
            _pageText.color = _newPageColor;
        }
        
        public void OnClick()
        {
            if (!BookManager.Instance.Pages[_page].IsUnlocked) return;

            IsNeverVisit = false;
            BookManager.Instance.OpenPage(_page);
        }

        public void SetCurrentPage(bool isCurrentPage)
        {
            _pageText.color = isCurrentPage ? _currentPageColor : _defaultPageColor;
        }
    }
}