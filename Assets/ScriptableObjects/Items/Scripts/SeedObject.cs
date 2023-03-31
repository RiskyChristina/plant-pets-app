using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Seed Object", menuName = "Container System/Items/Seed")]
public class SeedObject : ItemObject
{
    public int seedHealthValue;
    //public int or float for when it needs water
    //public int or float for time it take to grow
    //public int or float when it hits max growth
    //public int or float for time it takes for health to decrease over time when not watered
    //Switch prefab image here?
    public void Awake()
    {
        type = ItemType.Seed;
    }
}
