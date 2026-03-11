using System.Collections.Generic;
using System.Linq;
using App.Scripts.Core.Storage;
using App.Scripts.Core.Storage.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ����������� ������ ��� ��� �������� �����
public class MenuManager : MonoBehaviour, ILogDistributor
{
    public string DistributorName => GetType().Name;

    [SerializeField] private Sprite _levelButtonSprite;
    [SerializeField] private Sprite _levelButtonCompletedSprite;

    [SerializeField] private Sprite _lockSprite;

    [SerializeField] private TMP_FontAsset _textFont;

    [SerializeField] private List<LevelSelectionButton> _levels;

    private Levels _levelsEntity;

    protected virtual void Awake()
    {
        EntitiesStorage.Instance.TryGet(out _levelsEntity);
    }

    void Start() {
        setVisualForLevel();
        setMaxAvailableLevelAmount();
    }

    private void setVisualForLevel() {
        this.Log($"completedLevels: [{string.Join(", ", _levelsEntity.CompletedLevels.Select(x => x.ToString()))}]");
        foreach (LevelSelectionButton level in _levels) {

            GameObject levelIcon = initiateLevelIcon(level);

            levelIcon.transform.SetParent(level.transform, false);

            level.LevelImage.sprite = _levelsEntity.CompletedLevels.Contains(level.LevelIndex)
                ? _levelButtonCompletedSprite
                : _levelButtonSprite;
        }
    }

    private void setMaxAvailableLevelAmount()
    {
        _levelsEntity.MaxLevelId = _levels.Count - 1;
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
