using NUnit.Framework;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TilemapHandler : MonoBehaviour {
    [SerializeField] private Grid Grid;
    [SerializeField] private List<AbstractTile> objects;

    private Vector3 playerBegginingPosition;
    public Vector3 PlayerBeginningPosition => playerBegginingPosition;


    //private Player player;

    public void Awake() {
        playerBegginingPosition = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        Debug.Log($"[TilemapHandler] playerBegginingPosition: {playerBegginingPosition}");

        Grid = GetComponent<Grid>();

        foreach (AbstractTile obj in objects) {
            obj._tilemapHandler = this;
        }
        Debug.Log($"[TilemapHandler] Awake");
    }

    //void Start() {
    //    //bool isPlayer = TryGetComponent<Player>(out Player playerComponent);
    //    Player player = GameObject.FindFirstObjectByType<Player>();

    //    if (!player) {
    //        Debug.Log($"[TilemapHandler] Player component found!");
    //        player.transform.position = playerBegginingPosition.transform.position;
    //    } else {
    //        Debug.LogError($"[TilemapHandler] Player component is not found!");
    //    }
    //}

    public Vector3Int getCellFromCoords(Vector3 objCoord) {
        return Grid.WorldToCell(objCoord);
    }
    public Vector3 getCoordFromCell(Vector3Int objCell) {
        return Grid.GetCellCenterWorld(objCell);
    }

    //public Vector3Int getInitialPlayerPosition() {
    //    return Grid.WorldToCell(playerBegginingPosition.transform.position);
    //}


    public void triggerTileEvent(Vector3Int currentCell, Vector3Int nextCell) {
        AbstractTile objBehCurrent = getObjectBeh(currentCell);
        AbstractTile objBehNext = getObjectBeh(nextCell);
        
        if (objBehCurrent != null) {
            objBehCurrent.OnEvent(objBehNext);
        }
        if (objBehNext != null) { 
            objBehNext.OnEvent(); 
        };
    }

    public bool isCollision(Vector3Int cell) {
        AbstractTile objBeh = getObjectBeh(cell);
        return isCollision(objBeh);
    }

    public virtual bool isCollision(AbstractTile objBeh) {
        return objBeh != null
            ? objBeh.objectProperty.IsCollision
            : false;
    }

    private AbstractTile getObjectBeh(Vector3Int currentCell) {
        foreach (AbstractTile tile in objects) {
            if (tile.CheckIsCurrentObject(currentCell)) {
                return tile;
            }
        }
        return null;
    }

}