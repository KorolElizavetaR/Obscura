using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Запускается каждый раз при загрузке сцены
public class MenuManager : MonoBehaviour
{
    [SerializeField] private Sprite _levelButtonSprite;
    [SerializeField] private Sprite _levelButtonCompletedSprite;

    [SerializeField] private Sprite _lockSprite;

    [SerializeField] private TMP_FontAsset _textFont;

    [SerializeField] private List<LevelSelectionButton> _levels;

    

    void Start() {
        setVisualForLevel();
        setMaxAvailableLevelAmount();
    }

    private HashSet<int> getCompletedLevels() {
        string jsonData = PlayerPrefs.GetString("levels", string.Empty);
        return string.IsNullOrEmpty(jsonData)
            ? new HashSet<int>()
            : JsonFormatter.FromJson<HashSet<int>>(jsonData);
    }

    private void setVisualForLevel() {
        HashSet<int> completedLevels = getCompletedLevels();
        Debug.Log($"completedLevels: [{string.Join(", ", completedLevels)}]");
        foreach (LevelSelectionButton level in _levels) {

            GameObject levelIcon = initiateLevelIcon(level);

            levelIcon.transform.SetParent(level.transform, false);

            level.LevelImage.sprite = completedLevels.Contains(level.LevelIndex)
                ? _levelButtonCompletedSprite
                : _levelButtonSprite;

            // make object from initiateLevelIcon(level) chilf og LevelSelectionButton
        }
    }

    private void setMaxAvailableLevelAmount() {
        PlayerPrefs.SetInt("maxAvailableLevel", _levels.Count-1);
        PlayerPrefs.Save();
    }

    private GameObject initiateLevelIcon(LevelSelectionButton level) {
        GameObject icon =
            level.Available
                ? CreateLevelText(level.LevelIndex)
                : CreateLockImage();
        return icon;
    }

    private GameObject CreateLevelText(int levelNumber) {
        GameObject textObject = new GameObject("index");
        TextMeshProUGUI textComponent = textObject.AddComponent<TextMeshProUGUI>();

        textComponent.text = levelNumber.ToString();
        textComponent.font = _textFont;
        textComponent.alignment = TextAlignmentOptions.Center;
        if (ColorUtility.TryParseHtmlString("#627B56", out Color color)) {
            textComponent.color = color;
        }
        else {
            textComponent.color = Color.black; // fallback
        }
        textComponent.fontSize = 100;
        textComponent.fontStyle = FontStyles.Bold;
        return textObject;
    }

    private GameObject CreateLockImage() {
        GameObject imageObject = new GameObject("lock");
        Image imageComponent = imageObject.AddComponent<Image>();

        imageComponent.sprite = _lockSprite;
        imageComponent.preserveAspect = true;

        return imageObject;
    }
}
