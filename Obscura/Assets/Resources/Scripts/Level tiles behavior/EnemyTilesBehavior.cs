using System.Collections;
using UnityEngine;

public class EnemyTilesBehavior : TilesBehavior {
    public EnemyTilesBehavior() {
        base.state = new State();
        state.SetCollision(true);
        state.SetDeadly(true);
    }   

    override public State onEvent() {
        Debug.Log($"u ded in 1 sec");
        StartCoroutine(ShowDeathWindow());
        return base.onEvent();
    }

    public IEnumerator ShowDeathWindow() {
        yield return null; // Pause for one frame (in Unity)
        Debug.Log("Show death window");
    }
}
