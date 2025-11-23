using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputHandler;

public class TapToPlayManager : MonoBehaviour
{
    private InputHandler tapAction;
    private static TapToPlayManager Instance;

    private bool tapped;

    private CanvasGroup tapToPlayCanvas;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        if (tapAction != null) {
            tapAction.onTouchComplete -= OnTap;
        }
    }

    void Start()
    {
        tapAction = FindFirstObjectByType<InputHandler>();
        tapAction.onTouchComplete += OnTap;

        tapToPlayCanvas = GetComponent<CanvasGroup>();
        tapToPlayCanvas.alpha = 1f;
    }

    private void OnTap(InputCallback callback) {
        if (!tapped) {
            tapToPlayCanvas.DOFade(0f, 0.6f)
            .OnComplete(() => {
                tapToPlayCanvas.gameObject.SetActive(false);
            });
            tapped = true;
        }
    }

}
