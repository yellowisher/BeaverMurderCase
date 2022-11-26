using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BeaverMurderCase.GameBook.Gimmick
{
    public enum ScrollerType
    {
        Fire,
        Valve,
    }

    [Serializable]
    public class ScrollerPair
    {
        public ScrollerType Type;
        public GameObject GameObject;
    } 
    
    public class Scroller : MonoBehaviour
    {
        [SerializeField] private float _yIgnoranceRate;
        [SerializeField] private List<ScrollerPair> _pairs;

        private Dictionary<ScrollerType, GameObject> _scrollerObjects = new();
        private List<ScrollObject> _scrollObjects;
        private Bounds _prevScrollerBounds;

        private void Awake()
        {
            foreach (var pair in _pairs)
            {
                _scrollerObjects.Add(pair.Type, pair.GameObject);
            }
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);

            Cursor.visible = !isActive;
            if (isActive)
            {
                _scrollObjects = FindObjectsOfType<ScrollObject>().ToList();
                _prevScrollerBounds = default;
            }
        }

        private void Update()
        {
            foreach (var pair in _scrollerObjects)
            {
                pair.Value.SetActive(BookManager.Instance.CurrentPage.ScrollerType == pair.Key);
            }
            
            var root = GameManager.Instance.RootCanvas.transform as RectTransform;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(root, Input.mousePosition, Camera.main, out var worldPoint);

            transform.position = worldPoint;
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