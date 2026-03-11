using System.Collections;
using UnityEngine;

public class SpikeTile : StaticTile {
    public PopupAnimation failWindow;

    protected override void Awake() {
        base.Awake();
        objectProperty.IsCollision = true;        
    }
    override public void OnThisNextEvent(GameObject trigger) {

        if (trigger.TryGetComponent<Player>(out var player)) {
            Player.State.IsDead = true;
            this.Log($"u ded in 1 sec");
            StartCoroutine(ShowDeathWindow());
        }

    }
    public override void OnThisCurrentEvent(AbstractTile nextCell, GameObject trigger) {
        throw new System.NotImplementedException("Shouldn't be here");
    }

    public IEnumerator ShowDeathWindow() {
        yield return null; // Pause for one frame (in Unity)
        this.Log("Show death window");
        failWindow.onOpenModalSlide();
    }
}
