using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class FinishTile : StaticTile {
    public PopupAnimation winWindow;

    protected override void Awake() {
        base.Awake();
        objectProperty.IsCollision = false;
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

            int currentLevel = PlayerPrefs.GetInt("level");

            string jsonData = PlayerPrefs.GetString("levels", string.Empty);
            var completedLevels = string.IsNullOrEmpty(jsonData)
                ? new HashSet<int>()
                : JsonFormatter.FromJson<HashSet<int>>(jsonData);

            completedLevels.Add(currentLevel);

            this.Log($"F completedLevels: {completedLevels.Count}");

            jsonData = JsonFormatter.ToJson(completedLevels);
            PlayerPrefs.SetString("levels", jsonData);

            Player.State.IsWin = true;
            

            ShowWinWindow();
        }
    }

    public void ShowWinWindow() {

        winWindow.onOpenModalSlide();
    }
}
