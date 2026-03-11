using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {
    [SerializeField] 
    private AudioMixer audioMixer;

    private const string OSTVolume = "OSTVolume";
    private const string SFXVolume = "SFXVolume";

    private void Start() {
        Debug.Log("AudioManager Awake in scene: " + gameObject.scene.name);
        string[] soundVolumePrefsNames = { OSTVolume, SFXVolume };

        foreach (string soundVolumePref in soundVolumePrefsNames) {
            bool turnedOn = PlayerPrefs.GetInt(soundVolumePref, 1) == 1;
            Debug.Log($"{soundVolumePref} active: {turnedOn}");
            setVolume(soundVolumePref, turnedOn);
        }
    }

    public void setVolume(string name, bool turnedOn) {
        float volume = turnedOn ? 0.0f : -80f;
        audioMixer.SetFloat(name, volume);
    }

}
