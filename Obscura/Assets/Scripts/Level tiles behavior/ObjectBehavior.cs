
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class ObjectBehavior : MonoBehaviour {

    public TilemapHandler _tilemapHandler;


    public ObjectProperty objectProperty { get; set; } = new ObjectProperty();
    public abstract bool CheckIsCurrentObject(Vector3Int cellPos);
    abstract public void OnEvent();
    abstract public void OnEvent(ObjectBehavior nextCell);
}