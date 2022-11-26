using UnityEngine;

namespace BeaverMurderCase.GameBook.Pages
{
    public abstract class PageScript : MonoBehaviour
    {
        protected Page _page;
        
        public void OnOpen(Page page)
        {
            if (_page == null)
            {
                _page = page;
                Initialize();
            }
            
            OnOpened();
        }

        protected virtual void Initialize()
        {
        }

        protected virtual void OnOpened()
        {
        }
        
        public void OnClose(Page page)
        {
        }
    }
}