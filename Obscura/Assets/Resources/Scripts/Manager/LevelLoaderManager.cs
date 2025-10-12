using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class LevelLoaderManager : MonoBehaviour {

    [SerializeField] private List<GameObject> _levels;
    private GameObject currentLevel;
    [SerializeField] private PlayerMovementBySteps player;
    [SerializeField] int currentLevelId;

    private void Awake() {
      //currentLevelId = PlayerPrefs.GetInt("level");
      currentLevel = Instantiate(_levels[currentLevelId]);
      player.tilemapHandler = currentLevel.GetComponent<TilemapHandler>();
    }
    
}
