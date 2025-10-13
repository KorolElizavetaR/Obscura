using UnityEngine;
using System.Collections;

public class FinishTileBeh : TilesBehavior {

    [SerializeField] private GameObject winWindow;

    private void Awake() {
        tileProperty.IsDeadly = false;
        tileProperty.IsCollision = false;
    }

    public override ObjectProperty OnEvent() {
        StartCoroutine(ShowWinWindow());
        return base.OnEvent();
    }

    public IEnumerator ShowWinWindow() {
        yield return new WaitForSeconds(1); // Pause for one frame (in Unity)
        Debug.Log("Show win window");
        winWindow.SetActive(true);
    }
}
