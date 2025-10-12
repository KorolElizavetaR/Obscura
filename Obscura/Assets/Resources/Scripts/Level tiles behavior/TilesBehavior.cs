using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesBehavior : MonoBehaviour {
    public TilePropertyModel tileProperty = new TilePropertyModel();

    protected Tilemap currentTilemap;

    private void Start() {
        currentTilemap = GetComponent<Tilemap>();
    }

    virtual public TilePropertyModel onEvent() {
        return tileProperty;
    }
    
    public bool checkEventTrigger (Vector3Int currentTile) {
        return currentTilemap.HasTile(currentTile);
    }

}
