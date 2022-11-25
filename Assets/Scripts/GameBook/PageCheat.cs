using NaughtyAttributes;
using UnityEngine;

namespace BeaverMurderCase.GameBook
{
    public class PageCheat : MonoBehaviour
    {
        public int GotoPage;
        public int UnlockPage;

        [Button]
        public void Go()
        {
            BookManager.Instance.OpenPage(GotoPage);
        }

        [Button]
        public void Unlock()
        {
            BookManager.Instance.UnlockPage(UnlockPage);
        }
    }
}