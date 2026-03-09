using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionButton : MonoBehaviour, ILogDistributor
{
    public string DistributorName => GetType().Name;
    
    [SerializeField] private Image levelImage;
    [SerializeField] private LevelStat levelData;

    [SerializeField] ModalLevelSelection modalLevelSelection;

    public Image LevelImage => levelImage;

    public void setSelectedLevelToPrefs() {
        PlayerPrefs.SetInt("level", levelData.levelIndex);
        if (modalLevelSelection is null) {
            this.LogError("modalLevelSelection is null");
        }

        modalLevelSelection.onClickOpenModal();
    }

    public int LevelIndex => levelData.levelIndex;
    public bool Available => levelData.isAvailable;

    [System.Serializable]
    public class LevelStat {
        public int levelIndex;
        public bool isAvailable;
    }
}
