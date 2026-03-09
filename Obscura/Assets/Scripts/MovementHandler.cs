using UnityEngine;

public class MovementHandler : MonoBehaviour, ILogDistributor {
    public static TilemapHandler tilemapHandler;
    public string DistributorName => GetType().Name;

    [SerializeField] private float moveSpeed = 10f;
    
    private Vector3Int currentCell;
    public Vector3Int CurrentCell { get => currentCell; set => currentCell = value; }

    private Vector3Int targetCell;
    public Vector3Int TargetCell { get => targetCell; set => targetCell = value; }
    
    public Vector3Int _moveDir { get; set; }

    public bool canMove;

    void Start() {
        Vector3 initialCoords = transform.position;
        this.Log($"initialCoords: {initialCoords}");
        this.Log($"tilemapHandler: {tilemapHandler}");
        
        currentCell = tilemapHandler.getCellFromCoords(initialCoords);
        targetCell = currentCell;
        
        this.Log($"currentCell: {currentCell}");
        transform.position = tilemapHandler.getCoordFromCell(currentCell);
    }

    public bool move() {
        //if (_moveDir == Vector3Int.zero) return false;
        
        Vector3 targetPos = tilemapHandler.getCoordFromCell(targetCell);
        //this.Log($"currentCell: {currentCell}");
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (Mathf.Approximately(Vector3.Distance(transform.position, targetPos), 0f)) {
            //this.Log($"next sell");
            transform.position = targetPos;
            currentCell = targetCell;
            TryMoveToNextCell();
            if (currentCell == targetCell) {
                _moveDir = Vector3Int.zero;
                return false;
            }
        }
        return true;
    }

    public void TryMoveToNextCell() {
        // this.Log($"movedir: {_moveDir}");
        Vector3Int nextCell = GetNextCell();
        
        //bool collision = tilemapHandler.isCollision(nextCell);

        this.Log($"tilemapHandler: {tilemapHandler}");
        this.Log($"currentCell: {currentCell}");
        this.Log($"nextCell: {nextCell}");
        tilemapHandler.triggerTileEvent(currentCell, nextCell, this.gameObject);
        bool collision = tilemapHandler.IsCollision(nextCell);

        if (!collision)
        {
            targetCell = nextCell;
        }
    }

    public Vector3Int GetNextCell() {
        return currentCell + new Vector3Int(_moveDir.x, _moveDir.y, 0);
    }
}
