using System;
using App.Scripts.Core.Storage;
using App.Scripts.Core.Storage.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleModalButtonsEvents : MonoBehaviour, ILogDistributor {
    public string DistributorName => GetType().Name;

    private Levels _levelsEntity;

    protected virtual void Awake()
    {
        EntitiesStorage.Instance.TryGet(out _levelsEntity);
    }

    public void resetProgress() {
        _levelsEntity.CompletedLevels.Clear();
        this.Log("Levels data erased");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loadNextLevel() {
        if (_levelsEntity.CurrentLevelId.Equals(_levelsEntity.MaxLevelId))
        {
            this.Log("Now max level");
            return;
        }

        _levelsEntity.CurrentLevelId++;
        SceneManager.LoadScene("game_scene");
    }

    public void reloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
