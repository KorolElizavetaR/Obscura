using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Sprite _levelSprite;
    [SerializeField] private Sprite _levelCompletedSprite;

    [SerializeField] private List<LevelPicker> _levels;

    void Start() {
        string jsonData = PlayerPrefs.GetString("levels", string.Empty);
        var completedLevels = string.IsNullOrEmpty(jsonData)
            ? new HashSet<int>()
            : JsonFormatter.FromJson<HashSet<int>>(jsonData);

        Debug.Log($"completedLevels: [{string.Join(", ", completedLevels)}]");

        foreach (var level in _levels) {
            if (completedLevels.Contains(level.LevelIndex)) {
                level.LevelImage.sprite = _levelCompletedSprite;
            } else {
                level.LevelImage.sprite = _levelSprite;
            }
        }
    }
}
