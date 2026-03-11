using UnityEngine;

public class ButtonTogglerGlobalSounds : ButtonToggler {
    [SerializeField]
    private AudioManager audioManager;

    public override void toggleState() {
        base.toggleState();
        audioManager.setVolume(GetToggleName(), GetToggleState());
    }
}
