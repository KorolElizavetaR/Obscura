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
        List<AbstractTile> objBehCurrent = GetObjectBeh(currentCell);
        List<AbstractTile> objBehNext = GetObjectBeh(nextCell);
        
        objBehCurrent.ForEach(x => x.OnThisCurrentEvents(objBehNext, obj));
        objBehNext.ForEach(x => x.OnThisNextEvent(obj));
        
        this.Log($"Triggered events for {obj.name}, current: {string.Join(", ", objBehCurrent.Select(x => x.name))}, " +
                 $"next: {string.Join(", ", objBehNext.Select(x => x.name))}");
    }
    
    public bool IsCollision(Vector3Int cell) {        
        List<AbstractTile> objBeh = GetObjectBeh(cell);
        
        return objBeh.Any(IsCollision);
    }

    public virtual bool IsCollision(AbstractTile objBeh) {
        return objBeh.objectProperty.IsCollision;
    }
   
    private List<AbstractTile> GetObjectBeh(Vector3Int currentCell) {
        return objects
            .Where(x => x != null)
            .Where(t => t.CheckIsCurrentObject(currentCell))
            .ToList();
    }
}