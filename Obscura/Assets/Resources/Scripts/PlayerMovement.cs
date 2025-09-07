using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;


public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float movementSpeed = 5f;
    //[SerializeField] private float acceleration = 1f;
    //[SerializeField] private float maxSpeed = 15f;

    private bool canMove = true;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (canMove) {
            this.proccessInput();
        }
    }

    void proccessInput() {
        float movementOffsetX = Input.GetAxisRaw("Horizontal");
        float movementOffsetY = Input.GetAxisRaw("Vertical");

        if (!Mathf.Approximately(movementOffsetX, 0f) || !Mathf.Approximately(movementOffsetY, 0f)) {
            canMove = false;
            bool isHorizontalMove = Mathf.Abs(movementOffsetX) > Mathf.Abs(movementOffsetY);


            Vector2 moveDirection = isHorizontalMove
                ? new Vector2(movementOffsetX * movementSpeed, 0f)
                : new Vector2(0f, movementOffsetY * movementSpeed);
          
            rb.linearVelocity = moveDirection;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!canMove) {
            rb.linearVelocity = Vector2.zero;
            canMove = true;
        }
    }
}
