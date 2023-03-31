using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dirt Object", menuName = "Container System/Items/Dirt")]
public class DirtObject : ItemObject
{
    public int GrowthValue;
    public void Awake()
    {
        type = ItemType.Dirt;
    }
}
