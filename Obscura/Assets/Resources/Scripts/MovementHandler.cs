using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    public static TilemapHandler tilemapHandler;

    private Vector3Int currentCell;
    private Vector3Int targetCell;
    public Vector3Int _moveDir { get ; set; }

    void Start()
    {
        currentCell = tilemapHandler.getInitialPlayerPosition();
        targetCell = currentCell;
        transform.position = tilemapHandler.Grid.GetCellCenterWorld(currentCell);
    }

    /// <summary>
    /// ���������, ����� �� ������ ��������� ������
    /// </summary>
    /// <returns>
    /// <para><c>true</c> - ���� ������ ����� ��������� ������</para>
    /// <para><c>false</c> - ���� ������ ���������������</para>
    /// </returns>
    public bool move () {
        Vector3 targetPos = tilemapHandler.Grid.GetCellCenterWorld(targetCell);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (Mathf.Approximately(Vector3.Distance(transform.position, targetPos), 0f)) {
            transform.position = targetPos;
            currentCell = targetCell;
            TryMoveToNextCell();
            if (currentCell == targetCell) {
                //canMove = true;
                _moveDir = Vector3Int.zero;
                return false;
            }
        }
        return true;
    }

    private void TryMoveToNextCell() {
        Vector3Int nextCell = currentCell + new Vector3Int(_moveDir.x, _moveDir.y, 0);
        TilePropertyModel tileProp = tilemapHandler.checkTileEvent(nextCell); // �������� ������� ��������� ������.

        if (!tileProp.IsCollision) // ���� ������ �� �����
        {
            targetCell = nextCell;
        }
    }
}
