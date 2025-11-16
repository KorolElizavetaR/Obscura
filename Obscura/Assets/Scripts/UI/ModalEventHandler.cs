using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void onClickOpenModal() {
        popupAnimation.onOpenModalSlide();
    }

    public void onClickCloseModal() {
        popupAnimation.onCloseModalSlide();
    }

}
