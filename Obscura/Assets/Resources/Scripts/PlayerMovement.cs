using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float movementSpeed = 5f;

    void Update() {
        var movementOffsetX = Input.GetAxisRaw("Horizontal");
        var movementOffsetY = Input.GetAxisRaw("Vertical");
        transform.Translate(
            Mathf.Abs(movementOffsetX) > Mathf.Abs(movementOffsetY) ?
            new Vector2(movementOffsetX * movementSpeed, 0f)
            : new Vector2(0f, movementOffsetY * movementSpeed)
        );
    }
}
