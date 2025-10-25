using System;
using UnityEngine;

public class MovingBlockBehavior : DynamicObjBehavior {
    // следит за игроком
    private MovementHandler playerMovement;
    // перемещение блока
    private MovementHandler movementHandler;
    private bool isMoving = false;
    private void Awake() {
        movementHandler = GetComponent<MovementHandler>();

        objectProperty.IsCollision = true;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            playerMovement = player.GetComponent<MovementHandler>();
        }
        else {
            Debug.Log($"Player is not initialized!!");
        }
        Debug.Log($"playerMovement initialized: {playerMovement.name}");
    }
    public void Update() {
        if (isMoving) {
            bool canMoveForward = movementHandler.move();
            isMoving = canMoveForward;
            objectProperty.IsCollision = !isMoving;
        }
    }

    override public void OnEvent() {
        movementHandler._moveDir = playerMovement._moveDir;
        bool canMoveForward = movementHandler.move();
        isMoving = canMoveForward;
        objectProperty.IsCollision = !isMoving;

        //throw new NotImplementedException();
    }

    public override void OnEvent(ObjectBehavior nextCell) {
        //movementHandler._moveDir = playerMovement._moveDir;

        //objectProperty.IsCollision = nextCell.objectProperty.IsCollision;
        //isMoving = !objectProperty.IsCollision;
        throw new NotImplementedException();
    }

}
