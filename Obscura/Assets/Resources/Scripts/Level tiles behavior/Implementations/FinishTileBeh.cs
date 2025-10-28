using UnityEngine;
using System.Collections;

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
        }
    }

    public IEnumerator ShowWinWindow() {
        yield return new WaitForSeconds(1);
        Debug.Log("Show win window");
        //winWindow.SetActive(true);
    }
}
