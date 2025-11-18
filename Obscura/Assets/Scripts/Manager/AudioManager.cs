using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {
    [SerializeField] private AudioMixer audioMixer;

    private const string OSTVolume = "OSTVolume";
    private const string SFXVolume = "SFXVolume";

    private void enableVolume(string name) {
        audioMixer.SetFloat(name, 0f);
    }

    private void disableVolume(string name) { 
        audioMixer.SetFloat(name, -80f); 
    }

    public void enableOST() {
        enableVolume(OSTVolume);
    }

    public void disableOST() {
        disableVolume(OSTVolume);
    }

    public void enableSFX() {
        enableVolume(SFXVolume);
    }

    public void disableSFX() {
        disableVolume(SFXVolume);
    }
}
