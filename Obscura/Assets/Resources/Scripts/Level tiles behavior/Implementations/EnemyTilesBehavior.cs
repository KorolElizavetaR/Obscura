using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Playables;

public class EnemyTilesBehavior : StaticObjBehavior {

    private void Awake() {
        objectProperty.IsCollision = true;

        
    }

    override public void OnEvent() {
        Player.State.IsDead = true;

        Debug.Log($"u ded in 1 sec");
        StartCoroutine(ShowDeathWindow());
    }
    public override void OnEvent(ObjectBehavior nextCell) {
        throw new System.NotImplementedException("Shouldn't be here");
    }

    public IEnumerator ShowDeathWindow() {
        yield return null; // Pause for one frame (in Unity)
        Debug.Log("Show death window");

    }
}
