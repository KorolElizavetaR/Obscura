using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour, ILogDistributor {
    public string DistributorName => GetType().Name;

    [SerializeField] private AudioMixer audioMixer;

    public void setVolume(string name, bool turnedOn) {
        float volume = turnedOn ? 0.0f : -80f;
        audioMixer.SetFloat(name, volume);
    }
}
