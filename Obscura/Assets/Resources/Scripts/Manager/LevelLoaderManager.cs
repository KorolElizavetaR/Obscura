using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class LevelLoaderManager : MonoBehaviour {

    [SerializeField] private List<GameObject> _levels;
    private GameObject currentLevel;
    //[SerializeField] private Player player;
    [SerializeField] int currentLevelId;

    private void Awake() {
      //currentLevelId = PlayerPrefs.GetInt("level");
      currentLevel = Instantiate(_levels[currentLevelId]);
      MovementHandler.tilemapHandler = currentLevel.GetComponent<TilemapHandler>();
    }
    
}
