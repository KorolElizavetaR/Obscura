using UnityEngine;

public class ObjectProperty {
    public ObjectProperty(bool isCollision) {
        IsCollision = isCollision;
    }

    public ObjectProperty() {
        IsCollision = false;
    }

    [SerializeField] public bool IsCollision { get; set; }

    public static ObjectProperty emptyTileProperty = new ObjectProperty(false);

    public override string ToString() {
        return $"IsCollision = {IsCollision}";
    }
}
