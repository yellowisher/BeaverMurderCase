using UnityEngine;

namespace BeaverMurderCase.GameBook.Gimmick
{
    public class Scroller : MonoBehaviour
    {
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
        
        private void Update()
        {
            var screenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            screenPosition.z = 0;
            transform.position = screenPosition;
        }
    }
}