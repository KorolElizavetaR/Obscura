
using UnityEngine;

public abstract class AbstractTile: MonoBehaviour {
    public TilemapHandler _tilemapHandler;
    public TileProperty objectProperty { get; set; } = new TileProperty();
    
    public abstract bool CheckIsCurrentObject(Vector3Int cellPos);
    public abstract void OnThisNextEvent(GameObject trigger);
    public abstract void OnThisCurrentEvent(AbstractTile nextCell, GameObject trigger);
}