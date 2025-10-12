using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class PlayerMovementBySteps : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.5f;
    public TilemapHandler tilemapHandler;

    private Vector3Int currentCell;
    private Vector3Int targetCell;
    private Vector3Int moveDir;
    public Vector3Int getMovementDir => moveDir;

    private bool canMove;

    private void Start() {
        if (tilemapHandler == null) {
            Debug.LogError("TilemapHandler is not assigned in the Inspector!");
            return;
        }
        currentCell = tilemapHandler.getInitialPlayerPosition();
        targetCell = currentCell;
        transform.position = tilemapHandler.Grid.GetCellCenterWorld(currentCell);
    }

    private void Update() {
        if (canMove) {
            ProcessInput();
        }
        else {
            MoveTowardsTarget();
        }
    }

    private void ProcessInput() {
        float movementOffsetX = Input.GetAxisRaw("Horizontal");
        float movementOffsetY = Input.GetAxisRaw("Vertical");

        if (!Mathf.Approximately(movementOffsetX, 0f) || !Mathf.Approximately(movementOffsetY, 0f)) {

            canMove = false;

            moveDir = Mathf.Abs(movementOffsetX) > Mathf.Abs(movementOffsetY)
                ? new Vector3Int(Mathf.RoundToInt(movementOffsetX), 0, 0)
                : new Vector3Int(0, Mathf.RoundToInt(movementOffsetY), 0);
        }
    }

    private void MoveTowardsTarget() {
        Vector3 targetPos = tilemapHandler.Grid.GetCellCenterWorld(targetCell);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (Mathf.Approximately(Vector3.Distance(transform.position, targetPos), 0f)  ) {
            transform.position = targetPos;
            currentCell = targetCell;
            TryMoveToNextCell();
            if (currentCell == targetCell) {
                canMove = true;
                moveDir = Vector3Int.zero;
            }
        }
    }

    private void TryMoveToNextCell() {
        Vector3Int nextCell = currentCell + new Vector3Int(moveDir.x, moveDir.y, 0);
        TilePropertyModel tileProp = tilemapHandler.checkTileEvent(nextCell); // Проверка события следующей клетки.

        if (!tileProp.IsCollision) // если клетка не стена
        {
            targetCell = nextCell;
        }
    }
}
