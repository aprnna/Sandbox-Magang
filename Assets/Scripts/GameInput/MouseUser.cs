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

        public event Action RotationPerformed;
        public Vector2 MousePosition { get; private set; }
        public Vector2 MouseInWorldPosition => Camera.main.ScreenToWorldPoint(MousePosition);

        private void OnEnable()
        {
            _inputActions = InputActions.Instance;
            _inputActions.Game.MousePosition.performed += OnMousePositionPerformed;
            _inputActions.Game.PerformAction.performed += OnPerformActionPerformed;
            _inputActions.Game.CancelAction.performed += OnCancelActionPerformed;
            _inputActions.Game.RotationObject.performed += OnRotationObjectPerformed;
        }

        private void OnDisable()
        {
            _inputActions.Game.MousePosition.performed -= OnMousePositionPerformed;
            _inputActions.Game.PerformAction.performed -= OnPerformActionPerformed;
            _inputActions.Game.CancelAction.performed -= OnCancelActionPerformed;
            _inputActions.Game.RotationObject.performed += OnRotationObjectPerformed;
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

        private void OnRotationObjectPerformed(InputAction.CallbackContext ctx)
        {
            RotationPerformed?.Invoke();
        }

    }
}

