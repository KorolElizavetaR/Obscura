using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesBehavior : MonoBehaviour {
    public State state;
    private Tilemap currentTilemap;

    private void Start() {
        currentTilemap = GetComponent<Tilemap>();
    }

    virtual public State onEvent() {
        return state;
    }
    
    public bool checkEventTrigger (Vector3Int currentTile) {
        return currentTilemap.HasTile(currentTile);
    }

    public class State {
        private bool isCollision { get; set;     }
        private bool isDeadly { get; set; }

        public void SetCollision(bool value) => isCollision = value;
        public bool GetCollision() => isCollision;

        public void SetDeadly(bool value) => isDeadly = value;
        public bool GetDeadly() => isDeadly;
    }

}
