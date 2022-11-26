using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BeaverMurderCase.GameBook.Gimmick
{
    public class Scroller : MonoBehaviour
    {
        [SerializeField] private float _yIgnoranceRate;

        private List<ScrollObject> _scrollObjects;
        private Bounds _prevScrollerBounds;

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);

            if (isActive)
            {
                _scrollObjects = FindObjectsOfType<ScrollObject>().ToList();
                _prevScrollerBounds = default;
            }
        }

        private void Update()
        {
            var screenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            screenPosition.z = 0;
            transform.position = screenPosition;

            var root = GameManager.Instance.RootCanvas.transform;
            var scrollerRt = transform as RectTransform;
            var currentBounds = RectTransformUtility.CalculateRelativeRectTransformBounds(root, scrollerRt); 
            
            foreach (var scrollObject in _scrollObjects)
            {
                var objectRt = scrollObject.transform as RectTransform;
                var objectBounds = RectTransformUtility.CalculateRelativeRectTransformBounds(root, objectRt);

                if (IsPointInScrollerRect(_prevScrollerBounds, objectBounds) && IsPointInScrollerRect(currentBounds, objectBounds))
                {
                    float delta = currentBounds.center.x - _prevScrollerBounds.center.x;
                    float ratio = delta / objectBounds.size.x;

                    if (ratio != 0)
                    {
                        scrollObject.Scroll(ratio);
                    }
                }
            }

            _prevScrollerBounds = currentBounds;
        }

        private bool IsPointInScrollerRect(Bounds scrollerBounds, Bounds targetBounds)
        {
            bool isInX = scrollerBounds.min.x < targetBounds.center.x && targetBounds.center.x < scrollerBounds.max.x;
            float adjustedYExtent = targetBounds.extents.y * _yIgnoranceRate;
            float objectYMin = targetBounds.center.y - adjustedYExtent;
            float objectYMax = targetBounds.center.y + adjustedYExtent;
            bool isInY = scrollerBounds.min.y < objectYMin && scrollerBounds.max.y > objectYMax;

            return isInX && isInY;
        }
    }
}