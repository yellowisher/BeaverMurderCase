using System;
using BeaverMurderCase.Dialogue;
using BeaverMurderCase.GameBook.Gimmick;
using UnityEngine;

namespace BeaverMurderCase.GameBook.Pages
{
    public class PageScript_Valve : PageScript
    {
        [SerializeField] private Transform _door;
        [SerializeField] private ScrollObject _valve;
        [SerializeField] private float _scrollForOpenDoor;
        [SerializeField] private float _doorMoveScale;

        private float _initialDoorY;
        private float _doorOpenValue;

        private void Awake()
        {
            _initialDoorY = _door.position.y;
        }

        protected override void Initialize()
        {
            _valve.OnScroll.AddListener(OnValveScroll);
        }

        public void OnValveScroll(Vector2 amount)
        {
            _doorOpenValue += amount.x;
            _doorOpenValue = Mathf.Clamp(_doorOpenValue, 0, _scrollForOpenDoor);

            float y = _initialDoorY + _doorOpenValue * _doorMoveScale;
            var position = _door.transform.position;
            position.y = y;
            _door.transform.position = position;

            if (Mathf.Abs(_doorOpenValue) >= _scrollForOpenDoor)
            {
                if (BookManager.Instance.UnlockPage(_page.PageNumber + 1))
                {
                    DialogueManager.Instance.StartSpeechSet("0_OpenDoor");
                }
            }
        }
    }
}