
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class AbstractTile: MonoBehaviour {
    public TilemapHandler _tilemapHandler;
    public TileProperty objectProperty { get; set; } = new TileProperty();
    
    public abstract bool CheckIsCurrentObject(Vector3Int cellPos);
    public abstract void OnThisNextEvent(GameObject trigger);
    public abstract void OnThisCurrentEvent(AbstractTile nextCell, GameObject trigger);

    public void OnThisCurrentEvents(List<AbstractTile> nextCells, GameObject trigger)
    {
        // In some conditions it is needed to run with null (ex. PortalTile)
        if (!nextCells.Any())
        {
            OnThisCurrentEvent(null, trigger);
            return;
        }
        
        nextCells.ForEach(x => OnThisCurrentEvent(x, trigger));
    }
}