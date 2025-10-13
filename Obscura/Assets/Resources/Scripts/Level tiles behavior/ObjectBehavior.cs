
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class ObjectBehavior : MonoBehaviour {
    public ObjectProperty tileProperty = new ObjectProperty();
    public abstract bool CheckIsCurrentObject(Vector3Int cellPos);
    virtual public ObjectProperty OnEvent() {
        return tileProperty;
    }
}