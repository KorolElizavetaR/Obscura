using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FinishTileBeh : StaticObjBehavior {

    //[SerializeField] private GameObject winWindow;

    private void Awake() {
        objectProperty.IsCollision = false;
    }

    public override void OnEvent() {
        return;
    }

    public override void OnEvent(ObjectBehavior nextCell) {
        //ObjectProperty nextCellProperty = nextCell.objectProperty;

        bool nextCellCollision = _tilemapHandler.isCollision(nextCell);

        if (nextCellCollision) {
            StartCoroutine(ShowWinWindow());

            int currentLevel = PlayerPrefs.GetInt("level");

            string jsonData = PlayerPrefs.GetString("levels", string.Empty);
            var completedLevels = string.IsNullOrEmpty(jsonData)
                ? new HashSet<int>()
                : JsonFormatter.FromJson<HashSet<int>>(jsonData);

            completedLevels.Add(currentLevel);

            Debug.Log($"F completedLevels: {completedLevels.Count}");

            jsonData = JsonFormatter.ToJson(completedLevels);
            PlayerPrefs.SetString("levels", jsonData);
        }
    }

    public IEnumerator ShowWinWindow() {
        yield return new WaitForSeconds(1);
        Debug.Log("Show win window");
        //winWindow.SetActive(true);
    }
}
