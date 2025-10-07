using UnityEngine;
using System.Collections;

public class FinishTileBeh : TilesBehavior {

    [SerializeField] private GameObject winWindow;

    public FinishTileBeh() {
        base.state = new State();
        state.SetCollision(false);
        state.SetDeadly(false);
    }

    public override State onEvent() {
        Debug.Log($"u win in 1 sec");
        StartCoroutine(ShowWinWindow());
        return base.onEvent();
    }

    public IEnumerator ShowWinWindow() {
        yield return new WaitForSeconds(1); // Pause for one frame (in Unity)
        Debug.Log("Show win window");
        winWindow.SetActive(true);
    }
}
