using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class StaticTile : AbstractTile {

    protected Tilemap currentTilemap;

    protected virtual void Awake() {
        currentTilemap = GetComponent<Tilemap>();
        //Debug.Log($"NIGER Awake tilemap {gameObject.name}, tilemap is null: {currentTilemap is null}");
    }


    override public bool CheckIsCurrentObject (Vector3Int currentTile) {
        //Debug.Log($"TRAMP tilemap {gameObject.name}, tilemap is null: {currentTilemap is null}");
        return currentTilemap.HasTile(currentTile);
    }

}
