using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class EnemyTilesBehavior : TilesBehavior {

    private void Awake() {
        tileProperty.IsCollision = true;
        tileProperty.IsDeadly  = true;
    }

    override public ObjectProperty OnEvent() {
        Debug.Log($"u ded in 1 sec");
        StartCoroutine(ShowDeathWindow());
        return tileProperty;
    }

    public IEnumerator ShowDeathWindow() {
        yield return null; // Pause for one frame (in Unity)
        Debug.Log("Show death window");
    }
}
