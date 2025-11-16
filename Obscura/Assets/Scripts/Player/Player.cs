using Unity.Android.Types;
using UnityEngine;

public class Player : MonoBehaviour {
    public static PlayerState State;
    private bool canMove;
    private MovementHandler movementHandler;
    [SerializeField] private Animator animator;

    private PlayerSFX playerSFX;


    private void Start() {
        State = new PlayerState(animator);
        movementHandler = GetComponent<MovementHandler>();

        playerSFX = GetComponent<PlayerSFX>();
    }

    private void Update() {
        if (!State.IsDead && !State.IsWin) {
            if (canMove) {
                ProcessInput();
            }
            else {
                bool canMoveForward = movementHandler.move();
                canMove = !canMoveForward;
                State.IsMoving = canMoveForward;
            }
        }
    }

    private void ProcessInput() {
        float movementOffsetX = Input.GetAxisRaw("Horizontal");
        float movementOffsetY = Input.GetAxisRaw("Vertical");

        if (!Mathf.Approximately(movementOffsetX, 0f) || !Mathf.Approximately(movementOffsetY, 0f)) {
            playerSFX.playMovementSound();

            canMove = false;
            State.IsMoving = true;
            movementHandler._moveDir = Mathf.Abs(movementOffsetX) > Mathf.Abs(movementOffsetY)
                ? new Vector3Int(Mathf.RoundToInt(movementOffsetX), 0, 0)
                : new Vector3Int(0, Mathf.RoundToInt(movementOffsetY), 0);

            transform.rotation = (movementHandler._moveDir.x, movementHandler._moveDir.y) switch {
                ( > 0, 0) => Quaternion.Euler(0, 0, 90),   // Right
                ( < 0, 0) => Quaternion.Euler(0, 0, -90),  // Left
                (0, > 0) => Quaternion.Euler(0, 0, 180),   // Up
                (0, < 0) => Quaternion.identity,           // Down
                _ => transform.rotation                    // No change for other cases
            };
        }
    }

    public class PlayerState {
        private bool isMoving;
        private bool isDead;
        private bool isWin = false;

        private Animator animator;

        public PlayerState(Animator animator) {
            this.animator = animator;

            Debug.Log($"animator null:{animator is null} ");
        }

        public bool IsWin { get => isWin; set => this.isWin = value; }

        public bool IsMoving {
            get => isMoving;
            set {
                if (isMoving && !value) {
                    animator.SetTrigger("bounceTrigger");
                } 
                this.isMoving = value;
            }
        }
        public bool IsDead {
            get => isDead;
            set {
                this.isDead = value;
                if (isDead) {
                    animator.SetTrigger("deathTrigger");
                }
            }
        }

    }

}
