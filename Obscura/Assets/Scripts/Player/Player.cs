using Unity.Android.Types;
using UnityEngine;
using static InputHandler;

public class Player : MonoBehaviour {
    public static PlayerState State;
    private bool canMove;
    private MovementHandler movementHandler;
    [SerializeField] 
    private Animator animator;
    private InputHandler inputHandler;

    private PlayerSFX playerSFX;

    private bool playedWinSoundOnce;


    private void Start() {
        State = new PlayerState(animator);
        movementHandler = GetComponent<MovementHandler>();
        inputHandler = GetComponent<InputHandler>();
        inputHandler.onTouchComplete += onSwipe;

        playerSFX = GetComponent<PlayerSFX>();
    }

    private void OnDestroy() {
        if (inputHandler != null) {
            inputHandler.onTouchComplete -= onSwipe;
        }
    }

    private void Update() {
        if (!State.IsDead && !State.IsWin && !canMove) {
            bool canMoveForward = movementHandler.move();
            canMove = !canMoveForward;
            State.IsMoving = canMoveForward;
        }
        if (State.IsWin && !playedWinSoundOnce) {
            playedWinSoundOnce = true;
            playerSFX.playWinSound();
        }
    }

    private void onSwipe(InputCallback inputCallback) {
        if (!canMove || State.IsDead || State.IsWin) {
            return;
        }

        Debug.Log("On swipe call");
        float movementOffsetX = inputCallback._swipeDelta.x;
        float movementOffsetY = inputCallback._swipeDelta.y;

        if (!Mathf.Approximately(movementOffsetX, 0f) || !Mathf.Approximately(movementOffsetY, 0f)) {
            ProcessMovement(movementOffsetX, movementOffsetY);
        }
    }

    private void ProcessMovement(float movementOffsetX, float movementOffsetY) {
        playerSFX.playMovementSound();
        canMove = false;
        State.IsMoving = true;

        // Normalize the swipe delta to get direction (-1, 0, or 1)
        float normalizedX = Mathf.Clamp(movementOffsetX, -1f, 1f);
        float normalizedY = Mathf.Clamp(movementOffsetY, -1f, 1f);

        movementHandler._moveDir = Mathf.Abs(normalizedX) > Mathf.Abs(normalizedY)
            ? new Vector3Int(Mathf.RoundToInt(Mathf.Sign(normalizedX)), 0, 0)
            : new Vector3Int(0, Mathf.RoundToInt(Mathf.Sign(normalizedY)), 0);

        transform.rotation = (movementHandler._moveDir.x, movementHandler._moveDir.y) switch {
            ( > 0, 0) => Quaternion.Euler(0, 0, 90),   // Right
            ( < 0, 0) => Quaternion.Euler(0, 0, -90),  // Left
            (0, > 0) => Quaternion.Euler(0, 0, 180),   // Up
            (0, < 0) => Quaternion.identity,           // Down
            _ => transform.rotation                    // No change for other cases
        };
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

        public bool IsWin { get => isWin; set {
                this.isWin = value;
            } }

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
