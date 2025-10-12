using UnityEngine;

public class TilePropertyModel {
    public TilePropertyModel(bool isCollision, bool isDeadly) {
        IsCollision = isCollision;
        IsDeadly = isDeadly;
    }

    public TilePropertyModel() {
        IsCollision = false;
        IsDeadly = false;
    }

    [SerializeField] public bool IsCollision { get; set; }
    [SerializeField] public bool IsDeadly { get; set; }

    public static TilePropertyModel baseProperty = new TilePropertyModel(false, false);
}
