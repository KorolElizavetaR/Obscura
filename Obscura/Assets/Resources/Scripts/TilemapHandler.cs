using NUnit.Framework;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TilemapHandler : MonoBehaviour {
    [SerializeField] private Grid Grid;
    [SerializeField] private List<ObjectBehavior> objects;
    private GameObject playerBegginingPosition;

    public void Awake() {
        playerBegginingPosition = GameObject.FindGameObjectWithTag("Respawn");
        Debug.Log($"[TilemapHandler] playerBegginingPosition: {playerBegginingPosition}");

        Grid = GetComponent<Grid>();

        foreach (var obj in objects) {
            obj._tilemapHandler = this;
        }
        Debug.Log($"[TilemapHandler] Awake");
    }

    public Vector3Int getCellFromCoords(Vector3 objCoord) {
        return Grid.WorldToCell(objCoord);
    }
    public Vector3 getCoordFromCell(Vector3Int objCell) {
        return Grid.GetCellCenterWorld(objCell);
    }

    public Vector3Int getInitialPlayerPosition() {
        return Grid.WorldToCell(playerBegginingPosition.transform.position);
    }

   
    public void triggerTileEvent(Vector3Int currentCell, Vector3Int nextCell) {
        ObjectBehavior objBehCurrent = getObjectBeh(currentCell);
        ObjectBehavior objBehNext = getObjectBeh(nextCell);
        
        if (objBehCurrent != null) {
            objBehCurrent.OnEvent(objBehNext);
        }
        if (objBehNext != null) { 
            objBehNext.OnEvent(); 
        };
    }

    public bool isCollision(Vector3Int cell) {
        ObjectBehavior objBeh = getObjectBeh(cell);
        return objBeh != null 
            ? objBeh.objectProperty.IsCollision 
            : false;
    }

    private ObjectBehavior getObjectBeh(Vector3Int currentCell) {
        foreach (ObjectBehavior tile in objects) {
            if (tile.CheckIsCurrentObject(currentCell)) {
                return tile;
            }
        }
        return null;
    }

}