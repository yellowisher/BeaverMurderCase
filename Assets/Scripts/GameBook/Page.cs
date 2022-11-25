using UnityEngine;

namespace BeaverMurderCase.GameBook
{
    public class Page : MonoBehaviour
    {
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}