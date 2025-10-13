using UnityEngine;

public class ObjectProperty {
    public ObjectProperty(bool isCollision, bool isDeadly) {
        IsCollision = isCollision;
        IsDeadly = isDeadly;
    }

    public ObjectProperty() {
        IsCollision = false;
        IsDeadly = false;
    }

    [SerializeField] public bool IsCollision { get; set; }
    [SerializeField] public bool IsDeadly { get; set; }

    public static ObjectProperty baseProperty = new ObjectProperty(false, false);
}
