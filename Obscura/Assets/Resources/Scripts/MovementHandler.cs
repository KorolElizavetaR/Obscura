using System;
using UnityEngine;

public class MovementHandler : MonoBehaviour {
    [SerializeField] private float moveSpeed = 10f;
    public static TilemapHandler tilemapHandler;

    private Vector3Int currentCell;
    private Vector3Int targetCell;
    public Vector3Int _moveDir { get; set; }

    private bool isPlayer;

    void Start() {
        isPlayer = TryGetComponent<Player>(out Player playerComponent);
        Debug.Log($"[MovementHandler] playerComponent: {playerComponent}");
        currentCell = isPlayer 
            ? tilemapHandler.getInitialPlayerPosition()
            : tilemapHandler.getCellFromCoords(transform.position);
        Debug.Log($"[MovementHandler] currentCell: {currentCell}");
        targetCell = currentCell;
        transform.position = tilemapHandler.getCoordFromCell(currentCell);
    }

    /// <summary>
    /// ��������� �����������, ����� ���� ���������, ����� �� ������ ��������� ������.
    /// </summary>
    /// <returns>
    /// <para><c>true</c> - ���� ������ ����� ��������� ������</para>
    /// <para><c>false</c> - ���� ������ ���������������</para>
    /// </returns>
    public bool move() {
        Vector3 targetPos = tilemapHandler.getCoordFromCell(targetCell);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        /// ������, ��� �� �������� ������ ������.
        if (Mathf.Approximately(Vector3.Distance(transform.position, targetPos), 0f)) {
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

    private void TryMoveToNextCell() {
        Debug.Log($"movedir: {_moveDir}");
        Vector3Int nextCell = currentCell + new Vector3Int(_moveDir.x, _moveDir.y, 0);

        //bool collision = tilemapHandler.isCollision(nextCell);

        if (isPlayer) {
            tilemapHandler.triggerTileEvent(currentCell, nextCell);
        }

        bool collision = tilemapHandler.isCollision(nextCell);

        if (!collision) // ���� ������ �� �����
        {
            targetCell = nextCell;
        }
    }

}
