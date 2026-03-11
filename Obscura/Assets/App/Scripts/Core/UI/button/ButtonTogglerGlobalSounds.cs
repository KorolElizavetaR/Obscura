using UnityEngine;

public class ButtonTogglerGlobalSounds : ButtonToggler {
    [SerializeField]
    private AudioManager audioManager;
    
    public override void toggleState()
    {
        base.toggleState();
        SetVolume();
    }

    private void SetVolume()
    {
        audioManager.setVolume(GetToggleName(), GetToggleState());
    }
}
