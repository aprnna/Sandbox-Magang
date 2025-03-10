using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace GameInput
{
    public enum MouseButton{
     Left,Right
    }
    public class MouseUser:MonoBehaviour
    {
        private InputActions _inputActions;
        
        public Vector2 MousePosition { get; private set; }
        public Vector2 MouseInWorldPosition => Camera.main.ScreenToWorldPoint(MousePosition);

        private bool _isLeftMouseButtonPressed;
        private bool _isRightMouseButoonPressed;

        private void Awake()
        {

        }

        private void OnEnable()
        {
            _inputActions = InputActions.Instance;
            _inputActions.Game.MousePosition.performed += OnMousePositionPerformed;
            _inputActions.Game.PerformAction.performed += OnPerformActionPerformed;
            _inputActions.Game.PerformAction.canceled += OnPerformActionCanceled;
            _inputActions.Game.CancelAction.performed += OnCancelActionPerformed;
            _inputActions.Game.CancelAction.canceled += OnCancelActionCancelled;
        }

        private void OnDisable()
        {
            _inputActions.Game.MousePosition.performed -= OnMousePositionPerformed;
            _inputActions.Game.PerformAction.performed -= OnPerformActionPerformed;
            _inputActions.Game.PerformAction.canceled -= OnPerformActionCanceled;
            _inputActions.Game.CancelAction.performed -= OnCancelActionPerformed;
            _inputActions.Game.CancelAction.canceled -= OnCancelActionCancelled;

        }

        private void OnMousePositionPerformed(InputAction.CallbackContext ctx)
        {
            MousePosition = ctx.ReadValue<Vector2>();
        }
        private void OnPerformActionPerformed(InputAction.CallbackContext ctx)
        {
            _isLeftMouseButtonPressed = true;
        }
        private void OnPerformActionCanceled(InputAction.CallbackContext ctx)
        {
            _isLeftMouseButtonPressed = false;
        }

        private void OnCancelActionPerformed(InputAction.CallbackContext ctx)
        {
            _isRightMouseButoonPressed = true;
        }
        private void OnCancelActionCancelled(InputAction.CallbackContext ctx)
        {
            _isRightMouseButoonPressed = false;
        }
        public bool IsMouseButtonPressed(MouseButton button)
        {
            return button == MouseButton.Left ? _isLeftMouseButtonPressed : _isRightMouseButoonPressed;
        }
    }
}

