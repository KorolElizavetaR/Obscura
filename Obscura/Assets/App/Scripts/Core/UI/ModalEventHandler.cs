using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ��������� � ����� ��������� ����
/// </summary>
public class ModalEventHandler : MonoBehaviour
{
    private PopupAnimation popupAnimation;

    protected virtual void Awake() {
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
