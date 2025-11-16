using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField] private Image levelImage;
    [SerializeField] private LevelStat levelData;

    public Image LevelImage => levelImage;
    public void IconLevelRepresentation() {

    }

    public void setSelectedLevelToPrefs() {
        PlayerPrefs.SetInt("level", levelData.levelIndex);
        SceneManager.LoadScene("game_scene");
    }

    public int LevelIndex => levelData.levelIndex;
    public bool Available => levelData.isAvailable;

    [System.Serializable]
    public class LevelStat {
        public int levelIndex;
        public bool isAvailable;
    }
}
