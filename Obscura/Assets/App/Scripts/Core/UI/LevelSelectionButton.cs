using System;
using App.Scripts.Core.Storage;
using App.Scripts.Core.Storage.Entities;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionButton : MonoBehaviour, ILogDistributor
{
    public string DistributorName => GetType().Name;
    
    [SerializeField] private Image levelImage;
    [SerializeField] private LevelStat levelData;

    [SerializeField] ModalLevelSelection modalLevelSelection;

    private Level levelEntity;
    
    public Image LevelImage => levelImage;

    private void Awake()
    {
        EntitiesStorage.Instance.TryGet(out levelEntity);
    }

    public void setSelectedLevelToPrefs() {
        if (levelEntity is not null)
        {
            levelEntity.Id = levelData.levelIndex;
        }
        
        if (modalLevelSelection is null) {
            this.LogError("modalLevelSelection is null");
            return;
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
