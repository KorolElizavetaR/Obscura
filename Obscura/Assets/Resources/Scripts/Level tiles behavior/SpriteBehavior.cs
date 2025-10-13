using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpriteBehavior : ObjectBehavior {

    public Vector3Int CurrentCell { get; set; }

    public override bool CheckIsCurrentObject(Vector3Int cellPos) {
        return cellPos == CurrentCell;
    }

    //public override ObjectProperty OnEvent() {
    //    throw new NotImplementedException();
    //}
}
