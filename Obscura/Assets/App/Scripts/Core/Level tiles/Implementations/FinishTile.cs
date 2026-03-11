using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Core.Storage;
using App.Scripts.Core.Storage.Entities;
using Unity.VisualScripting;

public class FinishTile : StaticTile {
    public PopupAnimation winWindow;

    private Levels _levelsEntity;

    protected override void Awake() {
        base.Awake();
        objectProperty.IsCollision = false;
        
        EntitiesStorage.Instance.TryGet(out _levelsEntity);
    }

    public override void OnThisNextEvent(GameObject trigger) {
        return;
    }

    public override void OnThisCurrentEvent(AbstractTile nextCell, GameObject trigger) {
        //ObjectProperty nextCellProperty = nextCell.objectProperty;

        if (nextCell == null || !trigger.CompareTag("Player"))
        {
            return;
        }

        bool nextCellCollision = _tilemapHandler.IsCollision(nextCell);

        if (nextCellCollision) {
            //StartCoroutine(ShowWinWindow());
            _levelsEntity.CompletedLevels.Add(_levelsEntity.CurrentLevelId);
            
            this.Log($"F completedLevels: {string.Join(", ", _levelsEntity.CompletedLevels.Select(x => x.ToString()))}");

            Player.State.IsWin = true;
            
            ShowWinWindow();
        }
    }

    public void ShowWinWindow() {

        winWindow.onOpenModalSlide();
    }
}
