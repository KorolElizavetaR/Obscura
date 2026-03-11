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
        public Vector3Int _swipeDelta;
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
        inputCallback._swipeDelta = getMovementDirecton(swipeDelta);
        onSwipeDelta?.Invoke(inputCallback);
    }

    private void ProcessTouchComplete(InputAction.CallbackContext context) {
        Debug.Log($"inputCallback._swipeDelta: {inputCallback._swipeDelta}");
        onTouchComplete?.Invoke(inputCallback);
    }

    private Vector3Int getMovementDirecton(Vector2 swipeDelta) {
        float movementOffsetX = swipeDelta.x;
        float movementOffsetY = swipeDelta.y;

        if (!Mathf.Approximately(movementOffsetX, 0f) || !Mathf.Approximately(movementOffsetY, 0f)) {
            return Mathf.Abs(movementOffsetX) > Mathf.Abs(movementOffsetY)
                ? new Vector3Int(Mathf.RoundToInt(Mathf.Sign(movementOffsetX)), 0, 0)
                : new Vector3Int(0, Mathf.RoundToInt(Mathf.Sign(movementOffsetY)), 0);
        }
        else {
            return Vector3Int.zero;
        }
    }

}
