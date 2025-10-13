using UnityEngine;

public class ObstacleTileBeh : TilesBehavior {
    private void Awake() {
        tileProperty.IsDeadly = false;
        tileProperty.IsCollision = true;
    }
}
