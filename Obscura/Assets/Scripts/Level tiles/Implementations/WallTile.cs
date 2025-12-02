using UnityEngine;

public class WallTile : StaticTile {
    private void Awake() {
        objectProperty.IsCollision = true;
    }
    public override void OnEvent() {
        return;
    }

    public override void OnEvent(AbstractTile nextCell) {
        return;
    }

}
