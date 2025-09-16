using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;


public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float initialMovementSpeed = 0.02f;
    [SerializeField] private float acceleration = 0.5f;
    [SerializeField] private float maxSpeed = 1f;

    [SerializeField] private Tilemap collisionTilemap;

    private readonly int TARGET_CALCULATION_DEPTH = 20;

    private float currentSpeed;

    private Vector3Int moveDirection;
    private Vector3 targetPosition;

    private Vector3Int currentCell;

    private bool canMove = true;

    private void Start() {
        currentSpeed = initialMovementSpeed;

        currentCell = collisionTilemap.WorldToCell(transform.position);
        transform.position = collisionTilemap.GetCellCenterWorld(currentCell);
    }

    void Update() {
        if (canMove) {
            proccessInput();
        }
        else {
            proccessMovementTowardsTarget();
        }
    }

    void proccessInput() {
        float movementOffsetX = Input.GetAxisRaw("Horizontal");
        float movementOffsetY = Input.GetAxisRaw("Vertical");

        if (!Mathf.Approximately(movementOffsetX, 0f) || !Mathf.Approximately(movementOffsetY, 0f)) {

            canMove = false;

            moveDirection = Mathf.Abs(movementOffsetX) > Mathf.Abs(movementOffsetY) 
                ? new Vector3Int(Mathf.RoundToInt(movementOffsetX), 0, 0)
                : new Vector3Int(0, Mathf.RoundToInt(movementOffsetY), 0);

            Vector3Int targetCell = calculateTargetCell(currentCell, moveDirection);
            targetPosition = collisionTilemap.GetCellCenterWorld(targetCell);

            Debug.Log($"[PlayerMovement::proccessInput]: targetCell = {targetCell}");
            Debug.Log($"[PlayerMovement::proccessInput]: targetCell = {targetPosition}");
        }
    }

    void proccessMovementTowardsTarget() {
        currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.001f) {
            transform.position = targetPosition;
            currentCell = collisionTilemap.WorldToCell(transform.position);

            currentSpeed = initialMovementSpeed;
            canMove = true;
        }
    }

    Vector3Int calculateTargetCell(Vector3Int prevCell, Vector3Int moveDir, int depth = 0) {
        Vector3Int nextCell = prevCell + new Vector3Int(moveDir.x, moveDir.y, 0);
        if (!collisionTilemap.HasTile(nextCell) && depth < TARGET_CALCULATION_DEPTH) {
            return calculateTargetCell(nextCell, moveDir, depth + 1);
        }
        return prevCell;
    }

}
