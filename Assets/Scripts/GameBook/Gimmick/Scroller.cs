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
        GameStart,
    }

    [Serializable]
    public class ScrollerPair
    {
        public ScrollerType Type;
        public GameObject GameObject;
    } 
    
    public class Scroller : MonoBehaviour
    {
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
            Transform scrollerTransform = null;
            foreach (var pair in _scrollerObjects)
            {
                pair.Value.SetActive(BookManager.Instance.CurrentPage.ScrollerType == pair.Key);
                if (BookManager.Instance.CurrentPage.ScrollerType == pair.Key)
                {
                    scrollerTransform = pair.Value.transform;
                }
            }
            
            var root = GameManager.Instance.RootCanvas.transform as RectTransform;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(root, Input.mousePosition, Camera.main, out var worldPoint);

            transform.position = worldPoint;
            var scrollerRt = scrollerTransform as RectTransform;
            var currentBounds = RectTransformUtility.CalculateRelativeRectTransformBounds(root, scrollerRt);
            
            foreach (var scrollObject in _scrollObjects)
            {
                var objectRt = scrollObject.transform as RectTransform;
                var objectBounds = RectTransformUtility.CalculateRelativeRectTransformBounds(root, objectRt);

                if (IsPointInScrollerRect(_prevScrollerBounds, objectBounds) && IsPointInScrollerRect(currentBounds, objectBounds))
                {
                    var delta = currentBounds.center - _prevScrollerBounds.center;
                    var amount = new Vector2(delta.x / objectBounds.size.x, delta.y / objectBounds.size.y);

                    if (amount != Vector2.zero)
                    {
                        scrollObject.Scroll(amount);
                    }
                }
            }

            _prevScrollerBounds = currentBounds;
        }

        private bool IsPointInScrollerRect(Bounds scrollerBounds, Bounds targetBounds)
        {
            bool isInX = scrollerBounds.min.x < targetBounds.center.x && targetBounds.center.x < scrollerBounds.max.x;
            bool isInY = scrollerBounds.min.y < targetBounds.center.y && targetBounds.center.y < scrollerBounds.max.y;
            return isInX && isInY;
        }
    }
}