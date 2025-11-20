using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTogglerGlobalSounds : ButtonToggler {
    [SerializeField]
    private AudioManager audioManager;

    public override void toggleState() {
        base.toggleState();
        audioManager.setVolume(prefName, currentToggleState);
    }
}
