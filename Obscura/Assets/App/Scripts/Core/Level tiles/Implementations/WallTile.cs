using UnityEngine;

public class WallTile : StaticTile {
    protected override void Awake() {
        base.Awake();
        objectProperty.IsCollision = true;
    }
    public override void OnThisNextEvent(GameObject trigger) {
        return;
    }

    public override void OnThisCurrentEvent(AbstractTile nextCell, GameObject trigger) {
        return;
    }

}
