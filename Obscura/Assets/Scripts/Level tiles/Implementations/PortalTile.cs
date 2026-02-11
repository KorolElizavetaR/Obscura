using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PortalTile : StaticTile {
    private MovementHandler playerMovement;
    Player player;

    Vector3Int[] portalCoords = new Vector3Int[2];

    private void Awake() {
        objectProperty.IsCollision = false;
     

        var coords = GetAllTileCoords();
        portalCoords[0] = coords[0];
        portalCoords[1] = coords[1];
    }

    protected List<Vector3Int> GetAllTileCoords() {
        var result = new List<Vector3Int>();

        foreach (var pos in currentTilemap.cellBounds.allPositionsWithin) {
            if (currentTilemap.HasTile(pos)) {
                result.Add(pos);
            }
        }

        return result;
    }

    /// клетка до
    public override void OnEvent(GameObject trigger) {
        Vector3Int nextPortalCoord = playerMovement.TargetCell;
        Vector3Int teleportCoord = nextPortalCoord == portalCoords[0] 
            ? portalCoords[1] 
            : portalCoords[0];
        
    }
    /// на клетке
    public override void OnEvent(AbstractTile nextCell) {

    }

  

}
