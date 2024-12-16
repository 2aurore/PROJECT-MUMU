using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MM
{
    public class InputSystem : SingletonBase<InputSystem>
    {
        public bool IsForceCursorVisible { get; set; }

        private bool isCommonCursorVisible = false;


        public System.Action OnEscapeInput;
        public System.Action OnTab;

        public System.Action<float> OnScrollWheel;

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

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                OnTab?.Invoke();
            }

            if (Input.mouseScrollDelta.y > 0)
            {
                OnScrollWheel?.Invoke(Input.mouseScrollDelta.y);
            }
            else if (Input.mouseScrollDelta.y < 0)
            {
                OnScrollWheel?.Invoke(Input.mouseScrollDelta.y);
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

