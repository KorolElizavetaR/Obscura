using UnityEngine;

public class MovingBlockTile : DynamicTile {
    // ����������� �����
    private MovementHandler movementHandler;
    private bool isMoving = false;

    public bool IsMoving
    {
        get => isMoving;
        set => isMoving = value;
    }
    
    private void Awake() {
        movementHandler = GetComponent<MovementHandler>();

        objectProperty.IsCollision = true;
       
    }
    public void Update() {
        if (isMoving) {
            bool canMoveForward = movementHandler.move();
            isMoving = canMoveForward;
            objectProperty.IsCollision = !isMoving;
        }
    }

    override public void OnEvent(GameObject trigger) {
        movementHandler._moveDir = Player.currMovementHandler._moveDir; 
        bool canMoveForward = movementHandler.move();
        isMoving = canMoveForward;
        objectProperty.IsCollision = !isMoving;
    }

    public override void OnEvent(AbstractTile nextCell, GameObject trigger) {
       
    }
}
