using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonToggler : MonoBehaviour, ILogDistributor {
    public string DistributorName => GetType().Name;

    [SerializeField] protected string prefName;
    
    private Image[] buttonImages;
    protected bool currentToggleState;

    public virtual void Awake() {
        buttonImages = GetComponentsInChildren<Image>();
        currentToggleState = PlayerPrefs.GetInt(prefName, 1) == 1;
        this.Log($"INIT currentToggleState for pref {prefName}: {currentToggleState}");
        changeImageAlpha();
    }

    public virtual void toggleState() {
        currentToggleState = !currentToggleState;
        this.Log($"currentToggleState for pref {prefName}: {currentToggleState}");
        changeImageAlpha();
        PlayerPrefs.SetInt(prefName, currentToggleState ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void changeImageAlpha() {
        float targetAlpha = currentToggleState ? 1f : 0.5f;

        foreach (Image img in buttonImages) {
            img.color = new Color(img.color.r, img.color.g, img.color.b, targetAlpha);
        }
    }
}
