using UnityEngine;
using System.Collections.Generic;

public class PortalTile : StaticTile {
    Vector3Int[] portalCoords = new Vector3Int[2];

    private void Start() {
        objectProperty.IsCollision = false;

        var coords = GetAllTileCoords();
        portalCoords[0] = coords[0];
        portalCoords[1] = coords[1];
        this.Log($"portal1: {portalCoords[0]} | portal2: {portalCoords[1]}");
    }

    protected List<Vector3Int> GetAllTileCoords() {
        var result = new List<Vector3Int>();
        this.Log($"1");
        foreach (var pos in currentTilemap.cellBounds.allPositionsWithin) {
            if (currentTilemap.HasTile(pos)) {
                result.Add(pos);
            }
        }
        this.Log($"2");
        return result;
    }

    /// ������ ��
    public override void OnEvent(GameObject trigger) {
        ToDelete.Add(trigger);
        
        this.Log($"New portal trigger: {trigger.name}");
        
        MovementHandler movementHandler = trigger.GetComponent<MovementHandler>();
        this.Log($"movementHandler {movementHandler}, {trigger.name}");

        Vector3Int nextPortalCoord = movementHandler.TargetCell + movementHandler._moveDir;
        this.Log($"nextPortalCoord: {nextPortalCoord}");
        Vector3Int teleportCoord = nextPortalCoord == portalCoords[0] 
            ? portalCoords[1] 
            : portalCoords[0];
        
        Vector3 vector = new Vector3(teleportCoord.x, teleportCoord.y, trigger.transform.position.z);
        
        GameObject newObject = Instantiate(trigger, vector, trigger.transform.rotation);
        newObject.name = trigger.name;
        
        MovementHandler newObjectMovementHandler = newObject.GetComponent<MovementHandler>();
         
        newObjectMovementHandler.CurrentCell = teleportCoord;
        newObjectMovementHandler._moveDir = movementHandler._moveDir;
        newObjectMovementHandler.TargetCell = newObjectMovementHandler.GetNextCell();
        this.Log($"{newObject.name} is teleported at {teleportCoord} with moveDir = {newObjectMovementHandler._moveDir} " +
            $"and target cell = {newObjectMovementHandler.TargetCell}");

        if (newObject.TryGetComponent(out MovingBlockTile movingBlockTile))
        {
            movingBlockTile.IsMoving = true;
        }
    }

    protected HashSet<GameObject> ToDelete = new();

    /// �� ������
    public override void OnEvent(AbstractTile nextCell, GameObject trigger) {
        if (ToDelete.Remove(trigger)) {
            Destroy(trigger);
        }
    }
}
