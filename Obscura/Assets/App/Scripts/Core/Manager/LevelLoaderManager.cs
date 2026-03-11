using System.Collections.Generic;
using App.Scripts.Core.Storage;
using App.Scripts.Core.Storage.Entities;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class LevelLoaderManager : MonoBehaviour {

    [SerializeField] private List<GameObject> _levels;

    private GameObject currentLevel;
    private TilemapHandler currentTilemapHandler;
    private Levels _levelsEntity;

    [Header("Camera")]
    public Camera cam;
    public float horizontalPadding = 1f;
    public float verticalPadding = 1f;

    [SerializeField] private PopupAnimation winModal;
    [SerializeField] private PopupAnimation failWindow;

    [SerializeField]
    private Player player;

    private void Awake()
    {
        EntitiesStorage.Instance.TryGet(out _levelsEntity);
        
        currentLevel = Instantiate(_levels[_levelsEntity.CurrentLevelId]);
        currentTilemapHandler = currentLevel.GetComponent<TilemapHandler>();
        MovementHandler.tilemapHandler = currentTilemapHandler;
        SetupCamera();
        SetupPlayerPosition();
        initWinModal();
    }

    private void SetupCamera() {
        if (currentLevel is null) return;

        var bounds = currentLevel.GetComponentInChildren<MonoBounds>();
        if (bounds is null) return;

        cam ??= Camera.main;
        if (cam is null || !cam.orthographic) return;

        cam.transform.position = new Vector3(bounds.transform.position.x, bounds.transform.position.y, cam.transform.position.z);

        var aspect = (float)Screen.width / Screen.height;
        var requiredVertSize = (bounds.height / 2f) + verticalPadding;
        var requiredHorzSize = ((bounds.width / 2f) + horizontalPadding) / aspect;

        cam.orthographicSize = Mathf.Max(requiredVertSize, requiredHorzSize);
    }

    private void initWinModal() {
        FinishTile finishTileBeh = currentLevel.GetComponentInChildren<FinishTile>();
        if (finishTileBeh is not null) {
            finishTileBeh.winWindow = winModal;
        }
        SpikeTile enemyTilesBehavior = currentLevel.GetComponentInChildren<SpikeTile>();
        if (enemyTilesBehavior is not null) {
            enemyTilesBehavior.failWindow = failWindow;
        }
    }

    private void SetupPlayerPosition() {
        player.transform.position = currentTilemapHandler.PlayerBeginningPosition;
    }
}
