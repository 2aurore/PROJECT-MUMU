using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MM
{
    public class InputSystem : MonoBehaviour
    {
        public bool IsForceCursorVisible { get; set; }

        private bool isCommonCursorVisible = false;

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

