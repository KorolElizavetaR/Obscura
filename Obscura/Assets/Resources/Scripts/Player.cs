using Unity.Android.Types;
using UnityEngine;

public class Player : MonoBehaviour
{

    private bool canMove;
    private MovementHandler movementHandler;

    private void Start() {
        movementHandler = GetComponent<MovementHandler>();
    }

    private void Update() {
        if (canMove) {
            ProcessInput();
        }
        else {
            bool canMoveForward = movementHandler.move();
            canMove = !canMoveForward;
        }
    }

    private void ProcessInput() {
        float movementOffsetX = Input.GetAxisRaw("Horizontal");
        float movementOffsetY = Input.GetAxisRaw("Vertical");

        if (!Mathf.Approximately(movementOffsetX, 0f) || !Mathf.Approximately(movementOffsetY, 0f)) {

            canMove = false;
            movementHandler._moveDir = Mathf.Abs(movementOffsetX) > Mathf.Abs(movementOffsetY)
                ? new Vector3Int(Mathf.RoundToInt(movementOffsetX), 0, 0)
                : new Vector3Int(0, Mathf.RoundToInt(movementOffsetY), 0);
        }
    }

}
