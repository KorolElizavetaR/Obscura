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
}
