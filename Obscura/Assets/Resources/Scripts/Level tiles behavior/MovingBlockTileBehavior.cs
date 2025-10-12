using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class MovingBlockTileBehavior : TilesBehavior {
    // в блестящем будущем переместить мувмент скрипт в отдельный... скрипт
    public TilemapHandler tilemapHandler;

    // следит за игроком
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
         * 1. берем текущий дирекшен игрока
         * 2. ЕСЛИ следующая клетка для нашей текущей имеет коллизию, возвращаем исКоллижн = тру
         * 3. ЕСЛИ следующая клетка для этого блока не имеет коллизию, двигаемся вместе с игроком на клетку вперде
         */
        Vector3Int playerMovementDirection = playerMovement.getMovementDir;
        Vector3Int nextCell = currentCell + new Vector3Int(playerMovementDirection.x, playerMovementDirection.y, 0);
        TilePropertyModel tileProp = tilemapHandler.checkTileEvent(nextCell);
        if (!tileProp.IsCollision) // если клетка не стена
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
