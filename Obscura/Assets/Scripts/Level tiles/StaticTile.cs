using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class StaticTile : AbstractTile, ILogDistributor {
    public string DistributorName => GetType().Name;

    protected Tilemap currentTilemap;

    protected virtual void Awake() {
        currentTilemap = GetComponent<Tilemap>();
        //this.Log($"NIGER Awake tilemap {gameObject.name}, tilemap is null: {currentTilemap is null}");
    }


    override public bool CheckIsCurrentObject (Vector3Int currentTile) {
        //this.Log($"TRAMP tilemap {gameObject.name}, tilemap is null: {currentTilemap is null}");
        return currentTilemap.HasTile(currentTile);
    }

}
