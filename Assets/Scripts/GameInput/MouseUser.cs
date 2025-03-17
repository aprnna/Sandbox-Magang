using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace GameInput
{
    public class MouseUser : MonoBehaviour
    {
        private InputActions _inputActions;

        public event Action RightMouseClicked;
        public event Action LeftMouseClicked;

        public event Action RotateLeftPerformed;
        public event Action RotateRightPerformed;
        public Vector2 MousePosition { get; private set; }
        public Vector2 MouseInWorldPosition => Camera.main.ScreenToWorldPoint(MousePosition);

        private void OnEnable()
        {
            _inputActions = InputActions.Instance;
            _inputActions.Game.MousePosition.performed += OnMousePositionPerformed;
            _inputActions.Game.PerformAction.performed += OnPerformActionPerformed;
            _inputActions.Game.CancelAction.performed += OnCancelActionPerformed;
            _inputActions.Game.RotateRightObject.performed += OnRotationRightObjectPerformed;
            _inputActions.Game.RotateLeftObject.performed += OnRotationLeftObjectPerformed;
        }

        private void OnDisable()
        {
            _inputActions.Game.MousePosition.performed -= OnMousePositionPerformed;
            _inputActions.Game.PerformAction.performed -= OnPerformActionPerformed;
            _inputActions.Game.CancelAction.performed -= OnCancelActionPerformed;
            _inputActions.Game.RotateRightObject.performed += OnRotationRightObjectPerformed;
            _inputActions.Game.RotateLeftObject.performed += OnRotationLeftObjectPerformed;
        }

        private void OnMousePositionPerformed(InputAction.CallbackContext ctx)
        {
            MousePosition = ctx.ReadValue<Vector2>();
        }

        private void OnPerformActionPerformed(InputAction.CallbackContext ctx)
        {
            LeftMouseClicked?.Invoke();
        }


        private void OnCancelActionPerformed(InputAction.CallbackContext ctx)
        {
            RightMouseClicked?.Invoke();
        }

        private void OnRotationLeftObjectPerformed(InputAction.CallbackContext ctx)
        {
            RotateLeftPerformed?.Invoke();
        }
        private void OnRotationRightObjectPerformed(InputAction.CallbackContext ctx)
        {
            RotateRightPerformed?.Invoke();
        }
    
    }
}

