using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;

    [SerializeField] private AudioClip movementSound;
    [SerializeField] private AudioClip winSound;


    public void playMovementSound() {
        AudioSource.PlayOneShot(movementSound);
    }

    public void playWinSound() {
        AudioSource.PlayOneShot(winSound);
    }
}
