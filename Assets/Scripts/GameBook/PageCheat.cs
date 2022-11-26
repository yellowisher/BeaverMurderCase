using NaughtyAttributes;
using UnityEngine;

namespace BeaverMurderCase.GameBook
{
    public class PageCheat : MonoBehaviour
    {
        public int TargetPage;

        [Button]
        public void Go()
        {
            BookManager.Instance.OpenPage(TargetPage);
        }

        [Button]
        public void Unlock()
        {
            BookManager.Instance.UnlockPage(TargetPage);
        }

        [Button]
        public void UnlockAll()
        {
            foreach (var pageNumber in BookManager.Instance.Pages.Keys)
            {
                BookManager.Instance.UnlockPage(pageNumber);
            }
        }
    }
}