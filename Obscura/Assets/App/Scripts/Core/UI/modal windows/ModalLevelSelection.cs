using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModalLevelSelection : ModalEventHandler {
    [SerializeField] TextMeshProUGUI text;

    public override void onClickOpenModal() {
        int levelNum = PlayerPrefs.GetInt("level", 1);
        text.text = "������� " + levelNum;
        base.onClickOpenModal();
    }

    public void loadLevel() {
        SceneManager.LoadScene("game_scene");
    }
}
