using System.Collections;
using UnityEngine;

public class SpikeTile : StaticTile {
    public PopupAnimation failWindow;

    protected override void Awake() {
        base.Awake();
        objectProperty.IsCollision = true;        
    }
    override public void OnEvent(GameObject trigger) {

        if (trigger.TryGetComponent<Player>(out var player)) {
            Player.State.IsDead = true;
            Debug.Log($"u ded in 1 sec");
            StartCoroutine(ShowDeathWindow());
        }

    }
    public override void OnEvent(AbstractTile nextCell) {
        throw new System.NotImplementedException("Shouldn't be here");
    }

    public IEnumerator ShowDeathWindow() {
        yield return null; // Pause for one frame (in Unity)
        Debug.Log("Show death window");
        failWindow.onOpenModalSlide();
    }
}
