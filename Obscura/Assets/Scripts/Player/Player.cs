using UnityEngine;
using static InputHandler;

public class Player : DynamicTile, ILogDistributor {
    public string DistributorName => GetType().Name;

    public static PlayerState State;
    public static MovementHandler currMovementHandler;

    [SerializeField] private Animator animator;

    private MovementHandler movementHandler;
    private InputHandler inputHandler;
    
    private PlayerSFX playerSFX;
    private bool restrictSwiping;
    private bool playedWinSoundOnce;

    private void Start() {
        State = new PlayerState(animator);
        movementHandler = GetComponent<MovementHandler>();
        currMovementHandler = movementHandler;
        inputHandler = FindFirstObjectByType<InputHandler>();
        inputHandler.onTouchComplete += onSwipe;

        playerSFX = GetComponent<PlayerSFX>();
    }

    private void OnDestroy() {
        if (inputHandler != null) {
            inputHandler.onTouchComplete -= onSwipe;
        }
    }

    private void Update() {
        if (!State.IsDead && !State.IsWin && !restrictSwiping) {
            bool canMoveForward = movementHandler.move();
            restrictSwiping = !canMoveForward;
            State.IsMoving = canMoveForward;
        }
        if (State.IsWin && !playedWinSoundOnce) {
            playedWinSoundOnce = true;
            playerSFX.playWinSound();
        }
    }

    private void onSwipe(InputCallback inputCallback) {
        if (!restrictSwiping || State.IsDead || State.IsWin) {
            return;
        }

        this.Log("on swipe call");
        Vector3Int movementDir = inputCallback._swipeDelta;

        if (!movementDir.Equals(Vector3Int.zero)) {
            ProcessMovement(movementDir);
        }
    }

    private void ProcessMovement(Vector3Int movementDir) {
        //playerSFX.playMovementSound();
        restrictSwiping = false;
        State.IsMoving = true;

        this.Log($"movementDir: {movementDir}");
        movementHandler._moveDir = movementDir;
        this.Log($"movementHandler._moveDir: {movementHandler._moveDir};");

        transform.rotation = (movementHandler._moveDir.x, movementHandler._moveDir.y) switch {
            ( > 0, 0) => Quaternion.Euler(0, 0, 90),   // Right
            ( < 0, 0) => Quaternion.Euler(0, 0, -90),  // Left
            (0, > 0) => Quaternion.Euler(0, 0, 180),   // Up
            (0, < 0) => Quaternion.identity,           // Down
            _ => transform.rotation                    // No change for other cases
        };
    }

    public override void OnThisNextEvent(GameObject trigger) {
        throw new System.NotImplementedException();
    }

    public override void OnThisCurrentEvent(AbstractTile nextCell, GameObject trigger) {
        throw new System.NotImplementedException();
    }

    public class PlayerState : ILogDistributor {
        public string DistributorName => GetType().Name;

        private bool isMoving;
        private bool isDead;
        private bool isWin = false;

        private Animator animator;

        public PlayerState(Animator animator) {
            this.animator = animator;

            this.Log($"animator null:{animator is null} ");
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
