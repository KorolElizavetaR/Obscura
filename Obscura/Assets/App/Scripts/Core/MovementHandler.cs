using System;
using UnityEngine;

public class MovementHandler : MonoBehaviour {
    [SerializeField] 
    private float moveSpeed = 10f;
    public static TilemapHandler tilemapHandler;


    private Vector3Int currentCell;

    public Vector3Int CurrentCell { get => currentCell; set => currentCell = value; }

    private Vector3Int targetCell;
    public Vector3Int TargetCell { get => targetCell; set => targetCell = value; }
    public Vector3Int _moveDir { get; set; }

    public bool canMove;

    void Start() {
        Vector3 initialCoords = transform.position;
        Debug.Log($"[MovementHandler] initialCoords: {initialCoords}");
        Debug.Log($"[MovementHandler] tilemapHandler: {tilemapHandler}");
        currentCell = tilemapHandler.getCellFromCoords(initialCoords);
        targetCell = currentCell;
        Debug.Log($"[MovementHandler] currentCell: {currentCell}");
        //targetCell = currentCell;
        transform.position = tilemapHandler.getCoordFromCell(currentCell);
    }

    /// <summary>
    /// Совершает перемещение, после чего проверяет, будет ли объект двигаться дальше.
    /// </summary>
    /// <returns>
    /// <para><c>true</c> - если объект будет двигаться дальше</para>
    /// <para><c>false</c> - если объект останавливается</para>
    /// </returns>
    public bool move() {
        //if (_moveDir == Vector3Int.zero) return false;

        Vector3 targetPos = tilemapHandler.getCoordFromCell(targetCell);
        //Debug.Log($"[MovementHandler] currentCell: {currentCell}");
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        /// значит, что мы достигли нужной клетки.
        if (Mathf.Approximately(Vector3.Distance(transform.position, targetPos), 0f)) {
            //Debug.Log($"next sell");
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
        // Debug.Log($"movedir: {_moveDir}");
        Vector3Int nextCell = GetNextCell();

        //bool collision = tilemapHandler.isCollision(nextCell);

        Debug.Log($"tilemapHandler: {tilemapHandler}");
        Debug.Log($"currentCell: {currentCell}");
        Debug.Log($"nextCell: {nextCell}");
        tilemapHandler.triggerTileEvent(currentCell, nextCell, this.gameObject);
        bool collision = tilemapHandler.isCollision(nextCell);

        if (!collision) // если клетка не стена
        {
            targetCell = nextCell;
        }
    }

    public Vector3Int GetNextCell() {
        return currentCell + new Vector3Int(_moveDir.x, _moveDir.y, 0);
    }
}
