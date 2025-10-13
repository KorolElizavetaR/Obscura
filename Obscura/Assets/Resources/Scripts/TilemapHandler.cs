using NUnit.Framework;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TilemapHandler : MonoBehaviour {
    [SerializeField] private Grid grid;
    [SerializeField] private List<ObjectBehavior> objects;
    [SerializeField] private GameObject playerBegginingPosition;

    private void Awake() {
        playerBegginingPosition = GameObject.FindGameObjectWithTag("Respawn");
        foreach (ObjectBehavior obj in objects) {
            if (obj is SpriteBehavior sprite) {
                sprite.CurrentCell = getCell(sprite.gameObject);
            }
        }
    }

    public Vector3Int getInitialPlayerPosition() {
        return Grid.WorldToCell(playerBegginingPosition.transform.position);
    }

    public Vector3Int getCell(GameObject obj) {
        return Grid.WorldToCell(obj.transform.position);
    }

    public Grid Grid => grid;

    public ObjectProperty checkTileEvent(Vector3Int currentTile) {
        foreach (ObjectBehavior tile in objects) {
            if (tile.CheckIsCurrentObject(currentTile)) {
                ObjectProperty state = tile.OnEvent();
                return state;
            }
        }
        return ObjectProperty.baseProperty;
    }

}