using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class DynamicTile : AbstractTile {
    public override bool CheckIsCurrentObject(Vector3Int cellPos) {
        return cellPos == _tilemapHandler.getCellFromCoords(transform.position);
    }

}
