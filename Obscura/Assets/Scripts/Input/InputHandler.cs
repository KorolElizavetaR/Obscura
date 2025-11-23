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

    private static InputHandler Instance;
    //private float _swipeThreshold = 10f;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    private void Start() {
        _touch.action.Enable();
        _swipe.action.Enable();

        _touch.action.canceled += ProcessTouchComplete;
        _swipe.action.performed += ProcessSwipeDelta;
    }

    private void ProcessSwipeDelta(InputAction.CallbackContext context) {
        Vector2 swipeDelta = _swipe.action.ReadValue<Vector2>();
        inputCallback._swipeDelta = swipeDelta;
        onSwipeDelta?.Invoke(inputCallback);

        //if (swipeDelta.magnitude >= _swipeThreshold) {
        //    inputCallback._swipeDelta = swipeDelta;
        //    onSwipeDelta?.Invoke(inputCallback);
        //} else {
        //    inputCallback._swipeDelta = Vector2.zero;
        //}
    }

    private void ProcessTouchComplete(InputAction.CallbackContext context) {
        Debug.Log($"inputCallback._swipeDelta: {inputCallback._swipeDelta}");
        onTouchComplete?.Invoke(inputCallback);
    }

}
