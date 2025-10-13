using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesBehavior : ObjectBehavior {

    protected Tilemap currentTilemap;

    private void Start() {
        currentTilemap = GetComponent<Tilemap>();
    }

    //override public ObjectProperty OnEvent() {
    //    return tileProperty;
    //}
    
    override public bool CheckIsCurrentObject (Vector3Int currentTile) {
        return currentTilemap.HasTile(currentTile);
    }

}
