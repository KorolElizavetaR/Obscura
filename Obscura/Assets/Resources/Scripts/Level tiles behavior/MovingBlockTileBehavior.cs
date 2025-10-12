using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class MovingBlockTileBehavior : TilesBehavior {
    // � ��������� ������� ����������� ������� ������ � ���������... ������
    public TilemapHandler tilemapHandler;

    // ������ �� �������
    private PlayerMovementBySteps playerMovement;

    private Vector3Int currentCell;
    private Vector3Int targetCell;

    private void Awake() {
        tileProperty.IsCollision = true;
        tileProperty.IsDeadly = false;

        // Find player by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            playerMovement = player.GetComponent<PlayerMovementBySteps>();
        }

        currentCell = currentTilemap.WorldToCell(transform.position);
        targetCell = currentCell;
    }

    override public TilePropertyModel onEvent() {
        /**
         * 1. ����� ������� �������� ������
         * 2. ���� ��������� ������ ��� ����� ������� ����� ��������, ���������� ��������� = ���
         * 3. ���� ��������� ������ ��� ����� ����� �� ����� ��������, ��������� ������ � ������� �� ������ ������
         */
        Vector3Int playerMovementDirection = playerMovement.getMovementDir;
        Vector3Int nextCell = currentCell + new Vector3Int(playerMovementDirection.x, playerMovementDirection.y, 0);
        TilePropertyModel tileProp = tilemapHandler.checkTileEvent(nextCell);
        if (!tileProp.IsCollision) // ���� ������ �� �����
        {
            Vector3 targetPos = tilemapHandler.Grid.GetCellCenterWorld(targetCell);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 1.5f * Time.deltaTime);

            tileProperty.IsCollision = false;

            return tileProperty;
        } 
        else {
            tileProperty.IsCollision = true;
            return tileProperty;
        }
    }

    
}
