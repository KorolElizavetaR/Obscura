using UnityEngine;

public class ButtonTogglerGlobalSounds : ButtonToggler {
    [SerializeField]
    private AudioManager audioManager;

    protected override void Awake()
    {
        base.Awake();
        SetVolume();
    }

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
