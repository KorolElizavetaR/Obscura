using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private InputActionReference _touch;
    [SerializeField]
    private InputActionReference _swipe;

    public event Action<InputCallback> onTouchComplete;
    public event Action<InputCallback> onSwipeDelta;

    public struct InputCallback {
        public Vector2 _swipeDelta;
    }

    private InputCallback inputCallback;

    private void Start() {
        _touch.action.Enable();
        _swipe.action.Enable();

        _touch.action.canceled += ProcessTouchComplete;
        _swipe.action.performed += ProcessSwipeDelta;
    }

    private void ProcessSwipeDelta(InputAction.CallbackContext context) {
        inputCallback._swipeDelta = _swipe.action.ReadValue<Vector2>();
        onSwipeDelta?.Invoke(inputCallback);
    }

    private void ProcessTouchComplete(InputAction.CallbackContext context) {
        onTouchComplete?.Invoke(inputCallback);
    }

}
