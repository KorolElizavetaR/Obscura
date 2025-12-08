using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Перенести в папку модальных окон
/// </summary>
public class ModalEventHandler : MonoBehaviour
{
    private PopupAnimation popupAnimation;

    private void Awake() {
        popupAnimation = GetComponent<PopupAnimation>();
    }

    public void onClickLoadMenu() {
        Tween tween = popupAnimation.onCloseModalFade();

        var seq = DOTween.Sequence();
        seq.Append(tween);
        seq.OnComplete(() => {
            SceneManager.LoadScene("menu");
        });
    }

    public virtual void onClickOpenModal() {
        popupAnimation.onOpenModalSlide();
    }

    public void onClickCloseModal() {
        popupAnimation.onCloseModalSlide();
    }

}
