using UnityEngine;

public class MovingBlockTileBehavior : TilesBehavior {
    // следит за игроком
    private MovementHandler playerMovement;
    // перемещение блока
    private MovementHandler movementHandler;

    private void Awake() {
        tileProperty.IsCollision = false;
        tileProperty.IsDeadly = false;

        // Find player by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            playerMovement = player.GetComponent<MovementHandler>();
        }
    }

    override public ObjectProperty OnEvent() {
        /**
         * 1. берем текущий дирекшен игрока
         * 2. ЕСЛИ следующая клетка для нашей текущей имеет коллизию, возвращаем исКоллижн = тру
         * 3. ЕСЛИ следующая клетка для этого блока не имеет коллизию, двигаемся вместе с игроком на клетку вперде
         */
        movementHandler._moveDir = playerMovement._moveDir;
        bool canMoveForward = movementHandler.move();
        tileProperty.IsCollision = !canMoveForward;
        return tileProperty;
    }
}
