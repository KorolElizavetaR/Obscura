using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class LevelPicker : MonoBehaviour
{
    [SerializeField] private int levelIndex;
    
    public void loadLevel() {
        PlayerPrefs.SetInt("level", levelIndex);
        SceneManager.LoadScene("game_scene");
    }
}
