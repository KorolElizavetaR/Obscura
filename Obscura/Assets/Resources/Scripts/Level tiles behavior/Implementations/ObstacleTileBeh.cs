using UnityEngine;

public class ObstacleTileBeh : StaticObjBehavior {
    private void Awake() {
        objectProperty.IsCollision = true;
    }
    public override void OnEvent() {
        return;
    }

    public override void OnEvent(ObjectBehavior nextCell) {
        return;
    }

}
