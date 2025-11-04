public class PlayerState {
    public bool IsMoving { get; set; }
    public bool IsDead { get; set; }

    public PlayerState() {
        IsMoving = false;
        IsDead = false;
    }
}