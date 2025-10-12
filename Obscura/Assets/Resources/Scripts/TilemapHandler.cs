using NUnit.Framework;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TilemapHandler : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private List <TilesBehavior> tiles;
    [SerializeField] private GameObject playerBegginingPosition;

    public Vector3Int getInitialPlayerPosition() {
        return Grid.WorldToCell(playerBegginingPosition.transform.position);
    }

    public Grid Grid => grid;

    public TilePropertyModel checkTileEvent(Vector3Int currentTile) {
        foreach (TilesBehavior tile in tiles) {
            if (tile is FinishTileBeh finishTileBeh) {

            }

            if (tile.checkEventTrigger(currentTile)) {
                TilePropertyModel state = tile.onEvent();
                return state;
            }
        }
        return TilePropertyModel.baseProperty;
    }
}