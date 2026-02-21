using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TilemapHandler : MonoBehaviour, ILogDistributor {
    public string DistributorName => GetType().Name;

    [SerializeField] private Grid Grid;
    [SerializeField] private List<AbstractTile> objects;

    private Vector3 playerBegginingPosition;
    
    public Vector3 PlayerBeginningPosition => playerBegginingPosition;
    

    public void Awake() {
        playerBegginingPosition = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        this.Log($"playerBegginingPosition: {playerBegginingPosition}");

        Grid = GetComponent<Grid>();

        foreach (AbstractTile obj in objects) {
            obj._tilemapHandler = this;
        }
        
        this.Log("Awake end");
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

    public void triggerTileEvent(Vector3Int currentCell, Vector3Int nextCell, GameObject obj) {
        this.Log("enter");
        AbstractTile objBehCurrent = getObjectBeh(currentCell);
        this.Log($"objBehCurrent: {objBehCurrent}");
        AbstractTile objBehNext = getObjectBeh(nextCell);


        if (objBehCurrent != null) {
            this.Log($"objBehNext: {objBehNext}");
            objBehCurrent.OnEvent(objBehNext, obj);
        }
        if (objBehNext != null) {
            this.Log($"this.gameObject: {obj}");
            objBehNext.OnEvent(obj); 
        };

        // List<AbstractTile> objsBehCurrent = getObjectBehList(currentCell);
        // List<AbstractTile> objsBehNext = getObjectBehList(nextCell);
        //
        // foreach (var objBehCurrent in objsBehCurrent.Where(x => x != null)) {
        //     objBehCurrent.OnEvent(obj);
        // }
        //
        // foreach (var objBehNext in objsBehNext.Where(x => x != null)) {
        //     objBehNext.OnEvent(obj);
        // }
    }

    public bool isCollisionList(Vector3Int cell) {
        List<AbstractTile> objBeh = getObjectBehList(cell);
        foreach (AbstractTile obj in objBeh) {
            if (isCollision(obj))
                return true;
        }
        return false;
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
        return objects
            .Where(t => t.CheckIsCurrentObject(currentCell))
            .OrderByDescending(t => t is DynamicTile)
            .FirstOrDefault();
    }

    private List<AbstractTile> getObjectBehList(Vector3Int currentCell) {
        return objects
            .Where(t => t.CheckIsCurrentObject(currentCell))
            .OrderByDescending(t => t is DynamicTile)
            .ToList();
    }
}