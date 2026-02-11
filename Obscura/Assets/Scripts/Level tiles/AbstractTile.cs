
using UnityEngine;

public abstract class AbstractTile: MonoBehaviour {

    public TilemapHandler _tilemapHandler;

    public TileProperty objectProperty { get; set; } = new TileProperty();
    public abstract bool CheckIsCurrentObject(Vector3Int cellPos);
    abstract public void OnEvent(GameObject trigger);
    abstract public void OnEvent(AbstractTile nextCell);
}