using UnityEngine;

public class WallTile : StaticTile {
    protected override void Awake() {
        base.Awake();
        objectProperty.IsCollision = true;
    }
    public override void OnEvent(GameObject trigger) {
        return;
    }

    public override void OnEvent(AbstractTile nextCell, GameObject trigger) {
        return;
    }

}
