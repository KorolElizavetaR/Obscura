using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PortalTile : StaticTile {

    Vector3Int[] portalCoords = new Vector3Int[2];

    private void Start() {
        objectProperty.IsCollision = false;
     

        var coords = GetAllTileCoords();
        portalCoords[0] = coords[0];
        portalCoords[1] = coords[1];
        Debug.Log($"portal1: {portalCoords[0]} | portal2: {portalCoords[1]}");
    }

    protected List<Vector3Int> GetAllTileCoords() {
        var result = new List<Vector3Int>();
        Debug.Log($"1");
        foreach (var pos in currentTilemap.cellBounds.allPositionsWithin) {
            if (currentTilemap.HasTile(pos)) {
                result.Add(pos);
            }
        }
        Debug.Log($"2");
        return result;
    }

    /// клетка до
    public override void OnEvent(GameObject trigger) {
        ToDelete.Add(trigger);

        Debug.Log($"PORTAL TRIGER: {trigger.name}");
        
        MovementHandler movementHandler = trigger.GetComponent<MovementHandler>();
        Debug.Log($"movementHandler {movementHandler}, {trigger.name}");

        Vector3Int nextPortalCoord = movementHandler.TargetCell + movementHandler._moveDir;
        Debug.Log($"nextPortalCoord: {nextPortalCoord}");
        Vector3Int teleportCoord = nextPortalCoord == portalCoords[0] 
            ? portalCoords[1] 
            : portalCoords[0];
        
        Vector3 vector = new Vector3(teleportCoord.x, teleportCoord.y, trigger.transform.position.z);
        
        GameObject newObject = Instantiate(trigger, vector, trigger.transform.rotation);
        MovementHandler newObjectMovementHandler = newObject.GetComponent<MovementHandler>();
         
        newObjectMovementHandler.CurrentCell = teleportCoord;
        newObjectMovementHandler._moveDir = movementHandler._moveDir;
        newObjectMovementHandler.TargetCell = newObjectMovementHandler.GetNextCell();
        Debug.Log($"{newObject.name} is teleported at {teleportCoord} with moveDir = {newObjectMovementHandler._moveDir} " +
            $"and target cell = {newObjectMovementHandler.TargetCell}");
    }

    protected HashSet<GameObject> ToDelete = new();

    /// на клетке
    public override void OnEvent(AbstractTile nextCell, GameObject trigger) {
        if (ToDelete.Contains(trigger)) {
            ToDelete.Remove(trigger);
            Destroy(trigger);
        }
    }
}
