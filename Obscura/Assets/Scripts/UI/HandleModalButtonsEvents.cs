using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleModalButtonsEvents : MonoBehaviour {
    public void resetProgress() {
        if (PlayerPrefs.HasKey("levels")) {
            PlayerPrefs.DeleteKey("levels");
            PlayerPrefs.Save(); // ensure changes are written to disk
            Debug.Log("All level progress erased.");
        }
        else {
            Debug.Log("No saved progress to erase.");
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loadNextLevel() {
        int maxAvailableLevel = PlayerPrefs.GetInt("maxAvailableLevel");
        int currLevel = PlayerPrefs.GetInt("level");
        if (currLevel == maxAvailableLevel) {
            Debug.Log("Дальше уровней нема");
            return;
        }
        PlayerPrefs.SetInt("level", ++currLevel);
        SceneManager.LoadScene("game_scene");
    }

    public void reloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
