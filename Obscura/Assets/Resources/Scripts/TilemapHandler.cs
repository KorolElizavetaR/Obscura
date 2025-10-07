using NUnit.Framework;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TilemapHandler : MonoBehaviour
{
    [SerializeField]  private Grid grid;

    //[SerializeField] private Tilemap levelCollisionTilemap;
    //[SerializeField] private Tilemap finishTilemap;
    [SerializeField] private List <TilesBehavior> tiles;

    public Grid Grid => grid;

    private void Start() {
        //grid = GetComponent<Grid>();
    }

    public bool checkTileForCollision(Vector3Int currentTile) {
        //if (levelCollisionTilemap.HasTile(currentTile)) {
        //    return true;
        //} else if (finishTilemap.HasTile(currentTile)) {
        //    return false;
        //}

        foreach (TilesBehavior tile in tiles) {
            if (tile.checkEventTrigger(currentTile)) {
                TilesBehavior.State state = tile.onEvent();
                Debug.Log($"Obtained state");
                return state.GetCollision();
            }
        }

        return false;
    }
}