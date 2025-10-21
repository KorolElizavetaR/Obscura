using System;
using UnityEngine;

public class MovingBlockBehavior : SpriteBehavior {
    // ������ �� �������
    private MovementHandler playerMovement;
    // ����������� �����
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
         * 1. ����� ������� �������� ������
         * 2. ���� ��������� ������ ��� ����� ������� ����� ��������, ���������� ��������� = ���
         * 3. ���� ��������� ������ ��� ����� ����� �� ����� ��������, ��������� ������ � ������� �� ������ ������
         */
        Debug.Log($"Player movement direction: {playerMovement._moveDir}");

        movementHandler._moveDir = playerMovement._moveDir;
        bool canMoveForward = movementHandler.move();
        tileProperty.IsCollision = !canMoveForward;
        return tileProperty;
    }
}
