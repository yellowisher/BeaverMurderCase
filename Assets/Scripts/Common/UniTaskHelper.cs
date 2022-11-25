using Cysharp.Threading.Tasks;

namespace BeaverMurderCase.Common
{
    public static class UniTaskHelper
    {
        public static UniTask DelaySeconds(float second)
        {
            return UniTask.Delay((int)(second * 1000f));
        }
    }
}
