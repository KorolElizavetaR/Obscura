using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class LevelLoaderManager : MonoBehaviour {

    [SerializeField] private List<GameObject> _levels;
    private GameObject currentLevel;
    [SerializeField] int currentLevelId;
    
    [Header("Camera")]
    public Camera cam;
    public float horizontalPadding = 1f;
    public float verticalPadding = 1f;

    private void Awake() {
      //currentLevelId = PlayerPrefs.GetInt("level");
      currentLevel = Instantiate(_levels[currentLevelId]);
      MovementHandler.tilemapHandler = currentLevel.GetComponent<TilemapHandler>();
      SetupCamera();
    }

    private void SetupCamera()
    {
        if (currentLevel is null) return;
        
        var bounds = currentLevel.GetComponentInChildren<MonoBounds>();
        if (bounds is null) return;
        
        cam ??= Camera.main;
        if (cam is null || !cam.orthographic) return;
        
        cam.transform.position = new Vector3(bounds.transform.position.x, bounds.transform.position.y, cam.transform.position.z);
        
        var aspect = (float)Screen.width / Screen.height;
        var requiredVertSize = (bounds.height / 2f) + verticalPadding;
        var requiredHorzSize = ((bounds.width / 2f) + horizontalPadding) / aspect;

        cam.orthographicSize = Mathf.Max(requiredVertSize, requiredHorzSize);
    }
}
