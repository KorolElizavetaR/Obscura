using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class StaticTile : AbstractTile {

    protected Tilemap currentTilemap;

    private void Start() {
        currentTilemap = GetComponent<Tilemap>();
    }
    
    override public bool CheckIsCurrentObject (Vector3Int currentTile) {
        return currentTilemap.HasTile(currentTile);
    }

}
