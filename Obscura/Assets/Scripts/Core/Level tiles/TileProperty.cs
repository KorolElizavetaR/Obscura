using UnityEngine;

public class TileProperty {
    public TileProperty(bool isCollision) {
        IsCollision = isCollision;
    }

    public TileProperty() {
        IsCollision = false;
    }

    [SerializeField] public bool IsCollision { get; set; }

    public static TileProperty emptyTileProperty = new TileProperty(false);

    public override string ToString() {
        return $"IsCollision = {IsCollision}";
    }
}
