using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleModalButtonsEvents : MonoBehaviour, ILogDistributor {
    public string DistributorName => GetType().Name;

    public void resetProgress() {
        if (PlayerPrefs.HasKey("levels")) {
            PlayerPrefs.DeleteKey("levels");
            PlayerPrefs.Save(); // ensure changes are written to disk
            this.Log("All level progress erased.");
        }
        else {
            this.Log("No saved progress to erase.");
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loadNextLevel() {
        int maxAvailableLevel = PlayerPrefs.GetInt("maxAvailableLevel");
        int currLevel = PlayerPrefs.GetInt("level");
        if (currLevel == maxAvailableLevel) {
            this.Log("������ ������� ����");
            return;
        }
        PlayerPrefs.SetInt("level", ++currLevel);
        SceneManager.LoadScene("game_scene");
    }

    public void reloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
