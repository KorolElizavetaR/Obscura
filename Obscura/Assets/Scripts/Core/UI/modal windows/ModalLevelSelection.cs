using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModalLevelSelection : ModalEventHandler {


    [SerializeField]
    TextMeshProUGUI text;

    //void Start() {
    //    text = levelText.GetComponent<TextMeshPro>();
    //    if (text == null) {
    //        Debug.LogError("TextMeshPro component not found on levelText GameObject!");
    //    }
    //}

    public override void onClickOpenModal() {
        int levelNum = PlayerPrefs.GetInt("level", 1);
        text.text = "Уровень " + levelNum;
        base.onClickOpenModal();
    }

    public void loadLevel() {
        SceneManager.LoadScene("game_scene");
    }

}
