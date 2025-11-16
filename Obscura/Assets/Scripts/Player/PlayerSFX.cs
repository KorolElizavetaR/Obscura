using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;

    [SerializeField] private AudioClip movementSound;


    public void playMovementSound() {
        AudioSource.PlayOneShot(movementSound);
    }
}
