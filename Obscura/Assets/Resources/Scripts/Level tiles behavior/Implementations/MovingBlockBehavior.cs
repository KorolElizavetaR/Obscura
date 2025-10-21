using System;
using UnityEngine;

public class MovingBlockBehavior : SpriteBehavior {
    // следит за игроком
    private MovementHandler playerMovement;
    // перемещение блока
    private MovementHandler movementHandler;

    private void Awake() {
        movementHandler = GetComponent<MovementHandler>();

        tileProperty.IsCollision = false;
        tileProperty.IsDeadly = false;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            playerMovement = player.GetComponent<MovementHandler>();
        }
        else {
            Debug.Log($"Player is not initialized!!");
        }
        Debug.Log($"playerMovement initialized: {playerMovement.name}");
    }

    override public ObjectProperty OnEvent() {
        /**
         * 1. берем текущий дирекшен игрока
         * 2. ЕСЛИ следующая клетка для нашей текущей имеет коллизию, возвращаем исКоллижн = тру
         * 3. ЕСЛИ следующая клетка для этого блока не имеет коллизию, двигаемся вместе с игроком на клетку вперде
         */
        Debug.Log($"Player movement direction: {playerMovement._moveDir}");

        movementHandler._moveDir = playerMovement._moveDir;
        bool canMoveForward = movementHandler.move();
        tileProperty.IsCollision = !canMoveForward;
        return tileProperty;
    }
}
