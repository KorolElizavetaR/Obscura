using UnityEngine;

public class ObstacleTileBeh : TilesBehavior {
    public ObstacleTileBeh() {
        state = new State();
        state.SetCollision(true);
        state.SetDeadly(false);
    }
}
