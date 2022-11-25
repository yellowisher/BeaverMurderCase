using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BeaverMurderCase.GameBook
{
    public class PageButton : MonoBehaviour
    {
        [SerializeField] private int _page;
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _pageText;
        [SerializeField] private Color _lockedPageColor;
        [SerializeField] private Color _defaultPageColor;
        [SerializeField] private Color _newPageColor;
        
        public bool IsUnlocked { get; private set; }
        public bool IsNeverVisit { get; private set; }

        private BookManager _bookManager;

        public void EditorInitialize(int index)
        {
            _pageText.text = $"{index}p";
            _page = index;
        }

        [Inject]
        public void Constructor(BookManager bookManager)
        {
            _bookManager = bookManager;
        }

        public void Initialize()
        {
            _pageText.color = _lockedPageColor;
        }

        public void Unlock()
        {
            IsUnlocked = true;
            _pageText.color = _newPageColor;
        }
        
        public void OnClick()
        {
            if (!IsUnlocked) return;

            IsNeverVisit = false;
            _pageText.color = _defaultPageColor;
        }
    }
}