using DG.Tweening;
using UnityEngine;

public class TapToPlayManager : MonoBehaviour
{
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

    void Start()
    {
        tapToPlayCanvas = GetComponent<CanvasGroup>();
        tapToPlayCanvas.alpha = 1f;
    }

    private void Update() {
        if (!tapped && Input.GetMouseButtonDown(0)) {
            tapped = true;
            OnTap();
        }
    }

    private void OnTap() {
        // Fade out whole canvas
        tapToPlayCanvas.DOFade(0f, 0.6f)
            .OnComplete(() => {
                tapToPlayCanvas.gameObject.SetActive(false);
            });
        tapped = true;
    }

}
