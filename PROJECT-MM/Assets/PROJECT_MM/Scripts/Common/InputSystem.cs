using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MM
{
    public class InputSystem : SingletonBase<InputSystem>
    {
        public bool IsForceCursorVisible { get; set; }

        private bool isCommonCursorVisible = false;


        public System.Action OnEscapeInput;

        private void Start()
        {
            SetCursorVisible(false);
        }

        private void Update()
        {
            IsForceCursorVisible = Input.GetKey(KeyCode.LeftAlt);
            if (IsForceCursorVisible)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                SetCursorVisible(isCommonCursorVisible);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnEscapeInput?.Invoke();
            }
        }

        public void SetCursorVisible(bool isVisible)
        {
            isCommonCursorVisible = isVisible;
            if (isVisible)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}

