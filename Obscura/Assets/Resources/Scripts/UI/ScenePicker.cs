using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePicker : MonoBehaviour
{
    [SerializeField] private string levelName;
    
    public void loadLevel() {
        SceneManager.LoadScene(levelName);
    }
}
