using UnityEngine;

namespace BeaverMurderCase.Common
{
    public class DestroyAfterPlay : MonoBehaviour
    {
        private async void Awake()
        {
            await UniTaskHelper.DelaySeconds(10f);
            Destroy(gameObject);
        }
    }
}