using UnityEngine;

public class MovingBlockTileBehavior : TilesBehavior {
    // ������ �� �������
    private MovementHandler playerMovement;
    // ����������� �����
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
         * 1. ����� ������� �������� ������
         * 2. ���� ��������� ������ ��� ����� ������� ����� ��������, ���������� ��������� = ���
         * 3. ���� ��������� ������ ��� ����� ����� �� ����� ��������, ��������� ������ � ������� �� ������ ������
         */
        movementHandler._moveDir = playerMovement._moveDir;
        bool canMoveForward = movementHandler.move();
        tileProperty.IsCollision = !canMoveForward;
        return tileProperty;
    }
}
