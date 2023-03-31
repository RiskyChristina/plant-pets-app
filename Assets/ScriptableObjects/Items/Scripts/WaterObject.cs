using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Water Object", menuName = "Container System/Items/Water")]
public class WaterObject : ItemObject
{
    public int restoreHealthValue;

    public void Awake()
    {
        type = ItemType.Water;
    }
}
