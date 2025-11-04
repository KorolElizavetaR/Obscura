using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPicker : MonoBehaviour
{
    [SerializeField] private int levelIndex;
    [SerializeField] private Image levelImage;

    public int LevelIndex => levelIndex;
    public Image LevelImage => levelImage;

    public void loadLevel() {
        PlayerPrefs.SetInt("level", levelIndex);
        SceneManager.LoadScene("game_scene");
    }
}
