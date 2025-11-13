using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PopupAnimation : MonoBehaviour {
    private Tween tween;

    [SerializeField] private Vector2 targetPoz;
    private Vector2 startPoz;

    [SerializeField] private float duration;
    [SerializeField] private Ease ease;
    [SerializeField] private Image levelFade;
    [SerializeField] private Image backgroundFade;
    [SerializeField] private float fadeOpacity;

    private RectTransform rectTransform;

    public void Start() {
        rectTransform = GetComponent<RectTransform>();
        startPoz = rectTransform.anchoredPosition;
    }

    public Tween onOpenModalSlide() {
        tween?.Kill();

        Sequence seq = DOTween.Sequence();
        seq.Append(rectTransform.DOAnchorPos(targetPoz, duration).SetEase(ease));
        seq.Join(backgroundFade.DOFade(fadeOpacity, duration));

        tween = seq;

        return tween;
    }

    public Tween onCloseModalSlide() {
        tween?.Kill();

        var seq = DOTween.Sequence();
        seq.Append(rectTransform.DOAnchorPos(startPoz, duration).SetEase(ease));
        seq.Join(backgroundFade.DOFade(0, duration));

        tween = seq;

        return tween;
    }

    //public void onCloseModalSlideF() {
    //    onCloseModalSlide();
    //}

    public Tween onCloseModalFade() {
        tween?.Kill();
        tween = levelFade.DOFade(1f, duration) as Tween;
        return tween;
    }

}
