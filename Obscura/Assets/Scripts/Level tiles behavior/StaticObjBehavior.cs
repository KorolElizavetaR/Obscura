using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class StaticObjBehavior : ObjectBehavior {

    protected Tilemap currentTilemap;

    private void Start() {
        currentTilemap = GetComponent<Tilemap>();
    }
    
    override public bool CheckIsCurrentObject (Vector3Int currentTile) {
        return currentTilemap.HasTile(currentTile);
    }

}
