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

    public override void OnEvent(GameObject trigger) {
        return;
    }

    public override void OnEvent(AbstractTile nextCell) {
        //ObjectProperty nextCellProperty = nextCell.objectProperty;

        bool nextCellCollision = _tilemapHandler.isCollision(nextCell);

        if (nextCellCollision) {
            //StartCoroutine(ShowWinWindow());

            int currentLevel = PlayerPrefs.GetInt("level");

            string jsonData = PlayerPrefs.GetString("levels", string.Empty);
            var completedLevels = string.IsNullOrEmpty(jsonData)
                ? new HashSet<int>()
                : JsonFormatter.FromJson<HashSet<int>>(jsonData);

            completedLevels.Add(currentLevel);

            Debug.Log($"F completedLevels: {completedLevels.Count}");

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
